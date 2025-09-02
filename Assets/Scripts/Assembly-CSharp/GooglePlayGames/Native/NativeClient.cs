using System;
using System.Collections.Generic;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.Events;
using GooglePlayGames.BasicApi.Multiplayer;
using GooglePlayGames.BasicApi.SavedGame;
using GooglePlayGames.BasicApi.Video;
using GooglePlayGames.Native.Cwrapper;
using GooglePlayGames.Native.PInvoke;
using GooglePlayGames.OurUtils;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Types = GooglePlayGames.Native.Cwrapper.Types;

namespace GooglePlayGames.Native
{
	public class NativeClient : IPlayGamesClient
	{
		private enum AuthState
		{
			Unauthenticated = 0,
			Authenticated = 1
		}

		private readonly IClientImpl clientImpl;

		private readonly object GameServicesLock = new object();

		private readonly object AuthStateLock = new object();

		private readonly PlayGamesClientConfiguration mConfiguration;

		private GooglePlayGames.Native.PInvoke.GameServices mServices;

		private volatile NativeTurnBasedMultiplayerClient mTurnBasedClient;

		private volatile NativeRealtimeMultiplayerClient mRealTimeClient;

		private volatile ISavedGameClient mSavedGameClient;

		private volatile IEventsClient mEventsClient;

		private volatile IVideoClient mVideoClient;

		private volatile TokenClient mTokenClient;

		private volatile Action<Invitation, bool> mInvitationDelegate;

		private volatile GooglePlayGames.BasicApi.Multiplayer.Player mUser;

		private volatile List<GooglePlayGames.BasicApi.Multiplayer.Player> mFriends;

		private volatile Action<bool, string> mPendingAuthCallbacks;

		private volatile AuthState mAuthState;

		private volatile uint mAuthGeneration;

		private volatile bool friendsLoading;

		internal NativeClient(PlayGamesClientConfiguration configuration, IClientImpl clientImpl)
		{
			PlayGamesHelperObject.CreateObject();
			mConfiguration = Misc.CheckNotNull(configuration);
			this.clientImpl = clientImpl;
		}

		private GooglePlayGames.Native.PInvoke.GameServices GameServices()
		{
			lock (GameServicesLock)
			{
				return mServices;
			}
		}

		public void Authenticate(Action<bool, string> callback, bool silent)
		{
			lock (AuthStateLock)
			{
				if (mAuthState == AuthState.Authenticated)
				{
					InvokeCallbackOnGameThread(callback, true, null);
					return;
				}
			}
			friendsLoading = false;
			InitializeTokenClient();
			Debug.Log("Starting Auth with token client.");
			mTokenClient.FetchTokens(silent, delegate(int result)
			{
				bool num = result == 0;
				InitializeGameServices();
				if (num)
				{
					if (callback != null)
					{
						mPendingAuthCallbacks = (Action<bool, string>)Delegate.Combine(mPendingAuthCallbacks, callback);
					}
					GameServices().StartAuthorizationUI();
					LoadAchievements(delegate
					{
					});
				}
				else
				{
					Action<bool, string> callback2 = callback;
					switch (result)
					{
					case 16:
						InvokeCallbackOnGameThread(callback2, false, "Authentication canceled");
						break;
					case 8:
						InvokeCallbackOnGameThread(callback2, false, "Authentication failed - developer error");
						break;
					default:
						InvokeCallbackOnGameThread(callback2, false, "Authentication failed");
						break;
					}
				}
			});
		}

		private static Action<T> AsOnGameThreadCallback<T>(Action<T> callback)
		{
			if (callback == null)
			{
				return delegate
				{
				};
			}
			return delegate(T result)
			{
				InvokeCallbackOnGameThread(callback, result);
			};
		}

		private static void InvokeCallbackOnGameThread<T, S>(Action<T, S> callback, T data, S msg)
		{
			if (callback != null)
			{
				PlayGamesHelperObject.RunOnGameThread(delegate
				{
					GooglePlayGames.OurUtils.Logger.d("Invoking user callback on game thread");
					callback(data, msg);
				});
			}
		}

		private static void InvokeCallbackOnGameThread<T>(Action<T> callback, T data)
		{
			if (callback != null)
			{
				PlayGamesHelperObject.RunOnGameThread(delegate
				{
					GooglePlayGames.OurUtils.Logger.d("Invoking user callback on game thread");
					callback(data);
				});
			}
		}

		private void InitializeGameServices()
		{
			lock (GameServicesLock)
			{
				if (mServices != null)
				{
					return;
				}
				using (GameServicesBuilder gameServicesBuilder = GameServicesBuilder.Create())
				{
					using (PlatformConfiguration configRef = clientImpl.CreatePlatformConfiguration(mConfiguration))
					{
						RegisterInvitationDelegate(mConfiguration.InvitationDelegate);
						gameServicesBuilder.SetOnAuthFinishedCallback(HandleAuthTransition);
						gameServicesBuilder.SetOnTurnBasedMatchEventCallback(delegate(Types.MultiplayerEvent eventType, string matchId, NativeTurnBasedMatch match)
						{
							mTurnBasedClient.HandleMatchEvent(eventType, matchId, match);
						});
						gameServicesBuilder.SetOnMultiplayerInvitationEventCallback(HandleInvitation);
						if (mConfiguration.EnableSavedGames)
						{
							gameServicesBuilder.EnableSnapshots();
						}
						string[] scopes = mConfiguration.Scopes;
						for (int i = 0; i < scopes.Length; i++)
						{
							gameServicesBuilder.AddOauthScope(scopes[i]);
						}
						if (mConfiguration.IsHidingPopups)
						{
							gameServicesBuilder.SetShowConnectingPopup(false);
						}
						Debug.Log("Building GPG services, implicitly attempts silent auth");
						mServices = gameServicesBuilder.Build(configRef);
						mEventsClient = new NativeEventClient(new GooglePlayGames.Native.PInvoke.EventManager(mServices));
						mVideoClient = new NativeVideoClient(new GooglePlayGames.Native.PInvoke.VideoManager(mServices));
						mTurnBasedClient = new NativeTurnBasedMultiplayerClient(this, new TurnBasedManager(mServices));
						mTurnBasedClient.RegisterMatchDelegate(mConfiguration.MatchDelegate);
						mRealTimeClient = new NativeRealtimeMultiplayerClient(this, new RealtimeManager(mServices));
						if (mConfiguration.EnableSavedGames)
						{
							mSavedGameClient = new NativeSavedGameClient(new GooglePlayGames.Native.PInvoke.SnapshotManager(mServices));
						}
						else
						{
							mSavedGameClient = new UnsupportedSavedGamesClient("You must enable saved games before it can be used. See PlayGamesClientConfiguration.Builder.EnableSavedGames.");
						}
						InitializeTokenClient();
					}
				}
			}
		}

		private void InitializeTokenClient()
		{
			if (mTokenClient == null)
			{
				mTokenClient = clientImpl.CreateTokenClient(true);
				if (!GameInfo.WebClientIdInitialized() && (mConfiguration.IsRequestingIdToken || mConfiguration.IsRequestingAuthCode))
				{
					GooglePlayGames.OurUtils.Logger.e("Server Auth Code and ID Token require web clientId to configured.");
				}
				string[] scopes = mConfiguration.Scopes;
				mTokenClient.SetWebClientId("");
				mTokenClient.SetRequestAuthCode(mConfiguration.IsRequestingAuthCode, mConfiguration.IsForcingRefresh);
				mTokenClient.SetRequestEmail(mConfiguration.IsRequestingEmail);
				mTokenClient.SetRequestIdToken(mConfiguration.IsRequestingIdToken);
				mTokenClient.SetHidePopups(mConfiguration.IsHidingPopups);
				mTokenClient.AddOauthScopes("https://www.googleapis.com/auth/games_lite");
				if (mConfiguration.EnableSavedGames)
				{
					mTokenClient.AddOauthScopes("https://www.googleapis.com/auth/drive.appdata");
				}
				mTokenClient.AddOauthScopes(scopes);
				mTokenClient.SetAccountName(mConfiguration.AccountName);
			}
		}

		internal void HandleInvitation(Types.MultiplayerEvent eventType, string invitationId, GooglePlayGames.Native.PInvoke.MultiplayerInvitation invitation)
		{
			Action<Invitation, bool> currentHandler = mInvitationDelegate;
			if (currentHandler == null)
			{
				GooglePlayGames.OurUtils.Logger.d(string.Concat("Received ", eventType, " for invitation ", invitationId, " but no handler was registered."));
			}
			else if (eventType == Types.MultiplayerEvent.REMOVED)
			{
				GooglePlayGames.OurUtils.Logger.d("Ignoring REMOVED for invitation " + invitationId);
			}
			else
			{
				bool shouldAutolaunch = eventType == Types.MultiplayerEvent.UPDATED_FROM_APP_LAUNCH;
				Invitation invite = invitation.AsInvitation();
				PlayGamesHelperObject.RunOnGameThread(delegate
				{
					currentHandler(invite, shouldAutolaunch);
				});
			}
		}

		public string GetUserEmail()
		{
			if (!IsAuthenticated())
			{
				Debug.Log("Cannot get API client - not authenticated");
				return null;
			}
			return mTokenClient.GetEmail();
		}

		public string GetIdToken()
		{
			if (!IsAuthenticated())
			{
				Debug.Log("Cannot get API client - not authenticated");
				return null;
			}
			return mTokenClient.GetIdToken();
		}

		public string GetServerAuthCode()
		{
			if (!IsAuthenticated())
			{
				Debug.Log("Cannot get API client - not authenticated");
				return null;
			}
			return mTokenClient.GetAuthCode();
		}

		public void GetAnotherServerAuthCode(bool reAuthenticateIfNeeded, Action<string> callback)
		{
			mTokenClient.GetAnotherServerAuthCode(reAuthenticateIfNeeded, callback);
		}

		public bool IsAuthenticated()
		{
			lock (AuthStateLock)
			{
				return mAuthState == AuthState.Authenticated;
			}
		}

		public void LoadFriends(Action<bool> callback)
		{
			if (!IsAuthenticated())
			{
				GooglePlayGames.OurUtils.Logger.d("Cannot loadFriends when not authenticated");
				PlayGamesHelperObject.RunOnGameThread(delegate
				{
					callback(false);
				});
				return;
			}
			if (mFriends != null)
			{
				PlayGamesHelperObject.RunOnGameThread(delegate
				{
					callback(true);
				});
				return;
			}
			mServices.PlayerManager().FetchFriends(delegate(ResponseStatus status, List<GooglePlayGames.BasicApi.Multiplayer.Player> players)
			{
				if (status == ResponseStatus.Success || status == ResponseStatus.SuccessWithStale)
				{
					mFriends = players;
					PlayGamesHelperObject.RunOnGameThread(delegate
					{
						callback(true);
					});
				}
				else
				{
					mFriends = new List<GooglePlayGames.BasicApi.Multiplayer.Player>();
					GooglePlayGames.OurUtils.Logger.e(string.Concat("Got ", status, " loading friends"));
					PlayGamesHelperObject.RunOnGameThread(delegate
					{
						callback(false);
					});
				}
			});
		}

		public IUserProfile[] GetFriends()
		{
			if (mFriends == null && !friendsLoading)
			{
				GooglePlayGames.OurUtils.Logger.w("Getting friends before they are loaded!!!");
				friendsLoading = true;
				LoadFriends(delegate(bool ok)
				{
					GooglePlayGames.OurUtils.Logger.d("loading: " + ok.ToString() + " mFriends = " + mFriends);
					if (!ok)
					{
						GooglePlayGames.OurUtils.Logger.e("Friends list did not load successfully.  Disabling loading until re-authenticated");
					}
					friendsLoading = !ok;
				});
			}
			if (mFriends != null)
			{
				return mFriends.ToArray();
			}
			return new IUserProfile[0];
		}

		private void MaybeFinishAuthentication()
		{
			Action<bool, string> action = null;
			lock (AuthStateLock)
			{
				if (mUser == null)
				{
					GooglePlayGames.OurUtils.Logger.d("Auth not finished. User=" + mUser);
					return;
				}
				GooglePlayGames.OurUtils.Logger.d("Auth finished. Proceeding.");
				action = mPendingAuthCallbacks;
				mPendingAuthCallbacks = null;
				mAuthState = AuthState.Authenticated;
			}
			if (action != null)
			{
				GooglePlayGames.OurUtils.Logger.d("Invoking Callbacks: " + action);
				InvokeCallbackOnGameThread(action, true, null);
			}
		}

		private void PopulateUser(uint authGeneration, GooglePlayGames.Native.PInvoke.PlayerManager.FetchSelfResponse response)
		{
			GooglePlayGames.OurUtils.Logger.d("Populating User");
			if (authGeneration != mAuthGeneration)
			{
				GooglePlayGames.OurUtils.Logger.d("Received user callback after signout occurred, ignoring");
				return;
			}
			lock (AuthStateLock)
			{
				if (response.Status() != CommonErrorStatus.ResponseStatus.VALID && response.Status() != CommonErrorStatus.ResponseStatus.VALID_BUT_STALE)
				{
					GooglePlayGames.OurUtils.Logger.e("Error retrieving user, signing out");
					Action<bool, string> action = mPendingAuthCallbacks;
					mPendingAuthCallbacks = null;
					if (action != null)
					{
						InvokeCallbackOnGameThread(action, false, "Cannot load user profile");
					}
					SignOut();
					return;
				}
				mUser = response.Self().AsPlayer();
				mFriends = null;
			}
			GooglePlayGames.OurUtils.Logger.d("Found User: " + mUser);
			GooglePlayGames.OurUtils.Logger.d("Maybe finish for User");
			MaybeFinishAuthentication();
		}

		private void HandleAuthTransition(Types.AuthOperation operation, CommonErrorStatus.AuthStatus status)
		{
			GooglePlayGames.OurUtils.Logger.d(string.Concat("Starting Auth Transition. Op: ", operation, " status: ", status));
			lock (AuthStateLock)
			{
				switch (operation)
				{
				case Types.AuthOperation.SIGN_IN:
					if (status == CommonErrorStatus.AuthStatus.VALID)
					{
						uint currentAuthGeneration = mAuthGeneration;
						mServices.PlayerManager().FetchSelf(delegate(GooglePlayGames.Native.PInvoke.PlayerManager.FetchSelfResponse results)
						{
							PopulateUser(currentAuthGeneration, results);
						});
					}
					else
					{
						mAuthState = AuthState.Unauthenticated;
						GooglePlayGames.OurUtils.Logger.d(string.Concat("AuthState == ", mAuthState, " calling auth callbacks with failure"));
						Action<bool, string> callback = mPendingAuthCallbacks;
						mPendingAuthCallbacks = null;
						InvokeCallbackOnGameThread(callback, false, "Authentication failed");
					}
					break;
				case Types.AuthOperation.SIGN_OUT:
					ToUnauthenticated();
					break;
				default:
					GooglePlayGames.OurUtils.Logger.e("Unknown AuthOperation " + operation);
					break;
				}
			}
		}

		private void ToUnauthenticated()
		{
			lock (AuthStateLock)
			{
				mUser = null;
				mFriends = null;
				mAuthState = AuthState.Unauthenticated;
				mTokenClient = clientImpl.CreateTokenClient(true);
				mAuthGeneration++;
			}
		}

		public void SignOut()
		{
			ToUnauthenticated();
			if (GameServices() != null)
			{
				mTokenClient.Signout();
				GameServices().SignOut();
			}
		}

		public string GetUserId()
		{
			if (mUser == null)
			{
				return null;
			}
			return mUser.id;
		}

		public string GetUserDisplayName()
		{
			if (mUser == null)
			{
				return null;
			}
			return mUser.userName;
		}

		public string GetUserImageUrl()
		{
			if (mUser == null)
			{
				return null;
			}
			return mUser.AvatarURL;
		}

		public void SetGravityForPopups(Gravity gravity)
		{
			PlayGamesHelperObject.RunOnGameThread(delegate
			{
				clientImpl.SetGravityForPopups(GetApiClient(), gravity);
			});
		}

		public void GetPlayerStats(Action<CommonStatusCodes, GooglePlayGames.BasicApi.PlayerStats> callback)
		{
			PlayGamesHelperObject.RunOnGameThread(delegate
			{
				clientImpl.GetPlayerStats(GetApiClient(), callback);
			});
		}

		public void LoadUsers(string[] userIds, Action<IUserProfile[]> callback)
		{
			mServices.PlayerManager().FetchList(userIds, delegate(NativePlayer[] nativeUsers)
			{
				IUserProfile[] users = new IUserProfile[nativeUsers.Length];
				for (int i = 0; i < users.Length; i++)
				{
					users[i] = nativeUsers[i].AsPlayer();
				}
				PlayGamesHelperObject.RunOnGameThread(delegate
				{
					callback(users);
				});
			});
		}

		public void LoadAchievements(Action<GooglePlayGames.BasicApi.Achievement[]> callback)
		{
			callback = AsOnGameThreadCallback(callback);
			if (!IsAuthenticated())
			{
				callback(null);
				return;
			}
			mServices.AchievementManager().FetchAll(delegate(GooglePlayGames.Native.PInvoke.AchievementManager.FetchAllResponse response)
			{
				if (response.Status() != CommonErrorStatus.ResponseStatus.VALID && response.Status() != CommonErrorStatus.ResponseStatus.VALID_BUT_STALE)
				{
					GooglePlayGames.OurUtils.Logger.e("Error retrieving achievements - check the log for more information. ");
					callback(null);
				}
				else
				{
					GooglePlayGames.BasicApi.Achievement[] array = new GooglePlayGames.BasicApi.Achievement[(uint)response.Length()];
					int num = 0;
					foreach (NativeAchievement item in response)
					{
						using (item)
						{
							array[num++] = item.AsAchievement();
						}
					}
					callback(array);
				}
			});
		}

		public void UnlockAchievement(string achId, Action<bool> callback)
		{
			Misc.CheckNotNull(achId);
			callback = AsOnGameThreadCallback(callback);
			InitializeGameServices();
			GameServices().AchievementManager().Unlock(achId);
			callback(true);
		}

		public void RevealAchievement(string achId, Action<bool> callback)
		{
			Misc.CheckNotNull(achId);
			callback = AsOnGameThreadCallback(callback);
			InitializeGameServices();
			GameServices().AchievementManager().Reveal(achId);
			callback(true);
		}

		public void IncrementAchievement(string achId, int steps, Action<bool> callback)
		{
			Misc.CheckNotNull(achId);
			callback = AsOnGameThreadCallback(callback);
			InitializeGameServices();
			if (steps < 0)
			{
				GooglePlayGames.OurUtils.Logger.e("Attempted to increment by negative steps");
				callback(false);
			}
			else
			{
				GameServices().AchievementManager().Increment(achId, Convert.ToUInt32(steps));
				callback(true);
			}
		}

		public void SetStepsAtLeast(string achId, int steps, Action<bool> callback)
		{
			Misc.CheckNotNull(achId);
			callback = AsOnGameThreadCallback(callback);
			InitializeGameServices();
			if (steps < 0)
			{
				GooglePlayGames.OurUtils.Logger.e("Attempted to increment by negative steps");
				callback(false);
			}
			else
			{
				GameServices().AchievementManager().SetStepsAtLeast(achId, Convert.ToUInt32(steps));
				callback(true);
			}
		}

		public void ShowAchievementsUI(Action<UIStatus> cb)
		{
			if (!IsAuthenticated())
			{
				return;
			}
			Action<CommonErrorStatus.UIStatus> callback = Callbacks.NoopUICallback;
			if (cb != null)
			{
				callback = delegate(CommonErrorStatus.UIStatus result)
				{
					cb((UIStatus)result);
				};
			}
			callback = AsOnGameThreadCallback(callback);
			GameServices().AchievementManager().ShowAllUI(callback);
		}

		public int LeaderboardMaxResults()
		{
			return GameServices().LeaderboardManager().LeaderboardMaxResults;
		}

		public void ShowLeaderboardUI(string leaderboardId, LeaderboardTimeSpan span, Action<UIStatus> cb)
		{
			if (!IsAuthenticated())
			{
				return;
			}
			Action<CommonErrorStatus.UIStatus> callback = Callbacks.NoopUICallback;
			if (cb != null)
			{
				callback = delegate(CommonErrorStatus.UIStatus result)
				{
					cb((UIStatus)result);
				};
			}
			callback = AsOnGameThreadCallback(callback);
			if (leaderboardId == null)
			{
				GameServices().LeaderboardManager().ShowAllUI(callback);
			}
			else
			{
				GameServices().LeaderboardManager().ShowUI(leaderboardId, span, callback);
			}
		}

		public void LoadScores(string leaderboardId, LeaderboardStart start, int rowCount, LeaderboardCollection collection, LeaderboardTimeSpan timeSpan, Action<LeaderboardScoreData> callback)
		{
			callback = AsOnGameThreadCallback(callback);
			GameServices().LeaderboardManager().LoadLeaderboardData(leaderboardId, start, rowCount, collection, timeSpan, mUser.id, callback);
		}

		public void LoadMoreScores(ScorePageToken token, int rowCount, Action<LeaderboardScoreData> callback)
		{
			callback = AsOnGameThreadCallback(callback);
			GameServices().LeaderboardManager().LoadScorePage(null, rowCount, token, callback);
		}

		public void SubmitScore(string leaderboardId, long score, Action<bool> callback)
		{
			callback = AsOnGameThreadCallback(callback);
			if (!IsAuthenticated())
			{
				callback(false);
			}
			InitializeGameServices();
			if (leaderboardId == null)
			{
				throw new ArgumentNullException("leaderboardId");
			}
			GameServices().LeaderboardManager().SubmitScore(leaderboardId, score, null);
			callback(true);
		}

		public void SubmitScore(string leaderboardId, long score, string metadata, Action<bool> callback)
		{
			callback = AsOnGameThreadCallback(callback);
			if (!IsAuthenticated())
			{
				callback(false);
			}
			InitializeGameServices();
			if (leaderboardId == null)
			{
				throw new ArgumentNullException("leaderboardId");
			}
			GameServices().LeaderboardManager().SubmitScore(leaderboardId, score, metadata);
			callback(true);
		}

		public IRealTimeMultiplayerClient GetRtmpClient()
		{
			if (!IsAuthenticated())
			{
				return null;
			}
			lock (GameServicesLock)
			{
				return mRealTimeClient;
			}
		}

		public ITurnBasedMultiplayerClient GetTbmpClient()
		{
			lock (GameServicesLock)
			{
				return mTurnBasedClient;
			}
		}

		public ISavedGameClient GetSavedGameClient()
		{
			lock (GameServicesLock)
			{
				return mSavedGameClient;
			}
		}

		public IEventsClient GetEventsClient()
		{
			lock (GameServicesLock)
			{
				return mEventsClient;
			}
		}

		public IVideoClient GetVideoClient()
		{
			lock (GameServicesLock)
			{
				return mVideoClient;
			}
		}

		public void RegisterInvitationDelegate(InvitationReceivedDelegate invitationDelegate)
		{
			if (invitationDelegate == null)
			{
				mInvitationDelegate = null;
				return;
			}
			mInvitationDelegate = Callbacks.AsOnGameThreadCallback(delegate(Invitation invitation, bool autoAccept)
			{
				invitationDelegate(invitation, autoAccept);
			});
		}

		public IntPtr GetApiClient()
		{
			return InternalHooks.InternalHooks_GetApiClient(mServices.AsHandle());
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
