using UnityEngine;
using UnityEngine.UI;

public class RateBtnHandler : MonoBehaviour
{
	private void OnEnable()
	{
		RatePage.RateSuccessCallBack += SuccessCallBack;
	}

	private void OnDisable()
	{
		RatePage.RateSuccessCallBack -= SuccessCallBack;
	}

	private void Start()
	{
		if (PlayerPrefs.GetString("IsRated", "false") == "true")
		{
			base.gameObject.GetComponent<Button>().interactable = false;
			return;
		}
		base.gameObject.GetComponent<Button>().interactable = true;
		base.gameObject.GetComponent<Button>().onClick.AddListener(delegate
		{
			RateClicked();
		});
	}

	public void RateClicked()
	{
		AdManager.instance.ShowRatePopUp();
	}

	public void SuccessCallBack()
	{
		Debug.Log("-------------- InAppSuccessCallBack");
		base.gameObject.GetComponent<Button>().interactable = false;
	}

	public void FailCallBack()
	{
		Debug.Log("-------------- InAppFailedCallBack");
		base.gameObject.GetComponent<Button>().interactable = true;
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
