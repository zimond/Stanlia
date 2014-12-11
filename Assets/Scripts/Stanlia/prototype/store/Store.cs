using System;
using System.Collections.Generic;
using Stanlia.prototype.item;
using Stanlia.prototype.loader;
using SimpleJSON;
using UnityEngine;

namespace Stanlia.prototype.store
{
	public class Store
	{
		public Store ()
		{
			NPCLuaStore = new Dictionary<string, string> ();
			loadData ();
		}

		public static Dictionary<string, string> NPCLuaStore { get; private set; }
		public static JSONNode ItemDefStore { get; private set; }
		public static Dictionary<uint, Item> ItemInstanceStore { get; private set; }
		private Boolean loadData()
		{
			JSONNode store = Loader.loadJSON ("ItemDefs.json");
			store.Merge (Loader.loadJSON ("NPC.json"));

			Store.ItemInstanceStore = new Dictionary<uint, Item> ();
			Store.ItemDefStore = store;

			//load lua
			Loader.loadLua ("npc/RubyTheRabbit.lua");
			return true;
		}
	}
}

