using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectionHandler : MonoBehaviour
{
	private static LevelSelectionHandler _instance;

	public GameObject content;

	private soundmanager _soundmanager;

	public GameObject[] freeModeBtns;

	public Image MyBg;

	public Button[] AllLevels_obj;

	public GameObject MissionSelection;

	public Text CurrentBalance;

	public static int CurrentLevel = 0;

	public Button[] NavButtons;

	public Color[] MyColors;

	private float val = 150f;

	public GameObject[] movefrom_obj;

	public GameObject[] scalefrom_obj;

	[Header("Audio")]
	public AudioClip[] Sounds_m;

	public AudioSource audioSource;

	public GameObject gunCamera;

	public static string CPage = "lselection";

	public Text freemode_txt;

	private int Free_mNum = 4;

	private float _fillamount = 1f;

	private int showingtill = 1;

	private int MaxLevelNum = 1;

	public static LevelSelectionHandler Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = Object.FindObjectOfType<LevelSelectionHandler>();
			}
			return _instance;
		}
	}

	private void OnEnable()
	{
		float num = 0.8f;
		GameObject[] array = movefrom_obj;
		foreach (GameObject gameObject in array)
		{
			if (gameObject != null)
			{
				iTween.MoveFrom(gameObject, iTween.Hash("y", gameObject.transform.position.y + val, "time", 0.5f, "delay", num));
			}
			num += 0.5f;
		}
		num = 1f;
		array = scalefrom_obj;
		for (int i = 0; i < array.Length; i++)
		{
			iTween.ScaleFrom(array[i], iTween.Hash("Scale", Vector3.zero, "time", 1f, "delay", num));
			num += 0.2f;
		}
		Invoke("SetContent", 0.1f);
	}

	private void SetContent()
	{
		Debug.Log("+++Set");
		content.transform.localPosition = new Vector3(content.transform.localPosition.x - (float)(PlayerPrefs.GetInt("selectedLevel") * 500), content.transform.localPosition.y, content.transform.localPosition.z);
	}

	public void Btn_Sound(int _index)
	{
		audioSource.PlayOneShot(Sounds_m[_index]);
	}

	private void Awake()
	{
		updateCoinsText();
	}

	private void Start()
	{
		Debug.Log("$$$$$$$$$$$$ selected level" + PlayerPrefs.GetInt("selectedLevel"));
		Debug.Log("levelselection...");
		setLevelDetails();
		if (MaxLevelNum >= 4)
		{
			showingtill = 5;
		}
		if (MaxLevelNum >= 8)
		{
			showingtill = 9;
		}
		if (MaxLevelNum >= 12)
		{
			showingtill = 13;
		}
		if (MaxLevelNum >= 16)
		{
			showingtill = 17;
		}
		Invoke("levelsin", 1.5f);
		if (!MenuPageHandler.menusoundplaying)
		{
			if ((bool)soundmanager.mee)
			{
				soundmanager.mee.EnableBg_sound();
			}
			MenuPageHandler.menusoundplaying = true;
			Debug.Log("$$$$$$$$playSound");
		}
		if (!PlayerPrefs.HasKey("freemode"))
		{
			PlayerPrefs.SetInt("freemode", Free_mNum);
		}
		MissionSelection.SetActive(false);
		gunCamera.SetActive(true);
		WeaponSelection.Instance.Open();
		CPage = "Ws";
		_soundmanager = Object.FindObjectOfType<soundmanager>();
	}

	public void WatchEarn()
	{
	}

	public void Start_open()
	{
		CPage = "Ls";
		Debug.Log("levelselection...");
		setLevelDetails();
		if (!MenuPageHandler.menusoundplaying)
		{
			soundmanager.mee.EnableBg_sound();
			MenuPageHandler.menusoundplaying = true;
		}
	}

	public void WatchFremodeVideo()
	{
	}

	private void enable_btns()
	{
	}

	public void setFreemodeDetails()
	{
		Debug.Log("free mode " + PlayerPrefs.GetInt("freemode"));
		if (PlayerPrefs.GetInt("freemode") <= 1)
		{
			Invoke("enable_btns", 0.5f);
		}
		int num = PlayerPrefs.GetInt("freemode") - 1;
		freemode_txt.text = "Watch " + num + " Videos";
	}

	private void Update()
	{
		if (_fillamount > 0f)
		{
			_fillamount -= 0.01f;
			MyBg.fillAmount = _fillamount;
		}
		Input.GetKeyDown(KeyCode.Escape);
	}

	public void NextLevels()
	{
		levelsOut();
	}

	public void levelsin()
	{
		MonoBehaviour.print(showingtill + " --num " + (showingtill - 1));
		NavButtons[0].interactable = true;
		NavButtons[1].interactable = true;
		if (AllLevels_obj.Length <= showingtill + 3)
		{
			NavButtons[0].interactable = false;
		}
		else if (showingtill <= 1)
		{
			NavButtons[1].interactable = false;
		}
		int num = 1;
		for (int i = showingtill - 1; i < showingtill + 3; i++)
		{
			Debug.Log(AllLevels_obj[i]);
			num++;
		}
	}

	public void levelsOut()
	{
		Btn_Sound(1);
		MonoBehaviour.print(showingtill + " num ");
		int num = 1;
		for (int i = showingtill - 1; i < showingtill + 3; i++)
		{
			Debug.Log(AllLevels_obj[i]);
			num++;
		}
		showingtill += 4;
		Invoke("levelsin", 0.6f);
	}

	public void levelsOutPrev()
	{
		Btn_Sound(1);
		MonoBehaviour.print(showingtill + " num ");
		int num = 1;
		for (int i = showingtill - 1; i < showingtill + 3; i++)
		{
			Debug.Log(AllLevels_obj[i]);
			num++;
		}
		showingtill -= 4;
		Invoke("levelsin", 0.6f);
	}

	public void watchVideo_unlockLevel(int _clevel)
	{
	}

	public void updateCoinsText()
	{
		CurrentBalance.text = PlayerPrefs.GetInt(StoreManager.KEY_COINS, 0).ToString();
	}

	public void setLevelDetails()
	{
		for (int i = 0; i < AllLevels_obj.Length; i++)
		{
			if (!PlayerPrefs.HasKey("levelvideo" + i))
			{
				PlayerPrefs.SetInt("levelvideo" + i, i + 1);
				PlayerPrefs.SetInt("levelsUnlocked" + i, 0);
				PlayerPrefs.SetInt("levelsUnlocked" + 0, 1);
				if (i >= 9)
				{
					PlayerPrefs.SetInt("levelvideo" + i, 9);
				}
			}
			if (PlayerPrefs.GetInt("levelvideo" + i) <= 0)
			{
				PlayerPrefs.SetInt("levelsUnlocked" + i, 1);
			}
			if (PlayerPrefs.GetInt("levelsUnlocked" + i) == 0)
			{
				AllLevels_obj[i].GetComponentInChildren<Image>().enabled = true;
				AllLevels_obj[i].transform.GetChild(2).gameObject.SetActive(true);
			}
			else
			{
				AllLevels_obj[i].transform.GetChild(3).GetComponent<Image>().enabled = false;
				AllLevels_obj[i].interactable = true;
				MaxLevelNum = i;
			}
		}
		Debug.Log("max level " + MaxLevelNum);
		bool flag = PlayerPrefs.GetString("levelUnlocked") == "true";
	}

	public void LevelOpener(int index)
	{
		if (PlayerPrefs.GetInt("levelsUnlocked" + (index - 1)) == 1)
		{
			CurrentLevel = index;
			PlayerPrefs.SetInt("selectedLevel", CurrentLevel);
			Debug.Log("$$$$$$$$$$$$ selected level" + PlayerPrefs.GetInt("selectedLevel"));
			GoToGame();
			soundmanager.mee.DisableBg_sound();
			if (index != 50)
			{
				Btn_Sound(0);
			}
			else
			{
				PlayerPrefs.SetInt("freemode", Free_mNum);
			}
		}
		else
		{
			MonoBehaviour.print("unlock");
			AdManager.instance.BuyItem(2, true);
		}
	}

	public void Back()
	{
		Btn_Sound(0);
		if (WeaponSelection.Instance.gameObject.activeSelf)
		{
			if ((bool)_soundmanager)
			{
				Object.Destroy(_soundmanager.gameObject);
			}
			SceneManager.LoadScene("Menu");
		}
		else if (MissionSelection.activeSelf)
		{
			MissionSelection.SetActive(false);
			WeaponSelection.Instance.Open();
		}
		else
		{
			if ((bool)_soundmanager)
			{
				Object.Destroy(_soundmanager.gameObject);
			}
			SceneManager.LoadScene("Menu");
		}
	}

	public void OpenStore()
	{
		Btn_Sound(0);
		MenuPageHandler.lastOpenPage = "LevelSelection";
		Application.LoadLevel("Store");
	}

	public void WatchAndEarn()
	{
		Btn_Sound(0);
		Debug.Log("Watch video And Earn 200 Coins :: LevelSelection ");
	}

	private void GoToGame()
	{
		LoadingManager.SceneName = "MainGameNew";
		SceneManager.LoadScene("Loading");
	}

	public void GoToPlayArea()
	{
		MissionSelection.SetActive(true);
		WeaponSelection.Instance.Close();
		gunCamera.SetActive(false);
		Btn_Sound(1);
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
