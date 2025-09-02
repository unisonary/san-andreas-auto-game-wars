using UnityEngine;

public class VehiclePath : MonoBehaviour
{
	public Color pathColor = new Color(1f, 0.5f, 0f);

	private Node nodeComponent;

	private Transform firstNode;

	private void Start()
	{
		int num = 0;
		foreach (Transform item in base.transform)
		{
			if (num == 0)
			{
				firstNode = item;
				num++;
			}
			item.GetComponent<Node>().mode = firstNode.GetComponent<Node>().mode;
		}
	}

	private void OnDrawGizmos()
	{
		int num = 1;
		Gizmos.color = pathColor;
		foreach (Transform item in base.transform)
		{
			nodeComponent = item.GetComponent<Node>();
			if (num == 1)
			{
				nodeComponent.firistNode = true;
				nodeComponent.lastNode = false;
			}
			else if (num == base.transform.childCount)
			{
				nodeComponent.firistNode = false;
				nodeComponent.lastNode = true;
			}
			else
			{
				nodeComponent.firistNode = false;
				nodeComponent.lastNode = false;
			}
			if (!nodeComponent)
			{
				item.gameObject.AddComponent<Node>();
				nodeComponent.nodeColor = pathColor;
				nodeComponent.parentPath = base.name;
			}
			else
			{
				nodeComponent.nodeColor = pathColor;
				nodeComponent.parentPath = base.name;
			}
			if (item.name != num.ToString())
			{
				item.name = num.ToString();
			}
			num++;
			Transform transform2 = base.transform.Find(num.ToString());
			Transform transform3 = base.transform.Find((num - 2).ToString());
			if ((bool)transform3)
			{
				nodeComponent.previousNode = transform3;
			}
			if ((bool)transform2)
			{
				Gizmos.DrawLine(item.position, transform2.position);
				nodeComponent.nextNode = transform2;
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
