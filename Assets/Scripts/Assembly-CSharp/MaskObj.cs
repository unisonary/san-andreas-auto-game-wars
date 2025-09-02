using UnityEngine;
using UnityEngine.UI;

public class MaskObj : MonoBehaviour
{
	public bool ScaleNeed;

	public float _delay;

	public float speed = 2f;

	private void Start()
	{
		if (!ScaleNeed)
		{
			iTween.ValueTo(base.gameObject, iTween.Hash("from", 0f, "to", 0.98f, "time", speed, "delay", _delay, "onupdate", "numUpdate"));
		}
		else
		{
			iTween.ScaleFrom(base.gameObject, iTween.Hash("x", 0, "y", 0, "delay", _delay));
		}
	}

	private void numUpdate(float newValue)
	{
		base.gameObject.GetComponent<Image>().fillAmount = newValue;
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
