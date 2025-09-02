using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCompleteSample : MonoBehaviour
{
	public static LevelCompleteSample instance;

	public GameObject PopUp;

	public Text CoinsTxt;

	private int LvlCompleteCoins = 1000;

	public GameObject DoubleRewardBtn;

	public int score = 1000;

	private void Awake()
	{
		instance = this;
		base.gameObject.SetActive(false);
	}

	public void Open()
	{
		base.gameObject.SetActive(true);
		CoinsTxt.text = "Reward:" + LvlCompleteCoins;
		PopUp.transform.localPosition = Vector3.zero;
		iTween.MoveFrom(PopUp, iTween.Hash("y", 1000, "time", 0.4f, "islocal", true, "easetype", iTween.EaseType.spring));
		AdManager.instance.RunActions(AdManager.PageType.LC, InGameSample.CurrentLvl, score);
	}

	public void Close()
	{
		SceneManager.LoadScene("MenuSample");
	}

	public void RetryBtnClick()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void NextBtnClick()
	{
		InGameSample.CurrentLvl++;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void WatchVideoDoubleReward()
	{
		AdManager.instance.ShowRewardVideoWithCallback(delegate
		{
			LvlCompleteCoins *= 2;
			CoinsTxt.text = "Reward:" + LvlCompleteCoins;
			Debug.Log("------ Menu Watched video successfully");
		});
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
