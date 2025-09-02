using System;
using System.Runtime.CompilerServices;
using System.Threading;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine;

namespace GoogleMobileAds.Android
{
	public class BannerClient : AndroidJavaProxy, IBannerClient
	{
		private AndroidJavaObject bannerView;

		[CompilerGenerated]
		private EventHandler<EventArgs> m_OnAdLoaded;

		[CompilerGenerated]
		private EventHandler<AdFailedToLoadEventArgs> m_OnAdFailedToLoad;

		[CompilerGenerated]
		private EventHandler<EventArgs> m_OnAdOpening;

		[CompilerGenerated]
		private EventHandler<EventArgs> m_OnAdClosed;

		[CompilerGenerated]
		private EventHandler<EventArgs> m_OnAdLeavingApplication;

		public event EventHandler<EventArgs> OnAdLoaded
		{
			[CompilerGenerated]
			add
			{
				EventHandler<EventArgs> eventHandler = this.m_OnAdLoaded;
				EventHandler<EventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.m_OnAdLoaded, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<EventArgs> eventHandler = this.m_OnAdLoaded;
				EventHandler<EventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.m_OnAdLoaded, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

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

		public event EventHandler<EventArgs> OnAdOpening
		{
			[CompilerGenerated]
			add
			{
				EventHandler<EventArgs> eventHandler = this.m_OnAdOpening;
				EventHandler<EventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.m_OnAdOpening, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<EventArgs> eventHandler = this.m_OnAdOpening;
				EventHandler<EventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.m_OnAdOpening, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		public event EventHandler<EventArgs> OnAdClosed
		{
			[CompilerGenerated]
			add
			{
				EventHandler<EventArgs> eventHandler = this.m_OnAdClosed;
				EventHandler<EventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.m_OnAdClosed, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<EventArgs> eventHandler = this.m_OnAdClosed;
				EventHandler<EventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.m_OnAdClosed, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		public event EventHandler<EventArgs> OnAdLeavingApplication
		{
			[CompilerGenerated]
			add
			{
				EventHandler<EventArgs> eventHandler = this.m_OnAdLeavingApplication;
				EventHandler<EventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.m_OnAdLeavingApplication, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<EventArgs> eventHandler = this.m_OnAdLeavingApplication;
				EventHandler<EventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.m_OnAdLeavingApplication, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		public BannerClient()
			: base("com.google.unity.ads.UnityAdListener")
		{
			AndroidJavaObject @static = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
			bannerView = new AndroidJavaObject("com.google.unity.ads.Banner", @static, this);
		}

		public void CreateBannerView(string adUnitId, AdSize adSize, AdPosition position)
		{
			bannerView.Call("create", adUnitId, Utils.GetAdSizeJavaObject(adSize), (int)position);
		}

		public void CreateBannerView(string adUnitId, AdSize adSize, int x, int y)
		{
			bannerView.Call("create", adUnitId, Utils.GetAdSizeJavaObject(adSize), x, y);
		}

		public void LoadAd(AdRequest request)
		{
			bannerView.Call("loadAd", Utils.GetAdRequestJavaObject(request));
		}

		public void ShowBannerView()
		{
			bannerView.Call("show");
		}

		public void HideBannerView()
		{
			bannerView.Call("hide");
		}

		public void DestroyBannerView()
		{
			bannerView.Call("destroy");
		}

		public float GetHeightInPixels()
		{
			return bannerView.Call<float>("getHeightInPixels", Array.Empty<object>());
		}

		public float GetWidthInPixels()
		{
			return bannerView.Call<float>("getWidthInPixels", Array.Empty<object>());
		}

		public void SetPosition(AdPosition adPosition)
		{
			bannerView.Call("setPosition", (int)adPosition);
		}

		public void SetPosition(int x, int y)
		{
			bannerView.Call("setPosition", x, y);
		}

		public string MediationAdapterClassName()
		{
			return bannerView.Call<string>("getMediationAdapterClassName", Array.Empty<object>());
		}

		public void onAdLoaded()
		{

		}

		public void onAdFailedToLoad(string errorReason)
		{

		}

		public void onAdOpened()
		{ 
		}

		public void onAdClosed()
		{

		}

		public void onAdLeftApplication()
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
