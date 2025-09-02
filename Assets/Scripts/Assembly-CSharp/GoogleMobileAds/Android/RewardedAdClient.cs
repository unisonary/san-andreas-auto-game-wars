using System;
using System.Runtime.CompilerServices;
using System.Threading;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine;

namespace GoogleMobileAds.Android
{
	public class RewardedAdClient : AndroidJavaProxy, IRewardedAdClient
	{
		private AndroidJavaObject androidRewardedAd;

		[CompilerGenerated]
		private EventHandler<EventArgs> m_OnAdLoaded;

		[CompilerGenerated]
		private EventHandler<AdErrorEventArgs> m_OnAdFailedToLoad;

		[CompilerGenerated]
		private EventHandler<AdErrorEventArgs> m_OnAdFailedToShow;

		[CompilerGenerated]
		private EventHandler<EventArgs> m_OnAdOpening;

		[CompilerGenerated]
		private EventHandler<Reward> m_OnUserEarnedReward;

		[CompilerGenerated]
		private EventHandler<EventArgs> m_OnAdClosed;

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

		public event EventHandler<AdErrorEventArgs> OnAdFailedToLoad
		{
			[CompilerGenerated]
			add
			{
				EventHandler<AdErrorEventArgs> eventHandler = this.m_OnAdFailedToLoad;
				EventHandler<AdErrorEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<AdErrorEventArgs> value2 = (EventHandler<AdErrorEventArgs>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.m_OnAdFailedToLoad, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<AdErrorEventArgs> eventHandler = this.m_OnAdFailedToLoad;
				EventHandler<AdErrorEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<AdErrorEventArgs> value2 = (EventHandler<AdErrorEventArgs>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.m_OnAdFailedToLoad, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		public event EventHandler<AdErrorEventArgs> OnAdFailedToShow
		{
			[CompilerGenerated]
			add
			{
				EventHandler<AdErrorEventArgs> eventHandler = this.m_OnAdFailedToShow;
				EventHandler<AdErrorEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<AdErrorEventArgs> value2 = (EventHandler<AdErrorEventArgs>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.m_OnAdFailedToShow, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<AdErrorEventArgs> eventHandler = this.m_OnAdFailedToShow;
				EventHandler<AdErrorEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<AdErrorEventArgs> value2 = (EventHandler<AdErrorEventArgs>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.m_OnAdFailedToShow, value2, eventHandler2);
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

		public event EventHandler<Reward> OnUserEarnedReward
		{
			[CompilerGenerated]
			add
			{
				EventHandler<Reward> eventHandler = this.m_OnUserEarnedReward;
				EventHandler<Reward> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<Reward> value2 = (EventHandler<Reward>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.m_OnUserEarnedReward, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<Reward> eventHandler = this.m_OnUserEarnedReward;
				EventHandler<Reward> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<Reward> value2 = (EventHandler<Reward>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.m_OnUserEarnedReward, value2, eventHandler2);
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

		public RewardedAdClient()
			: base("com.google.unity.ads.UnityRewardedAdCallback")
		{
			AndroidJavaObject @static = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
			androidRewardedAd = new AndroidJavaObject("com.google.unity.ads.UnityRewardedAd", @static, this);
		}

		public void CreateRewardedAd(string adUnitId)
		{
			androidRewardedAd.Call("create", adUnitId);
		}

		public void LoadAd(AdRequest request)
		{
			androidRewardedAd.Call("loadAd", Utils.GetAdRequestJavaObject(request));
		}

		public bool IsLoaded()
		{
			return androidRewardedAd.Call<bool>("isLoaded", Array.Empty<object>());
		}

		public void Show()
		{
			androidRewardedAd.Call("show");
		}

		public void SetServerSideVerificationOptions(ServerSideVerificationOptions serverSideVerificationOptions)
		{
			androidRewardedAd.Call("setServerSideVerificationOptions", Utils.GetServerSideVerificationOptionsJavaObject(serverSideVerificationOptions));
		}

		public void DestroyRewardBasedVideoAd()
		{
			androidRewardedAd.Call("destroy");
		}

		public string MediationAdapterClassName()
		{
			return androidRewardedAd.Call<string>("getMediationAdapterClassName", Array.Empty<object>());
		}

		private void onRewardedAdLoaded()
		{

		}

		private void onRewardedAdFailedToLoad(string errorReason)
		{

		}

		private void onRewardedAdFailedToShow(string errorReason)
		{

		}

		private void onRewardedAdOpened()
		{

		}

		private void onRewardedAdClosed()
		{

		}

		private void onUserEarnedReward(string type, float amount)
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
