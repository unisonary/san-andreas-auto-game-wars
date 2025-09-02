using UnityEngine;
using UnityEngine.UI;

public class Session_N_PageNav_CountDisplay : MonoBehaviour
{
	public bool isSessionNavteCount;

	public AdManager.PageType pageType;

	private void Start()
	{
		Invoke("SetNavigationCountDisplay", 0.5f);
	}

	private void SetNavigationCountDisplay()
	{
		if (isSessionNavteCount)
		{
			GetComponent<Text>().text = "SessionCount=" + PlayerPrefs.GetInt("SessionCount", 1);
			return;
		}
		switch (pageType)
		{
		case AdManager.PageType.Menu:
			GetComponent<Text>().text = "PageNavigationCount=" + PlayerPrefs.GetInt("MenuPageNavigationCount", 0);
			break;
		case AdManager.PageType.LvlSelection:
			GetComponent<Text>().text = "PageNavigationCount=" + PlayerPrefs.GetInt("LevelsPageNavigationCount", 0);
			break;
		case AdManager.PageType.Upgrade:
			GetComponent<Text>().text = "PageNavigationCount=" + PlayerPrefs.GetInt("UpgradePageNavigationCount", 0);
			break;
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
