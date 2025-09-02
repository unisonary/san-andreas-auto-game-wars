using GoogleMobileAds.Android;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;

namespace GoogleMobileAds
{
	public class GoogleMobileAdsClientFactory
	{
		public static IBannerClient BuildBannerClient()
		{
			return new BannerClient();
		}

		public static IInterstitialClient BuildInterstitialClient()
		{
			return new InterstitialClient();
		}


		public static IRewardedAdClient BuildRewardedAdClient()
		{
			return new RewardedAdClient();
		}

		public static IAdLoaderClient BuildAdLoaderClient(AdLoader adLoader)
		{
			return new AdLoaderClient(adLoader);
		}

		public static IMobileAdsClient MobileAdsInstance()
		{
			return MobileAdsClient.Instance;
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
