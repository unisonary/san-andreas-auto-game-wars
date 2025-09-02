using UnityEngine;
using UnityEngine.UI;

public class SharePopup : MonoBehaviour
{
	public Text HeadLine;

	public Text Description;

	public Button[] Buttons;

	private bool _isshown;

	private static SharePopup _instance;

	public static SharePopup Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = Object.FindObjectOfType<SharePopup>();
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
		_isshown = true;
		HeadLine.text = headlines;
		Description.text = _description;
		base.gameObject.SetActive(true);
	}

	public void Close()
	{
		_isshown = false;
		base.gameObject.SetActive(false);
	}

	public void ShareNow(string eventType)
	{
	}

	public void ShowMyShare()
	{
		base.gameObject.SetActive(true);
	}

	public void HideMyShare()
	{
		base.gameObject.SetActive(false);
	}

	public bool GetStatus()
	{
		return _isshown;
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
