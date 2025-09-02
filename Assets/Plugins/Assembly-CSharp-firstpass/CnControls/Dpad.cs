using UnityEngine;
using UnityEngine.EventSystems;

namespace CnControls
{
	public class Dpad : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		public DpadAxis[] DpadAxis;

		public Camera CurrentEventCamera { get; set; }

		public void OnPointerDown(PointerEventData eventData)
		{
			CurrentEventCamera = eventData.pressEventCamera ?? CurrentEventCamera;
			DpadAxis[] dpadAxis = DpadAxis;
			foreach (DpadAxis dpadAxis2 in dpadAxis)
			{
				if (RectTransformUtility.RectangleContainsScreenPoint(dpadAxis2.RectTransform, eventData.position, CurrentEventCamera))
				{
					dpadAxis2.Press(eventData.position, CurrentEventCamera, eventData.pointerId);
				}
			}
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			DpadAxis[] dpadAxis = DpadAxis;
			for (int i = 0; i < dpadAxis.Length; i++)
			{
				dpadAxis[i].TryRelease(eventData.pointerId);
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
