using UnityEngine;
using UnityEngine.AI;

public class CreateAI : MonoBehaviour
{
	public LayerMask nodeMask = -1;

	public float InstantiateTime = 2f;

	private float vehicleTimer;

	private float humanTimer;

	public bool createVehicles = true;

	public bool createHumans = true;

	private AIContoller AICScript;

	private GameObject AiVehicleCreated;

	private GameObject AIVehicle;

	private float offsetDistance = 25f;

	private int randomWay;

	private RaycastHit hit;

	private Node CurrentNode;

	public static CreateAI mee;

	public Transform Human_Holder;

	public Transform vehicle_holder;

	private int numm;

	private GameObject Humann;

	private float Dist;

	private void Start()
	{
		mee = this;
	}

	public void CreateEnemyVehicles_OnSide(GameObject _pos)
	{
		AIVehicle = AIContoller.manager.vehiclesPrefabs[Random.Range(0, 1)];
		AiVehicleCreated = Object.Instantiate(AIVehicle, _pos.transform.position, _pos.transform.localRotation);
		AiVehicleCreated.name = "AIVehicle_Enemy";
		AiVehicleCreated.GetComponent<DestroyGameObject>().enabled = false;
		AiVehicleCreated.GetComponent<RadarObj>().NeedRadarIcon = true;
		AiVehicleCreated.GetComponent<AIVehicle>().vehicleStatus = VehicleStatus.EmptyOff;
	}

	public void CreateEnemyVehicles(Node _CurrentNode)
	{
		Physics.OverlapSphere(CurrentNode.transform.position, offsetDistance);
		AIVehicle = AIContoller.manager.vehiclesPrefabs[Random.Range(0, 1)];
		if (!AIVehicle)
		{
			return;
		}
		if (Physics.Raycast(_CurrentNode.transform.position, -Vector3.up, out hit))
		{
			AIContoller.manager.currentVehicles++;
			Debug.Log(string.Concat(CurrentNode, " boat ", CurrentNode.transform.parent, " : ", CurrentNode.transform.parent.tag));
			if (_CurrentNode.transform.parent.CompareTag("Water"))
			{
				AIVehicle = AIContoller.manager.BoatPrefabs[Random.Range(0, AIContoller.manager.BoatPrefabs.Length)];
				AiVehicleCreated = Object.Instantiate(AIVehicle, hit.point + Vector3.up / 2f, Quaternion.identity);
			}
			else
			{
				Debug.LogError(string.Concat(_CurrentNode, " -- ", _CurrentNode.transform.parent, " : ", _CurrentNode.transform.parent.tag));
				AiVehicleCreated = Object.Instantiate(AIVehicle, hit.point + Vector3.up / 2f, Quaternion.identity);
			}
		}
		AiVehicleCreated.name = "AIVehicle_Enemy";
		AiVehicleCreated.GetComponent<DestroyGameObject>().enabled = false;
		AiVehicleCreated.GetComponent<RadarObj>().NeedRadarIcon = true;
		if (!AiVehicleCreated.GetComponent<AIVehicle>())
		{
			return;
		}
		AIVehicle component = AiVehicleCreated.GetComponent<AIVehicle>();
		if (_CurrentNode.mode == "TwoWay")
		{
			randomWay = Random.Range(1, 3);
			if (randomWay == 1)
			{
				component.wayMove = WayMove.Left;
				component.myStatue = "NextPoint";
				AiVehicleCreated.transform.LookAt(_CurrentNode.previousNode);
				component.currentNode = _CurrentNode.transform;
				component.nextNode = _CurrentNode.nextNode;
				AiVehicleCreated.transform.position = AiVehicleCreated.transform.TransformPoint(_CurrentNode.widthDistance, 0f, 0f);
			}
			else
			{
				component.wayMove = WayMove.Right;
				component.myStatue = "PreviousPoint";
				AiVehicleCreated.transform.LookAt(_CurrentNode.nextNode);
				component.currentNode = _CurrentNode.transform;
				component.nextNode = _CurrentNode.previousNode;
				AiVehicleCreated.transform.position = AiVehicleCreated.transform.TransformPoint(_CurrentNode.widthDistance, 0f, 0f);
			}
		}
		else
		{
			component.wayMove = WayMove.Right;
			component.myStatue = "PreviousPoint";
			AiVehicleCreated.transform.LookAt(_CurrentNode.nextNode);
			component.currentNode = _CurrentNode.transform;
			component.nextNode = _CurrentNode.nextNode;
			AiVehicleCreated.transform.position = AiVehicleCreated.transform.TransformPoint(Random.Range(0f - _CurrentNode.widthDistance, _CurrentNode.widthDistance) / 2f, 0f, 0f);
		}
	}

	public void InstantiateVehicle(Collider _CurrentNode)
	{
		if (vehicle_holder.childCount > AIContoller.manager.maxVehicles)
		{
			return;
		}
		CurrentNode = _CurrentNode.GetComponent<Node>();
		Collider[] array = Physics.OverlapSphere(CurrentNode.transform.position, offsetDistance);
		bool flag = true;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].CompareTag("Vehicle"))
			{
				flag = false;
			}
		}
		AIVehicle = AIContoller.manager.vehiclesPrefabs[Random.Range(0, AIContoller.manager.vehiclesPrefabs.Length)];
		if (!AIVehicle || !flag || AIContoller.manager.currentVehicles >= AIContoller.manager.maxVehicles)
		{
			return;
		}
		if (Physics.Raycast(CurrentNode.transform.position, -Vector3.up, out hit))
		{
			AIContoller.manager.currentVehicles++;
			if (CurrentNode.transform.parent.CompareTag("Water"))
			{
				AIVehicle = AIContoller.manager.BoatPrefabs[Random.Range(0, AIContoller.manager.BoatPrefabs.Length)];
				Debug.Log(string.Concat(AIVehicle, "---"));
				AiVehicleCreated = Object.Instantiate(AIVehicle, hit.point + Vector3.up / 2f, Quaternion.identity);
			}
			else
			{
				AiVehicleCreated = Object.Instantiate(AIVehicle, hit.point + Vector3.up / 2f, Quaternion.identity);
			}
			AiVehicleCreated.transform.parent = vehicle_holder;
		}
		AiVehicleCreated.name = "AIVehicle";
		if (!AiVehicleCreated.GetComponent<AIVehicle>())
		{
			return;
		}
		AIVehicle component = AiVehicleCreated.GetComponent<AIVehicle>();
		if (CurrentNode.mode == "TwoWay")
		{
			randomWay = Random.Range(1, 3);
			if (randomWay == 1)
			{
				component.wayMove = WayMove.Left;
				component.myStatue = "NextPoint";
				AiVehicleCreated.transform.LookAt(CurrentNode.previousNode);
				component.currentNode = CurrentNode.transform;
				component.nextNode = CurrentNode.nextNode;
				AiVehicleCreated.transform.position = AiVehicleCreated.transform.TransformPoint(CurrentNode.widthDistance, 0f, 0f);
			}
			else
			{
				component.wayMove = WayMove.Right;
				component.myStatue = "PreviousPoint";
				AiVehicleCreated.transform.LookAt(CurrentNode.nextNode);
				component.currentNode = CurrentNode.transform;
				component.nextNode = CurrentNode.previousNode;
				AiVehicleCreated.transform.position = AiVehicleCreated.transform.TransformPoint(CurrentNode.widthDistance, 0f, 0f);
			}
		}
		else
		{
			component.wayMove = WayMove.Right;
			component.myStatue = "PreviousPoint";
			AiVehicleCreated.transform.LookAt(CurrentNode.nextNode);
			component.currentNode = CurrentNode.transform;
			component.nextNode = CurrentNode.nextNode;
			AiVehicleCreated.transform.position = AiVehicleCreated.transform.TransformPoint(Random.Range(0f - CurrentNode.widthDistance, CurrentNode.widthDistance) / 2f, 0f, 0f);
		}
	}

	private void CeateAIHuman(GameObject AIHuman)
	{
		NavMeshHit navMeshHit;
		if (!NavMesh.SamplePosition(Random.insideUnitSphere * 200f + base.transform.position, out navMeshHit, 200f, -1))
		{
			return;
		}
		Collider[] array = Physics.OverlapSphere(navMeshHit.position, 25f);
		bool flag = true;
		Collider[] array2 = array;
		foreach (Collider collider in array2)
		{
			if (collider.CompareTag("Human") || collider.CompareTag("Vehicle"))
			{
				flag = false;
			}
		}
		if (flag && AIContoller.manager.currentHumans < AIContoller.manager.maxHumans && Human_Holder.transform.childCount <= AIContoller.manager.maxHumans)
		{
			AIContoller.manager.currentHumans++;
			numm++;
			Humann = Object.Instantiate(AIHuman, navMeshHit.position, Quaternion.identity);
			Humann.name = "hname" + numm;
			Humann.transform.parent = Human_Holder;
		}
	}

	private void Awake()
	{
		AICScript = AIContoller.manager;
	}

	private void Update()
	{
		if (createHumans && AIContoller.manager.humansPrefabs.Length != 0)
		{
			if (humanTimer == 0f)
			{
				CeateAIHuman(AIContoller.manager.humansPrefabs[Random.Range(0, AIContoller.manager.humansPrefabs.Length)]);
				humanTimer = InstantiateTime;
			}
			else
			{
				humanTimer = Mathf.MoveTowards(humanTimer, 0f, Time.deltaTime);
			}
		}
		if (!createVehicles)
		{
			return;
		}
		if (vehicleTimer == 0f)
		{
			Collider[] array = Physics.OverlapSphere(base.transform.position, 300f, nodeMask);
			for (int i = 0; i < array.Length; i++)
			{
				Dist = Vector3.Distance(base.transform.position, array[i].transform.position);
				if (Dist < 100f && Dist > 70f && AIContoller.manager.vehiclesPrefabs.Length != 0 && !GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(Camera.main), array[i].bounds))
				{
					InstantiateVehicle(array[i]);
					vehicleTimer = InstantiateTime;
				}
			}
		}
		else
		{
			vehicleTimer = Mathf.MoveTowards(vehicleTimer, 0f, Time.deltaTime);
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
