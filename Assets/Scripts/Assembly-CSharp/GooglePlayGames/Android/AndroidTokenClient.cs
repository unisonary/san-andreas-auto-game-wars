using System;
using System.Collections.Generic;
using GooglePlayGames.OurUtils;
using UnityEngine;

namespace GooglePlayGames.Android
{
	internal class AndroidTokenClient : TokenClient
	{
		private class ResultCallbackProxy : AndroidJavaProxy
		{
			private Action<AndroidJavaObject> mCallback;

			public ResultCallbackProxy(Action<AndroidJavaObject> callback)
				: base("com/google/android/gms/common/api/ResultCallback")
			{
				mCallback = callback;
			}

			public void onResult(AndroidJavaObject tokenResult)
			{
				mCallback(tokenResult);
			}
		}

		private const string TokenFragmentClass = "com.google.games.bridge.TokenFragment";

		private bool requestEmail;

		private bool requestAuthCode;

		private bool requestIdToken;

		private List<string> oauthScopes;

		private string webClientId;

		private bool forceRefresh;

		private bool hidePopups;

		private string accountName;

		private string email;

		private string authCode;

		private string idToken;

		public static AndroidJavaObject CreateInvisibleView()
		{
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.google.games.bridge.TokenFragment"))
			{
				return androidJavaClass.CallStatic<AndroidJavaObject>("createInvisibleView", new object[1] { GetActivity() });
			}
		}

		public static AndroidJavaObject GetActivity()
		{
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
			{
				return androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
			}
		}

		public void SetRequestAuthCode(bool flag, bool forceRefresh)
		{
			requestAuthCode = flag;
			this.forceRefresh = forceRefresh;
		}

		public void SetRequestEmail(bool flag)
		{
			requestEmail = flag;
		}

		public void SetRequestIdToken(bool flag)
		{
			requestIdToken = flag;
		}

		public void SetWebClientId(string webClientId)
		{
			this.webClientId = webClientId;
		}

		public void SetHidePopups(bool flag)
		{
			hidePopups = flag;
		}

		public void SetAccountName(string accountName)
		{
			this.accountName = accountName;
		}

		public void AddOauthScopes(params string[] scopes)
		{
			if (scopes != null)
			{
				if (oauthScopes == null)
				{
					oauthScopes = new List<string>();
				}
				oauthScopes.AddRange(scopes);
			}
		}

		public void Signout()
		{
			authCode = null;
			email = null;
			idToken = null;
			PlayGamesHelperObject.RunOnGameThread(delegate
			{
				Debug.Log("Calling Signout in token client");
				new AndroidJavaClass("com.google.games.bridge.TokenFragment").CallStatic("signOut", GetActivity());
			});
		}

		public string GetEmail()
		{
			return email;
		}

		public string GetAuthCode()
		{
			return authCode;
		}

		public string GetIdToken()
		{
			return idToken;
		}

		public void FetchTokens(bool silent, Action<int> callback)
		{
			PlayGamesHelperObject.RunOnGameThread(delegate
			{
				DoFetchToken(silent, callback);
			});
		}

		private void DoFetchToken(bool silent, Action<int> callback)
		{
			try
			{
				using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.google.games.bridge.TokenFragment"))
				{
					using (AndroidJavaObject androidJavaObject = GetActivity())
					{
						using (AndroidJavaObject androidJavaObject2 = androidJavaClass.CallStatic<AndroidJavaObject>("fetchToken", new object[10]
						{
							androidJavaObject,
							silent,
							requestAuthCode,
							requestEmail,
							requestIdToken,
							webClientId,
							forceRefresh,
							oauthScopes.ToArray(),
							hidePopups,
							accountName
						}))
						{
							androidJavaObject2.Call("setResultCallback", new ResultCallbackProxy(delegate(AndroidJavaObject tokenResult)
							{
								authCode = tokenResult.Call<string>("getAuthCode", Array.Empty<object>());
								email = tokenResult.Call<string>("getEmail", Array.Empty<object>());
								idToken = tokenResult.Call<string>("getIdToken", Array.Empty<object>());
								callback(tokenResult.Call<int>("getStatusCode", Array.Empty<object>()));
							}));
						}
					}
				}
			}
			catch (Exception ex)
			{
				GooglePlayGames.OurUtils.Logger.e("Exception launching token request: " + ex.Message);
				GooglePlayGames.OurUtils.Logger.e(ex.ToString());
			}
		}

		public void GetAnotherServerAuthCode(bool reAuthenticateIfNeeded, Action<string> callback)
		{
			PlayGamesHelperObject.RunOnGameThread(delegate
			{
				DoGetAnotherServerAuthCode(reAuthenticateIfNeeded, callback);
			});
		}

		private void DoGetAnotherServerAuthCode(bool reAuthenticateIfNeeded, Action<string> callback)
		{
			try
			{
				using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.google.games.bridge.TokenFragment"))
				{
					using (AndroidJavaObject androidJavaObject = GetActivity())
					{
						using (AndroidJavaObject androidJavaObject2 = androidJavaClass.CallStatic<AndroidJavaObject>("fetchToken", new object[10]
						{
							androidJavaObject,
							!reAuthenticateIfNeeded,
							true,
							requestEmail,
							requestIdToken,
							webClientId,
							false,
							oauthScopes.ToArray(),
							true,
							accountName
						}))
						{
							androidJavaObject2.Call("setResultCallback", new ResultCallbackProxy(delegate(AndroidJavaObject tokenResult)
							{
								callback(tokenResult.Call<string>("getAuthCode", Array.Empty<object>()));
							}));
						}
					}
				}
			}
			catch (Exception ex)
			{
				GooglePlayGames.OurUtils.Logger.e("Exception launching token request: " + ex.Message);
				GooglePlayGames.OurUtils.Logger.e(ex.ToString());
			}
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
