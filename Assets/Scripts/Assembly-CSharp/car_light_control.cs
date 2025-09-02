using UnityEngine;

public class car_light_control : MonoBehaviour
{
	private Light light;

	private Light interior_light;

	public bool interior_light_bool;

	private void Start()
	{
		light = base.gameObject.GetComponent<Light>();
		interior_light = base.gameObject.GetComponent<Light>();
		light.enabled = false;
		interior_light.enabled = false;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q) && !interior_light_bool)
		{
			light.enabled = !light.enabled;
		}
		if (Input.GetKeyDown(KeyCode.T) && interior_light_bool)
		{
			interior_light.enabled = !interior_light.enabled;
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
