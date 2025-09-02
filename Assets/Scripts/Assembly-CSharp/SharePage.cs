using UnityEngine;
using UnityEngine.UI;

public class SharePage : MonoBehaviour
{
	public static SharePage instance;

	public GameObject PopUp;

	public GameObject CloseBtn;

	public Text Desc;

	private void Awake()
	{
		instance = this;
		base.gameObject.SetActive(false);
	}

	public void Open()
	{
		base.gameObject.SetActive(true);
		if (AdManager.instance.ShareDesc != string.Empty)
		{
			Desc.text = AdManager.instance.ShareDesc;
		}
		PopUp.transform.localPosition = Vector3.zero;
		iTween.MoveFrom(PopUp, iTween.Hash("y", 1000, "time", 0.4f, "islocal", true, "easetype", iTween.EaseType.spring));
		iTween.ScaleFrom(CloseBtn, iTween.Hash("x", 0, "y", 0, "time", 0.5, "delay", 2.5f, "easetype", iTween.EaseType.spring));
	}

	public void Close()
	{
		base.gameObject.SetActive(false);
	}

	public void ShareClick()
	{
		PlayerPrefs.SetString("IsFBShared", "true");
		AdManager.instance.FacebookShare();
		if (AdManager.instance.ShareCoins > 0)
		{
			AdManager.instance.StartCoroutine(AdManager.instance.AddCoinsWithDelay(2f, AdManager.instance.ShareCoins, AdManager.RewardDescType.Sharing));
		}
		Close();
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
