using UnityEngine;
using UnityEngine.UI;

public class WelcomeGiftPage : MonoBehaviour
{
	public static WelcomeGiftPage instance;

	public GameObject PopUp;

	public GameObject ClaimBtn;

	public Text Desc;

	private void Awake()
	{
		instance = this;
		base.gameObject.SetActive(false);
	}

	public void Open()
	{
		Debug.LogError("----------- welcomegift open");
		base.gameObject.SetActive(true);
		PopUp.transform.localPosition = Vector3.zero;
		iTween.MoveFrom(PopUp, iTween.Hash("y", 1000, "time", 0.4f, "islocal", true, "easetype", iTween.EaseType.spring));
	}

	public void Close()
	{
		base.gameObject.SetActive(false);
		AdManager.instance.LoadFirstScene();
	}

	public void claimBtnClick()
	{
		PlayerPrefs.SetString("IsGotWelcomeGift", "true");
		CallbacksController.instance.AddCoins(AdManager.instance.WelcomeGiftReward, AdManager.RewardDescType.WelcomeGift, AdManager.RewardType.WelcomeGift);
		ClaimBtn.GetComponent<Button>().interactable = false;
		Close();
	}

	public void QuitApp()
	{
		Application.Quit();
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
