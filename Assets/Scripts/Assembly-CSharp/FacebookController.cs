using System;
using System.Collections.Generic;
using Facebook.Unity;
using UnityEngine;

public class FacebookController : MonoBehaviour
{
	private List<string> perms = new List<string> { "public_profile", "email" };

	public static FacebookController instance;

	private void Awake()
	{
		instance = this;
		if (!FB.IsInitialized)
		{
			Debug.Log("------- FB not initialized call Init");
			FB.Init(InitCallback, OnHideUnity);
		}
		else
		{
			Debug.Log("------- FB already initialized call activate app");
			FB.ActivateApp();
		}
	}

	private void InitCallback()
	{
		Debug.Log("------ InitCallback");
		if (FB.IsInitialized)
		{
			Debug.Log("------- FB initialized successfully");
			FB.ActivateApp();
		}
		else
		{
			Debug.Log("Failed to Initialize the Facebook SDK");
		}
	}

	private void OnHideUnity(bool isGameShown)
	{
		Debug.Log("OnHideUnity isGameShown=" + isGameShown);
	}

	public void FBLogIn()
	{
		if (!FB.IsLoggedIn)
		{
			FB.LogInWithReadPermissions(perms, AuthCallback);
		}
		else
		{
			FBLogOut();
		}
	}

	public void FBLogOut()
	{
		FB.LogOut();
	}

	private void AuthCallback(ILoginResult result)
	{
		if (FB.IsLoggedIn)
		{
			Debug.Log("------ FB login successfull");
			AccessToken currentAccessToken = AccessToken.CurrentAccessToken;
			Debug.Log(currentAccessToken.UserId);
			{
				foreach (string permission in currentAccessToken.Permissions)
				{
					Debug.Log(permission);
				}
				return;
			}
		}
		Debug.Log("User cancelled login");
	}

	public void FBShare()
	{
		FB.ShareLink(new Uri(AdManager.instance.ShareUrl), "", "", null, ShareCallback);
	}

	private void ShareCallback(IShareResult result)
	{
		if (result.Cancelled || !string.IsNullOrEmpty(result.Error))
		{
			Debug.Log("ShareLink Error: " + result.Error);
		}
		else if (!string.IsNullOrEmpty(result.PostId))
		{
			Debug.Log("ShareLink Error 222: " + result.PostId);
			Debug.Log(result.PostId);
		}
		else
		{
			Debug.Log("-------- ShareLink success!");
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
