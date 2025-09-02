using System;
using GoogleMobileAds.Api;

namespace GoogleMobileAds.Common
{
	public interface IRewardBasedVideoAdClient
	{
		event EventHandler<EventArgs> OnAdLoaded;

		event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

		event EventHandler<EventArgs> OnAdOpening;

		event EventHandler<EventArgs> OnAdStarted;

		event EventHandler<Reward> OnAdRewarded;

		event EventHandler<EventArgs> OnAdClosed;

		event EventHandler<EventArgs> OnAdLeavingApplication;

		event EventHandler<EventArgs> OnAdCompleted;

		void CreateRewardBasedVideoAd();

		void LoadAd(AdRequest request, string adUnitId);

		bool IsLoaded();

		string MediationAdapterClassName();

		void ShowRewardBasedVideoAd();

		void SetUserId(string userId);
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
