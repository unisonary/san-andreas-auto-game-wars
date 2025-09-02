using GoogleMobileAds.Common;
using UnityEngine;

namespace GoogleMobileAds.Android
{
	public class MobileAdsClient : IMobileAdsClient
	{
		private static MobileAdsClient instance = new MobileAdsClient();

		public static MobileAdsClient Instance
		{
			get
			{
				return instance;
			}
		}

		public void Initialize(string appId)
		{
			AndroidJavaObject @static = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
			new AndroidJavaClass("com.google.android.gms.ads.MobileAds").CallStatic("initialize", @static, appId);
		}

		public void SetApplicationVolume(float volume)
		{
			new AndroidJavaClass("com.google.android.gms.ads.MobileAds").CallStatic("setAppVolume", volume);
		}

		public void SetApplicationMuted(bool muted)
		{
			new AndroidJavaClass("com.google.android.gms.ads.MobileAds").CallStatic("setAppMuted", muted);
		}

		public void SetiOSAppPauseOnBackground(bool pause)
		{
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
