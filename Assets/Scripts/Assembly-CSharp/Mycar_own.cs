using UnityEngine;

public class Mycar_own : MonoBehaviour
{
	public GameObject[] DisableObjects;

	public static Mycar_own mee;

	private void Start()
	{
		mee = this;
	}

	public void DisableThings()
	{
		Debug.Log("disable things...");
		for (int i = 0; i < DisableObjects.Length; i++)
		{
			DisableObjects[i].SetActive(false);
		}
	}

	private void Update()
	{
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
