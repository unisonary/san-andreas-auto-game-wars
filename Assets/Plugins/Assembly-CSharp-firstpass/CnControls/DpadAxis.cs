using UnityEngine;

namespace CnControls
{
	public class DpadAxis : MonoBehaviour
	{
		public string AxisName;

		public float AxisMultiplier;

		private VirtualAxis _virtualAxis;

		public RectTransform RectTransform { get; private set; }

		public int LastFingerId { get; set; }

		private void Awake()
		{
			RectTransform = GetComponent<RectTransform>();
		}

		private void OnEnable()
		{
			_virtualAxis = _virtualAxis ?? new VirtualAxis(AxisName);
			LastFingerId = -1;
			CnInputManager.RegisterVirtualAxis(_virtualAxis);
		}

		private void OnDisable()
		{
			CnInputManager.UnregisterVirtualAxis(_virtualAxis);
		}

		public void Press(Vector2 screenPoint, Camera eventCamera, int pointerId)
		{
			_virtualAxis.Value = Mathf.Clamp(AxisMultiplier, -1f, 1f);
			LastFingerId = pointerId;
		}

		public void TryRelease(int pointerId)
		{
			if (LastFingerId == pointerId)
			{
				_virtualAxis.Value = 0f;
				LastFingerId = -1;
			}
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
