using System;

namespace Stanlia.prototype.item
{
	public class People : Creature
	{
		public People (string defId, uint id) : base(defId)
		{
			this.InstanceId = id;
			this.Type = "People";
			this.Age = 0;
			this.Title = "";
		}

		public int Age { get; set; }
		public String Title { get; set; }
	}
}

