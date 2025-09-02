using System;
using UnityEngine;

namespace GooglePlayGames.OurUtils
{
	public static class PlatformUtils
	{
		public static bool Supported
		{
			get
			{
				AndroidJavaObject androidJavaObject = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity").Call<AndroidJavaObject>("getPackageManager", Array.Empty<object>());
				AndroidJavaObject androidJavaObject2 = null;
				try
				{
					androidJavaObject2 = androidJavaObject.Call<AndroidJavaObject>("getLaunchIntentForPackage", new object[1] { "com.google.android.play.games" });
				}
				catch (Exception)
				{
					return false;
				}
				return androidJavaObject2 != null;
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
