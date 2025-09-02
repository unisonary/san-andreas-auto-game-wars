using UnityEngine;

public class HelpIngame : MonoBehaviour
{
	public GameObject CurrentHelp;

	public GameObject CarHelp;

	private void Start()
	{
	}

	public void ShowcarHelp()
	{
		CurrentHelp.SetActive(false);
		CurrentHelp = CarHelp;
		CurrentHelp.SetActive(true);
	}

	public void NextBtn(GameObject _nextObj = null)
	{
		CurrentHelp.SetActive(false);
		if (_nextObj != CurrentHelp)
		{
			_nextObj.SetActive(true);
			CurrentHelp = _nextObj;
		}
		else
		{
			Leveldata.mee._helpObj.SetActive(false);
			LevelManager.mee.Inpopup = false;
			Leveldata.startGame = true;
		}
		Debug.Log("CurrentHelp " + CurrentHelp);
	}

	private void callLCAd()
	{
	}

	public void SkipBtn()
	{
		PlayerPrefs.SetString("firsttimeGettingIna", "true");
		base.gameObject.SetActive(false);
		LevelManager.mee.Inpopup = false;
		Leveldata.startGame = true;
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
