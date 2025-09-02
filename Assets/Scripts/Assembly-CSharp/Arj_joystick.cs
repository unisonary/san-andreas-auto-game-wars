using UnityEngine;

public class Arj_joystick : MonoBehaviour
{
	public Camera camera;

	private void Start()
	{
	}

	private void Update()
	{
		camera.transform.LookAt(base.transform);
		float num = 1f;
		base.transform.Rotate(Vector3.up, Input.GetAxis("horizontal") * num);
		base.transform.Rotate(Vector3.left, Input.GetAxis("vertical") * num);
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
