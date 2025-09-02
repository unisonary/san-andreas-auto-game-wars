using UnityEngine;

public class WebViewExit : MonoBehaviour
{
	[HideInInspector]
	public bool IsMoreGamesShowing;

	[HideInInspector]
	public bool IsExitShowing;

	public static string ExitPageURL = "";

	public static WebViewExit instance;

	private void Awake()
	{
		instance = this;
	}

	private void Update()
	{
	}

	public void ShowExit()
	{
		using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.timuz.moregames.webViewClass"))
		{
			if (IsMoreGamesShowing)
			{
				androidJavaClass.CallStatic("hideWebView");
				IsMoreGamesShowing = false;
			}
			else if (IsExitShowing)
			{
				androidJavaClass.CallStatic("hideWebView");
				IsExitShowing = false;
			}
			else if (ExitPageURL != "")
			{
				IsExitShowing = true;
			}
			else if (Application.loadedLevelName.Contains("Level") && Application.loadedLevelName != "Levelcomplete")
			{
				if (GameObject.Find("UIcontrols(Clone)") != null)
				{
					GameObject.Find("UIcontrols(Clone)").SendMessage("Quitpagefunc");
				}
				else
				{
					Application.Quit();
				}
			}
			else
			{
				Application.Quit();
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
