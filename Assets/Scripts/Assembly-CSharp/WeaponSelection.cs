using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelection : MonoBehaviour
{
	private float[] Damage_data = new float[6] { 0.5f, 0.6f, 0.8f, 1f, 0.8f, 0.8f };

	private float[] reload_data = new float[6] { 0.6f, 0.5f, 0.9f, 0.3f, 0.6f, 0.7f };

	private float[] firerate_data = new float[6] { 0.2f, 0.3f, 0.6f, 0.2f, 0.8f, 0.8f };

	private float[] clipsize_data = new float[6] { 0.7f, 0.8f, 0.9f, 0.1f, 0.7f, 0.9f };

	private string[] WeponNames_data = new string[6] { "Benelli B65", "Magnum A61", "Mstringer", "Cannon R81", "Smg D95", "BigShot" };

	public Text[] buyText_Weapons;

	public Text weaponName_txt;

	public GameObject WatchVideo_btn;

	public Button[] watchtoUnlock;

	public Image[] InfoData_txt;

	public GameObject[] gunModels;

	[Header("Audio")]
	public AudioClip[] Sounds_m;

	public AudioSource audioSource;

	private static WeaponSelection _instance;

	[HideInInspector]
	public int SelectedWeapon;

	private int weaponNum;

	public Button PrevButton;

	public Button NextButton;

	public GameObject playBtn;

	public GameObject unlockBtn;

	private int cuurentWatchIndex;

	public static WeaponSelection Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = Object.FindObjectOfType<WeaponSelection>();
			}
			return _instance;
		}
	}

	public void Btn_Sound(int _index)
	{
		audioSource.PlayOneShot(Sounds_m[_index]);
	}

	private void Awake()
	{
		_instance = this;
		base.gameObject.SetActive(false);
	}

	private void numUpdate(float newValue)
	{
		WatchVideo_btn.transform.parent.parent.GetComponent<Image>().fillAmount = newValue;
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			WebViewExit.instance.ShowExit();
		}
	}

	public void NextWeapon()
	{
		buyText_Weapons[weaponNum].transform.parent.parent.gameObject.SetActive(false);
		bool flag = watchtoUnlock[weaponNum] != null;
		iTween.ValueTo(base.gameObject, iTween.Hash("from", 0.98f, "to", 0.01f, "time", 0.2f, "onupdate", "numUpdate"));
		weaponNum++;
		Debug.Log(weaponNum + "next " + buyText_Weapons.Length);
		buyText_Weapons[weaponNum].transform.parent.parent.gameObject.SetActive(true);
		iTween.ScaleTo(watchtoUnlock[weaponNum].gameObject, iTween.Hash("x", 1, "y", 1, "time", 0.2, "delay", 0.7));
		iTween.ValueTo(base.gameObject, iTween.Hash("from", 0, "to", 0.98f, "time", 0.2f, "onupdate", "numUpdate", "delay", 0.5));
		NextButton.interactable = true;
		PrevButton.interactable = true;
		InfoData_txt[0].fillAmount = Damage_data[weaponNum];
		InfoData_txt[1].fillAmount = reload_data[weaponNum];
		InfoData_txt[2].fillAmount = firerate_data[weaponNum];
		InfoData_txt[3].fillAmount = clipsize_data[weaponNum];
		weaponName_txt.text = " " + WeponNames_data[weaponNum];
		if (weaponNum + 1 >= buyText_Weapons.Length)
		{
			NextButton.interactable = false;
		}
		for (int i = 0; i < gunModels.Length; i++)
		{
			gunModels[i].SetActive(false);
		}
		gunModels[weaponNum].SetActive(true);
		Btn_Sound(1);
		if (PlayerPrefs.GetInt(StoreManager.weaponsUnlockSystem[weaponNum]) == 1)
		{
			playBtn.SetActive(true);
			unlockBtn.SetActive(false);
		}
		else
		{
			playBtn.SetActive(false);
			unlockBtn.SetActive(true);
		}
	}

	public void previousWeapon()
	{
		if (weaponNum > 0)
		{
			Debug.Log("WN" + weaponNum);
			Btn_Sound(1);
			buyText_Weapons[weaponNum].transform.parent.parent.gameObject.SetActive(false);
			iTween.ScaleTo(watchtoUnlock[weaponNum].gameObject, iTween.Hash("x", 0, "y", 0, "time", 0.2));
			iTween.ValueTo(base.gameObject, iTween.Hash("from", 0.98f, "to", 0.01f, "time", 0.2f, "onupdate", "numUpdate"));
			weaponNum--;
			buyText_Weapons[weaponNum].transform.parent.parent.gameObject.SetActive(true);
			if (watchtoUnlock[weaponNum] != null)
			{
				iTween.ScaleTo(watchtoUnlock[weaponNum].gameObject, iTween.Hash("x", 1, "y", 1, "time", 0.2, "delay", 0.7));
			}
			iTween.ValueTo(base.gameObject, iTween.Hash("from", 0, "to", 0.98f, "time", 0.2f, "onupdate", "numUpdate", "delay", 0.5));
			InfoData_txt[0].fillAmount = Damage_data[weaponNum];
			InfoData_txt[1].fillAmount = reload_data[weaponNum];
			InfoData_txt[2].fillAmount = firerate_data[weaponNum];
			InfoData_txt[3].fillAmount = clipsize_data[weaponNum];
			weaponName_txt.text = WeponNames_data[weaponNum] ?? "";
			NextButton.interactable = true;
			PrevButton.interactable = true;
			Debug.Log(weaponNum);
			if (weaponNum <= 0)
			{
				PrevButton.interactable = false;
			}
		}
		for (int i = 0; i < gunModels.Length; i++)
		{
			gunModels[i].SetActive(false);
		}
		gunModels[weaponNum].SetActive(true);
		if (PlayerPrefs.GetInt(StoreManager.weaponsUnlockSystem[weaponNum]) == 1)
		{
			playBtn.SetActive(true);
			unlockBtn.SetActive(false);
		}
		else
		{
			playBtn.SetActive(false);
			unlockBtn.SetActive(true);
		}
	}

	public void Open()
	{
		Debug.Log("open...");
		LevelSelectionHandler.CPage = "Ws";
		LevelSelectionHandler.Instance.gunCamera.SetActive(true);
		base.gameObject.SetActive(true);
		PlayerPrefs.SetInt(StoreManager.weaponsUnlockSystem[0], 1);
		setUpDetails();
		BackButton.CloseCurrentPopupEvent += Close;
		if ((bool)AdManager.instance)
		{
			MonoBehaviour.print("call add ingame nawaz " + LevelSelectionHandler.CurrentLevel);
			AdManager.instance.RunActions(AdManager.PageType.Upgrade);
		}
	}

	public void Start_Open()
	{
		setUpDetails();
	}

	public void setUpDetails()
	{
		for (int i = 0; i < buyText_Weapons.Length; i++)
		{
			Debug.Log(i + " ::  : " + PlayerPrefs.GetInt(StoreManager.weaponsUnlockSystem[i]));
			if (PlayerPrefs.GetInt(StoreManager.weaponsUnlockSystem[i]) == 0)
			{
				buyText_Weapons[i].text = string.Concat(StoreManager.weaponPrice[i]);
				Debug.Log("++++++Set price");
				if (watchtoUnlock[i] != null)
				{
					watchtoUnlock[i].gameObject.GetComponentInChildren<Text>().text = "Watch " + (StoreManager.VideoCounts[i] - PlayerPrefs.GetInt(StoreManager.VideoKeys[i])) + " Videos to Unlock";
				}
				continue;
			}
			if (i == PlayerPrefs.GetInt(StoreManager.selectedWeaponIndex))
			{
				buyText_Weapons[i].text = "EQUIPPED";
				buyText_Weapons[i].transform.parent.gameObject.SetActive(false);
			}
			else
			{
				buyText_Weapons[i].text = "USE";
				playBtn.SetActive(true);
				unlockBtn.SetActive(false);
			}
			if (watchtoUnlock[i] != null)
			{
				watchtoUnlock[i].gameObject.SetActive(false);
			}
		}
		if (PlayerPrefs.GetString("weaponsunlocked") == "true")
		{
			StorePopup.Instance._btnStores[1].color = StorePopup.Instance._mycolor;
			StorePopup.Instance._btnStores[1].transform.parent.gameObject.GetComponent<Image>().color = StorePopup.Instance._mycolor;
		}
	}

	public void Close()
	{
		LevelSelectionHandler.Instance.gunCamera.SetActive(false);
		Btn_Sound(0);
		base.gameObject.SetActive(false);
		LevelSelectionHandler.Instance.MissionSelection.SetActive(true);
		BackButton.CloseCurrentPopupEvent -= Close;
		if ((bool)AdManager.instance)
		{
			MonoBehaviour.print("call add ingame nawaz " + LevelSelectionHandler.CurrentLevel);
			AdManager.instance.RunActions(AdManager.PageType.LvlSelection, LevelSelectionHandler.CurrentLevel);
		}
	}

	public void SelectWeapon(int Index)
	{
		Btn_Sound(0);
		SelectedWeapon = Index;
		Debug.Log("WeaponSelected Index::" + Index);
		int @int = PlayerPrefs.GetInt(StoreManager.KEY_COINS);
		if (PlayerPrefs.GetInt(StoreManager.weaponsUnlockSystem[Index]) == 1)
		{
			StoreManager.oldWeaponIndex = PlayerPrefs.GetInt(StoreManager.selectedWeaponIndex, 0);
			PlayerPrefs.SetInt(StoreManager.selectedWeaponIndex, Index);
			setUpDetails();
			buyText_Weapons[Index].text = "";
			buyText_Weapons[Index].transform.parent.gameObject.SetActive(false);
			playBtn.SetActive(true);
			unlockBtn.SetActive(false);
			Debug.Log("SelWepn" + PlayerPrefs.GetInt(StoreManager.selectedWeaponIndex));
		}
		else if (@int > StoreManager.weaponPrice[Index])
		{
			LevelSelectionHandler.Instance.updateCoinsText();
			PlayerPrefs.SetInt(StoreManager.weaponsUnlockSystem[Index], 1);
			StoreManager.oldWeaponIndex = PlayerPrefs.GetInt(StoreManager.selectedWeaponIndex, 0);
			PlayerPrefs.SetInt(StoreManager.selectedWeaponIndex, Index);
			setUpDetails();
			buyText_Weapons[Index].text = "";
			buyText_Weapons[Index].transform.parent.gameObject.SetActive(false);
			playBtn.SetActive(true);
			unlockBtn.SetActive(false);
			@int -= StoreManager.weaponPrice[Index];
			StoreManager.DeductCoins(StoreManager.weaponPrice[Index]);
		}
		else
		{
			MonoBehaviour.print("no Cash........");
			AdManager.instance.BuyItem(1, true);
		}
	}

	public void sharetounlock(int Index)
	{
		Debug.Log("share to unlock");
		StartCoroutine(AfterShare(Index));
	}

	private IEnumerator AfterShare(int Index)
	{
		yield return new WaitForSeconds(2f);
		Debug.Log("share to unlock---");
		PlayerPrefs.SetInt(StoreManager.weaponsUnlockSystem[Index], 1);
		StoreManager.oldWeaponIndex = PlayerPrefs.GetInt(StoreManager.selectedWeaponIndex, 0);
		PlayerPrefs.SetInt(StoreManager.selectedWeaponIndex, Index);
		setUpDetails();
		buyText_Weapons[Index].text = "";
		buyText_Weapons[Index].transform.parent.gameObject.SetActive(false);
	}

	public void SelectToWatchVideo(int Index)
	{
		cuurentWatchIndex = Index;
		Btn_Sound(0);
	}

	public void checkVideoUnlockButtons()
	{
		PlayerPrefs.SetInt(StoreManager.VideoKeys[cuurentWatchIndex], PlayerPrefs.GetInt(StoreManager.VideoKeys[cuurentWatchIndex], 0) + 1);
		watchtoUnlock[cuurentWatchIndex].GetComponentInChildren<Text>().text = "Watch " + (StoreManager.VideoCounts[cuurentWatchIndex] - PlayerPrefs.GetInt(StoreManager.VideoKeys[cuurentWatchIndex])) + " Videos to Unlock";
		if (PlayerPrefs.GetInt(StoreManager.VideoKeys[cuurentWatchIndex]) >= StoreManager.VideoCounts[cuurentWatchIndex])
		{
			PlayerPrefs.SetInt(StoreManager.weaponsUnlockSystem[cuurentWatchIndex], 1);
			StoreManager.oldWeaponIndex = PlayerPrefs.GetInt(StoreManager.selectedWeaponIndex, 0);
			PlayerPrefs.SetInt(StoreManager.selectedWeaponIndex, cuurentWatchIndex);
			setUpDetails();
			buyText_Weapons[cuurentWatchIndex].text = "";
			buyText_Weapons[cuurentWatchIndex].transform.parent.gameObject.SetActive(false);
		}
		Debug.Log("vunlock...");
		Btn_Sound(0);
	}

	public void WatchEarn()
	{
		Btn_Sound(0);
	}

	public void purchaseWeapon(int WeaponIdex)
	{
		Btn_Sound(0);
		MonoBehaviour.print("weapon purchase : " + WeaponIdex + " : " + StoreManager.weaponPrice[WeaponIdex - 1]);
		int @int = PlayerPrefs.GetInt(StoreManager.KEY_COINS);
		if (@int > StoreManager.weaponPrice[WeaponIdex - 1])
		{
			@int -= StoreManager.weaponPrice[WeaponIdex - 1];
			StoreManager.DeductCoins(StoreManager.weaponPrice[WeaponIdex - 1]);
			StoreManager.oldWeaponIndex = PlayerPrefs.GetInt(StoreManager.selectedWeaponIndex, 0);
			PlayerPrefs.SetInt(StoreManager.selectedWeaponIndex, WeaponIdex);
		}
		else
		{
			MonoBehaviour.print("no Cash........");
			StorePopup.Instance.Open();
		}
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
