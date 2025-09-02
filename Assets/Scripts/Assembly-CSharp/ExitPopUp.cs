using UnityEngine;

public class ExitPopUp : MonoBehaviour
{
	public static ExitPopUp instance;

	public GameObject ExitInNoNet;

	public GameObject PopUp;

	public GameObject YesBtn;

	public GameObject NoBtn;

	private bool isNativeExtiOpened;

	private void Awake()
	{
		instance = this;
		ExitInNoNet.SetActive(false);
	}

	public void NoClick()
	{
		ExitInNoNet.SetActive(false);
		isNativeExtiOpened = false;
	}

	public void YesClick()
	{
		Application.Quit();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if ((AdManager.instance.isWifi_OR_Data_Availble() || WebViewController.instance.showWebView || WebViewController.instance.showExitView) && !isNativeExtiOpened && AdManager.instance.ExitLink != string.Empty)
			{
				WebViewController.instance.BackPressedAction();
			}
			else if (!isNativeExtiOpened)
			{
				ExitInNoNet.SetActive(true);
				iTween.Stop(PopUp);
				PopUp.transform.localPosition = Vector3.zero;
				iTween.MoveFrom(PopUp, iTween.Hash("y", 1000, "time", 0.4f, "islocal", true, "easetype", iTween.EaseType.spring));
				iTween.Stop(YesBtn);
				iTween.Stop(NoBtn);
				NoBtn.transform.localScale = Vector3.one;
				YesBtn.transform.localScale = Vector3.one;
				iTween.ScaleFrom(YesBtn, iTween.Hash("x", 0, "y", 0, "time", 0.5, "delay", 0.4f, "easetype", iTween.EaseType.spring));
				iTween.ScaleFrom(NoBtn, iTween.Hash("x", 0, "y", 0, "time", 0.5, "delay", 0.5f, "easetype", iTween.EaseType.spring));
				isNativeExtiOpened = true;
			}
			else
			{
				ExitInNoNet.SetActive(false);
				isNativeExtiOpened = false;
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
