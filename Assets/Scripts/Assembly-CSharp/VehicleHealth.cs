using UnityEngine;

public class VehicleHealth : MonoBehaviour
{
	public int Vehiclehealth = 100;

	public AIVehicle vehicleAI;

	public GameObject Smoke;

	public GameObject Fire;

	public GameObject Blast;

	public bool Car;

	private Transform Parent;

	public CarComponents CarCompo;

	public BikeComponents BikeCompo;

	public GameObject Health_obj;

	public int BlastForce = 1850000;

	private void Awake()
	{
		Smoke.SetActive(false);
		Fire.SetActive(false);
		if (Car)
		{
			CarCompo.CarHealth = Vehiclehealth;
		}
		else
		{
			BikeCompo.BikeHealth = Vehiclehealth;
		}
		Parent = vehicleAI.transform;
	}

	public void OnShootVehicle(int _decreaseHealth = 30)
	{
		Debug.Log(Leveldata.MissionFailed.ToString() + " Vi.... " + vehicleAI);
		if (!vehicleAI || Leveldata.MissionFailed)
		{
			return;
		}
		Debug.Log("tag.... " + base.name);
		Vehiclehealth -= _decreaseHealth;
		GameUI.Instance.ShowVehicleHealth(Vehiclehealth);
		if (Car)
		{
			CarCompo.CarHealth = Vehiclehealth;
		}
		else
		{
			BikeCompo.BikeHealth = Vehiclehealth;
		}
		Debug.Log(Vehiclehealth + " Decrease Player Health ");
		if (Vehiclehealth <= 40)
		{
			Debug.Log("Vehicle in Danger Stage :Show Flames:");
			Smoke.SetActive(true);
		}
		if (Vehiclehealth <= 20)
		{
			Debug.Log("Vehicle in Danger Stage :Show Flames:");
			Fire.SetActive(true);
		}
		if (Vehiclehealth > 0)
		{
			return;
		}
		Debug.Log("Blast the Vehicle");
		Blast.SetActive(true);
		if (Car)
		{
			Parent.GetComponent<BoxCollider>().enabled = false;
			Parent.GetComponent<VehicleControl>().enabled = false;
			Parent.GetComponent<AIVehicle>().enabled = false;
			Parent.GetComponent<CarComponents>().enabled = false;
			Parent.GetComponent<DestroyGameObject>().enabled = false;
			Parent.GetComponent<CarComponents>().door.gameObject.SetActive(false);
			Parent.GetComponent<CarComponents>().Rightdoor.gameObject.SetActive(false);
			Parent.GetComponent<CarComponents>().handleTrigger.gameObject.SetActive(false);
			Parent.GetComponent<CarComponents>().handleTriggerright.gameObject.SetActive(false);
		}
		else
		{
			Parent.GetComponent<BoxCollider>().enabled = false;
			Parent.GetComponent<BikeControl>().enabled = false;
			Parent.GetComponent<AIVehicle>().enabled = false;
			Parent.GetComponent<BikeComponents>().enabled = false;
			Parent.GetComponent<DestroyGameObject>().enabled = false;
			Parent.GetComponent<BikeComponents>().handleTrigger.gameObject.SetActive(false);
			Parent.GetComponent<BikeControl>().bikeWheels.wheels.wheelFront.gameObject.SetActive(false);
			Parent.GetComponent<BikeControl>().bikeWheels.wheels.wheelBack.gameObject.SetActive(false);
			Parent.GetComponent<BikeControl>()._wheelColliders[0].gameObject.SetActive(false);
			Parent.GetComponent<BikeControl>()._wheelColliders[1].gameObject.SetActive(false);
		}
		if (Car)
		{
			Parent.GetComponent<Rigidbody>().AddExplosionForce(BlastForce, Parent.position, 800f);
			if ((bool)Parent.GetComponent<RadarObj>())
			{
				Object.Destroy(Parent.GetComponent<RadarObj>().MissionIcon);
				Object.Destroy(Parent.GetComponent<RadarObj>().RadarRef);
				if (LevelManager.mee.EnemyVehiclesBlaststatic > 0)
				{
					LevelManager.mee.EnemyVehiclesBlaststatic--;
					if (vehicleAI.vehicleStatus != VehicleStatus.Player)
					{
						Object.Destroy(base.gameObject, 1f);
					}
					Debug.Log("Health......." + Health_obj);
				}
				if (LevelManager.mee.EnemyVehiclesBlast_nonstatic > 0)
				{
					LevelManager.mee.EnemyVehiclesBlast_nonstatic--;
					if (vehicleAI.vehicleStatus != VehicleStatus.Player)
					{
						Object.Destroy(base.gameObject, 5f);
					}
					Debug.Log("Health......." + Health_obj);
				}
				Debug.Log(LevelManager.mee.EnemyVehiclesBlaststatic + " AS aa " + LevelManager.mee.EnemyVehiclesBlast_nonstatic);
				if (LevelManager.mee.EnemyVehiclesBlaststatic <= 0 && LevelManager.mee.EnemyVehiclesBlast_nonstatic <= 0)
				{
					Leveldata.mee.Lootcompleted(0, true, true, "Well Done", "Mission Completed");
				}
			}
			else
			{
				Debug.Log("Health......." + Health_obj);
				if (vehicleAI.vehicleStatus != VehicleStatus.Player)
				{
					Object.Destroy(base.gameObject, 8f);
				}
			}
		}
		else
		{
			Parent.GetComponent<Rigidbody>().AddExplosionForce(BlastForce, Parent.position, 500f);
		}
		if (vehicleAI.vehicleStatus == VehicleStatus.Player)
		{
			StartCoroutine(YouAreDeadPage.Instance.Open("You Killed Your Self", 2f));
			Leveldata.MissionFailed = true;
			return;
		}
		Debug.Log("Health......." + Health_obj);
		if (Health_obj != null)
		{
			Health_obj.transform.localScale = new Vector3((float)Vehiclehealth / 100f, 1f, 1f);
		}
	}

	private void OnTriggerEnter(Collider Col)
	{
		if (!vehicleAI || Leveldata.MissionFailed)
		{
			return;
		}
		if (vehicleAI.vehicleStatus == VehicleStatus.Player)
		{
			if (Col.tag == "Walls" || Col.tag == "TrafficLight" || Col.tag == "Obstacle" || Col.tag == "TowerLight" || Col.tag == "Vehicle" || Col.tag == "streetlight")
			{
				Debug.Log(base.gameObject.name + "  tag.... " + Col.tag + " : " + Vehiclehealth);
				Vehiclehealth -= 10;
				GameUI.Instance.ShowVehicleHealth(Vehiclehealth);
				if (Car)
				{
					CarCompo.CarHealth = Vehiclehealth;
				}
				else
				{
					BikeCompo.BikeHealth = Vehiclehealth;
				}
			}
			if (Vehiclehealth <= 40)
			{
				Smoke.SetActive(true);
				LevelManager.mee.ShowHint.SetActive(true);
			}
			if (Vehiclehealth <= 20)
			{
				Fire.SetActive(true);
			}
			if (Vehiclehealth > 0)
			{
				return;
			}
			if (Parent.GetComponent<AIVehicle>().vehicleStatus == VehicleStatus.Player)
			{
				Leveldata.mee.PresentVehicle = Parent.gameObject;
			}
			Debug.Log("Blast the Vehicle ");
			Blast.SetActive(true);
			if (Car)
			{
				Parent.GetComponent<BoxCollider>().enabled = false;
				Parent.GetComponent<VehicleControl>().enabled = false;
				Parent.GetComponent<AIVehicle>().enabled = false;
				Parent.GetComponent<CarComponents>().enabled = false;
				Parent.GetComponent<DestroyGameObject>().enabled = false;
				if (Parent.GetComponent<CarComponents>().Carsounds != null)
				{
					Parent.GetComponent<CarComponents>().Carsounds.SetActive(false);
				}
			}
			else
			{
				Parent.GetComponent<BoxCollider>().enabled = false;
				Parent.GetComponent<BikeControl>().enabled = false;
				Parent.GetComponent<AIVehicle>().enabled = false;
				Parent.GetComponent<BikeComponents>().enabled = false;
				Parent.GetComponent<DestroyGameObject>().enabled = false;
				Parent.GetComponent<BikeComponents>().handleTrigger.gameObject.SetActive(false);
				Parent.GetComponent<BikeControl>().bikeWheels.wheels.wheelFront.gameObject.SetActive(false);
				Parent.GetComponent<BikeControl>().bikeWheels.wheels.wheelBack.gameObject.SetActive(false);
				Parent.GetComponent<BikeControl>()._wheelColliders[0].gameObject.SetActive(false);
				Parent.GetComponent<BikeControl>()._wheelColliders[1].gameObject.SetActive(false);
				if (Parent.GetComponent<BikeComponents>().Bikesounds != null)
				{
					Parent.GetComponent<BikeComponents>().Bikesounds.SetActive(false);
				}
			}
			if (Car)
			{
				Parent.GetComponent<Rigidbody>().AddExplosionForce(BlastForce, Parent.position, 100f);
			}
			else
			{
				Parent.GetComponent<Rigidbody>().AddExplosionForce(BlastForce, Parent.position, 500f);
			}
			Debug.Log("fail");
			StartCoroutine(YouAreDeadPage.Instance.Open("You Killed Your Self", 2f));
			Leveldata.MissionFailed = true;
		}
		else
		{
			DamageVehicle(Col);
		}
	}

	private void DamageVehicle(Collider Col)
	{
		if (Col.tag == "Walls" || Col.tag == "TrafficLight" || Col.tag == "Obstacle" || Col.tag == "TowerLight" || Col.tag == "Vehicle")
		{
			Vehiclehealth -= 10;
			if (Parent.GetComponent<AIVehicle>().vehicleStatus == VehicleStatus.Player)
			{
				GameUI.Instance.ShowVehicleHealth(Vehiclehealth);
			}
			if (Car)
			{
				CarCompo.CarHealth = Vehiclehealth;
			}
			else
			{
				BikeCompo.BikeHealth = Vehiclehealth;
			}
		}
		if (Health_obj != null)
		{
			Health_obj.transform.localScale = new Vector3((float)Vehiclehealth / 100f, 1f, 1f);
		}
		if (Vehiclehealth <= 40)
		{
			Smoke.SetActive(true);
		}
		if (Vehiclehealth <= 20)
		{
			Fire.SetActive(true);
		}
		if (Vehiclehealth > 0)
		{
			return;
		}
		if (Parent.GetComponent<AIVehicle>().vehicleStatus == VehicleStatus.Player)
		{
			Leveldata.mee.PresentVehicle = Parent.gameObject;
		}
		Debug.Log("Blast the Vehicle " + Parent);
		Blast.SetActive(true);
		if (Car)
		{
			Parent.GetComponent<BoxCollider>().enabled = false;
			Parent.GetComponent<VehicleControl>().enabled = false;
			Parent.GetComponent<AIVehicle>().enabled = false;
			Parent.GetComponent<CarComponents>().enabled = false;
			if (Parent.GetComponent<CarComponents>().Carsounds != null)
			{
				Parent.GetComponent<CarComponents>().Carsounds.SetActive(false);
			}
		}
		else
		{
			Parent.GetComponent<BoxCollider>().enabled = false;
			Parent.GetComponent<BikeControl>().enabled = false;
			Parent.GetComponent<AIVehicle>().enabled = false;
			Parent.GetComponent<BikeComponents>().enabled = false;
			Parent.GetComponent<BikeComponents>().handleTrigger.gameObject.SetActive(false);
			Parent.GetComponent<BikeControl>().bikeWheels.wheels.wheelFront.gameObject.SetActive(false);
			Parent.GetComponent<BikeControl>().bikeWheels.wheels.wheelBack.gameObject.SetActive(false);
			Parent.GetComponent<BikeControl>()._wheelColliders[0].gameObject.SetActive(false);
			Parent.GetComponent<BikeControl>()._wheelColliders[1].gameObject.SetActive(false);
			if (Parent.GetComponent<BikeComponents>().Bikesounds != null)
			{
				Parent.GetComponent<BikeComponents>().Bikesounds.SetActive(false);
			}
		}
		if (Car)
		{
			Parent.GetComponent<Rigidbody>().AddExplosionForce(BlastForce, Parent.position, 100f);
		}
		else
		{
			Parent.GetComponent<Rigidbody>().AddExplosionForce(BlastForce, Parent.position, 500f);
		}
		Debug.Log(string.Concat(AIContoller.manager.player.root, " :: blast ", base.gameObject));
		Object.Destroy(base.gameObject, 2f);
	}

	public void ResetVehicle(GameObject _pos = null)
	{
		Vehiclehealth = 100;
		Debug.Log("aa");
		Smoke.SetActive(false);
		Debug.Log("aad");
		Fire.SetActive(false);
		Debug.Log("aaf");
		Blast.SetActive(false);
		Debug.Log("aah");
		Leveldata.MissionFailed = false;
		Debug.Log("aaG");
		GameControl.manager.VehicleAccelForward(0f);
		GameUI.Instance.ShowVehicleHealth(100);
		Debug.Log("aaGf");
		if (Car)
		{
			Parent.GetComponent<VehicleControl>().enabled = true;
			Parent.GetComponent<AIVehicle>().enabled = true;
			Parent.GetComponent<CarComponents>().enabled = true;
			Parent.GetComponent<DestroyGameObject>().enabled = false;
			if (Parent.GetComponent<CarComponents>().Carsounds != null)
			{
				Parent.GetComponent<CarComponents>().Carsounds.SetActive(true);
			}
			Parent.GetComponent<CarComponents>().CarHealth = 100;
		}
		else
		{
			Debug.Log("aaGg");
			Parent.GetComponent<BoxCollider>().enabled = true;
			Parent.GetComponent<BikeControl>().enabled = true;
			Parent.GetComponent<AIVehicle>().enabled = true;
			Parent.GetComponent<BikeComponents>().enabled = true;
			Parent.GetComponent<DestroyGameObject>().enabled = false;
			Debug.Log("aaGl");
			Parent.GetComponent<BikeComponents>().BikeHealth = 100;
			Parent.GetComponent<BikeComponents>().handleTrigger.gameObject.SetActive(true);
			Parent.GetComponent<BikeControl>().bikeWheels.wheels.wheelFront.gameObject.SetActive(true);
			Parent.GetComponent<BikeControl>().bikeWheels.wheels.wheelBack.gameObject.SetActive(true);
			Parent.GetComponent<BikeControl>()._wheelColliders[0].gameObject.SetActive(true);
			Parent.GetComponent<BikeControl>()._wheelColliders[1].gameObject.SetActive(true);
			if (Parent.GetComponent<BikeComponents>().Bikesounds != null)
			{
				Parent.GetComponent<BikeComponents>().Bikesounds.SetActive(true);
			}
		}
		if (_pos != null)
		{
			base.transform.position = _pos.transform.position;
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
