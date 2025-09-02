using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
	private Transform target;

	public Vector3 targetPosition;

	private ThirdPersonCharacter character;

	private bool startWalk;

	private float speed = 0.5f;

	private float defaultSpeed = 0.5f;

	private bool reduceSpeed;

	public float life;

	public AudioClip[] deathSoundClips;

	public GameObject playerRoot;

	public GameObject PassingRayCastsParent;

	public int randomNum = 10;

	private bool playerShooting;

	public bool ISHeroCame;

	public bool CanRun = true;

	public float _dist;

	public float _ypos = 80f;

	private bool CannShoot = true;

	public GameObject Enemy_health;

	public ParticleSystem FireEffect;

	private bool callonce = true;

	private bool HitPlayer;

	public Animator policeAnimator;

	private bool anim1 = true;

	private bool anim2;

	private bool CheckOnce = true;

	public GameObject PlayerCollider;

	public GameObject MstarObj;

	private void Awake()
	{
		target = GameObject.FindGameObjectWithTag("Player").transform;
		character = GetComponent<ThirdPersonCharacter>();
		speed = defaultSpeed;
	}

	private void OnEnable()
	{
		StartWalk();
	}

	private void resetshoot()
	{
		CannShoot = true;
	}

	private void Update()
	{
		if (!startWalk || !ISHeroCame)
		{
			return;
		}
		targetPosition = target.position;
		Vector3 vector = base.transform.TransformDirection(Vector3.forward) * 50f;
		Debug.DrawRay(base.transform.position, vector, Color.red);
		Vector3 vector2 = base.transform.position + new Vector3(0f, _ypos, 0f);
		RaycastHit hitInfo;
		if (Physics.Raycast(vector2, vector, out hitInfo, _dist) && playerShooting)
		{
			if ((hitInfo.transform.tag == "Player" || hitInfo.transform.tag == "Vehicle") && CannShoot)
			{
				Debug.Log(hitInfo.transform.name + " : " + hitInfo.transform.tag);
				CannShoot = false;
				FireEffect.Play();
				if (hitInfo.transform.tag == "Player")
				{
					decreasePlayerHealth();
				}
				else if (hitInfo.transform.tag == "Vehicle")
				{
					AIContoller.manager.player.transform.root.gameObject.GetComponent<VehicleHealth>().OnShootVehicle(10);
				}
				Invoke("resetshoot", 2f);
			}
			Debug.DrawLine(vector2, hitInfo.point, Color.yellow);
		}
		Vector3 direction = targetPosition - base.transform.position;
		if (CanRun)
		{
			character.Move(target.InverseTransformDirection(direction) * speed, false, false);
		}
		float num = Vector3.Distance(base.transform.position, target.transform.position);
		if (num <= (float)randomNum && !playerShooting)
		{
			reduceSpeed = true;
			speed -= 0.1f;
			speed = Mathf.Max(0f, speed);
			if (!PassingRayCastsParent.gameObject.activeInHierarchy)
			{
				Debug.Log("enabling...");
				PassingRayCastsParent.gameObject.SetActive(true);
			}
			playerShooting = true;
			if (playerShooting)
			{
				base.transform.GetComponent<Animator>().ForceStateNormalizedTime(0f);
				base.transform.GetComponent<Animator>().SetFloat("policefireStatus", 1f);
				base.transform.GetComponent<Animator>().SetBool("policefire", true);
				base.transform.GetComponent<Animator>().Play("policefiring", 0);
			}
			Debug.Log("look target.....");
		}
		if (num > (float)randomNum)
		{
			playerShooting = false;
			reduceSpeed = false;
			speed = 50f;
			if (PassingRayCastsParent.gameObject.activeInHierarchy)
			{
				PassingRayCastsParent.gameObject.SetActive(false);
				base.transform.GetComponent<Animator>().SetBool("policefire", false);
			}
		}
		base.transform.LookAt(target);
	}

	private void StartWalk()
	{
		startWalk = true;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.CompareTag("Vehicle") && collision.rigidbody.velocity.magnitude > 10f)
		{
			Die();
		}
	}

	private void OnTriggerEnter(Collider collider)
	{
		if (collider.CompareTag("Player") && ISHeroCame)
		{
			Debug.Log("Police reached Player");
			reduceSpeed = true;
		}
	}

	private void OnTriggerStay(Collider collider)
	{
		if (reduceSpeed)
		{
			speed -= 0.1f;
			speed = Mathf.Max(0f, speed);
		}
	}

	public void decreasePlayerHealth()
	{
		AIContoller.manager.player.gameObject.GetComponent<PlayerBehaviour>().Damage(10f);
	}

	private void OnTriggerExit(Collider collider)
	{
		if (reduceSpeed)
		{
			HitPlayer = false;
			reduceSpeed = false;
			speed = defaultSpeed;
			callonce = true;
		}
	}

	public void Damage(float amount)
	{
		Debug.LogError("damage " + amount);
		life -= amount;
		Enemy_health.transform.localScale = new Vector3(life * 0.01f, 1f, 1f);
		if (life <= 0f)
		{
			Die();
		}
	}

	private void CheckComplete()
	{
		LevelManager.mee.killEnemies_count--;
		if (LevelManager.mee.killEnemies_count <= 0)
		{
			MstarObj.GetComponent<StarObj>().OnTriggerEnter(PlayerCollider.GetComponent<Collider>());
		}
		CheckOnce = false;
	}

	public void Die()
	{
		Enemy_health.transform.localScale = new Vector3(0f, 1f, 1f);
		Debug.LogError("damage -----");
		Object.Destroy(GetComponent<PoliceBehaviour>());
		GetComponent<Rigidbody>().isKinematic = true;
		base.transform.GetComponent<Collider>().isTrigger = true;
		base.transform.GetComponent<Animator>().enabled = false;
		GetComponent<ThirdPersonCharacter>().enabled = false;
		DisableRagdoll(true);
		GetComponent<AudioSource>().clip = deathSoundClips[Random.Range(0, deathSoundClips.Length)];
		GetComponent<AudioSource>().Play();
		if (PassingRayCastsParent.gameObject.activeInHierarchy)
		{
			PassingRayCastsParent.gameObject.SetActive(false);
			base.transform.GetComponent<Animator>().SetBool("policefire", false);
		}
		Object.Destroy(base.gameObject, 10f);
		PlayerBehaviour.isCriminal = true;
		if (CheckOnce)
		{
			CheckComplete();
		}
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
