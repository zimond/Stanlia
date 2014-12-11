using System;
using System.Collections.Generic;

namespace Stanlia.prototype.item
{
	public class Item
	{
		public Item (string defId)
		{
			this.DefId = defId;
			this.Tags = new Tag ();
			this.Children = new List<Item> ();
			this.StackCount = 0;
			this.Type = "Item";
			this.AttachedLua = "DefaultItem";//Attach to the default item lua script 
		}
		public string Desc { get; set; }
		public string Name { get; set; }
		public string DefId  { get; set; }
		public uint InstanceId { get; set; }
		public String Type { get; protected set; }
		public Tag Tags { get; set; }
		public string AttachedLua { get; set; }//the id (aka. filename) of lua script related to this item.
		public List<Item> Children { get; private set; }
		private uint _capacity = 0;
		public uint Capacity
		{
			get {
				return _capacity;
			}
			set {
				if (this.Tags.Container != true) return;
				_capacity = value;
			}
		}
		private uint _maxStack = 0;
		public uint MaxStack
		{
			get {
				return _maxStack;
			}
			set {
				if (this.Tags.Stackable != true) return;
				_maxStack = value;
			}
		}
		public uint AvailableStack
		{
			get {
				return this.Tags.Container ? this.MaxStack - this.StackCount : 0;
			}
		}
		public uint StackCount { get; set; }
		public bool addChildren (Item item)
		{
			if (this.Tags.Container != true)
				return false;
			if (this.Children.Count >= this.Capacity)
				return false;
			this.Children.Add (item);
			return true;
		}
	}
}

