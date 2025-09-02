using UnityEngine;

public class bulletColision : MonoBehaviour
{
	public PoliceBehaviour policeBehav;

	private void Start()
	{
	}

	private void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			policeBehav.decreasePlayerHealth();
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
