using System;
using System.Collections.Generic;
using UnityEngine;

public class BikeComponents : MonoBehaviour
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

	public Transform sitPoint;

	public Transform driver;

	public AudioClip[] deathSoundClips;

	[HideInInspector]
	public bool driving = true;

	public CameraViewSetting cameraViewSetting;

	[Range(0f, 100f)]
	public int BikeHealth = 100;

	public GameObject Bikesounds;

	public Animator _sitAnimObj;

	public GameObject[] BoatColiders;

	private void Start()
	{
		if (_sitAnimObj != null)
		{
			_sitAnimObj.enabled = true;
		}
	}

	private void diableanim()
	{
		_sitAnimObj.enabled = false;
	}

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
		if (_obj.gameObject.transform.tag == "watersurface" && base.transform.tag != "streamer")
		{
			Debug.Log(_obj.transform.tag + " bikecomponent " + base.transform.tag);
			GameControl.bikeGetDownForce = true;
			handleTrigger.gameObject.SetActive(false);
			GameControl.manager.getInVehicle.SetActive(false);
		}
		if ((_obj.gameObject.transform.tag == "Grass" || _obj.gameObject.transform.tag == "Ground") && base.transform.tag == "streamer")
		{
			GameControl.bikeGetDownForce = true;
			GameControl.manager.getInVehicle.SetActive(false);
			BoatColiders[0].SetActive(false);
			BoatColiders[1].SetActive(false);
			BoatColiders[2].SetActive(true);
			SendMessage("MoveWheelCollidersUp");
			UnityEngine.Object.Destroy(base.gameObject, 3f);
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
