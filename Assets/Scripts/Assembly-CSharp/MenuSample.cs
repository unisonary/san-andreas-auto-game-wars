using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSample : MonoBehaviour
{
	public Text CoinsTxt;

	private void Start()
	{
		CoinsTxt.text = "Coins:" + PlayerPrefs.GetInt("MyCoins", 100);
		AdManager.instance.RunActions(AdManager.PageType.Menu);
	}

	public void PlayClick()
	{
		Debug.Log("PlayClick");
		SceneManager.LoadScene("LevelSelectionSample");
	}

	public void WatchVideo()
	{
		Debug.Log("---- MenuWatchVideo Click");
		AdManager.instance.ShowRewardVideoWithCallback(delegate(bool result)
		{
			if (result)
			{
				int @int = PlayerPrefs.GetInt("MyCoins", 100);
				@int += 1000;
				PlayerPrefs.SetInt("MyCoins", @int);
				CoinsTxt.text = "Coins:" + @int;
				Debug.Log("------ Menu Watched video successfully");
				CoinsAddedPopUp.instance.Open(1000, AdManager.RewardDescType.WatchVideo);
			}
		});
	}

	public void LBClick()
	{
		AdManager.instance.ShowLeaderBoards();
	}

	public void ACHClick()
	{
		AdManager.instance.ShowAchievements();
	}

	public void MoreGamesClick()
	{
		AdManager.instance.ShowMoreGames();
	}

	public void FBLoginClick()
	{
		FacebookController.instance.FBLogIn();
	}

	public void FBShareClick()
	{
		FacebookController.instance.FBShare();
	}

	public void SubmitScore()
	{
		AdManager.instance.SubmitScore(1000);
	}

	public void ShowAd()
	{
		AdManager.instance.ShowAd();
	}

	public void ShowRewardVideoAd()
	{
		AdManager.instance.ShowRewardVideo();
	}

	public void ValidateIronSource()
	{
	}

	public void LoadIronSourceAd()
	{
		AdController.instance.LoadIronSourceInterstitial();
	}

	public void ShowIronSourceAd()
	{
		AdController.instance.ShowIronSourceInterstitial();
	}

	public void ShowIronSourceVideoAd()
	{
		AdController.instance.ShowIronSourceRewardVideo();
	}

	public void AdsCheckButtonClick()
	{
		SceneManager.LoadScene("AdsCheckPage");
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
