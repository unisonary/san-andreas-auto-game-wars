using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
	public enum DoForce
	{
		AtStart = 0,
		InFixedUpdate = 1
	}

	public float force = 2000f;

	public DoForce addForce;

	private Rigidbody rb;

	public float damage = 70f;

	public float explosionForce = 1000f;

	public float explosionRadius = 30f;

	public GameObject particle;

	public GameObject trail;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		if (addForce == DoForce.AtStart)
		{
			rb.AddForce(base.transform.forward * force, ForceMode.Acceleration);
		}
	}

	private void FixedUpdate()
	{
		if (addForce == DoForce.InFixedUpdate)
		{
			rb.AddForce(base.transform.forward * force, ForceMode.Acceleration);
		}
	}

	private void OnCollisionEnterAsd(Collision _obj)
	{
		string text = _obj.transform.tag;
		Debug.Log(text + "   ---- tag " + _obj.transform.name);
		if (text == "Vehicle")
		{
			if ((bool)_obj.transform.GetComponent<VehicleHealth>())
			{
				_obj.transform.gameObject.GetComponent<VehicleHealth>().OnShootVehicle(100);
			}
		}
		else if (base.tag == "Human")
		{
			if ((bool)_obj.transform.GetComponent<AICharacterControl>())
			{
				_obj.transform.GetComponent<AICharacterControl>().Damage(40f);
			}
		}
		else if (base.tag == "Police" && (bool)_obj.transform.GetComponent<PoliceBehaviour>())
		{
			_obj.transform.GetComponent<PoliceBehaviour>().Damage(40f);
		}
		Object.Instantiate(particle, base.transform.position, Quaternion.identity);
		Object.Destroy(base.gameObject);
	}

	private void OnCollisionEnter()
	{
		Collider[] array = Physics.OverlapSphere(base.transform.position, explosionRadius);
		for (int i = 0; i < array.Length; i++)
		{
			Debug.Log(array[i].gameObject.name + " colliderrr... " + array[i].gameObject.tag);
			Rigidbody component = array[i].GetComponent<Rigidbody>();
			if ((bool)component)
			{
				if (array[i].gameObject.CompareTag("Vehicle") && array[i].gameObject.name == "helicopter")
				{
					array[i].gameObject.GetComponent<BlastingEffect>().Explod();
					return;
				}
				Debug.Log(component.gameObject.name + " r");
				PlayerBehaviour component2 = component.GetComponent<PlayerBehaviour>();
				AICharacterControl component3 = component.GetComponent<AICharacterControl>();
				VehicleHealth component4 = component.GetComponent<VehicleHealth>();
				if ((bool)component3)
				{
					component3.Damage(damage / Vector3.Distance(base.transform.position, component3.transform.position));
				}
				if ((bool)component2)
				{
					component2.Damage(damage / Vector3.Distance(base.transform.position, component2.transform.position));
					if (!component2.ragdollh.ragdolled)
					{
						component2.ToggleRagdoll();
					}
				}
				if ((bool)component4)
				{
					Debug.Log(component4.gameObject.name + " : name");
					component4.OnShootVehicle(100);
				}
				component.AddExplosionForce(explosionForce, base.transform.position, explosionRadius);
			}
			else if (array[i].gameObject.CompareTag("Vehicle") && array[i].gameObject.name == "helicopter")
			{
				array[i].gameObject.GetComponent<BlastingEffect>().Explod();
			}
		}
		Object.Instantiate(particle, base.transform.position, Quaternion.identity);
		if ((bool)trail)
		{
			trail.transform.parent = null;
		}
		Object.Destroy(base.gameObject);
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
