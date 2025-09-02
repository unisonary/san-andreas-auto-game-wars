using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using GoogleMobileAds.Api;
using UnityEngine;

namespace GoogleMobileAds.Common
{
	public class DummyClient : IBannerClient, IInterstitialClient, IRewardBasedVideoAdClient, IAdLoaderClient, IMobileAdsClient
	{
		[CompilerGenerated]
		private EventHandler<EventArgs> m_OnAdLoaded;

		[CompilerGenerated]
		private EventHandler<AdFailedToLoadEventArgs> m_OnAdFailedToLoad;

		[CompilerGenerated]
		private EventHandler<EventArgs> m_OnAdOpening;

		[CompilerGenerated]
		private EventHandler<EventArgs> m_OnAdStarted;

		[CompilerGenerated]
		private EventHandler<EventArgs> m_OnAdClosed;

		[CompilerGenerated]
		private EventHandler<Reward> m_OnAdRewarded;

		[CompilerGenerated]
		private EventHandler<EventArgs> m_OnAdLeavingApplication;

		[CompilerGenerated]
		private EventHandler<EventArgs> m_OnAdCompleted;

		[CompilerGenerated]
		private EventHandler<CustomNativeEventArgs> m_OnCustomNativeTemplateAdLoaded;

		public string UserId
		{
			get
			{
				Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
				return "UserId";
			}
			set
			{
				Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
			}
		}

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

		public event EventHandler<EventArgs> OnAdStarted
		{
			[CompilerGenerated]
			add
			{
				EventHandler<EventArgs> eventHandler = this.m_OnAdStarted;
				EventHandler<EventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.m_OnAdStarted, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<EventArgs> eventHandler = this.m_OnAdStarted;
				EventHandler<EventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.m_OnAdStarted, value2, eventHandler2);
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

		public event EventHandler<Reward> OnAdRewarded
		{
			[CompilerGenerated]
			add
			{
				EventHandler<Reward> eventHandler = this.m_OnAdRewarded;
				EventHandler<Reward> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<Reward> value2 = (EventHandler<Reward>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.m_OnAdRewarded, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<Reward> eventHandler = this.m_OnAdRewarded;
				EventHandler<Reward> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<Reward> value2 = (EventHandler<Reward>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.m_OnAdRewarded, value2, eventHandler2);
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

		public event EventHandler<EventArgs> OnAdCompleted
		{
			[CompilerGenerated]
			add
			{
				EventHandler<EventArgs> eventHandler = this.m_OnAdCompleted;
				EventHandler<EventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.m_OnAdCompleted, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<EventArgs> eventHandler = this.m_OnAdCompleted;
				EventHandler<EventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.m_OnAdCompleted, value2, eventHandler2);
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

		public DummyClient()
		{
			Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		public void Initialize(string appId)
		{
			Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		public void SetApplicationMuted(bool muted)
		{
			Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		public void SetApplicationVolume(float volume)
		{
			Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		public void SetiOSAppPauseOnBackground(bool pause)
		{
			Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		public void CreateBannerView(string adUnitId, AdSize adSize, AdPosition position)
		{
			Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		public void CreateBannerView(string adUnitId, AdSize adSize, int positionX, int positionY)
		{
			Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		public void LoadAd(AdRequest request)
		{
			Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		public void ShowBannerView()
		{
			Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		public void HideBannerView()
		{
			Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		public void DestroyBannerView()
		{
			Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		public float GetHeightInPixels()
		{
			Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
			return 0f;
		}

		public float GetWidthInPixels()
		{
			Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
			return 0f;
		}

		public void SetPosition(AdPosition adPosition)
		{
			Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		public void SetPosition(int x, int y)
		{
			Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		public void CreateInterstitialAd(string adUnitId)
		{
			Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		public bool IsLoaded()
		{
			Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
			return true;
		}

		public void ShowInterstitial()
		{
			Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		public void DestroyInterstitial()
		{
			Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		public void CreateRewardBasedVideoAd()
		{
			Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		public void SetUserId(string userId)
		{
			Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		public void LoadAd(AdRequest request, string adUnitId)
		{
			Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		public void DestroyRewardBasedVideoAd()
		{
			Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		public void ShowRewardBasedVideoAd()
		{
			Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		public void CreateAdLoader(AdLoader.Builder builder)
		{
			Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		public void Load(AdRequest request)
		{
			Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		public void SetAdSize(AdSize adSize)
		{
			Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		public string MediationAdapterClassName()
		{
			Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
			return null;
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
