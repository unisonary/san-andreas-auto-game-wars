using System;
using System.Reflection;
using GoogleMobileAds.Common;

namespace GoogleMobileAds.Api
{
	public class MobileAds
	{
		private static readonly IMobileAdsClient client = GetMobileAdsClient();

		public static void Initialize(string appId)
		{
			client.Initialize(appId);
			MobileAdsEventExecutor.Initialize();
		}

		public static void SetApplicationMuted(bool muted)
		{
			client.SetApplicationMuted(muted);
		}

		public static void SetApplicationVolume(float volume)
		{
			client.SetApplicationVolume(volume);
		}

		public static void SetiOSAppPauseOnBackground(bool pause)
		{
			client.SetiOSAppPauseOnBackground(pause);
		}

		private static IMobileAdsClient GetMobileAdsClient()
		{
			return (IMobileAdsClient)Type.GetType("GoogleMobileAds.GoogleMobileAdsClientFactory,Assembly-CSharp").GetMethod("MobileAdsInstance", BindingFlags.Static | BindingFlags.Public).Invoke(null, null);
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
