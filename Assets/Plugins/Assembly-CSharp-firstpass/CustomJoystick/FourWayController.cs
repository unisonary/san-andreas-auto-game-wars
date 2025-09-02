using CnControls;
using UnityEngine;

namespace CustomJoystick
{
	public class FourWayController : MonoBehaviour
	{
		private Vector3[] directionalVectors = new Vector3[4]
		{
			Vector3.forward,
			Vector3.back,
			Vector3.right,
			Vector3.left
		};

		private Transform _mainCameraTransform;

		private void Awake()
		{
			_mainCameraTransform = Camera.main.transform;
		}

		private void Update()
		{
			Vector3 lhs = new Vector3(CnInputManager.GetAxis("Horizontal"), 0f, CnInputManager.GetAxis("Vertical"));
			if (lhs.sqrMagnitude < 1E-05f)
			{
				return;
			}
			Vector3 vector = directionalVectors[0];
			float num = Vector3.Dot(lhs, vector);
			for (int i = 1; i < directionalVectors.Length; i++)
			{
				float num2 = Vector3.Dot(lhs, directionalVectors[i]);
				if (num2 < num)
				{
					vector = directionalVectors[i];
					num = num2;
				}
			}
			Vector3 vector2 = _mainCameraTransform.InverseTransformDirection(vector);
			vector2.y = 0f;
			vector2.Normalize();
			base.transform.position += vector2 * Time.deltaTime;
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
