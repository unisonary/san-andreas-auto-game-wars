using UnityEngine;

public class GamePlayHandler : MonoBehaviour
{
	private static GamePlayHandler _instance;

	public static GamePlayHandler Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = Object.FindObjectOfType<GamePlayHandler>();
			}
			return _instance;
		}
	}

	public void WatchAndEarn()
	{
		LevelManager.mee.Btn_Sound(0);
		Debug.Log("Watch video And Earn 200 Coins :: InGame ");
	}

	public void LevelCompleteMoreGamesImage()
	{
		LevelManager.mee.Btn_Sound(0);
		Debug.Log("Level Complete More Games Clicked");
		AdManager.instance.ShowMoreGames();
	}

	public void LevelFailMoreGamesImage()
	{
		LevelManager.mee.Btn_Sound(0);
		Debug.Log("Level Fail More Games Clicked");
		AdManager.instance.ShowMoreGames();
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
