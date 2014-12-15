using System;
using Stanlia.prototype.store;
using Stanlia.instance.helper;
using NLua;
using UnityEngine;

namespace Stanlia
{
	public class Stanlia
	{
		public Stanlia ()
		{
			dataStore = new Store ();
			creator = new ItemCreator ();
			creator.createItem ("npc#Ruby");

			rabbit = new Lua ();
			rabbit.DoString (Store.NPCLuaStore ["npc#Ruby"]);
			var table = rabbit["RubyTheRabbit"]	as LuaTable;
			this.talk = table ["Talk"] as LuaFunction;
			registerCommands ();
		}
		private LuaFunction talk;
		private Lua rabbit;
		private ItemCreator creator;
		public Store dataStore;
		private GameObject player;
		private Animator playerAnimator;

		private string Talk(string npc)
		{
			return talk.Call () [0] as string;
		}
		private void registerCommands()
		{
			GConsole.AddCommand ("talkto", "talk to an NPC", Talk, null);
		}

		public void Update()
		{

		}
	}
}

