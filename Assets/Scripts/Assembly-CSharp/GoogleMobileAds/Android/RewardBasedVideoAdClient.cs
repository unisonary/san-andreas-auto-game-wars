using System;
using System.Runtime.CompilerServices;
using System.Threading;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine;

namespace GoogleMobileAds.Android
{
	public class RewardBasedVideoAdClient : AndroidJavaProxy, IRewardBasedVideoAdClient
	{
		private AndroidJavaObject androidRewardBasedVideo;

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

        public RewardBasedVideoAdClient(string javaInterface) : base(javaInterface)
        {
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

		public void CreateRewardBasedVideoAd()
		{
			androidRewardBasedVideo.Call("create");
		}

		public void LoadAd(AdRequest request, string adUnitId)
		{
			androidRewardBasedVideo.Call("loadAd", Utils.GetAdRequestJavaObject(request), adUnitId);
		}

		public bool IsLoaded()
		{
			return androidRewardBasedVideo.Call<bool>("isLoaded", Array.Empty<object>());
		}

		public void ShowRewardBasedVideoAd()
		{
			androidRewardBasedVideo.Call("show");
		}

		public void SetUserId(string userId)
		{
			androidRewardBasedVideo.Call("setUserId", userId);
		}

		public void DestroyRewardBasedVideoAd()
		{
			androidRewardBasedVideo.Call("destroy");
		}

		public string MediationAdapterClassName()
		{
			return androidRewardBasedVideo.Call<string>("getMediationAdapterClassName", Array.Empty<object>());
		}

		private void onAdLoaded()
		{

		}

		private void onAdFailedToLoad(string errorReason)
		{

		}

		private void onAdOpened()
		{

		}

		private void onAdStarted()
		{

		}

		private void onAdClosed()
		{

		}

		private void onAdRewarded(string type, float amount)
		{

		}

		private void onAdLeftApplication()
		{


		}

		private void onAdCompleted()
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
