using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelFail : MonoBehaviour
{
	private static LevelFail _instance;

	public Text CurrentBalance;

	public Image MoreGamesImage;

	[HideInInspector]
	public int CurrentLevelNumber = 1;

	public GameObject[] movefrom_obj;

	public GameObject[] movefrom_obj2;

	public GameObject[] scalefrom_obj;

	public GameObject lF;

	public static LevelFail Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = Object.FindObjectOfType<LevelFail>();
			}
			return _instance;
		}
	}

	private void OnEnable()
	{
		lF.SetActive(true);
		float num = 0.8f;
		GameObject[] array = movefrom_obj;
		foreach (GameObject gameObject in array)
		{
			if (gameObject != null)
			{
				iTween.MoveFrom(gameObject, iTween.Hash("y", gameObject.transform.position.y + 550f, "time", 0.2f, "delay", num));
			}
			num += 0.2f;
		}
		num = 1f;
		array = scalefrom_obj;
		for (int i = 0; i < array.Length; i++)
		{
			iTween.ScaleFrom(array[i], iTween.Hash("Scale", Vector3.zero, "time", 1f, "delay", num));
			num += 0.2f;
		}
		num = 1.5f;
		array = movefrom_obj2;
		foreach (GameObject gameObject2 in array)
		{
			if (gameObject2 != null)
			{
				iTween.MoveFrom(gameObject2, iTween.Hash("y", gameObject2.transform.position.y - 550f, "time", 0.5f, "delay", num));
			}
			num += 0.5f;
		}
	}

	public void updateCoins()
	{
		CurrentBalance.text = PlayerPrefs.GetInt(StoreManager.KEY_COINS, 0).ToString();
	}

	private void Awake()
	{
		_instance = this;
		base.gameObject.SetActive(false);
	}

	private void ShowAd()
	{
		if ((bool)AdManager.instance)
		{
			MonoBehaviour.print("call add ingame nawaz " + LevelSelectionHandler.CurrentLevel);
			AdManager.instance.RunActions(AdManager.PageType.LF, LevelSelectionHandler.CurrentLevel);
		}
	}

	public void Open()
	{
		Invoke("ShowAd", 0.2f);
		LevelManager.mee.Bg_Sound(2);
		base.gameObject.SetActive(true);
		SetUpDetails();
	}

	private void callLFAd()
	{
	}

	private void SetUpDetails()
	{
		CurrentBalance.text = PlayerPrefs.GetInt(StoreManager.KEY_COINS, 0).ToString();
	}

	public void Close()
	{
		LevelManager.mee.Btn_Sound(1);
		base.gameObject.SetActive(false);
	}

	public void WatchVideoToResume()
	{
		LevelManager.mee.Btn_Sound(0);
		Debug.Log("Watch video To Resume with Full Health");
		LevelManager.mee.Btn_Sound(1);
		LoadingManager.SceneName = "MainGameNew";
		SceneManager.LoadScene("Loading");
	}

	public void GoToHome()
	{
		LevelManager.mee.Btn_Sound(1);
		SceneManager.LoadScene("Menu");
	}

	public void UnlockAllLevels()
	{
		MonoBehaviour.print("levels");
	}

	public void GoToLevelSelection()
	{
		LevelManager.mee.Btn_Sound(1);
		LoadingManager.SceneName = "LevelSelection";
		SceneManager.LoadScene("Loading");
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
