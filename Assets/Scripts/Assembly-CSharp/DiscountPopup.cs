using UnityEngine;
using UnityEngine.UI;

public class DiscountPopup : MonoBehaviour
{
	public Text HeadLine;

	public Text Description;

	public Text priceText;

	public Text doublePrice;

	public Button[] Buttons;

	private static DiscountPopup _instance;

	public static DiscountPopup Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = Object.FindObjectOfType<DiscountPopup>();
			}
			return _instance;
		}
	}

	private void Awake()
	{
		_instance = this;
		base.gameObject.SetActive(false);
	}

	private void Start()
	{
	}

	private void SetupDetails()
	{
	}

	public void Close()
	{
		base.gameObject.SetActive(false);
	}

	public void Buy()
	{
		Debug.Log("Discount Buy Button Clicked");
	}

	public void Open(string headlines, string _description)
	{
		HeadLine.text = headlines;
		Description.text = _description;
		base.gameObject.SetActive(true);
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
