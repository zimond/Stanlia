using System;

namespace Stanlia.prototype.item
{
	public class Tag
	{
		public bool Stackable{ get; set; }
		public bool Container{ get; set; }
		public Tag ()
		{
			this.Stackable = false;
			this.Container = false;
		}
	}
	public class CreatureTag : Tag
	{
		public bool People { get; set; }
		public CreatureTag() : base()
		{
			this.People = false;
			this.Stackable = false;
			this.Container = true;
		}
	}
}

