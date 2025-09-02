using UnityEngine;

public class watchVideoAgain : MonoBehaviour
{
	private static watchVideoAgain _instance;

	public static watchVideoAgain Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = Object.FindObjectOfType<watchVideoAgain>();
			}
			return _instance;
		}
	}

	private void Awake()
	{
		_instance = this;
		base.gameObject.SetActive(false);
	}

	private void OnEnable()
	{
	}

	public void Open()
	{
		base.gameObject.SetActive(true);
	}

	public void Close()
	{
		base.gameObject.SetActive(false);
	}

	public void watchVideoNow()
	{
		MonoBehaviour.print("watch video Second Time");
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
