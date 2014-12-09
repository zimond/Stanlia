using System;
using Stanlia.prototype.store;
using Stanlia.instance.helper;

namespace Stanlia
{
	public class Stanlia
	{
		public Stanlia ()
		{
			dataStore = new Store ();
			creator = new ItemCreator ();
			creator.createItem ("npc#Ruby");
		}
		private ItemCreator creator;
		public Store dataStore;
	}
}

