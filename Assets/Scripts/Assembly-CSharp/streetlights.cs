using UnityEngine;

public class streetlights : MonoBehaviour
{
	public Rigidbody myRig;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Vehicle")
		{
			GetComponent<Rigidbody>().isKinematic = false;
			Object.Destroy(base.gameObject, 10f);
		}
		if (collision.gameObject.tag == "AI Vehicle")
		{
			GetComponent<Rigidbody>().isKinematic = false;
			Object.Destroy(base.gameObject, 10f);
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
