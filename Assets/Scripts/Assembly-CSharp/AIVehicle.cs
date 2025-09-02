using UnityEngine;

public class AIVehicle : MonoBehaviour
{
	public VehicleStatus vehicleStatus = VehicleStatus.Player;

	public float forwardSpeed = 1f;

	public float steerSpeed = 1f;

	public float nextNodeDistance = 10f;

	public float rayCastLentgh = 1f;

	public float rayCastBackLentgh = 1f;

	public float rayCastAngle = 1f;

	public bool drawGozmos = true;

	public Transform raycastPoint;

	public LayerMask layerMask;

	[HideInInspector]
	public bool trafficStop;

	[HideInInspector]
	public bool AIActive = true;

	[HideInInspector]
	public Transform currentNode;

	[HideInInspector]
	public Transform lastNode;

	[HideInInspector]
	public Transform nextNode;

	[HideInInspector]
	public WayMove wayMove = WayMove.Center;

	[HideInInspector]
	public string myStatue;

	[HideInInspector]
	public float AIAccel;

	[HideInInspector]
	public float AISteer;

	[HideInInspector]
	public bool AIBrake;

	[HideInInspector]
	public bool oneWay;

	[HideInInspector]
	public float widthDistance;

	[HideInInspector]
	public float minWidthDistance;

	[HideInInspector]
	public float maxWidthDistance;

	[HideInInspector]
	public float vehicleSpeed;

	[HideInInspector]
	public AudioSource horn;

	[HideInInspector]
	public bool automaticGear;

	[HideInInspector]
	public bool neutralGear;

	[HideInInspector]
	public int currentGear;

	[HideInInspector]
	public float motorRPM;

	[HideInInspector]
	public float powerShift;

	private float waitingTime;

	private float raycastSteer;

	private float currentFwdSpeed;

	private float stopTimer;

	private float targetAngle;

	private int randomWays;

	private bool wayActive;

	private bool waysActive;

	private bool RearGear;

	private Transform player;

	private Node nodeComponenet;

	private float hittingTimer;

	private RaycastHit raycastHit;

	private AIVehicle _aivehicle;

	private float lentgh;

	private float rotate;

	private bool hitting;

	private float RightHitDistance;

	private float LeftHitDistance;

	public Vector3 relativeTarget;

	private WaysControl waysScript;

	private void Start()
	{
		player = AIContoller.manager.player;
		currentFwdSpeed = forwardSpeed;
		if (vehicleStatus == VehicleStatus.AI)
		{
			AIActive = true;
			if ((bool)currentNode && currentNode.GetComponent<Node>().mode == "OnWay")
			{
				oneWay = true;
			}
		}
		else
		{
			AIActive = false;
		}
	}

	private void Update()
	{
		if (!AIActive)
		{
			return;
		}
		AIBrake = false;
		trafficStop = false;
		currentFwdSpeed = forwardSpeed;
		if (raycastSteer > 0f)
		{
			raycastSteer = Mathf.SmoothStep(raycastSteer, 0f, Time.deltaTime * 10f);
		}
		lentgh = 0f;
		rotate = 0f;
		hitting = false;
		RightHitDistance = 0f;
		LeftHitDistance = 0f;
		for (int i = 0; i < 6; i++)
		{
			switch (i)
			{
			case 0:
				rotate = -1f;
				lentgh = 7f;
				break;
			case 1:
				rotate = 0f;
				lentgh = 10f;
				break;
			case 2:
				rotate = 1f;
				lentgh = 7f;
				break;
			case 3:
				rotate = -3f;
				lentgh = 6f;
				break;
			case 4:
				rotate = 0f;
				lentgh = 0f - rayCastBackLentgh;
				break;
			case 5:
				rotate = 3f;
				lentgh = 6f;
				break;
			}
			if (!Physics.Raycast(raycastPoint.TransformPoint(Mathf.Repeat(i, 3f) - 1f, 0f, 0f), raycastPoint.TransformDirection(rotate * rayCastAngle, 0f, lentgh * rayCastLentgh), out raycastHit, lentgh * rayCastLentgh, layerMask.value))
			{
				continue;
			}
			hitting = true;
			switch (i)
			{
			case 0:
			case 3:
				LeftHitDistance = 10f - raycastHit.distance;
				if (vehicleSpeed > 10f)
				{
					currentFwdSpeed -= 1f;
				}
				if (!(raycastHit.distance < 0.5f))
				{
					break;
				}
				if (waitingTime == 0f && !RearGear)
				{
					waitingTime = Random.Range(2f, 5f);
					if ((bool)horn)
					{
						horn.Play();
					}
				}
				RearGear = true;
				break;
			case 1:
				LeftHitDistance = 5f;
				if (!(raycastHit.distance < lentgh / 2f))
				{
					break;
				}
				if (waitingTime == 0f && !RearGear)
				{
					waitingTime = Random.Range(5f, 10f);
					if ((bool)horn)
					{
						horn.Play();
					}
				}
				RearGear = true;
				break;
			case 4:
				if (vehicleSpeed > 0f)
				{
					AIBrake = true;
				}
				break;
			case 2:
			case 5:
				RightHitDistance = -10f + raycastHit.distance;
				if (vehicleSpeed > 10f)
				{
					currentFwdSpeed -= 1f;
				}
				if (!(raycastHit.distance < 0.5f))
				{
					break;
				}
				if (waitingTime == 0f && !RearGear)
				{
					waitingTime = Random.Range(2.5f, 5f);
					if ((bool)horn)
					{
						horn.Play();
					}
				}
				RearGear = true;
				break;
			}
			_aivehicle = raycastHit.transform.root.GetComponent<AIVehicle>();
			if ((bool)_aivehicle && _aivehicle.trafficStop && Quaternion.Dot(base.transform.rotation, raycastHit.transform.root.rotation) > 0.5f)
			{
				AIBrake = _aivehicle.AIBrake;
			}
		}
		if (Vector3.Distance(raycastPoint.position, player.position) < 5f)
		{
			AIBrake = true;
		}
		if (RearGear)
		{
			if (waitingTime == 0f)
			{
				if (hitting)
				{
					if (stopTimer != 3f)
					{
						stopTimer = Mathf.MoveTowards(stopTimer, 3f, Time.deltaTime);
						AIBrake = true;
					}
					hittingTimer = 0f;
				}
				else
				{
					hittingTimer = Mathf.MoveTowards(hittingTimer, 1f, Time.deltaTime);
					if (hittingTimer == 1f)
					{
						stopTimer = 0f;
						RearGear = false;
					}
				}
			}
			else
			{
				waitingTime = Mathf.Lerp(waitingTime, 0f, Time.deltaTime);
			}
		}
		if (!AIBrake && !RearGear)
		{
			AIAccel = currentFwdSpeed / 50f;
		}
		else if (stopTimer == 3f)
		{
			AIAccel = (0f - currentFwdSpeed) / 100f;
		}
		else
		{
			AIAccel = 0f;
		}
		raycastSteer = Mathf.SmoothStep(raycastSteer, (RightHitDistance + LeftHitDistance) * 50f, Time.deltaTime * 5f);
		if (stopTimer != 0f)
		{
			AISteer = Mathf.SmoothStep(AISteer, (0f - targetAngle) / 40f, steerSpeed / 3f);
		}
		else
		{
			AISteer = Mathf.SmoothStep(AISteer, targetAngle / 60f, steerSpeed / 3f);
		}
		if (nextNode != null)
		{
			AIControl();
			relativeTarget = base.transform.InverseTransformPoint(nextNode.position);
			targetAngle = Mathf.Atan2(relativeTarget.x + widthDistance, relativeTarget.z);
			targetAngle *= 57.29578f;
			targetAngle = Mathf.Clamp(targetAngle + raycastSteer, -65f, 65f);
		}
	}

	public void widthDistanceRefrash(Node node)
	{
		if (!(node != null))
		{
			return;
		}
		if (oneWay)
		{
			if (maxWidthDistance != node.widthDistance)
			{
				maxWidthDistance = node.widthDistance;
				widthDistance = Random.Range(0f - node.widthDistance, node.widthDistance);
			}
			return;
		}
		minWidthDistance = 3f;
		if (maxWidthDistance != node.widthDistance)
		{
			maxWidthDistance = Mathf.Clamp(node.widthDistance, 3f, 20f);
			widthDistance = Random.Range(minWidthDistance, maxWidthDistance);
		}
	}

	private void AIControl()
	{
		if ((bool)nextNode && Vector3.Distance(raycastPoint.position, nextNode.position) < nextNodeDistance && nextNode != currentNode)
		{
			currentNode = nextNode;
		}
		if (!currentNode)
		{
			return;
		}
		waysScript = currentNode.GetComponent<WaysControl>();
		if ((bool)waysScript)
		{
			if (!waysActive)
			{
				nextNode = RandomWay(nextNode, waysScript.ways);
				waysActive = true;
			}
			return;
		}
		nodeComponenet = currentNode.GetComponent<Node>();
		widthDistanceRefrash(currentNode.GetComponent<Node>());
		if ((bool)nodeComponenet && ((nodeComponenet.nodeState == "NextPoint" && myStatue == "PreviousPoint") || (nodeComponenet.nodeState == "PreviousPoint" && myStatue == "NextPoint")) && nodeComponenet.trafficMode != TrafficMode.Go)
		{
			trafficStop = true;
			AIBrake = true;
			currentFwdSpeed = -1f;
		}
		if (wayMove == WayMove.Right)
		{
			lastNode = currentNode;
			nextNode = nodeComponenet.nextNode;
		}
		else if (wayMove == WayMove.Left)
		{
			lastNode = currentNode;
			nextNode = nodeComponenet.previousNode;
		}
		waysActive = false;
	}

	private Transform RandomWay(Transform node, int maxWays)
	{
		WaysControl waysControl = waysScript;
		while (!wayActive)
		{
			if (maxWays == 1)
			{
				randomWays = 1;
				wayActive = true;
				continue;
			}
			randomWays = Random.Range(1, maxWays + 1);
			switch (randomWays)
			{
			case 1:
				if (waysControl.way1 != lastNode)
				{
					oneWay = ((waysControl.way1Mode == 0) ? true : false);
					if (int.Parse(waysControl.way1.name) > 1)
					{
						wayMove = WayMove.Left;
					}
					else
					{
						wayMove = WayMove.Right;
					}
					node = waysControl.way1;
					myStatue = waysControl.way1.GetComponent<Node>().nodeState;
					wayActive = true;
				}
				break;
			case 2:
				if (waysControl.way2 != lastNode)
				{
					oneWay = ((waysControl.way2Mode == 0) ? true : false);
					if (int.Parse(waysControl.way2.name) > 1)
					{
						wayMove = WayMove.Left;
					}
					else
					{
						wayMove = WayMove.Right;
					}
					node = waysControl.way2;
					myStatue = waysControl.way2.GetComponent<Node>().nodeState;
					wayActive = true;
				}
				break;
			case 3:
				if (waysControl.way3 != lastNode)
				{
					oneWay = ((waysControl.way3Mode == 0) ? true : false);
					if (int.Parse(waysControl.way3.name) > 1)
					{
						wayMove = WayMove.Left;
					}
					else
					{
						wayMove = WayMove.Right;
					}
					node = waysControl.way3;
					myStatue = waysControl.way3.GetComponent<Node>().nodeState;
					wayActive = true;
				}
				break;
			case 4:
				if (waysControl.way4 != lastNode)
				{
					oneWay = ((waysControl.way4Mode == 0) ? true : false);
					if (int.Parse(waysControl.way4.name) > 1)
					{
						wayMove = WayMove.Left;
					}
					else
					{
						wayMove = WayMove.Right;
					}
					node = waysControl.way4;
					myStatue = waysControl.way4.GetComponent<Node>().nodeState;
					wayActive = true;
				}
				break;
			}
		}
		wayActive = false;
		maxWidthDistance -= 0.1f;
		if (lastNode != null)
		{
			widthDistanceRefrash(lastNode.GetComponent<Node>());
		}
		return node;
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
