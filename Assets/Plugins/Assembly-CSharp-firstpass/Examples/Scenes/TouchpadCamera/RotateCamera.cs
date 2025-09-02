using CnControls;
using UnityEngine;

namespace Examples.Scenes.TouchpadCamera
{
	public class RotateCamera : MonoBehaviour
	{
		public float RotationSpeed = 15f;

		public Transform OriginTransform;

		public void Update()
		{
			float axis = CnInputManager.GetAxis("Horizontal");
			float axis2 = CnInputManager.GetAxis("Vertical");
			OriginTransform.Rotate(Vector3.down, axis * Time.deltaTime * RotationSpeed);
			OriginTransform.Rotate(Vector3.right, axis2 * Time.deltaTime * RotationSpeed);
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
