using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using GoogleMobileAds.Common;

namespace GoogleMobileAds.Api
{
	public class AdLoader
	{
		public class Builder
		{
			internal string AdUnitId { get; private set; }

			internal HashSet<NativeAdType> AdTypes { get; private set; }

			internal HashSet<string> TemplateIds { get; private set; }

			internal Dictionary<string, Action<CustomNativeTemplateAd, string>> CustomNativeTemplateClickHandlers { get; private set; }

			public Builder(string adUnitId)
			{
				AdUnitId = adUnitId;
				AdTypes = new HashSet<NativeAdType>();
				TemplateIds = new HashSet<string>();
				CustomNativeTemplateClickHandlers = new Dictionary<string, Action<CustomNativeTemplateAd, string>>();
			}

			public Builder ForCustomNativeAd(string templateId)
			{
				TemplateIds.Add(templateId);
				AdTypes.Add(NativeAdType.CustomTemplate);
				return this;
			}

			public Builder ForCustomNativeAd(string templateId, Action<CustomNativeTemplateAd, string> callback)
			{
				TemplateIds.Add(templateId);
				CustomNativeTemplateClickHandlers[templateId] = callback;
				AdTypes.Add(NativeAdType.CustomTemplate);
				return this;
			}

			public AdLoader Build()
			{
				return new AdLoader(this);
			}
		}

		private IAdLoaderClient adLoaderClient;

		[CompilerGenerated]
		private EventHandler<AdFailedToLoadEventArgs> m_OnAdFailedToLoad;

		[CompilerGenerated]
		private EventHandler<CustomNativeEventArgs> m_OnCustomNativeTemplateAdLoaded;

		public Dictionary<string, Action<CustomNativeTemplateAd, string>> CustomNativeTemplateClickHandlers { get; private set; }

		public string AdUnitId { get; private set; }

		public HashSet<NativeAdType> AdTypes { get; private set; }

		public HashSet<string> TemplateIds { get; private set; }

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

		private AdLoader(Builder builder)
		{
			AdUnitId = string.Copy(builder.AdUnitId);
			CustomNativeTemplateClickHandlers = new Dictionary<string, Action<CustomNativeTemplateAd, string>>(builder.CustomNativeTemplateClickHandlers);
			TemplateIds = new HashSet<string>(builder.TemplateIds);
			AdTypes = new HashSet<NativeAdType>(builder.AdTypes);
			MethodInfo method = Type.GetType("GoogleMobileAds.GoogleMobileAdsClientFactory,Assembly-CSharp").GetMethod("BuildAdLoaderClient", BindingFlags.Static | BindingFlags.Public);
			adLoaderClient = (IAdLoaderClient)method.Invoke(null, new object[1] { this });
			Utils.CheckInitialization();

		}

		public void LoadAd(AdRequest request)
		{
			adLoaderClient.LoadAd(request);
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
