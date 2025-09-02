using UnityEngine;
using UnityEngine.UI;

public class PreLFPage : MonoBehaviour
{
	public static PreLFPage instance;

	public GameObject PopUp;

	public GameObject CloseBtn;

	public Text Desc;

	public GameObject WatchToContinueBtn;

	public GameObject ResumeAlwaysBtn;

	public GameObject ContinueBtn;

	private void Awake()
	{
		instance = this;
		base.gameObject.SetActive(false);
	}

	public void Open()
	{
		AdManager.instance.RunActions(AdManager.PageType.PreLF);
		base.gameObject.SetActive(true);
		ContinueBtn.SetActive(false);
		ResumeAlwaysBtn.SetActive(false);
		WatchToContinueBtn.SetActive(false);
		if (PlayerPrefs.GetString("ResumeAlwaysPurchased", "false") == "true")
		{
			Desc.text = "Click To Continue To Resume.";
			ContinueBtn.SetActive(true);
		}
		else
		{
			Desc.text = "You Crashed";
			ResumeAlwaysBtn.SetActive(true);
			WatchToContinueBtn.SetActive(true);
		}
		PopUp.transform.localPosition = Vector3.zero;
		iTween.MoveFrom(PopUp, iTween.Hash("y", 1000, "time", 0.4f, "islocal", true, "easetype", iTween.EaseType.spring));
		iTween.ScaleFrom(CloseBtn, iTween.Hash("x", 0, "y", 0, "time", 0.5, "delay", 0.5f, "easetype", iTween.EaseType.spring));
	}

	public void Close()
	{
		base.gameObject.SetActive(false);
		LevelFailSample.instance.Open();
	}

	public void WatchVideoBtnClick()
	{
		base.gameObject.SetActive(false);
	}

	public void ContinueBtnClick()
	{
		base.gameObject.SetActive(false);
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
