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
			loadData ();
		}

		public static JSONArray NPCDefStore { get; private set; }
		public static JSONNode ItemDefStore { get; private set; }
		public static Dictionary<uint, Item> ItemInstanceStore { get; private set; }
		private Boolean loadData()
		{
			JSONNode store = Loader.load ("ItemDefs.json");
			store.Merge (Loader.load ("NPC.json"));

			Store.ItemInstanceStore = new Dictionary<uint, Item> ();
			Store.ItemDefStore = store;
			return true;
		}
	}
}

