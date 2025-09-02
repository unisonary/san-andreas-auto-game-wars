using UnityEngine;

public class Node : MonoBehaviour
{
	public Transform previousNode;

	public Transform nextNode;

	public float widthDistance = 5f;

	public Color nodeColor = Color.green;

	[HideInInspector]
	public TrafficMode trafficMode = TrafficMode.Stop;

	[HideInInspector]
	public string nodeState;

	[HideInInspector]
	public string mode = "OneWay";

	[HideInInspector]
	public string parentPath;

	[HideInInspector]
	public bool firistNode;

	[HideInInspector]
	public bool lastNode;

	[HideInInspector]
	public bool trafficNode;

	private void OnDrawGizmos()
	{
		if (trafficNode)
		{
			switch (trafficMode)
			{
			case TrafficMode.Go:
				Gizmos.color = Color.green;
				Gizmos.DrawWireSphere(base.transform.position, 2f);
				break;
			case TrafficMode.Wait:
				Gizmos.color = Color.yellow;
				Gizmos.DrawWireSphere(base.transform.position, 2f);
				break;
			case TrafficMode.Stop:
				Gizmos.color = Color.red;
				Gizmos.DrawWireSphere(base.transform.position, 2f);
				break;
			}
		}
		Gizmos.color = nodeColor;
		Vector3 vector = base.transform.TransformDirection(Vector3.left);
		Gizmos.DrawRay(base.transform.position, vector * widthDistance);
		Gizmos.DrawRay(base.transform.position, vector * (0f - widthDistance));
		Gizmos.DrawSphere(base.transform.position, 1f);
		if ((bool)nextNode)
		{
			Vector3 vector2 = base.transform.position - nextNode.position;
			vector2.y = 0f;
		}
	}

	private void Awake()
	{
		if (!previousNode)
		{
			Debug.LogError("previousNode is missing on : " + parentPath + " Node " + base.name);
		}
		if ((bool)nextNode)
		{
			if ((bool)nextNode.GetComponent<WaysControl>())
			{
				nodeState = "NextPoint";
			}
			else
			{
				nodeState = "PreviousPoint";
			}
		}
		else
		{
			Debug.LogError("NextNode is missing on : " + parentPath + " Node " + base.name);
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
