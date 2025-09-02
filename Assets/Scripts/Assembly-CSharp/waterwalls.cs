using UnityEngine;

public class waterwalls : MonoBehaviour
{
	public GameObject mainWater;

	public static bool showwater = true;

	private void Start()
	{
		Invoke("disable", 1f);
	}

	private void disable()
	{
		mainWater.SetActive(false);
	}

	private void OnTriggerEnter(Collider _obj)
	{
		if (_obj.transform.name == "waterwall")
		{
			mainWater.SetActive(showwater);
			showwater = !showwater;
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
