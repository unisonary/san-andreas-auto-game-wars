using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour
{
	private static LevelComplete _instance;

	public Text CurrentBalance;

	public Image MoreGamesImage;

	public Text Missionreward_txt;

	public Text Cashcollected_txt;

	public GameObject[] movefrom_obj;

	public GameObject[] movefrom_obj2;

	public GameObject[] scalefrom_obj;

	public GameObject BGMusic;

	public GameObject lC;

	public GameObject UnlockWeaponPop;

	private bool checkOnce = true;

	public string NextPop = "null";

	public static LevelComplete Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = Object.FindObjectOfType<LevelComplete>();
			}
			return _instance;
		}
	}

	private void OnEnable()
	{
		lC.SetActive(true);
		float num = 0.8f;
		GameObject[] array = movefrom_obj;
		foreach (GameObject gameObject in array)
		{
			if (gameObject != null)
			{
				iTween.MoveFrom(gameObject, iTween.Hash("y", gameObject.transform.position.y + 550f, "time", 0.2f, "delay", num, "easetype", iTween.EaseType.easeOutCubic));
			}
			num += 0.1f;
		}
		num = 1f;
		array = scalefrom_obj;
		for (int i = 0; i < array.Length; i++)
		{
			iTween.ScaleFrom(array[i], iTween.Hash("Scale", Vector3.zero, "time", 0.5f, "delay", num));
			num += 0.2f;
		}
		num = 1.5f;
		array = movefrom_obj2;
		foreach (GameObject gameObject2 in array)
		{
			if (gameObject2 != null)
			{
				iTween.MoveFrom(gameObject2, iTween.Hash("y", gameObject2.transform.position.y - 550f, "time", 0.5f, "delay", num, "easetype", iTween.EaseType.easeOutCubic));
			}
			num += 0.1f;
		}
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
			AdManager.instance.RunActions(AdManager.PageType.LC, LevelSelectionHandler.CurrentLevel);
		}
	}

	public void Open()
	{
		if ((bool)BGMusic)
		{
			BGMusic.GetComponent<AudioSource>().enabled = false;
		}
		Invoke("ShowAd", 0.2f);
		base.gameObject.SetActive(true);
		SetUpDetails();
		Debug.Log(LevelSelectionHandler.CurrentLevel + " : " + PlayerPrefs.GetInt("levelsUnlocked" + LevelSelectionHandler.CurrentLevel));
		if (PlayerPrefs.GetInt("levelsUnlocked" + LevelSelectionHandler.CurrentLevel) == 0)
		{
			PlayerPrefs.SetInt("levelsUnlocked" + LevelSelectionHandler.CurrentLevel, 1);
		}
		Invoke("ShowRateShare", 0.5f);
	}

	private void ShowRateShare()
	{
		ContinueNext();
	}

	private void callLCAd()
	{
	}

	public void UnlockAllGuns()
	{
		MonoBehaviour.print("guns");
	}

	public void updateCoins()
	{
		CurrentBalance.text = PlayerPrefs.GetInt(StoreManager.KEY_COINS, 0).ToString();
	}

	private void SetUpDetails()
	{
		Missionreward_txt.text = string.Concat(Leveldata.mee.Levelrewards);
		StoreManager.AddCoins(Leveldata.mee.Levelrewards);
		CurrentBalance.text = PlayerPrefs.GetInt(StoreManager.KEY_COINS, 0).ToString();
		Cashcollected_txt.text = PlayerPrefs.GetInt(StoreManager.KEY_COINS, 0).ToString();
		Leveldata._cashcollected = 0;
	}

	public void Close()
	{
		if (!(BackButton.CurrentPopup != base.gameObject))
		{
			LevelManager.mee.Btn_Sound(0);
			base.gameObject.SetActive(false);
			BackButton.Instance.Remove();
			BackButton.CloseCurrentPopupEvent -= Close;
		}
	}

	public void Retry()
	{
		NextPop = "retry";
		ShowRateShare();
		LevelManager.mee.Btn_Sound(1);
	}

	public void Next()
	{
		NextPop = "next";
		ShowRateShare();
		LevelManager.mee.Btn_Sound(1);
	}

	public void Home()
	{
		NextPop = "home";
		ShowRateShare();
		LevelManager.mee.Btn_Sound(0);
	}

	public void ContinueNext()
	{
		switch (NextPop)
		{
		case "next":
			SceneManager.LoadScene("LevelSelection");
			break;
		case "home":
			SceneManager.LoadScene("Menu");
			break;
		case "retry":
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			break;
		}
	}

	public void FShare()
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
