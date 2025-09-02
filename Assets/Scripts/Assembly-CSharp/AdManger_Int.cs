using UnityEngine;
using UnityEngine.UI;

public class AdManger_Int : MonoBehaviour
{
	public static AdManger_Int myScript;

	public string PackageNameForRate;

	private int LevelCount;

	public float GPAuthDelay;

	public string[] StoreItemString;

	public float LCInternelDelay;

	public float LFInternelDelay;

	private int coinVal;

	private int ScoreToPush;

	private void Awake()
	{
		myScript = this;
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void GP_SignIn()
	{
	}

	public void CheckSignInTexture(string bb = "null")
	{
		bool flag = bb != "null";
	}

	public void GP_Authentication()
	{
		if (!PlayerPrefs.HasKey("PlayingForFirstTime"))
		{
			PlayerPrefs.SetInt("PlayingForFirstTime", 1);
		}
	}

	public void GP_AutoSignIn()
	{
		MonoBehaviour.print("This is On GP_Authentication");
	}

	private void HandleauthenticationFailedEvent(string obj)
	{
		Debug.Log("Authentication failed :: " + obj);
	}

	private void OnDisable()
	{
		bool flag = Application.loadedLevelName == "MenuScene";
		MonoBehaviour.print("This is On Disable");
	}

	private void HandleauthenticationSucceededEvent(string obj)
	{
		CheckSignInTexture();
	}

	public void Check_GP_Texture()
	{
	}

	public void Menu_Ad_INT(int CurrentLevel)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			LevelCount = CurrentLevel;
		}
	}

	public void InGame_Ad_INT(int CurrentLevel)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			LevelCount = CurrentLevel;
		}
	}

	public void LC_Ad_INT(int CurrentLevel)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			LevelCount = CurrentLevel;
		}
	}

	private void LC_Delay_Ad_INT()
	{
		RuntimePlatform platform = Application.platform;
		int num = 11;
	}

	public void LF_Ad_INT(int CurrentLevel)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			LevelCount = CurrentLevel;
		}
	}

	private void LF_Delay_Ad_INT()
	{
		RuntimePlatform platform = Application.platform;
		int num = 11;
	}

	public void Rate_INT()
	{
		Application.OpenURL("market://details?id=" + PackageNameForRate);
	}

	public void Share_INT()
	{
	}

	public void Show_Lb()
	{
	}

	public void Show_Ach()
	{
	}

	public void Show_MoreGames()
	{
	}

	public void GetStorePrices(Text[] BuyPrices)
	{
		for (int i = 0; i < BuyPrices.Length; i++)
		{
		}
	}

	public void StoreBtnEvent(int BtnCount)
	{
		Debug.Log("store index " + BtnCount);
	}

	public void InApp1_Succes()
	{
	}

	public void InApp2_Succes()
	{
		PlayerPrefs.SetInt(GlobalVariables.sTotalUnlockedLevels, GlobalVariables.iTotalLevels);
	}

	public void InApp3_Succes()
	{
		PlayerPrefs.SetInt(GlobalVariables.sTotalTrainsUnlocked, GlobalVariables.iTotalTrainsAvalaiable);
	}

	public void InApp4_Succes()
	{
		PlayerPrefs.SetInt(GlobalVariables.sTotalUnlockedLevels, GlobalVariables.iTotalLevels);
		PlayerPrefs.SetInt(GlobalVariables.sTotalTrainsUnlocked, GlobalVariables.iTotalTrainsAvalaiable);
	}

	public void OnConsumableSuccess(int consumableID)
	{
		Debug.LogError("Arj kept check inapp------");
		switch (consumableID)
		{
		case 0:
			coinVal = GlobalVariables.iCoinsForMiniPack;
			break;
		case 1:
			coinVal = GlobalVariables.iCoinsForBoosterPack;
			break;
		case 2:
			coinVal = GlobalVariables.iCoinsForSuperPack;
			break;
		case 3:
			coinVal = GlobalVariables.iCoinsForProPack;
			break;
		case 4:
			coinVal = GlobalVariables.iCoinsForMegaPack;
			break;
		case 5:
			coinVal = GlobalVariables.iCoinsForUltraPack;
			break;
		}
		if (coinVal > 0)
		{
			coinVal += PlayerPrefs.GetInt(GlobalVariables.sTotalCoinsAvaliable);
			PlayerPrefs.SetInt(GlobalVariables.sTotalCoinsAvaliable, coinVal);
		}
	}

	public void Check_Achievements(int AchievementID)
	{
	}

	public void LB_ScorePush(int Score)
	{
		ScoreToPush = Score;
		Invoke("PushScore", 1f);
	}

	private void PushScore()
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
