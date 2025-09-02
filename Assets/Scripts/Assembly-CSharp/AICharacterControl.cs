using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(ThirdPersonCharacter))]
public class AICharacterControl : MonoBehaviour
{
	public Transform playerRoot;

	public AudioClip[] deathSoundClips;

	public float life = 100f;

	private Vector3 minBoundsPoint;

	private Vector3 maxBoundsPoint;

	private float boundsSize = float.NegativeInfinity;

	private bool findTarget;

	public bool Set_Destination = true;

	private Vector3 makeOne = Vector3.one;

	private Vector3[] verticesA;

	private Vector3 _prev;

	private Vector3 _next = Vector3.zero;

	private bool check1;

	public bool runonce = true;

	public NavMeshAgent agent { get; private set; }

	public ThirdPersonCharacter character { get; private set; }

	protected virtual void MuckAbout()
	{
		if (Set_Destination && agent.desiredVelocity.magnitude < 0.1f)
		{
			agent.SetDestination(GetRandomTargetPoint());
		}
	}

	private Vector3 GetRandomTargetPointNew()
	{
		if (_prev == Vector3.zero)
		{
			_prev = base.transform.position;
		}
		else
		{
			_prev = _next;
		}
		return _next = base.transform.position + new Vector3(0f, 0f, 100f);
	}

	private Vector3 GetRandomTargetPoint()
	{
		if (boundsSize < 0f)
		{
			minBoundsPoint = makeOne * float.PositiveInfinity;
			maxBoundsPoint = -minBoundsPoint;
			verticesA = NavMesh.CalculateTriangulation().vertices;
			Vector3[] array = verticesA;
			for (int i = 0; i < array.Length; i++)
			{
				Vector3 vector = array[i];
				if (minBoundsPoint.x > vector.x)
				{
					minBoundsPoint = new Vector3(vector.x, minBoundsPoint.y, minBoundsPoint.z);
				}
				if (minBoundsPoint.y > vector.y)
				{
					minBoundsPoint = new Vector3(minBoundsPoint.x, vector.y, minBoundsPoint.z);
				}
				if (minBoundsPoint.z > vector.z)
				{
					minBoundsPoint = new Vector3(minBoundsPoint.x, minBoundsPoint.y, vector.z);
				}
				if (maxBoundsPoint.x < vector.x)
				{
					maxBoundsPoint = new Vector3(vector.x, maxBoundsPoint.y, maxBoundsPoint.z);
				}
				if (maxBoundsPoint.y < vector.y)
				{
					maxBoundsPoint = new Vector3(maxBoundsPoint.x, vector.y, maxBoundsPoint.z);
				}
				if (maxBoundsPoint.z < vector.z)
				{
					maxBoundsPoint = new Vector3(maxBoundsPoint.x, maxBoundsPoint.y, vector.z);
				}
			}
			boundsSize = Vector3.Distance(minBoundsPoint, maxBoundsPoint);
		}
		NavMeshHit hit;
		NavMesh.SamplePosition(new Vector3(Random.Range(minBoundsPoint.x, maxBoundsPoint.x), Random.Range(minBoundsPoint.y, maxBoundsPoint.y), Random.Range(minBoundsPoint.z, maxBoundsPoint.z)), out hit, boundsSize * 0.01f, 1);
		return hit.position;
	}

	private void Start()
	{
		agent = GetComponentInChildren<NavMeshAgent>();
		character = GetComponent<ThirdPersonCharacter>();
		agent.updateRotation = false;
		agent.updatePosition = true;
		Invoke("disableanim", 1f);
	}

	private void disableanim()
	{
		runonce = false;
	}

	private void DisableRagdoll(bool active)
	{
		Component[] componentsInChildren = playerRoot.GetComponentsInChildren(typeof(Rigidbody));
		Component[] componentsInChildren2 = playerRoot.GetComponentsInChildren(typeof(Collider));
		Component[] array = componentsInChildren;
		for (int i = 0; i < array.Length; i++)
		{
			((Rigidbody)array[i]).isKinematic = !active;
		}
		array = componentsInChildren2;
		for (int i = 0; i < array.Length; i++)
		{
			((Collider)array[i]).enabled = active;
		}
	}

	public void Damage(float amount)
	{
		Debug.Log(amount + " : kil human...........");
		life -= amount;
		if (life <= 0f)
		{
			Die();
			PlayerBehaviour.isCriminal = true;
		}
	}

	public void Die()
	{
		Debug.Log(base.tag + " : kil human...........");
		if (base.tag == "Human" && LevelManager._isKillpeopleMission)
		{
			LevelManager.mee.Personkill_count--;
			Leveldata.mee.Hint_mission[1].text = Leveldata.mee.Personstokill - LevelManager.mee.Personkill_count + "/" + Leveldata.mee.Personstokill;
			Debug.Log(" kill person " + LevelManager.mee.Personkill_count);
			if (LevelManager.mee.Personkill_count <= 0)
			{
				LevelManager._isKillpeopleMission = false;
				Leveldata.mee.Lootcompleted(0, true, true, "Well Done", "Mission Completed");
			}
		}
		if (base.tag == "Police" && LevelManager._isKillPoliceMission)
		{
			LevelManager.mee.policekill_count--;
			if (LevelManager.mee.policekill_count <= 0)
			{
				LevelManager._isKillPoliceMission = false;
				Leveldata.mee.Lootcompleted(0, true, true, "Well Done", "Mission Completed");
			}
		}
		Object.Destroy(GetComponent<AICharacterControl>());
		GetComponent<Rigidbody>().isKinematic = true;
		base.transform.GetComponent<Collider>().isTrigger = true;
		base.transform.GetComponent<Animator>().enabled = false;
		Object.Destroy(agent);
		GetComponent<ThirdPersonCharacter>().enabled = false;
		DisableRagdoll(true);
		GetComponent<AudioSource>().clip = deathSoundClips[Random.Range(0, deathSoundClips.Length)];
		GetComponent<AudioSource>().Play();
		GameObject obj = Object.Instantiate(Resources.Load("Prefabs/Base/Cash")) as GameObject;
		Debug.Log(obj);
		obj.transform.position = new Vector3(base.transform.position.x + 3f, base.transform.position.y + 1f, base.transform.position.z + 3f);
		Object.Destroy(base.gameObject, 10f);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.CompareTag("Vehicle") && collision.rigidbody.velocity.magnitude > 10f)
		{
			Die();
		}
	}

	private void Update()
	{
		if (Set_Destination && agent.enabled && !agent.pathPending)
		{
			MuckAbout();
			if (agent.remainingDistance > agent.stoppingDistance)
			{
				character.Move(agent.desiredVelocity * 0.5f, false, false);
			}
			else
			{
				character.Move(Vector3.zero, false, false);
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
