using System;
using System.Reflection;
using Fabric.Runtime.Internal;
using UnityEngine;

namespace Fabric.Runtime
{
	public class Fabric
	{
		private static readonly Impl impl;

		static Fabric()
		{
			impl = Impl.Make();
		}

		public static void Initialize()
		{
			string text = impl.Initialize();
			if (!string.IsNullOrEmpty(text))
			{
				string[] array = text.Split(',');
				for (int i = 0; i < array.Length; i++)
				{
					Initialize(array[i]);
				}
			}
		}

		internal static void Initialize(string kitMethod)
		{
			int num = kitMethod.LastIndexOf('.');
			string typeName = kitMethod.Substring(0, num);
			string name = kitMethod.Substring(num + 1);
			Type type = Type.GetType(typeName);
			if (type == null)
			{
				return;
			}
			MethodInfo method = type.GetMethod(name, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			if (!(method == null))
			{
				object obj = (typeof(ScriptableObject).IsAssignableFrom(type) ? ScriptableObject.CreateInstance(type) : Activator.CreateInstance(type));
				if (obj != null)
				{
					method.Invoke(obj, new object[0]);
				}
			}
		}
	}
}


//This source code is originally bought from www.codebuysell.com
// Visit www.codebuysell.com
//
//Contact us at:
//
//Email : admin@codebuysell.com
//Whatsapp: +15055090428
//Telegram: t.me/CodeBuySellLLC
//Facebook: https://www.facebook.com/CodeBuySellLLC/
//Skype: https://join.skype.com/invite/wKcWMjVYDNvk
//Twitter: https://x.com/CodeBuySellLLC
//Instagram: https://www.instagram.com/codebuysell/
//Youtube: http://www.youtube.com/@CodeBuySell
//LinkedIn: www.linkedin.com/in/CodeBuySellLLC
//Pinterest: https://www.pinterest.com/CodeBuySell/
