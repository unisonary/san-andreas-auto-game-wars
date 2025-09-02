using UnityEngine;
using UnityEngine.UI;

public class RatePopup : MonoBehaviour
{
	public Text HeadLine;

	public Text Description;

	public Button[] Buttons;

	private static RatePopup _instance;

	private bool _pageshown;

	public static RatePopup Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = Object.FindObjectOfType<RatePopup>();
			}
			return _instance;
		}
	}

	private void Awake()
	{
		_instance = this;
		base.gameObject.SetActive(false);
	}

	public void Open(string headlines, string _description)
	{
		_pageshown = true;
		HeadLine.text = headlines;
		Description.text = _description;
		base.gameObject.SetActive(true);
	}

	public void Close()
	{
		_pageshown = false;
		base.gameObject.SetActive(false);
	}

	public void RateNow()
	{
		Close();
		Debug.Log("RateNow");
		PlayerPrefs.SetString("rated", "true");
	}

	public void ShowMyRate()
	{
		base.gameObject.SetActive(true);
	}

	public void HideMyRate()
	{
		base.gameObject.SetActive(false);
	}

	public bool GetStatus()
	{
		return _pageshown;
	}

	public void openFeedBack()
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
