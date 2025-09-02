using UnityEngine;
using UnityEngine.UI;

public class MenuAdPage : MonoBehaviour
{
	public Image MenuAdImg;

	public GameObject CloseBtn;

	public static MenuAdPage instance;

	private void Awake()
	{
		instance = this;
		base.gameObject.SetActive(false);
	}

	public void Open()
	{
		Invoke("showMenuAd", AdManager.instance.menuAdDelay);
	}

	private void showMenuAd()
	{
		base.gameObject.SetActive(true);
		MenuAdImg.CrossFadeAlpha(1f, 1f, true);
		CloseBtn.transform.localScale = Vector3.one;
		iTween.ScaleFrom(CloseBtn, iTween.Hash("x", 0, "y", 0, "time", 0.4f, "delay", 2.5f, "easetype", iTween.EaseType.spring));
	}

	public void Close()
	{
		base.gameObject.SetActive(false);
	}

	public void MenuAdClick()
	{
		Debug.Log("MenuAdLink=" + AdManager.instance.MenuAdLinkTo);
		Application.OpenURL(AdManager.instance.MenuAdLinkTo);
		Close();
	}

	public void SetMenuAdTexture()
	{
		MenuAdImg.GetComponent<Image>().sprite = AdManager.instance.menuAdImg;
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
