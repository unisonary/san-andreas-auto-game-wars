using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	public abstract class PivotBasedCameraRig : AbstractTargetFollower
	{
		protected Transform m_Cam;

		protected Transform m_Pivot;

		protected Vector3 m_LastTargetPosition;

		protected virtual void Awake()
		{
			m_Cam = GetComponentInChildren<Camera>().transform;
			m_Pivot = m_Cam.parent;
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
