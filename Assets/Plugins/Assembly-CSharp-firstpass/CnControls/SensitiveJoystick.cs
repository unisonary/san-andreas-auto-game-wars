using UnityEngine;
using UnityEngine.EventSystems;

namespace CnControls
{
	public class SensitiveJoystick : SimpleJoystick
	{
		public AnimationCurve SensitivityCurve = new AnimationCurve(new Keyframe(0f, 0f, 1f, 1f), new Keyframe(1f, 1f, 1f, 1f));

		public override void OnDrag(PointerEventData eventData)
		{
			base.OnDrag(eventData);
			float value = HorizintalAxis.Value;
			float value2 = VerticalAxis.Value;
			float num = Mathf.Sign(value);
			float num2 = Mathf.Sign(value2);
			HorizintalAxis.Value = num * SensitivityCurve.Evaluate(num * value);
			VerticalAxis.Value = num2 * SensitivityCurve.Evaluate(num2 * value2);
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
