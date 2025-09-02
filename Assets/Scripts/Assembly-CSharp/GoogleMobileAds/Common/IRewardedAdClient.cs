using System;
using GoogleMobileAds.Api;

namespace GoogleMobileAds.Common
{
	public interface IRewardedAdClient
	{
		event EventHandler<EventArgs> OnAdLoaded;

		event EventHandler<AdErrorEventArgs> OnAdFailedToLoad;

		event EventHandler<AdErrorEventArgs> OnAdFailedToShow;

		event EventHandler<EventArgs> OnAdOpening;

		event EventHandler<Reward> OnUserEarnedReward;

		event EventHandler<EventArgs> OnAdClosed;

		void CreateRewardedAd(string adUnitId);

		void LoadAd(AdRequest request);

		bool IsLoaded();

		string MediationAdapterClassName();

		void Show();

		void SetServerSideVerificationOptions(ServerSideVerificationOptions serverSideVerificationOptions);
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
