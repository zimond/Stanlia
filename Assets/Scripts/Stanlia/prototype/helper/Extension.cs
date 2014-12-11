using System;

namespace Stanlia.prototype.helper
{
	public static class Extension
	{
		//create an extension to Type
		public static bool HasPublicProperty(this Type type, string name)
		{
			return type.GetProperty(name) != null;
		}
	}
}

