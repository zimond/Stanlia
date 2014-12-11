using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;

namespace Stanlia.prototype.loader
{
	public class Loader
	{
		public Loader ()
		{
		}

		public static JSONNode loadJSON(String filepath)
		{
			string currentDirectory = Application.dataPath;
			currentDirectory = Path.Combine(currentDirectory, "data/");
			currentDirectory = Path.Combine (currentDirectory, filepath);
			FileStream stream = File.OpenRead (currentDirectory);
			string json = new StreamReader (stream).ReadToEnd ();
			return JSON.Parse(json);
		}

		public static string loadLua(String filepath)
		{
			string currentDirectory = Application.dataPath;
			currentDirectory = Path.Combine(currentDirectory, "Scripts/Lua/");
			currentDirectory = Path.Combine (currentDirectory, filepath);
			FileStream stream = File.OpenRead (currentDirectory);
			string lua = new StreamReader (stream).ReadToEnd ();
			return lua;
		}
	}

}

