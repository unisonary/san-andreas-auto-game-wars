using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using GoogleMobileAds.Api;
using UnityEngine;

namespace GoogleMobileAds.Common
{
	public class RewardedAdDummyClient : IRewardedAdClient
	{
		[CompilerGenerated]
		private EventHandler<EventArgs> m_OnAdLoaded;

		[CompilerGenerated]
		private EventHandler<AdErrorEventArgs> m_OnAdFailedToLoad;

		[CompilerGenerated]
		private EventHandler<AdErrorEventArgs> m_OnAdFailedToShow;

		[CompilerGenerated]
		private EventHandler<EventArgs> m_OnAdOpening;

		[CompilerGenerated]
		private EventHandler<EventArgs> m_OnAdClosed;

		[CompilerGenerated]
		private EventHandler<Reward> m_OnUserEarnedReward;

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

		public RewardedAdDummyClient()
		{
			Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		public void CreateRewardedAd(string adUnitId)
		{
			Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		public void LoadAd(AdRequest request)
		{
			Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		public bool IsLoaded()
		{
			Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
			return true;
		}

		public void Show()
		{
			Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		public string MediationAdapterClassName()
		{
			Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
			return null;
		}

		public void SetServerSideVerificationOptions(ServerSideVerificationOptions serverSideVerificationOptions)
		{
			Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
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
