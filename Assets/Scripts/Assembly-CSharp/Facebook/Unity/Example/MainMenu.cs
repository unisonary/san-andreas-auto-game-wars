using System.Collections.Generic;
using UnityEngine;

namespace Facebook.Unity.Example
{
	internal sealed class MainMenu : MenuBase
	{
		protected override bool ShowBackButton()
		{
			return false;
		}

		protected override void GetGui()
		{
			GUILayout.BeginVertical();
			bool flag = GUI.enabled;
			if (Button("FB.Init"))
			{
				FB.Init(OnInitComplete, OnHideUnity);
				base.Status = "FB.Init() called with " + FB.AppId;
			}
			GUILayout.BeginHorizontal();
			GUI.enabled = flag && FB.IsInitialized;
			if (Button("Login"))
			{
				CallFBLogin();
				base.Status = "Login called";
			}
			GUI.enabled = FB.IsLoggedIn;
			if (Button("Get publish_actions"))
			{
				CallFBLoginForPublish();
				base.Status = "Login (for publish_actions) called";
			}
			GUILayout.Label(GUIContent.none, GUILayout.MinWidth(ConsoleBase.MarginFix));
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal();
			GUILayout.Label(GUIContent.none, GUILayout.MinWidth(ConsoleBase.MarginFix));
			GUILayout.EndHorizontal();
			if (Button("Logout"))
			{
				CallFBLogout();
				base.Status = "Logout called";
			}
			GUI.enabled = flag && FB.IsInitialized;
			if (Button("Share Dialog"))
			{
				SwitchMenu(typeof(DialogShare));
			}
			if (Button("App Requests"))
			{
				SwitchMenu(typeof(AppRequests));
			}
			if (Button("Graph Request"))
			{
				SwitchMenu(typeof(GraphRequest));
			}
			if (Constants.IsWeb && Button("Pay"))
			{
				SwitchMenu(typeof(Pay));
			}
			if (Button("App Events"))
			{
				SwitchMenu(typeof(AppEvents));
			}
			if (Button("App Links"))
			{
				SwitchMenu(typeof(AppLinks));
			}
			if (Constants.IsMobile && Button("App Invites"))
			{
				SwitchMenu(typeof(AppInvites));
			}
			if (Constants.IsMobile && Button("Access Token"))
			{
				SwitchMenu(typeof(AccessTokenMenu));
			}
			GUILayout.EndVertical();
			GUI.enabled = flag;
		}

		private void CallFBLogin()
		{
			FB.LogInWithReadPermissions(new List<string> { "public_profile", "email", "user_friends" }, base.HandleResult);
		}

		private void CallFBLoginForPublish()
		{
			FB.LogInWithPublishPermissions(new List<string> { "publish_actions" }, base.HandleResult);
		}

		private void CallFBLogout()
		{
			FB.LogOut();
		}

		private void OnInitComplete()
		{
			base.Status = "Success - Check log for details";
			base.LastResponse = "Success Response: OnInitComplete Called\n";
			LogView.AddLog(string.Format("OnInitCompleteCalled IsLoggedIn='{0}' IsInitialized='{1}'", FB.IsLoggedIn, FB.IsInitialized));
			if (AccessToken.CurrentAccessToken != null)
			{
				LogView.AddLog(AccessToken.CurrentAccessToken.ToString());
			}
		}

		private void OnHideUnity(bool isGameShown)
		{
			base.Status = "Success - Check log for details";
			base.LastResponse = string.Format("Success Response: OnHideUnity Called {0}\n", isGameShown);
			LogView.AddLog("Is game shown: " + isGameShown);
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
