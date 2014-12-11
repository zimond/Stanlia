using System;
using System.Reflection;
using Stanlia.prototype.item;
using Stanlia.prototype.store;
using System.Collections.Generic;
using Stanlia.prototype.constant;
using Stanlia.prototype.helper;
using SimpleJSON;
using UnityEngine;

namespace Stanlia.instance.helper
{
	public class ItemCreator
	{
		public ItemCreator ()
		{
			this.itemCount = 0;
		}
		private uint itemCount;
		public Item createItem(string defId)
		{
			var itemDef = Store.ItemDefStore [defId];
			var itemInstances = Store.ItemInstanceStore;

			if (itemDef == null)
				return null;

			var item = new Item("0");
			string t = itemDef ["BaseType"];

			if (t == null || t == "Item") {
				item = new Item (defId);
			}
			else if (t == "People") {
				item = new People (defId, this.itemCount++);
				itemInstances.Add (item.InstanceId, item);
			}

			string[] tags = ((string)itemDef ["Tags"]).Split (',');
			
			if (item.Type == "Item") {
				item.Tags.Stackable = Array.IndexOf(tags, "Stackable")!=-1;
				item.Tags.Container = Array.IndexOf(tags, "Container")!=-1;
				
			}
			item.Name = (itemDef.HasKey ("Name") ? itemDef ["Name"].ToString() : "");
			item.Desc = (itemDef.HasKey ("Desc") ? itemDef ["Desc"].ToString() : "");
			item.Capacity = itemDef.HasKey ("Capacity") ? itemDef ["Capacity"].AsUInt : 0;
			item.MaxStack = itemDef.HasKey ("MaxStack") ? itemDef ["MaxStack"].AsUInt : 0;

			if (itemDef["Children"] != null) {
				var children = itemDef["Children"] as JSONArray;
				foreach(JSONNode child in children){
					string child_defId = child["DefId"];
					Item child_item = createItem(child_defId);
					uint count = child["Count"].AsUInt;
					child_item.StackCount = Math.Min(child_item.MaxStack, count);
					item.addChildren(child_item);
				}
			}
			if (item is People) {
				GConsole.Print ("名字: " + item.Name.Split ('#') [1]);
				GConsole.Print ("介绍：" + item.Desc);
				GConsole.Print ("杀掉Ruby获得:");
				foreach (Item i in item.Children) {
					GConsole.Print (i.StackCount + "个" + i.Name.Split('#')[1]);
				}
			}
			return item;
		}
	}
}

