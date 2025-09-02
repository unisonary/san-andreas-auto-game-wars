using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using IronSourceJSON;
using UnityEngine;

public class IronSourceEvents : MonoBehaviour
{
	private const string ERROR_CODE = "error_code";

	private const string ERROR_DESCRIPTION = "error_description";

	private const string INSTANCE_ID_KEY = "instanceId";

	private const string PLACEMENT_KEY = "placement";

	[CompilerGenerated]
	private static Action<IronSourceError> m__onRewardedVideoAdShowFailedEvent;

	[CompilerGenerated]
	private static Action m__onRewardedVideoAdOpenedEvent;

	[CompilerGenerated]
	private static Action m__onRewardedVideoAdClosedEvent;

	[CompilerGenerated]
	private static Action m__onRewardedVideoAdStartedEvent;

	[CompilerGenerated]
	private static Action m__onRewardedVideoAdEndedEvent;

	[CompilerGenerated]
	private static Action<IronSourcePlacement> m__onRewardedVideoAdRewardedEvent;

	[CompilerGenerated]
	private static Action<IronSourcePlacement> m__onRewardedVideoAdClickedEvent;

	[CompilerGenerated]
	private static Action<bool> m__onRewardedVideoAvailabilityChangedEvent;

	[CompilerGenerated]
	private static Action<string, bool> m__onRewardedVideoAvailabilityChangedDemandOnlyEvent;

	[CompilerGenerated]
	private static Action<string> m__onRewardedVideoAdOpenedDemandOnlyEvent;

	[CompilerGenerated]
	private static Action<string> m__onRewardedVideoAdClosedDemandOnlyEvent;

	[CompilerGenerated]
	private static Action<string, IronSourcePlacement> m__onRewardedVideoAdRewardedDemandOnlyEvent;

	[CompilerGenerated]
	private static Action<string, IronSourceError> m__onRewardedVideoAdShowFailedDemandOnlyEvent;

	[CompilerGenerated]
	private static Action<string, IronSourcePlacement> m__onRewardedVideoAdClickedDemandOnlyEvent;

	[CompilerGenerated]
	private static Action m__onInterstitialAdReadyEvent;

	[CompilerGenerated]
	private static Action<IronSourceError> m__onInterstitialAdLoadFailedEvent;

	[CompilerGenerated]
	private static Action m__onInterstitialAdOpenedEvent;

	[CompilerGenerated]
	private static Action m__onInterstitialAdClosedEvent;

	[CompilerGenerated]
	private static Action m__onInterstitialAdShowSucceededEvent;

	[CompilerGenerated]
	private static Action<IronSourceError> m__onInterstitialAdShowFailedEvent;

	[CompilerGenerated]
	private static Action m__onInterstitialAdClickedEvent;

	[CompilerGenerated]
	private static Action<string> m__onInterstitialAdReadyDemandOnlyEvent;

	[CompilerGenerated]
	private static Action<string, IronSourceError> m__onInterstitialAdLoadFailedDemandOnlyEvent;

	[CompilerGenerated]
	private static Action<string> m__onInterstitialAdOpenedDemandOnlyEvent;

	[CompilerGenerated]
	private static Action<string> m__onInterstitialAdClosedDemandOnlyEvent;

	[CompilerGenerated]
	private static Action<string> m__onInterstitialAdShowSucceededDemandOnlyEvent;

	[CompilerGenerated]
	private static Action<string, IronSourceError> m__onInterstitialAdShowFailedDemandOnlyEvent;

	[CompilerGenerated]
	private static Action<string> m__onInterstitialAdClickedDemandOnlyEvent;

	[CompilerGenerated]
	private static Action m__onInterstitialAdRewardedEvent;

	[CompilerGenerated]
	private static Action m__onOfferwallOpenedEvent;

	[CompilerGenerated]
	private static Action<IronSourceError> m__onOfferwallShowFailedEvent;

	[CompilerGenerated]
	private static Action m__onOfferwallClosedEvent;

	[CompilerGenerated]
	private static Action<IronSourceError> m__onGetOfferwallCreditsFailedEvent;

	[CompilerGenerated]
	private static Action<Dictionary<string, object>> m__onOfferwallAdCreditedEvent;

	[CompilerGenerated]
	private static Action<bool> m__onOfferwallAvailableEvent;

	[CompilerGenerated]
	private static Action m__onBannerAdLoadedEvent;

	[CompilerGenerated]
	private static Action<IronSourceError> m__onBannerAdLoadFailedEvent;

	[CompilerGenerated]
	private static Action m__onBannerAdClickedEvent;

	[CompilerGenerated]
	private static Action m__onBannerAdScreenPresentedEvent;

	[CompilerGenerated]
	private static Action m__onBannerAdScreenDismissedEvent;

	[CompilerGenerated]
	private static Action m__onBannerAdLeftApplicationEvent;

	[CompilerGenerated]
	private static Action<string> m__onSegmentReceivedEvent;

	
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
