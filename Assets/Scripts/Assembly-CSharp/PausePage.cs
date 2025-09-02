using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePage : MonoBehaviour
{
	private void Start()
	{
	}

	public void Retry()
	{
		Time.timeScale = 1f;
		base.gameObject.SetActive(false);
		LoadingManager.SceneName = "MainGameNew";
		SceneManager.LoadScene("Loading");
		LevelManager.mee.Btn_Sound(1);
	}

	public void Home()
	{
		Time.timeScale = 1f;
		LevelManager.mee.Btn_Sound(1);
		SceneManager.LoadScene("Menu");
	}

	public void Resume()
	{
		Time.timeScale = 1f;
		base.gameObject.SetActive(false);
	}

	public void EarnCoins()
	{
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
