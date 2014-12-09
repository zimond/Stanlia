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

		public static JSONNode load(String filepath)
		{
			string currentDirectory = Application.dataPath;
			currentDirectory = Path.Combine(currentDirectory, "data/");
			Console.WriteLine (currentDirectory);
			currentDirectory = Path.Combine (currentDirectory, filepath);
			FileStream stream = File.OpenRead (currentDirectory);
			string json = new StreamReader (stream).ReadToEnd ();
			return JSON.Parse(json);
		}
	}

}

