using System;

namespace Stanlia.prototype.item
{
	public class Creature : Item
	{
		public Creature (string defId) : base(defId)
		{
			this.Type = "Creature";
			this.HP = 0;
			this.MaxHP = 0;
			this.Atk = 0;
			this.Def = 0;
			this.Tags = new CreatureTag ();
		}
		public int HP { get; set; }
		public int MaxHP { get; set; }
		public int Atk { get; set; }
		public int Def { get; set; }
	}
}

