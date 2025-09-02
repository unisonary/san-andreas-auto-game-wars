using UnityEngine;

internal class BezierController : MonoBehaviour
{
	public BezierPath path;

	public float speed = 1f;

	public bool byDist;

	private float t;

	private Vector3 lastpoint;

	private void Start()
	{
		lastpoint = base.transform.position;
	}

	private void Update()
	{
		t += speed * Time.deltaTime;
		if (!byDist)
		{
			base.transform.position = path.GetPositionByT(t);
		}
		else
		{
			base.transform.position = path.GetPositionByDistance(t);
		}
		base.transform.forward = -(lastpoint - base.transform.position).normalized;
		if (lastpoint == base.transform.position)
		{
			Object.Destroy(base.gameObject);
			MonoBehaviour.print("PATH ENDED..");
		}
		lastpoint = base.transform.position;
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
