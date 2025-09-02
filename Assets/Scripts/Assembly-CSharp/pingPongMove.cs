using UnityEngine;

public class pingPongMove : MonoBehaviour
{
	public float speed = 1.5f;

	public float frictionFactor = 0.999f;

	public float factor = 1f;

	private Vector3 qStart;

	private Vector3 qEnd;

	public Vector3 startPos;

	public Vector3 endPos;

	public bool isTriggerControled;

	public void Start()
	{
		qStart = base.transform.localPosition + startPos;
		qEnd = base.transform.localPosition + endPos;
	}

	private void Update()
	{
		base.transform.localPosition = Vector3.Lerp(qStart, qEnd, (Mathf.Sin(Time.time * speed) * factor + 1f) / 2f);
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
