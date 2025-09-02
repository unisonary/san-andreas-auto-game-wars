using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradeSample : MonoBehaviour
{
	public static UpgradeSample instance;

	public Text CoinsTxt;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		CoinsTxt.text = "Coins:" + PlayerPrefs.GetInt("MyCoins", 100);
		AdManager.instance.RunActions(AdManager.PageType.Upgrade);
	}

	public void BackClick()
	{
		SceneManager.LoadScene("LevelSelectionSample");
	}

	public void CarClick(int lvlIndex)
	{
		SceneManager.LoadScene("InGameSample");
	}

	public void UnlockAllClick()
	{
	}

	public void StoreClick()
	{
		StoreSample.instance.Open();
	}

	public void WatchVideo()
	{
		AdManager.instance.ShowRewardVideo();
	}

	public void AddCoins(int value)
	{
		int @int = PlayerPrefs.GetInt("MyCoins", 100);
		@int += value;
		PlayerPrefs.SetInt("MyCoins", @int);
		CoinsTxt.text = "Coins:" + @int;
		Debug.Log("------ Menu Watched video successfully");
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
