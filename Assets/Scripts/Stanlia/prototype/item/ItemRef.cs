using System;

namespace Stanlia.prototype.item
{
	public class ItemRef
	{
		public ItemRef (uint typeId, uint count)
		{
			this.TypeId = typeId;
			this.Count = count;
		}
		public uint TypeId { get; set; }
		public uint Count { get; set; }
	}
}

