using UnityEngine;

namespace CnControls
{
	public class VirtualButton
	{
		private int _lastPressedFrame = -1;

		private int _lastReleasedFrame = -1;

		public string Name { get; set; }

		public bool IsPressed { get; private set; }

		public bool GetButton
		{
			get
			{
				return IsPressed;
			}
		}

		public bool GetButtonDown
		{
			get
			{
				if (_lastPressedFrame != -1)
				{
					return _lastPressedFrame - Time.frameCount == -1;
				}
				return false;
			}
		}

		public bool GetButtonUp
		{
			get
			{
				if (_lastReleasedFrame != -1)
				{
					return _lastReleasedFrame == Time.frameCount - 1;
				}
				return false;
			}
		}

		public VirtualButton(string name)
		{
			Name = name;
		}

		public void Press()
		{
			if (!IsPressed)
			{
				IsPressed = true;
				_lastPressedFrame = Time.frameCount;
			}
		}

		public void Release()
		{
			IsPressed = false;
			_lastReleasedFrame = Time.frameCount;
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
