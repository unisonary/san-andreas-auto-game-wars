using System;
using System.Collections.Generic;
using UnityEngine;

public class CarComponents : MonoBehaviour
{
	[Serializable]
	public class CameraViewSetting
	{
		public List<Transform> cameraViews;

		public float distance = 5f;

		public float height = 1f;

		public float Angle = 20f;
	}

	public Transform handleTrigger;

	public Transform door;

	public Transform handleTriggerright;

	public Transform Rightdoor;

	public Transform sitPoint;

	public Transform driver;

	public AudioClip[] deathSoundClips;

	public CameraViewSetting cameraViewSetting;

	[HideInInspector]
	public bool driving = true;

	[Range(0f, 100f)]
	public int CarHealth = 100;

	public GameObject Carsounds;

	public Animator _sitAnimObj;

	private void Update()
	{
		if (!driver)
		{
			return;
		}
		if (driving)
		{
			driver.position = sitPoint.position;
			driver.rotation = sitPoint.rotation;
			return;
		}
		if (_sitAnimObj != null)
		{
			_sitAnimObj.enabled = false;
		}
		driver.position = handleTrigger.position;
		driver.rotation = handleTrigger.rotation;
		Component[] componentsInChildren = driver.GetComponentsInChildren(typeof(Rigidbody));
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			((Rigidbody)componentsInChildren[i]).isKinematic = false;
		}
		componentsInChildren = driver.GetComponentsInChildren(typeof(Collider));
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			((Collider)componentsInChildren[i]).enabled = true;
		}
		driver.GetComponent<AudioSource>().clip = deathSoundClips[UnityEngine.Random.Range(0, deathSoundClips.Length)];
		driver.GetComponent<AudioSource>().Play();
		UnityEngine.Object.Destroy(driver.gameObject, 10f);
		driver.parent = null;
		driver = null;
	}

	private void OnTriggerEnter(Collider _obj)
	{
		if (_obj.gameObject.transform.tag == "watersurface" && base.transform.tag != "streamer" && GetComponent<AIVehicle>().vehicleStatus == VehicleStatus.Player)
		{
			Debug.LogError(_obj.transform.tag + " bikecomponent " + base.transform.tag + " : " + base.transform.name);
			GameControl.CarGetDownForce = true;
			handleTrigger.gameObject.SetActive(false);
			handleTriggerright.gameObject.SetActive(false);
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
