using System;
using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdController : MonoBehaviour
{
	private InterstitialAd AdmobInterstitial;

	public RewardBasedVideoAd AdmobRewardBasedVideo;

	public string AdmobAdUnitID;

	public string AdmobRewardID;

	public string UnityGameID;

	public string IronSourceID = "7260ef2d";

	[HideInInspector]
	public string UnityPlacementId = "rewardedVideo";

	public static AdController instance;

	private bool IsUnityVideoRequested;

	private bool IsUnityAdRequested;

	private bool IsRequestedAdmobRewardBasedVideo;

	private bool IsRewardVideoRequested;

	private bool IsVideoRewarded;

	[HideInInspector]
	public bool IsEnableUnityInterstital;

	[HideInInspector]
	public bool IsEnableUnityReward;

	private int RequestCount;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		IsRequestedAdmobRewardBasedVideo = false;
		IsRewardVideoRequested = false;
		//MobileAds.Initialize(AdmobAdUnitID);
		AdmobRewardBasedVideo = RewardBasedVideoAd.Instance;
		AdmobRewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
		AdmobRewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
		AdmobRewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;
		AdmobRewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;
		AdmobRewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
		AdmobRewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
		AdmobRewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;
		//if (Advertisement.isSupported)
		//{
		//	Advertisement.Initialize(UnityGameID);
		//}
		IronSource.Agent.init(IronSourceID, IronSourceAdUnits.REWARDED_VIDEO);
		IronSource.Agent.init(IronSourceID, IronSourceAdUnits.INTERSTITIAL);
		IronSource.Agent.shouldTrackNetworkState(true);
	}

	public AdRequest CreateAdRequest()
	{
		Debug.Log("----- Admobe CreateAdRequest");
		return new AdRequest.Builder().Build();
	}

	public void RequestAdmobInterstitial()
	{
		Debug.Log("----------  Admob RequestInterstitial Ad 11111111");
		if (AdmobInterstitial != null)
		{
			Debug.Log("------ Admob Ad Ready Already(interstitial) so returning");
			return;
		}
		Debug.Log("---------- Admob RequestInterstitial Load ad call ..");
		AdmobInterstitial = new InterstitialAd(AdmobAdUnitID);
		AdmobInterstitial.OnAdLoaded += HandleOnAdLoaded;
		AdmobInterstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
		AdmobInterstitial.OnAdOpening += HandleOnAdOpened;
		AdmobInterstitial.OnAdClosed += HandleOnAdClosed;
		AdmobInterstitial.OnAdLeavingApplication += HandleOnAdLeftApplication;
		AdmobInterstitial.LoadAd(CreateAdRequest());
	}

	public void RequestAdmobRewardBasedVideo()
	{
		if (IsRequestedAdmobRewardBasedVideo)
		{
			Debug.Log("---- Request Admob Reward based video alreay loaded so returing");
			return;
		}
		Debug.Log("---------- Request Admob RewardBasedVideo Load call..");
		IsRequestedAdmobRewardBasedVideo = true;
		AdmobRewardBasedVideo.LoadAd(CreateAdRequest(), AdmobRewardID);
	}

	public void ShowAdmobInterstitial()
	{
		Debug.Log("---------- Show Admob Interstitial Ad");
		if (AdmobInterstitial != null && AdmobInterstitial.IsLoaded())
		{
			Debug.Log("---------- Show Admob Interstitial Ad call..");
			AdmobInterstitial.Show();
		}
		else if (IsIronSourceInterstitialAvailable())
		{
			Debug.Log("---------- Show Irsonsource Interstitial Ad call.. as admob not ready");
			ShowIronSourceInterstitial();
		}
		else if (IsEnableUnityInterstital)
		{
			Debug.Log("---------- Show Unity Interstitial Ad call.. as admob not ready");
			ShowUnityAd();
		}
	}

	public void ShowAdmobRewardBasedVideo()
	{
		Debug.Log("--------- ShowAdmobRewardBasedVideo isloaded=" + AdmobRewardBasedVideo.IsLoaded());
		if (IsRewardVideoRequested)
		{
			Debug.Log("-------- ShowAdmobRewardBasedVideo is returning ISRewardVideoRequested true");
		}
		else if (AdmobRewardBasedVideo.IsLoaded())
		{
			Debug.Log("---------- Show Admob RewardBased Video call.. ");
			IsRewardVideoRequested = true;
			AdmobRewardBasedVideo.Show();
		}
		else if (IsIronSourceRewardVideoAvailable())
		{
			Debug.Log("---------- Show IronSource RewardBased Video call.. as Admob not ready ");
			IsRewardVideoRequested = true;
			IronSource.Agent.showRewardedVideo();
		}
		else if (IsEnableUnityReward)
		{
			Debug.Log("---------- Show Unity RewardBased Video call.. as Admob not ready ");
			ShowUnityRewardedVideoAd();
		}
		else
		{
			AdManager.instance.ShowToast("--------- Video not ready to display");
			Debug.Log("-------- Show Admob Video not ready to display");
		}
	}

	public void HandleOnAdLoaded(object sender, EventArgs args)
	{
		MonoBehaviour.print("------- Admob HandleAdLoaded event received");
	}

	public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		MonoBehaviour.print("------- Admob HandleFailedToReceiveAd event received with message: " + args.Message);
		if (AdmobInterstitial != null)
		{
			AdmobInterstitial.Destroy();
			AdmobInterstitial = null;
		}
	}

	public void HandleOnAdOpened(object sender, EventArgs args)
	{
		MonoBehaviour.print("------- Admob HandleAdOpened event received");
	}

	public void HandleOnAdClosed(object sender, EventArgs args)
	{
		MonoBehaviour.print("-------- Admob HandleAdClosed event received");
		if (AdmobInterstitial != null)
		{
			AdmobInterstitial.Destroy();
			AdmobInterstitial = null;
		}
	}

	public void HandleOnAdLeftApplication(object sender, EventArgs args)
	{
		MonoBehaviour.print("-------- Admob HandleAdLeftApplication event received");
	}

	public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
	{
		MonoBehaviour.print("-------- Admob HandleRewardBasedVideoLoaded event received");
	}

	public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		MonoBehaviour.print("-------- Admob HandleRewardBasedVideoFailedToLoad event received with message: " + args.Message);
		IsRequestedAdmobRewardBasedVideo = false;
		if (RequestCount == 0)
		{
			RequestAdmobRewardBasedVideo();
			RequestCount = 1;
		}
	}

	public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
	{
		IsVideoRewarded = false;
		MonoBehaviour.print("-------- Admob HandleRewardBasedVideoOpened event received");
	}

	public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
	{
		IsVideoRewarded = false;
		MonoBehaviour.print("-------- Admob HandleRewardBasedVideoStarted event received");
	}

	public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
	{
		MonoBehaviour.print("-------- Admob HandleRewardBasedVideoClosed event received");
		if (!IsVideoRewarded)
		{
			AdManager.instance.VideoWatchedSuccessfully(false);
		}
		else
		{
			AdManager.instance.VideoWatchedSuccessfully();
		}
		RequestCount = 0;
		IsRequestedAdmobRewardBasedVideo = false;
		IsRewardVideoRequested = false;
		RequestAdmobRewardBasedVideo();
	}

	public void HandleRewardBasedVideoRewarded(object sender, Reward args)
	{
		string type = args.Type;
		MonoBehaviour.print("-------- Admob HandleRewardBasedVideoRewarded event received for " + args.Amount + " " + type);
		IsVideoRewarded = true;
		RequestCount = 0;
		RequestAdmobRewardBasedVideo();
		IsRequestedAdmobRewardBasedVideo = false;
		IsRewardVideoRequested = false;
	}

	public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
	{
		MonoBehaviour.print("-------- Admob HandleRewardBasedVideoLeftApplication event received");
	}

	public void ShowUnityRewardedVideoAd()
	{
		Debug.Log("-------- Show Unity RewardVideo 11111");
		if (IsRewardVideoRequested)
		{
			Debug.Log("-------- Show Unity RewardVideo returning as IsRewardVideoRequested");
			return;
		}
		Debug.Log("--------- Show Unity RewardBasedVideo IsUnityVideoRequested=" + IsUnityVideoRequested);
		if (!IsUnityVideoRequested)
		{
			//ShowOptions showOptions = new ShowOptions();
			//showOptions.resultCallback = VideoAdCallbackhandler;
			//Advertisement.Show(UnityPlacementId, showOptions);
			IsUnityVideoRequested = true;
			IsRewardVideoRequested = true;
		}
	}

	public void ShowUnityAd()
	{
		//Debug.Log("--------- Show UnityAd isRequested=" + IsUnityAdRequested + "::IsReady=" + Advertisement.IsReady());
		//if (!IsUnityAdRequested && Advertisement.IsReady())
		//{

			//resultCallback = AdCallbackhandler;

			IsUnityAdRequested = true;
		//}
	}

	/*private void AdCallbackhandler(ShowResult result)
	{
		IsUnityAdRequested = false;
		Debug.Log("-------- Unity AdCallbackHandler");
		switch (result)
		{
		case ShowResult.Finished:
			Debug.Log("-------- Unity Ad Finished. Rewarding player...");
			break;
		case ShowResult.Skipped:
			Debug.Log("-------- Unity Ad skipped.");
			break;
		case ShowResult.Failed:
			Debug.Log("-------- Unity Interstitial Ads Failed trying to call other ads");
			if (AdmobInterstitial != null && AdmobInterstitial.IsLoaded())
			{
				Debug.Log("--------show Admob Interstitial call as Unity Failed");
				AdmobInterstitial.Show();
			}
			else if (IsIronSourceInterstitialAvailable())
			{
				Debug.Log("-------- Show IronSrouce Interstitial call as Unity Failed");
				ShowIronSourceInterstitial();
			}
			else
			{
				Debug.Log("-------- Unity Ads Failed");
			}
			break;
		}
	}

	private void VideoAdCallbackhandler(ShowResult result)
	{
		IsUnityVideoRequested = false;
		IsRewardVideoRequested = false;
		Debug.Log("------- Unity Video AdCallbackhandler");
		switch (result)
		{
		case ShowResult.Finished:
			Debug.Log("------- Unity Reward Ad Finished. Rewarding player...");
			AdManager.instance.VideoWatchedSuccessfully();
			break;
		case ShowResult.Skipped:
			Debug.Log("------- Unity Reward Ad skipped.");
			AdManager.instance.VideoWatchedSuccessfully(false);
			break;
		case ShowResult.Failed:
			Debug.Log("-------- Unity Reward Ads Failed trying to call other ads");
			if (IsIronSourceRewardVideoAvailable())
			{
				Debug.Log("-------- Show IronSource Reward video call as Unity Failed..");
				IronSource.Agent.showRewardedVideo();
			}
			else if (AdmobRewardBasedVideo.IsLoaded())
			{
				Debug.Log("-------- Show Admobe Reward video call as Unity Failed..");
				AdmobRewardBasedVideo.Show();
			}
			else
			{
				AdManager.instance.ShowToast("Video not ready to display");
				Debug.Log("-------- Unity Video Not ready to display");
			}
			break;
		}
	}*/

	private void OnApplicationPause(bool isPaused)
	{
		Debug.Log("----------- OnApplicationPause isPaused=" + isPaused);
		IronSource.Agent.onApplicationPause(isPaused);
	}

	public void ValidateIntegration()
	{
		Debug.Log("---- IronSource Validate Integration");
		IronSource.Agent.validateIntegration();
	}

	public void LoadIronSourceInterstitial()
	{
		Debug.Log("---- Load Ironsource Interstitial is available=" + IsIronSourceInterstitialAvailable());
		if (!IsIronSourceInterstitialAvailable())
		{
			IronSource.Agent.loadInterstitial();
		}
	}

	public void ShowIronSourceInterstitial()
	{
		Debug.Log("---- Show Ironsource Interstitial is Available=" + IsIronSourceInterstitialAvailable() + ":::IsEnableUnityInterstital=" + IsEnableUnityInterstital);
		if (IsIronSourceInterstitialAvailable())
		{
			Debug.Log("---- Show Ironsource Interstitial call");
			IronSource.Agent.showInterstitial();
		}
		else if (AdmobInterstitial != null && AdmobInterstitial.IsLoaded())
		{
			Debug.Log("------ Show Admob Interstitial call as IronSource Failed");
			AdmobInterstitial.Show();
		}
		else if (IsEnableUnityInterstital)
		{
			Debug.Log("------ Show Unity Interstitial call as IronSource Failed");
			ShowUnityAd();
		}
		else
		{
			Debug.Log("------- Interstital ads not ready to display");
		}
	}

	public void ShowIronSourceRewardVideo()
	{
		Debug.Log("---- Show IronSource RewardVideo available=" + IsIronSourceRewardVideoAvailable() + ":::IsEnableUnityReward=" + IsEnableUnityReward);
		if (IsRewardVideoRequested)
		{
			Debug.Log("-------- Show IronSource Reward is returning ISRewardVideoRequested true");
		}
		else if (IsIronSourceRewardVideoAvailable())
		{
			Debug.Log("---- Show IronSource RewardVideo call");
			IsRewardVideoRequested = true;
			IronSource.Agent.showRewardedVideo();
		}
		else if (AdmobRewardBasedVideo.IsLoaded())
		{
			Debug.Log("---- Show Admob RewardVideo call as IronSource Reward Failed");
			IsRewardVideoRequested = true;
			AdmobRewardBasedVideo.Show();
		}
		else if (IsEnableUnityReward)
		{
			Debug.Log("---- Show Unity RewardVideo call as IronSource Reward Failed");
			ShowUnityRewardedVideoAd();
		}
		else
		{
			AdManager.instance.ShowToast("Video not ready to display");
			Debug.Log("----------- Show IronSource Video Not Ready to display");
		}
	}

	public bool IsIronSourceRewardVideoAvailable()
	{
		return IronSource.Agent.isRewardedVideoAvailable();
	}

	public bool IsIronSourceInterstitialAvailable()
	{
		return IronSource.Agent.isInterstitialReady();
	}

	private void InterstitialAdLoadFailedEvent(IronSourceError error)
	{
		Debug.Log("------- IronSource Interstitial Ad load Failed Event=" + error);
	}

	private void InterstitialAdShowSucceededEvent()
	{
		Debug.Log("------- IronSource Interstitial Ad Show Success Event");
	}

	private void InterstitialAdShowFailedEvent(IronSourceError error)
	{
		Debug.Log("------- IronSource Interstitial Ad Show Failed Event");
	}

	private void InterstitialAdClickedEvent()
	{
		Debug.Log("------- IronSource Interstitial Ad Clicked Event");
	}

	private void InterstitialAdClosedEvent()
	{
		Debug.Log("------- IronSource Interstitial Ad Closed Event");
	}

	private void InterstitialAdReadyEvent()
	{
		Debug.Log("------- IronSource Interstitial Ad Ready Event");
	}

	private void InterstitialAdOpenedEvent()
	{
		Debug.Log("------- IronSource Interstitial Ad Opened Event");
	}

	private void RewardedVideoAdOpenedEvent()
	{
		Debug.Log("----- IronSource Reward video Opened event");
		IsVideoRewarded = false;
	}

	private void RewardedVideoAdClosedEvent()
	{
		Debug.Log("----- IronSource Reward video Closed event IsVideoRewarded=" + IsVideoRewarded);
		IsRewardVideoRequested = false;
		if (IsVideoRewarded)
		{
			AdManager.instance.VideoWatchedSuccessfully();
		}
		else
		{
			AdManager.instance.VideoWatchedSuccessfully(false);
		}
	}

	private void RewardedVideoAvailabilityChangedEvent(bool available)
	{
		Debug.Log("----- IronSource Reward video Availablity event available=" + available);
	}

	private void RewardedVideoAdStartedEvent()
	{
		Debug.Log("----- IronSource Reward video Started event");
	}

	private void RewardedVideoAdEndedEvent()
	{
		Debug.Log("----- IronSource Reward video Ended event");
	}

	private void RewardedVideoAdRewardedEvent(IronSourcePlacement placement)
	{
		Debug.Log("----- IronSource Reward video rewarded event");
		IsRewardVideoRequested = false;
		IsVideoRewarded = true;
	}

	private void RewardedVideoAdShowFailedEvent(IronSourceError error)
	{
		Debug.Log("----- IronSource Reward video show failed event");
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
