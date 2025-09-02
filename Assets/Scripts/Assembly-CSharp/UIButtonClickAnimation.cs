using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonClickAnimation : MonoBehaviour, IPointerUpHandler, IEventSystemHandler, IPointerDownHandler
{
	private Vector3 mv_ButtonScale;

	private Vector3 mv_ButtonScaleHAlt;

	private Vector3 mv_ButtonScaleHorn;

	private Vector3 MainVal;

	private bool isButtonPressed;

	public bool canRotate;

	public GameObject RefObj;

	public float ScaleValue = 0.2f;

	private void Start()
	{
		if (base.transform.localScale.x <= 0f)
		{
			MainVal = (mv_ButtonScale = new Vector3(1f, 1f, 1f));
		}
		else
		{
			MainVal = (mv_ButtonScale = base.transform.localScale);
		}
		mv_ButtonScaleHAlt = new Vector3(1.2f, 1.2f, 1.2f);
		mv_ButtonScaleHorn = new Vector3(1.5f, 1.5f, 1.5f);
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		if (base.name == "Halt")
		{
			mv_ButtonScale = mv_ButtonScaleHAlt;
		}
		else if (base.name == "Horn")
		{
			mv_ButtonScale = mv_ButtonScaleHorn;
		}
		else
		{
			mv_ButtonScale = MainVal;
		}
		if (canRotate)
		{
			iTween.Stop();
		}
		iTween.ScaleTo(base.gameObject, iTween.Hash("scale", mv_ButtonScale, "time", 0.25f, "easetype", iTween.EaseType.easeOutBack));
		if (RefObj != null)
		{
			iTween.ScaleTo(RefObj.gameObject, iTween.Hash("scale", mv_ButtonScale, "time", 0.25f, "easetype", iTween.EaseType.easeOutBack));
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		MainVal = (mv_ButtonScale = base.transform.localScale);
		Vector3 localScale = mv_ButtonScale + new Vector3(ScaleValue, ScaleValue, ScaleValue);
		base.gameObject.GetComponent<RectTransform>().localScale = localScale;
		if (canRotate)
		{
			iTween.RotateBy(base.gameObject, iTween.Hash("z", -5, "time", 5, "easetype", "Linear", "islocal", true, "loopType", iTween.LoopType.loop));
		}
		if (RefObj != null)
		{
			RefObj.gameObject.GetComponent<RectTransform>().localScale = localScale;
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
