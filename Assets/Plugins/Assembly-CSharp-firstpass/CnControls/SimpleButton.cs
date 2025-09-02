using UnityEngine;
using UnityEngine.EventSystems;

namespace CnControls
{
	public class SimpleButton : MonoBehaviour, IPointerUpHandler, IEventSystemHandler, IPointerDownHandler
	{
		public string ButtonName = "Jump";

		public VirtualButton _virtualButton;

		private void OnEnable()
		{
			_virtualButton = _virtualButton ?? new VirtualButton(ButtonName);
			CnInputManager.RegisterVirtualButton(_virtualButton);
		}

		private void OnDisable()
		{
			CnInputManager.UnregisterVirtualButton(_virtualButton);
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			_virtualButton.Release();
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			_virtualButton.Press();
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
