using UnityEngine;
using UnityEngine.UI;

public class SocialBtnsController : MonoBehaviour
{
	public GameObject FacebookBtn;

	public GameObject YoutubeBtn;

	public GameObject TwitterBtn;

	public GameObject InstagramBtn;

	public Text FBCoinsTxt;

	public Text YoutubeCoinsTxt;

	public Text TwitterCoinsTxt;

	public Text InstagramCoinsTxt;

	public int FBRewardCoins;

	public int YoutubeRewardCoins;

	public int TwitterRewardCoins;

	public int InstagramRewardCoins;

	public static SocialBtnsController instance;

	private int BtnType;

	private int currentBtn;

	private bool IsFoundPossibility;

	private void Awake()
	{
		instance = this;
	}

	private void OnEnable()
	{
		Open();
	}

	public void Open()
	{
		base.gameObject.SetActive(true);
		FBCoinsTxt.text = string.Concat(FBRewardCoins);
		YoutubeCoinsTxt.text = string.Concat(YoutubeRewardCoins);
		TwitterCoinsTxt.text = string.Concat(TwitterRewardCoins);
		InstagramCoinsTxt.text = string.Concat(InstagramRewardCoins);
		BtnType = PlayerPrefs.GetInt("ScocialBtnType", 0);
		hideAllBtns();
		GetBtnDisplay();
	}

	public void Close()
	{
		base.gameObject.SetActive(false);
	}

	private void hideAllBtns()
	{
		FacebookBtn.SetActive(false);
		YoutubeBtn.SetActive(false);
		TwitterBtn.SetActive(false);
		InstagramBtn.SetActive(false);
	}

	public void GetBtnDisplay()
	{
		hideAllBtns();
		IsFoundPossibility = false;
		if (!(PlayerPrefs.GetString("FacebookUsed", "false") == "false") && !(PlayerPrefs.GetString("YoutubeUsed", "false") == "false") && !(PlayerPrefs.GetString("TwitterUsed", "false") == "false") && !(PlayerPrefs.GetString("InstagramUsed", "false") == "false"))
		{
			return;
		}
		BtnType = PlayerPrefs.GetInt("ScocialBtnType", 0);
		switch (BtnType)
		{
		case 0:
			if (PlayerPrefs.GetString("FacebookUsed", "false") == "false")
			{
				FacebookBtn.SetActive(true);
				IsFoundPossibility = true;
			}
			else
			{
				IsFoundPossibility = false;
			}
			break;
		case 1:
			if (PlayerPrefs.GetString("YoutubeUsed", "false") == "false")
			{
				YoutubeBtn.SetActive(true);
				IsFoundPossibility = true;
			}
			else
			{
				IsFoundPossibility = false;
			}
			break;
		case 2:
			if (PlayerPrefs.GetString("TwitterUsed", "false") == "false")
			{
				TwitterBtn.SetActive(true);
				IsFoundPossibility = true;
			}
			else
			{
				IsFoundPossibility = false;
			}
			break;
		case 3:
			if (PlayerPrefs.GetString("InstagramUsed", "false") == "false")
			{
				InstagramBtn.SetActive(true);
				IsFoundPossibility = true;
			}
			else
			{
				IsFoundPossibility = false;
			}
			break;
		}
		if (IsFoundPossibility)
		{
			BtnType++;
			PlayerPrefs.SetInt("ScocialBtnType", BtnType);
			return;
		}
		BtnType++;
		BtnType = ((BtnType <= 3) ? BtnType : 0);
		PlayerPrefs.SetInt("ScocialBtnType", BtnType);
		GetBtnDisplay();
	}

	public void FacebookBtnClick()
	{
		AdManager.instance.FBLike(FBRewardCoins);
		GetBtnDisplay();
	}

	public void YoutubeBtnClick()
	{
		AdManager.instance.YoutubeSubscribe(YoutubeRewardCoins);
		GetBtnDisplay();
	}

	public void TwitterBtnClick()
	{
		AdManager.instance.TwitterFollow(TwitterRewardCoins);
		GetBtnDisplay();
	}

	public void InstagramBtnClick()
	{
		AdManager.instance.InstagramFollow(InstagramRewardCoins);
		GetBtnDisplay();
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
