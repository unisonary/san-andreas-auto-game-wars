using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine;

namespace GoogleMobileAds.Android
{
	public class AdLoaderClient : AndroidJavaProxy, IAdLoaderClient
	{
		private AndroidJavaObject adLoader;

		[CompilerGenerated]
		private EventHandler<AdFailedToLoadEventArgs> m_OnAdFailedToLoad;

		[CompilerGenerated]
		private EventHandler<CustomNativeEventArgs> m_OnCustomNativeTemplateAdLoaded;

		private Dictionary<string, Action<CustomNativeTemplateAd, string>> CustomNativeTemplateCallbacks { get; set; }

		public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad
		{
			[CompilerGenerated]
			add
			{
				EventHandler<AdFailedToLoadEventArgs> eventHandler = this.m_OnAdFailedToLoad;
				EventHandler<AdFailedToLoadEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<AdFailedToLoadEventArgs> value2 = (EventHandler<AdFailedToLoadEventArgs>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.m_OnAdFailedToLoad, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<AdFailedToLoadEventArgs> eventHandler = this.m_OnAdFailedToLoad;
				EventHandler<AdFailedToLoadEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<AdFailedToLoadEventArgs> value2 = (EventHandler<AdFailedToLoadEventArgs>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.m_OnAdFailedToLoad, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		public event EventHandler<CustomNativeEventArgs> OnCustomNativeTemplateAdLoaded
		{
			[CompilerGenerated]
			add
			{
				EventHandler<CustomNativeEventArgs> eventHandler = this.m_OnCustomNativeTemplateAdLoaded;
				EventHandler<CustomNativeEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<CustomNativeEventArgs> value2 = (EventHandler<CustomNativeEventArgs>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.m_OnCustomNativeTemplateAdLoaded, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<CustomNativeEventArgs> eventHandler = this.m_OnCustomNativeTemplateAdLoaded;
				EventHandler<CustomNativeEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<CustomNativeEventArgs> value2 = (EventHandler<CustomNativeEventArgs>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.m_OnCustomNativeTemplateAdLoaded, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		public AdLoaderClient(AdLoader unityAdLoader)
			: base("com.google.unity.ads.UnityAdLoaderListener")
		{
			AndroidJavaObject @static = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
			adLoader = new AndroidJavaObject("com.google.unity.ads.NativeAdLoader", @static, unityAdLoader.AdUnitId, this);
			CustomNativeTemplateCallbacks = unityAdLoader.CustomNativeTemplateClickHandlers;
			if (unityAdLoader.AdTypes.Contains(NativeAdType.CustomTemplate))
			{
				foreach (string templateId in unityAdLoader.TemplateIds)
				{
					adLoader.Call("configureCustomNativeTemplateAd", templateId, CustomNativeTemplateCallbacks.ContainsKey(templateId));
				}
			}
			adLoader.Call("create");
		}

		public void LoadAd(AdRequest request)
		{
			adLoader.Call("loadAd", Utils.GetAdRequestJavaObject(request));
		}

		public void onCustomTemplateAdLoaded(AndroidJavaObject ad)
		{

		}

		private void onAdFailedToLoad(string errorReason)
		{
			AdFailedToLoadEventArgs e = new AdFailedToLoadEventArgs
			{
				Message = errorReason
			};
	
		}

		public void onCustomClick(AndroidJavaObject ad, string assetName)
		{
			CustomNativeTemplateAd customNativeTemplateAd = new CustomNativeTemplateAd(new CustomNativeTemplateClient(ad));
			CustomNativeTemplateCallbacks[customNativeTemplateAd.GetCustomTemplateId()](customNativeTemplateAd, assetName);
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
