using UnityEngine;

public class WaysControl : MonoBehaviour
{
	public enum WayMode
	{
		Side = 1,
		Center = 2
	}

	public int ways = 1;

	public bool TCActive;

	public int TrafficNumber = 1;

	public int[] trafficNumbers = new int[3];

	public float TrafficTime;

	public int TrafficWays = 2;

	public Transform way1;

	public Transform way2;

	public Transform way3;

	public Transform way4;

	public int way1Mode;

	public int way2Mode;

	public int way3Mode;

	public int way4Mode = 1;

	public string[] trafficMode = new string[4] { "Way1", "Way2", "Way3", "Way4" };

	public float TrafficTimer;

	public float TrafficWaitTimer = 3f;

	public float stopDistance = 4f;

	private Node[] waysConnected = new Node[4];

	private void Awake()
	{
		if ((bool)way1 && ways > 0)
		{
			way1.GetComponent<Node>().mode = ((way1Mode == 1) ? "TwoWay" : "OnWay");
		}
		if ((bool)way2 && ways > 1)
		{
			way2.GetComponent<Node>().mode = ((way2Mode == 1) ? "TwoWay" : "OnWay");
		}
		if ((bool)way3 && ways > 2)
		{
			way3.GetComponent<Node>().mode = ((way3Mode == 1) ? "TwoWay" : "OnWay");
		}
		if ((bool)way4 && ways > 3)
		{
			way4.GetComponent<Node>().mode = ((way4Mode == 1) ? "TwoWay" : "OnWay");
		}
	}

	private void Start()
	{
		if ((bool)way1)
		{
			waysConnected[0] = way1.GetComponent<Node>();
		}
		if ((bool)way2)
		{
			waysConnected[1] = way2.GetComponent<Node>();
		}
		if ((bool)way3)
		{
			waysConnected[2] = way3.GetComponent<Node>();
		}
		if ((bool)way4)
		{
			waysConnected[3] = way4.GetComponent<Node>();
		}
		TrafficWaitTimer = 3f;
		if (TCActive)
		{
			TrafficTimer = TrafficTime;
			TrafficController();
		}
	}

	private void Update()
	{
		if (!TCActive || Vector3.Distance(AIContoller.manager.player.position, base.transform.position) > 300f)
		{
			return;
		}
		TrafficTimer = Mathf.MoveTowards(TrafficTimer, 0f, Time.deltaTime);
		if (TrafficTimer == 0f)
		{
			TrafficWaitTimer = Mathf.MoveTowards(TrafficWaitTimer, 0f, Time.deltaTime);
			if (TrafficWaitTimer == 0f)
			{
				if (TrafficNumber >= TrafficWays)
				{
					TrafficNumber = 0;
				}
				TrafficNumber++;
				TrafficTimer = TrafficTime;
				TrafficWaitTimer = 3f;
			}
		}
		TrafficController();
	}

	private void TrafficController()
	{
		for (int i = 0; i < trafficNumbers.Length; i++)
		{
			for (int j = 0; j < trafficMode.Length; j++)
			{
				int num = 1 << j;
				if ((trafficNumbers[i] & num) != 0 && waysConnected[j] != null)
				{
					if (TrafficWaitTimer == 3f)
					{
						waysConnected[j].trafficMode = ((TrafficNumber - 1 == i) ? TrafficMode.Go : TrafficMode.Stop);
					}
					else
					{
						waysConnected[j].trafficMode = TrafficMode.Wait;
					}
					waysConnected[j].trafficNode = true;
				}
			}
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawSphere(base.transform.position, 2f);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(base.transform.position, stopDistance);
		Gizmos.color = Color.blue;
		if ((bool)way1 && ways > 0)
		{
			Gizmos.DrawCube(way1.position, Vector3.one * 2f);
			Gizmos.DrawIcon(way1.TransformPoint(Vector3.up), (way1Mode == 0) ? "OneWay" : "TwoWay", false);
		}
		if ((bool)way2 && ways > 1)
		{
			Gizmos.DrawCube(way2.position, Vector3.one * 2f);
			Gizmos.DrawIcon(way2.TransformPoint(Vector3.up), (way2Mode == 0) ? "OneWay" : "TwoWay", false);
		}
		if ((bool)way3 && ways > 2)
		{
			Gizmos.DrawCube(way3.position, Vector3.one * 2f);
			Gizmos.DrawIcon(way3.TransformPoint(Vector3.up), (way3Mode == 0) ? "OneWay" : "TwoWay", false);
		}
		if ((bool)way4 && ways > 3)
		{
			Gizmos.DrawCube(way4.position, Vector3.one * 2f);
			Gizmos.DrawIcon(way4.TransformPoint(Vector3.up), (way4Mode == 0) ? "OneWay" : "TwoWay", false);
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
