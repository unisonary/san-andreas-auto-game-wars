using System;
using System.Reflection;
using GooglePlayGames.OurUtils;
using UnityEngine;

namespace GooglePlayGames.Native
{
	internal static class JavaUtils
	{
		private static ConstructorInfo IntPtrConstructor = typeof(AndroidJavaObject).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[1] { typeof(IntPtr) }, null);

		internal static AndroidJavaObject JavaObjectFromPointer(IntPtr jobject)
		{
			if (jobject == IntPtr.Zero)
			{
				return null;
			}
			return (AndroidJavaObject)IntPtrConstructor.Invoke(new object[1] { jobject });
		}

		internal static AndroidJavaObject NullSafeCall(this AndroidJavaObject target, string methodName, params object[] args)
		{
			try
			{
				return target.Call<AndroidJavaObject>(methodName, args);
			}
			catch (Exception ex)
			{
				if (ex.Message.Contains("null"))
				{
					return null;
				}
				GooglePlayGames.OurUtils.Logger.w("CallObjectMethod exception: " + ex);
				return null;
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
