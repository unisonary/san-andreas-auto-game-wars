using System.Collections.Generic;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;

public class PlayServicesController : MonoBehaviour
{
	private bool mAuthenticating;

	public static PlayServicesController instance;

	public List<int> UnlockAchievementsInLvls;

	private string[] AchievementIds = new string[10];

	public bool IsCheckedSignIn;

	private void Awake()
	{
		instance = this;
		IsCheckedSignIn = false;
	}

	private void Start()
	{
		PlayGamesClientConfiguration configuration = new PlayGamesClientConfiguration.Builder().Build();
		PlayGamesPlatform.DebugLogEnabled = true;
		PlayGamesPlatform.InitializeInstance(configuration);
		PlayGamesPlatform.Activate();
		((PlayGamesPlatform)Social.Active).SetDefaultLeaderboardForUI("CgkIhYjvm_MJEAIQAA");
		Debug.Log("---------- play services authenticated=" + PlayGamesPlatform.Instance.localUser.authenticated);
		AchievementIds[0] = "CgkIhYjvm_MJEAIQAQ";
		AchievementIds[1] = "CgkIhYjvm_MJEAIQAg";
		AchievementIds[2] = "CgkIhYjvm_MJEAIQAw";
		AchievementIds[3] = "CgkIhYjvm_MJEAIQBA";
		AchievementIds[4] = "CgkIhYjvm_MJEAIQBQ";
	}

	public void CheckAutoSignIn()
	{
		if (!IsCheckedSignIn)
		{
			Debug.Log("----------------CheckAutoSignIn 111111");
			if (PlayerPrefs.GetString("IsGoogleAuthenticate", "false") == "false")
			{
				Debug.Log("----------------CheckAutoSignIn 222222222");
				SignIn();
			}
			else
			{
				Debug.Log("----------------CheckAutoSignIn 333333");
				Debug.Log("------------ Google Authenticating in background");
				PlayGamesPlatform.Instance.Authenticate(SignInCallback, true);
			}
			IsCheckedSignIn = true;
		}
	}

	public void SignIn()
	{
		Debug.Log("----------- playservices 111111111");
		if (!PlayGamesPlatform.Instance.localUser.authenticated)
		{
			Debug.Log("----------- playservices 222222222");
			PlayGamesPlatform.Instance.Authenticate(SignInCallback, false);
		}
	}

	public void SignInCallback(bool success)
	{
		if (success)
		{
			Debug.Log(" Signed in!");
			PlayerPrefs.SetString("IsGoogleAuthenticate", "true");
		}
		else
		{
			Debug.Log("(Lollygagger) Sign-in failed...");
		}
	}

	public void ShowLeaderBoards()
	{
		Debug.Log("ShowLeaderBoards called");
		if (PlayGamesPlatform.Instance.localUser.authenticated)
		{
			Debug.Log("ShowLeaderBoards UI called instance=" + PlayGamesPlatform.Instance);
			PlayGamesPlatform.Instance.ShowLeaderboardUI();
		}
		else
		{
			SignIn();
			Debug.Log("Cannot show leaderboard: not authenticated");
		}
	}

	public void ShowAchievements()
	{
		Debug.Log("ShowAchievements called");
		if (PlayGamesPlatform.Instance.localUser.authenticated)
		{
			Debug.Log("ShowAchievements UI called=" + PlayGamesPlatform.Instance);
			PlayGamesPlatform.Instance.ShowAchievementsUI();
		}
		else
		{
			SignIn();
			Debug.Log("Cannot show Achievements, not logged in");
		}
	}

	public void Check_UnlockAchievement(int LvlNo)
	{
		Debug.Log("--------------- CheckUnlockAchievement 1111 lvlno=" + LvlNo);
		if (!UnlockAchievementsInLvls.Contains(LvlNo))
		{
			return;
		}
		int num = UnlockAchievementsInLvls.IndexOf(LvlNo);
		Debug.Log("--------------- CheckUnlockAchievement 22222222 indx=" + num);
		if (Social.localUser.authenticated)
		{
			PlayGamesPlatform.Instance.ReportProgress(AchievementIds[num], 100.0, delegate(bool success)
			{
				Debug.Log("Achievement unlocked" + success);
			});
		}
	}

	public void SubmitScoreToLB(int score)
	{
		if (PlayGamesPlatform.Instance.localUser.authenticated)
		{
			PlayGamesPlatform.Instance.ReportScore(score, "CgkIhYjvm_MJEAIQAA", delegate(bool success)
			{
				Debug.Log("Score submitted to LB" + success);
			});
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
