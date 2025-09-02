using UnityEngine;

public class WebViewController : MonoBehaviour
{
	private AndroidJavaObject activityContext;

	[HideInInspector]
	public bool showWebView;

	[HideInInspector]
	public bool showExitView;

	public static WebViewController instance;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		SetToastObj();
	}

	public void LoadDummyUrls()
	{
		using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.timuz.webviewhandler.WebViewActivity"))
		{
			androidJavaClass.CallStatic("LoadDummyExitView", AdManager.instance.ExitLink);
			androidJavaClass.CallStatic("LoadDummyMoreGamesView", AdManager.instance.MgLink);
		}
	}

	public void SetToastObj()
	{
		using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.timuz.webviewhandler.WebViewActivity"))
		{
			androidJavaClass.CallStatic("SetToastObj");
		}
	}

	public void ShowToastMsg(string msg)
	{
		Debug.Log("----------- callToShowToastMsg");
		using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.timuz.webviewhandler.WebViewActivity"))
		{
			androidJavaClass.CallStatic("ShowToastMessage", msg);
		}
	}

	public void ShowMoreGames()
	{
		showWebView = true;
		using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.timuz.webviewhandler.WebViewActivity"))
		{
			androidJavaClass.CallStatic("showMoreGamesView", AdManager.instance.MgLink, Application.identifier);
		}
	}

	public void BackPressedAction()
	{
		using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.timuz.webviewhandler.WebViewActivity"))
		{
			if (showWebView)
			{
				androidJavaClass.CallStatic("hideWebView");
				showWebView = false;
				return;
			}
			if (showExitView)
			{
				androidJavaClass.CallStatic("hideWebView");
				showExitView = false;
				return;
			}
			androidJavaClass.CallStatic("showExitView", AdManager.instance.ExitLink, Application.identifier);
			showExitView = true;
		}
	}

	public void OpenLink(string str)
	{
		Debug.Log("---------- OpenLink=" + str);
		Application.OpenURL("market://details?id=" + str);
	}

	public void ExitApp(string str)
	{
		Debug.Log("----------ExitApp---");
		Application.Quit();
	}

	public void unityhideWebView(string str)
	{
		Debug.Log("----------unityhidewebview---");
		showWebView = false;
		showExitView = false;
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
