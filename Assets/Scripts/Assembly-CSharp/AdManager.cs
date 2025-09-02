using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class AdManager : MonoBehaviour
{
	public enum GameCategory
	{
		Driving = 0,
		Simulation = 1,
		Action = 2,
		Racing = 3,
		Casual = 4,
		Tapping = 5,
		Match3 = 6,
		Other = 7
	}

	public enum PageType
	{
		Menu = 0,
		LvlSelection = 1,
		Upgrade = 2,
		InGame = 3,
		LC = 4,
		LF = 5,
		PreLF = 6
	}

	public enum RewardType
	{
		WelcomeGift = 0,
		Coins = 1,
		DoubleCoins = 2,
		Resume = 3,
		WatchVideoAgain = 4
	}

	public enum RewardDescType
	{
		WelcomeGift = 0,
		WatchVideo = 1,
		Sharing = 2,
		Rating = 3,
		Notification = 4,
		Other = 5
	}

	public delegate void RewardVideoCallback(bool rewarded);

	public GameObject Loading;

	public GameCategory Game_Category;

	public float menuAdDelay = 1f;

	public string AllCommonUrl = "https://s3-us-west-2.amazonaws.com/ads2018/allcomman.xml";

	public List<int> RatingPopInLevels = new List<int>();

	public List<int> SharingPopInLevels = new List<int>();

	public string ShareUrl = "http://upon.in/eurotrainsimulatortimuz/fb";

	private bool IsMenuAdOpened;

	private bool IsUpgradeShownInMenu;

	private float PopUpDelayTime = 1f;

	private int PageNavigateCount;

	private int SessionCount;

	private int AdIndexAtRAdsList;

	private int AdIndexAtVideoRAdsList;

	[Header("Edit Below Variables Ony If Mandatory")]
	public int WelcomeGiftReward;

	public int RewardToWatchAnotherVideo;

	public string RateDesc;

	public string ShareDesc;

	public int[] AdInPages = new int[6] { 1, 0, 0, 4, 0, 6 };

	public List<int> RotationAdsList = new List<int> { 1, 2, 3 };

	public List<int> RotationVideoAdsList = new List<int> { 1, 2, 3 };

	public int AdDelay = 90;

	public float LcAdDelay;

	public float LfAdDelay;

	public float PreLfAdDelay;

	public float LsAdDelay;

	public float UpgradeAdDelay;

	public List<int> DiscountPopInMenu = new List<int> { 2, 3 };

	public int[] UnlockPopIn_UP_LS = new int[2] { 2, 3 };

	public int RateCoins;

	public int ShareCoins;

	public int VideoRewardCoins;

	public RewardType VideoRewardType;

	public int VideoRewardPriority;

	public float LastAdShownTime;

	public Sprite menuAdImg;

	public string MenuAdImgLink;

	public string MenuAdLinkTo;

	public string MgLink;

	public string ExitLink;

	public bool IsMenuLoaded;

	public bool IsOpenUpgradeDiscountFrmPush;

	public bool IsOpenLevelDiscountFrmPush;

	public string MenuAdUrl = "";

	public List<Sprite> MgImgList = new List<Sprite>();

	public List<string> MgImgLinkList = new List<string>();

	public List<string> MgLinkToList = new List<string>();

	private static string _sUpgradeUnlocked = "UpgradeUnlockedA";

	private static string _sLevelsUnlocked = "LevelsUnlockedA";

	public static AdManager instance;

	public RewardVideoCallback RewardSuccessEvent;

	private bool isPopUpOpened;

	private int RotationAdCheckCount;

	private int RotationVideoAdCheckCount;

	public static int UpgradeUnlocked
	{
		get
		{
			return PlayerPrefs.GetInt(_sUpgradeUnlocked, 0);
		}
		set
		{
			PlayerPrefs.SetInt(_sUpgradeUnlocked, value);
		}
	}

	public static int LevelsUnlocked
	{
		get
		{
			return PlayerPrefs.GetInt(_sLevelsUnlocked, 0);
		}
		set
		{
			PlayerPrefs.SetInt(_sLevelsUnlocked, value);
		}
	}

	private void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void OnDisable()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	private void Awake()
	{
		Screen.sleepTimeout = -1;
		instance = this;
		LastAdShownTime = -AdDelay;
		switch (Game_Category)
		{
		case GameCategory.Driving:
			MenuAdUrl = "https://zippygames.s3-us-west-1.amazonaws.com/catergoryxmls/Driving.xml";
			break;
		case GameCategory.Simulation:
			MenuAdUrl = "https://zippygames.s3-us-west-1.amazonaws.com/catergoryxmls/Simulation.xml";
			break;
		case GameCategory.Action:
			MenuAdUrl = "https://zippygames.s3-us-west-1.amazonaws.com/catergoryxmls/Action.xml";
			break;
		case GameCategory.Racing:
			MenuAdUrl = "https://zippygames.s3-us-west-1.amazonaws.com/catergoryxmls/Racing.xml";
			break;
		case GameCategory.Casual:
			MenuAdUrl = "https://zippygames.s3-us-west-1.amazonaws.com/catergoryxmls/Casual.xml";
			break;
		case GameCategory.Tapping:
			MenuAdUrl = "https://zippygames.s3-us-west-1.amazonaws.com/catergoryxmls/Tapping.xml";
			break;
		case GameCategory.Match3:
			MenuAdUrl = "https://zippygames.s3-us-west-1.amazonaws.com/catergoryxmls/Match3.xml";
			break;
		case GameCategory.Other:
			MenuAdUrl = "https://zippygames.s3-us-west-1.amazonaws.com/catergoryxmls/Innovative.xml";
			break;
		}
		Debug.Log("Menu Url" + MenuAdUrl);
	}

	private void Start()
	{
		Loading.SetActive(true);
		LoadFirstScene();
		SessionCount = PlayerPrefs.GetInt("SessionCount", 0);
		PlayerPrefs.SetInt("SessionCount", SessionCount + 1);
		base.gameObject.name = "AdManager";
		SetInitialAdIndex();
	}

	public void SetInitialAdIndex()
	{
		Debug.Log("---- SetInitialAdIndex");
		AdIndexAtRAdsList = -1;
		AdIndexAtVideoRAdsList = -1;
		RotationAdCheckCount = 0;
		setNextInterstitialAdIndex();
		RotationVideoAdCheckCount = 0;
		setNextVideoAdIndex();
	}

	public void RunActions(PageType CurrentPage, int LvlNo = 1, int score = 0)
	{
		Debug.Log("----- RunActions pageType=" + CurrentPage);
		switch (CurrentPage)
		{
		case PageType.Menu:
			PlayServicesController.instance.CheckAutoSignIn();
			if (IsOpenLevelDiscountFrmPush)
			{
				CheckLevelsInAppPopUp(CurrentPage);
			}
			else
			{
				CheckUpgradeInAppPopUp(CurrentPage);
			}
			if (AdInPages[1] == 2 || AdInPages[2] == 3)
			{
				RequestAd();
			}
			RequestRewardVideo();
			break;
		case PageType.LvlSelection:
			RequestRewardVideo();
			CheckLevelsInAppPopUp(CurrentPage);
			if (AdInPages[1] == 2)
			{
				Invoke("ShowAd", LsAdDelay);
			}
			break;
		case PageType.Upgrade:
			RequestRewardVideo();
			CheckUpgradeInAppPopUp(CurrentPage);
			if (AdInPages[2] == 3)
			{
				Invoke("ShowAd", LsAdDelay);
			}
			break;
		case PageType.InGame:
			RequestRewardVideo();
			if (AdInPages[3] == 4 || AdInPages[4] == 5 || AdInPages[5] == 6)
			{
				RequestAd();
			}
			break;
		case PageType.LC:
			isPopUpOpened = CheckAndDisplayPopUp(LvlNo);
			if (AdInPages[3] == 4)
			{
				Invoke("ShowAd", LcAdDelay);
			}
			PlayServicesController.instance.Check_UnlockAchievement(LvlNo);
			if (score > 0)
			{
				SubmitScore(score);
			}
			break;
		case PageType.PreLF:
			if (AdInPages[4] == 5)
			{
				Invoke("ShowAd", PreLfAdDelay);
			}
			break;
		case PageType.LF:
			if (AdInPages[5] == 6)
			{
				Invoke("ShowAd", LfAdDelay);
			}
			break;
		}
	}

	private void RequestAd()
	{
		Debug.Log("-------Gameconcontroller RequestAd");
		if (PlayerPrefs.GetString("NoAds", "false") == "true")
		{
			Debug.Log("----NoAds purchased so returning..");
		}
		else if (isWifi_OR_Data_Availble())
		{
			CancelInvoke("RequestAdWithDelay");
			if (Time.time < LastAdShownTime + (float)AdDelay)
			{
				Invoke("RequestAdWithDelay", (LastAdShownTime + (float)AdDelay - Time.time) * 0.5f);
			}
			else
			{
				RequestAdWithDelay();
			}
			Debug.Log("------- Request Ad IsEnableUnityInterstitial=" + AdController.instance.IsEnableUnityInterstital);
		}
	}

	private void RequestAdWithDelay()
	{
		if (RotationAdsList.Count >= 2 && RotationAdsList[1] != 0 && RotationAdsList[AdIndexAtRAdsList] == 2)
		{
			AdController.instance.RequestAdmobInterstitial();
		}
		if (RotationAdsList.Count >= 1 && RotationAdsList[0] != 0 && RotationAdsList[AdIndexAtRAdsList] == 1)
		{
			AdController.instance.LoadIronSourceInterstitial();
		}
		for (int i = 0; i < RotationAdsList.Count; i++)
		{
			if (RotationAdsList[i] == 3)
			{
				AdController.instance.IsEnableUnityInterstital = true;
				break;
			}
		}
		Debug.Log("------- Request Ad IsEnableUnityInterstitial=" + AdController.instance.IsEnableUnityInterstital);
	}

	private void RequestRewardVideo()
	{
		for (int i = 0; i < RotationVideoAdsList.Count; i++)
		{
			if (RotationVideoAdsList[i] == 2)
			{
				AdController.instance.RequestAdmobRewardBasedVideo();
			}
		}
		for (int j = 0; j < RotationVideoAdsList.Count; j++)
		{
			if (RotationVideoAdsList[j] == 3)
			{
				AdController.instance.IsEnableUnityReward = true;
				break;
			}
			Debug.Log("------- Request Ad IsEnableUnityReward=" + AdController.instance.IsEnableUnityReward);
		}
	}

	public void ShowAd()
	{
		Debug.Log("------------ Show Ad ----------- AdIndexAtRAdsList=" + AdIndexAtRAdsList);
		if (PlayerPrefs.GetString("NoAds", "false") == "true")
		{
			Debug.Log("----NoAds purchased so returning..");
			return;
		}
		Debug.Log("ShowAd time=" + Time.time + "ReqTime To AdDisplay=" + (LastAdShownTime + (float)AdDelay) + ":::Adindex=" + AdIndexAtRAdsList + ":::AdType=" + RotationAdsList[AdIndexAtRAdsList] + ":::count=" + RotationAdsList.Count);
		if (AdIndexAtRAdsList >= 0 && RotationAdsList.Count > 0 && Time.time >= LastAdShownTime + (float)AdDelay)
		{
			if (RotationAdsList[AdIndexAtRAdsList] == 1)
			{
				Debug.Log("----- Show Iron source Interstitial Ad");
				AdController.instance.ShowIronSourceInterstitial();
			}
			else if (RotationAdsList[AdIndexAtRAdsList] == 2)
			{
				Debug.Log("----- Show Admobe Interstitial Ad");
				AdController.instance.ShowAdmobInterstitial();
			}
			else if (RotationAdsList[AdIndexAtRAdsList] == 3)
			{
				Debug.Log("----- Show Unity interstitial Ad");
				AdController.instance.ShowUnityAd();
			}
			else
			{
				Debug.LogError("----------- Ads Not Activated");
			}
			LastAdShownTime = Time.time;
			RotationAdCheckCount = 0;
			setNextInterstitialAdIndex();
		}
		else
		{
			Debug.LogError("------- Wait for addelay or Ads Not Activated");
		}
	}

	private void setNextInterstitialAdIndex()
	{
		RotationAdCheckCount++;
		AdIndexAtRAdsList++;
		if (AdIndexAtRAdsList >= RotationAdsList.Count)
		{
			AdIndexAtRAdsList = 0;
		}
		if (RotationAdsList[AdIndexAtRAdsList] == 0 && RotationAdCheckCount < 3)
		{
			setNextInterstitialAdIndex();
		}
	}

	private void setNextVideoAdIndex()
	{
		RotationVideoAdCheckCount++;
		AdIndexAtVideoRAdsList++;
		if (AdIndexAtVideoRAdsList >= RotationVideoAdsList.Count)
		{
			AdIndexAtVideoRAdsList = 0;
		}
		if (RotationVideoAdsList[AdIndexAtVideoRAdsList] == 0 && RotationVideoAdCheckCount < 3)
		{
			setNextVideoAdIndex();
		}
	}

	public void ShowRewardVideo(int coins = 1000, RewardType type = RewardType.Coins)
	{
		Debug.Log("------------ ShowRewardVideo Ad ----------- AdIndexAtVideoRAdsList=" + AdIndexAtVideoRAdsList);
		VideoRewardCoins = coins;
		VideoRewardType = type;
		if (AdIndexAtVideoRAdsList >= 0 && RotationVideoAdsList.Count > 0)
		{
			if (RotationVideoAdsList[AdIndexAtVideoRAdsList] == 1)
			{
				Debug.Log("-------- Show Iron Source reward based video");
				AdController.instance.ShowIronSourceRewardVideo();
			}
			else if (RotationVideoAdsList[AdIndexAtVideoRAdsList] == 2)
			{
				Debug.Log("-------- Show Admob reward based video");
				AdController.instance.ShowAdmobRewardBasedVideo();
			}
			else if (RotationVideoAdsList[AdIndexAtVideoRAdsList] == 3)
			{
				Debug.Log("-------- Show Unity reward based video");
				AdController.instance.ShowUnityRewardedVideoAd();
			}
			RotationVideoAdCheckCount = 0;
			setNextVideoAdIndex();
		}
	}

	public void ShowRewardVideoWithCallback(RewardVideoCallback SuccessCallback)
	{
		Debug.Log("------------ ShowRewardVideoWithCallback Ad ----------- AdIndexAtVideoRAdsList=" + AdIndexAtVideoRAdsList);
		RewardSuccessEvent = SuccessCallback;
		if (AdIndexAtVideoRAdsList >= 0 && RotationVideoAdsList.Count > 0)
		{
			if (RotationVideoAdsList[AdIndexAtVideoRAdsList] == 1)
			{
				Debug.Log("-------- Show Iron Source reward based video");
				AdController.instance.ShowIronSourceRewardVideo();
			}
			else if (RotationVideoAdsList[AdIndexAtVideoRAdsList] == 2)
			{
				Debug.Log("-------- Show Admob reward based video");
				AdController.instance.ShowAdmobRewardBasedVideo();
			}
			else if (RotationVideoAdsList[AdIndexAtVideoRAdsList] == 3)
			{
				Debug.Log("-------- Show Unity reward based video");
				AdController.instance.ShowUnityRewardedVideoAd();
			}
			RotationVideoAdCheckCount = 0;
			setNextVideoAdIndex();
		}
	}

	public void VideoWatchedSuccessfully(bool isRewarded = true)
	{
		if (RewardSuccessEvent != null)
		{
			RewardSuccessEvent(isRewarded);
			RewardSuccessEvent = null;
		}
		else
		{
			CallbacksController.instance.VideoRewardCallback(isRewarded);
		}
	}

	private void CheckUpgradeInAppPopUp(PageType CurrentPage)
	{
		if (!isWifi_OR_Data_Availble() || UpgradeUnlocked == 1)
		{
			return;
		}
		SessionCount = PlayerPrefs.GetInt("SessionCount", 1);
		switch (CurrentPage)
		{
		case PageType.Menu:
			if (IsUpgradeShownInMenu)
			{
				return;
			}
			PageNavigateCount = PlayerPrefs.GetInt("MenuPageNavigationCount", 0);
			PageNavigateCount++;
			PlayerPrefs.SetInt("MenuPageNavigationCount", PageNavigateCount);
			if (IsOpenUpgradeDiscountFrmPush || (DiscountPopInMenu.Count > 0 && DiscountPopInMenu.Contains(SessionCount)))
			{
				UpgradesInAppPage.instance.IsShowDiscountPop = true;
				UpgradesInAppPage.instance.Open();
				IsUpgradeShownInMenu = true;
				if (IsOpenUpgradeDiscountFrmPush)
				{
					IsOpenUpgradeDiscountFrmPush = false;
				}
			}
			break;
		case PageType.Upgrade:
			PageNavigateCount = PlayerPrefs.GetInt("UpgradePageNavigationCount", 0);
			PageNavigateCount++;
			PlayerPrefs.SetInt("UpgradePageNavigationCount", PageNavigateCount);
			if (UnlockPopIn_UP_LS.Length != 0 && PageNavigateCount == UnlockPopIn_UP_LS[0])
			{
				UpgradesInAppPage.instance.IsShowDiscountPop = false;
				UpgradesInAppPage.instance.Open();
				PlayerPrefs.SetInt("UpgradePageNavigationCount", 0);
			}
			break;
		}
		Debug.Log("---CheckUpgradeInAppPopUp SessionCount=" + SessionCount + ":::pageNavigationCount=" + PageNavigateCount);
	}

	private void CheckLevelsInAppPopUp(PageType CurrentPage)
	{
		if (!isWifi_OR_Data_Availble() || LevelsUnlocked == 1)
		{
			return;
		}
		SessionCount = PlayerPrefs.GetInt("SessionCount", 1);
		switch (CurrentPage)
		{
		case PageType.Menu:
			if (IsUpgradeShownInMenu)
			{
				return;
			}
			PageNavigateCount = PlayerPrefs.GetInt("MenuPageNavigationCount", 0);
			PageNavigateCount++;
			PlayerPrefs.SetInt("MenuPageNavigationCount", PageNavigateCount);
			if (IsOpenLevelDiscountFrmPush)
			{
				LevelsInAppPage.instance.IsShowDiscountPop = true;
				LevelsInAppPage.instance.Open();
				IsUpgradeShownInMenu = true;
				IsOpenLevelDiscountFrmPush = false;
			}
			break;
		case PageType.LvlSelection:
			PageNavigateCount = PlayerPrefs.GetInt("LevelsPageNavigationCount", 0);
			PageNavigateCount++;
			PlayerPrefs.SetInt("LevelsPageNavigationCount", PageNavigateCount);
			if (UnlockPopIn_UP_LS.Length > 1 && PageNavigateCount == UnlockPopIn_UP_LS[1])
			{
				LevelsInAppPage.instance.IsShowDiscountPop = false;
				LevelsInAppPage.instance.Open();
				PlayerPrefs.SetInt("LevelsPageNavigationCount", 0);
			}
			break;
		}
		Debug.Log("---CheckLevelsInAppPopUp SessionCount=" + SessionCount + ":::pageNavigationCount=" + PageNavigateCount);
	}

	private bool CheckAndDisplayPopUp(int LvlNo)
	{
		if (isWifi_OR_Data_Availble() && RatingPopInLevels.Contains(LvlNo) && PlayerPrefs.GetString("IsRated", "false") == "false")
		{
			Invoke("ShowRatePopUp", PopUpDelayTime);
			return true;
		}
		if (isWifi_OR_Data_Availble() && SharingPopInLevels.Contains(LvlNo) && PlayerPrefs.GetString("IsFBShared", "false") == "false")
		{
			Invoke("ShowSharePopUp", PopUpDelayTime);
			return true;
		}
		return false;
	}

	public void BuyItem(int index, bool IsNonConsumable = false, GameObject BuyBtn = null)
	{
		InAppController.instance.BuyProductID(index, IsNonConsumable, BuyBtn);
	}

	public void GoToPush()
	{
		Application.LoadLevel("PushController");
	}

	public void FacebookShare(int rewardCoins = 0)
	{
		using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.timuz.webviewhandler.WebViewActivity"))
		{
			androidJavaClass.CallStatic("FBShare", ShareUrl);
		}
		if (rewardCoins > 0)
		{
			StartCoroutine(AddCoinsWithDelay(2f, rewardCoins, RewardDescType.Sharing));
		}
	}

	public void ShareIT()
	{
		using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.timuz.webviewhandler.WebViewActivity"))
		{
			androidJavaClass.CallStatic("shareIt", RewardDescType.Sharing);
		}
	}

	public void YoutubeSubscribe(int rewardCoins = 0)
	{
		Application.OpenURL("https://www.youtube.com/user/gamesgeni/feed");
		PlayerPrefs.SetString("YoutubeUsed", "true");
		if (rewardCoins > 0)
		{
			StartCoroutine(AddCoinsWithDelay(2f, rewardCoins, RewardDescType.Sharing));
		}
	}

	public void TwitterFollow(int rewardCoins = 0)
	{
		Application.OpenURL("https://twitter.com/timuzgames");
		PlayerPrefs.SetString("TwitterUsed", "true");
		if (rewardCoins > 0)
		{
			StartCoroutine(AddCoinsWithDelay(2f, rewardCoins, RewardDescType.Sharing));
		}
	}

	public void FBLike(int rewardCoins = 0)
	{
		Application.OpenURL("https://www.facebook.com/timuzsolutions/");
		PlayerPrefs.SetString("FacebookUsed", "true");
		if (rewardCoins > 0)
		{
			StartCoroutine(AddCoinsWithDelay(2f, rewardCoins, RewardDescType.Sharing));
		}
	}

	public void InstagramFollow(int rewardCoins = 0)
	{
		Application.OpenURL("https://www.instagram.com/timuzgamesofficial/");
		PlayerPrefs.SetString("InstagramUsed", "true");
		if (rewardCoins > 0)
		{
			StartCoroutine(AddCoinsWithDelay(2f, rewardCoins, RewardDescType.Sharing));
		}
	}

	public IEnumerator AddCoinsWithDelay(float waitTime, int coins, RewardDescType TypeofDesc)
	{
		yield return new WaitForSeconds(waitTime);
		CallbacksController.instance.AddCoins(coins, TypeofDesc);
	}

	public void ShowRatePopUp()
	{
		RatePage.instance.Open();
	}

	public void ShowSharePopUp()
	{
		SharePage.instance.Open();
	}

	public void ShowLeaderBoards()
	{
		PlayServicesController.instance.ShowLeaderBoards();
	}

	public void ShowAchievements()
	{
		PlayServicesController.instance.ShowAchievements();
	}

	public void ShowMoreGames()
	{
		WebViewController.instance.ShowMoreGames();
	}

	public void SubmitScore(int score)
	{
		PlayServicesController.instance.SubmitScoreToLB(score);
	}

	public void UnlockAchievements(int LvlNo)
	{
		PlayServicesController.instance.Check_UnlockAchievement(LvlNo);
	}

	public void ShowSocialBtns()
	{
		SocialBtnsController.instance.Open();
	}

	public void HideSocialBtns()
	{
		SocialBtnsController.instance.Close();
	}

	public void ShowLCMoreGames()
	{
		LCMoreGames.instance.Open();
	}

	public void HideLCMoreGames()
	{
		LCMoreGames.instance.Close();
	}

	public void LoadFirstScene()
	{
		Debug.Log("------- LoadFirstScene");
		Loading.SetActive(false);
		if (!PlayerPrefs.HasKey("IsGotWelcomeGift"))
		{
			Debug.Log("------Give welcome gift");
			WelcomeGiftPage.instance.Open();
		}
		else if (!IsMenuLoaded)
		{
			Debug.Log("------OpenMenuScene");
			Loading.SetActive(true);
			if (menuAdImg != null)
			{
				StartCoroutine(OpenMenuScene(0f));
			}
			else
			{
				StartCoroutine(OpenMenuScene(8f));
			}
		}
	}

	public IEnumerator OpenMenuScene(float waitTime, bool IsFromXml = false)
	{
		yield return new WaitForSeconds(waitTime);
		if (!IsMenuLoaded)
		{
			Debug.Log("-------- CallToOpenMenuScene IsFromXml=" + IsFromXml);
			CancelInvoke("OpenMenuScene");
			SceneManager.LoadScene(1);
			IsMenuLoaded = true;
		}
	}

	public bool isWifi_OR_Data_Availble()
	{
		if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork || Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
		{
			return true;
		}
		return false;
	}

	public void ShowToast(string msg)
	{
		WebViewController.instance.ShowToastMsg(msg);
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		Debug.Log(mode);
		int buildIndex = scene.buildIndex;
		if (buildIndex == 1)
		{
			Loading.SetActive(false);
			if (AdInPages[0] == 1 && menuAdImg != null && !IsMenuAdOpened)
			{
				MenuAdPage.instance.Open();
				IsMenuAdOpened = true;
			}
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
