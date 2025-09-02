using UnityEngine;

public class GameControl : MonoBehaviour
{
	public static GameControl manager;

	public static float accelFwd;

	public static float accelBack;

	public static float steerAmount;

	public static bool shift;

	public static bool brake;

	public static bool driving;

	public static bool jump;

	public static bool bikeGetDownForce;

	public static bool CarGetDownForce;

	public ControlMode controlMode = ControlMode.simple;

	public GameObject getInVehicle;

	private VehicleCamera vehicleCamera;

	private float drivingTimer;

	public void VehicleAccelForward(float amount)
	{
		accelFwd = amount;
	}

	public void VehicleAccelBack(float amount)
	{
		accelBack = amount;
	}

	public void VehicleSteer(float amount)
	{
		steerAmount = amount;
	}

	public void VehicleHandBrake(bool HBrakeing)
	{
		brake = HBrakeing;
	}

	public void VehicleShift(bool Shifting)
	{
		shift = Shifting;
	}

	public void GetInVehicle()
	{
		Debug.Log(drivingTimer);
		if (drivingTimer == 0f)
		{
			driving = true;
			drivingTimer = 3f;
		}
	}

	public void GetOutVehicle()
	{
		Debug.Log(drivingTimer + " : " + driving.ToString());
		if (drivingTimer == 0f)
		{
			driving = false;
			drivingTimer = 3f;
		}
	}

	public void Jumping()
	{
		jump = true;
	}

	private void Awake()
	{
		manager = this;
	}

	private void Start()
	{
		vehicleCamera = AIContoller.manager.vehicleCamera;
		GetOutVehicle();
	}

	private void Update()
	{
		drivingTimer = Mathf.MoveTowards(drivingTimer, 0f, Time.deltaTime);
	}

	public void CameraSwitch()
	{
		vehicleCamera.Switch++;
		if (vehicleCamera.Switch > vehicleCamera.cameraSwitchView.Count)
		{
			vehicleCamera.Switch = 0;
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
