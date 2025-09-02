using UnityEngine;

public class PoliceBehaviour : MonoBehaviour
{
	private Transform target;

	private Vector3 targetPosition;

	private ThirdPersonCharacter character;

	private bool startWalk;

	private float speed = 0.5f;

	private float defaultSpeed = 0.5f;

	private bool reduceSpeed;

	public float life;

	public AudioClip[] deathSoundClips;

	public GameObject playerRoot;

	public GameObject PassingRayCastsParent;

	private int randomNum = 10;

	private bool playerShooting;

	private bool callonce = true;

	private bool HitPlayer;

	public Animator policeAnimator;

	private bool anim1 = true;

	private bool anim2;

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

	private void Update()
	{
		if (!startWalk || !PlayerBehaviour.isCriminal)
		{
			return;
		}
		targetPosition = target.position;
		Vector3 direction = targetPosition - base.transform.position;
		character.Move(target.InverseTransformDirection(direction) * speed, false, false);
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
			speed = defaultSpeed;
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

	public void punchagain_police()
	{
		Debug.Log("Punch...police-----------------------------------------");
		if (HitPlayer)
		{
			policeAnimator.ForceStateNormalizedTime(0f);
			policeAnimator.SetFloat("policestatus", 2f);
			policeAnimator.Play("police_punching");
		}
	}

	public void punchagain_police2()
	{
		Debug.Log("Punch...police2-----------------------------------------");
		policeAnimator.ForceStateNormalizedTime(0f);
		policeAnimator.SetFloat("policestatus", 1f);
		policeAnimator.Play("police_punching");
	}

	private void OnTriggerEnter(Collider collider)
	{
		if (collider.CompareTag("Player") && PlayerBehaviour.isCriminal)
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

	private void HitThePlayer()
	{
		if (HitPlayer && anim1)
		{
			anim1 = false;
			anim2 = !anim1;
			Debug.Log("hit.................");
			policeAnimator.ForceStateNormalizedTime(0f);
			policeAnimator.SetFloat("policestatus", 1f);
			policeAnimator.Play("police_punching");
			AIContoller.manager.player.gameObject.GetComponent<PlayerBehaviour>().Damage(10f);
		}
		else
		{
			GetComponent<Animator>().SetBool("Hitt", false);
		}
	}

	private void HitThePlayer2()
	{
		if (HitPlayer && anim2)
		{
			anim2 = false;
			anim1 = !anim2;
			Debug.Log("hit2.................");
			policeAnimator.ForceStateNormalizedTime(0f);
			policeAnimator.SetFloat("policestatus", 2f);
			AIContoller.manager.player.gameObject.GetComponent<PlayerBehaviour>().Damage(1f);
		}
		else
		{
			GetComponent<Animator>().SetBool("Hitt", false);
		}
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
		Debug.Log("pdie...." + amount);
		life -= amount;
		if (life <= 0f)
		{
			Die();
			PlayerBehaviour.isCriminal = true;
		}
	}

	public void Die()
	{
		Debug.Log("pdie....");
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
