using UnityEngine;

public class Store : MonoBehaviour
{
	public GameObject StorePage;

	private soundmanager _soundmanager;

	private void Start()
	{
		StorePage.SetActive(true);
		_soundmanager = Object.FindObjectOfType<soundmanager>();
	}

	private void GoBack()
	{
		if ((bool)_soundmanager)
		{
			Object.Destroy(_soundmanager.gameObject);
		}
		Application.LoadLevel(MenuPageHandler.lastOpenPage);
	}

	public void OnBackBtn()
	{
		Invoke("GoBack", 0.3f);
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
