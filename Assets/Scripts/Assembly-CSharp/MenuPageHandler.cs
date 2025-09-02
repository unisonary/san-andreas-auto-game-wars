using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPageHandler : MonoBehaviour
{
	private static MenuPageHandler _instance;

	public static bool isSignIn;

	public static string lastOpenPage;

	public Text coinsText;

	public GameObject SettingPanel;

	public GameObject storePanel;

	private float val = -150f;

	public GameObject[] movefrom_obj;

	public GameObject[] scalefrom_obj;

	[Header("Audio")]
	public AudioClip[] Sounds_m;

	public AudioSource audioSource;

	public static bool menusoundplaying;

	public Text shareCoinTxt;

	private bool soundStatus = true;

	public static MenuPageHandler Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = Object.FindObjectOfType<MenuPageHandler>();
			}
			return _instance;
		}
	}

	private void Awake()
	{
		Screen.sleepTimeout = -1;
		lastOpenPage = "Menu";
		if (!PlayerPrefs.HasKey(StoreManager.freeResumesPurchased))
		{
			PlayerPrefs.SetString(StoreManager.freeResumesPurchased, "false");
		}
		SettingPanel.SetActive(false);
		storePanel.SetActive(false);
		if ((bool)AdManager.instance)
		{
			MonoBehaviour.print("call add ingame nawaz " + 1);
			AdManager.instance.RunActions(AdManager.PageType.Menu);
		}
		bool isSignIn2 = isSignIn;
	}

	private void Update()
	{
		Input.GetKeyDown(KeyCode.Escape);
		coinsText.text = PlayerPrefs.GetInt(StoreManager.KEY_COINS).ToString();
	}

	public void unlockLevels()
	{
		for (int i = 1; i < 20; i++)
		{
			PlayerPrefs.SetInt("levelsUnlocked" + i, 0);
		}
		for (int j = 1; j < 5; j++)
		{
			PlayerPrefs.SetInt(StoreManager.weaponsUnlockSystem[j], 1);
		}
	}

	private void OnEnable()
	{
		float num = 0f;
		GameObject[] array = scalefrom_obj;
		for (int i = 0; i < array.Length; i++)
		{
			iTween.ScaleFrom(array[i], iTween.Hash("Scale", Vector3.zero, "time", 1f, "delay", num));
			num += 0.5f;
		}
		num = 0.8f;
		array = movefrom_obj;
		foreach (GameObject gameObject in array)
		{
			if (gameObject != null)
			{
				iTween.MoveFrom(gameObject, iTween.Hash("y", gameObject.transform.position.y + val, "time", 1f, "delay", num, "easetype", iTween.EaseType.easeOutElastic));
			}
			num += 0.1f;
		}
		Invoke("loopit", 2f);
		if (!menusoundplaying)
		{
			menusoundplaying = true;
		}
	}

	private void loopit()
	{
	}

	private void LoadPlay()
	{
		SceneManager.LoadScene("LevelSelection");
	}

	public void Play()
	{
		Btn_Sound(1);
		Invoke("LoadPlay", 0.3f);
	}

	public void OpenRate()
	{
		Btn_Sound(0);
	}

	public void Openshare()
	{
		Btn_Sound(0);
	}

	public void OpenMoreGames()
	{
		Debug.Log("MoreGames Clicked");
		Btn_Sound(0);
		Application.OpenURL("market://search?q=pub:Zippy Games");
	}

	public void RateUs()
	{
		Application.OpenURL("market://details?id=com.zippygames.gangwarsofsanandreas");
	}

	public void GotoMoreGames()
	{
		Debug.Log("MoreGames Clicked");
		AdManager.instance.ShowMoreGames();
	}

	private void OpenSettings()
	{
		SettingPanel.SetActive(true);
	}

	public void GotoSettings()
	{
		Invoke("OpenSettings", 0.3f);
	}

	private void OpenStore()
	{
		Application.LoadLevel("Store");
	}

	public void GotoStore()
	{
		Invoke("OpenStore", 0.3f);
	}

	public void closePopups()
	{
		SettingPanel.SetActive(false);
		storePanel.SetActive(false);
	}

	public void showAch()
	{
		MonoBehaviour.print("showAch");
		AdManager.instance.ShowAchievements();
	}

	public void showLeaderBoard()
	{
		MonoBehaviour.print("showLB");
		AdManager.instance.ShowLeaderBoards();
	}

	public void Btn_Sound(int _index)
	{
		audioSource.PlayOneShot(Sounds_m[_index]);
	}

	public void WatchAndEarn()
	{
		Debug.Log("Watch video And Earn 200 Coins :: Menu ");
		Btn_Sound(0);
	}

	public void OpenTermsOfUse()
	{
		Application.OpenURL("http://www.yesgamesstudio.com/terms-of-use/");
	}

	public void OpenPrivacyPolicy()
	{
		Application.OpenURL("http://www.yesgamesstudio.com/privacy-policy/");
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
