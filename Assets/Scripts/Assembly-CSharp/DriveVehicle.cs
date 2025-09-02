using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class DriveVehicle : MonoBehaviour
{
	[Serializable]
	public class CharacterComponents
	{
		public Rigidbody myRigidbody;

		public Collider myCollider;

		public NavMeshObstacle myNavMeshObstacle;

		public PlayerBehaviour myPlayerBehaviour;

		public Controller myController;

		public CameraBehaviour myCameraBehaviour;

		public HUDBehaviour myHUDBehaviour;

		public TransformPathMaker myTransformPathMaker;

		public PlayerAnimationListener myPlayerAnimationListener;

		public RagdollHelper myRagdollHelper;

		public IKControl myIKControl;

		public GameObject aimHelper;
	}

	public CharacterComponents characterComponents;

	private PlayerCarStatus playerCarStatus;

	private PlayerBikeStatus playerBikeStatus;

	private bool gettingOnCar;

	private bool gettingOnBike;

	public Animator m_Animator;

	private CarComponents carComponents;

	private BikeComponents bikeComponents;

	private AIVehicle m_AIVehicle;

	private VehicleControl m_VehicleControl;

	private BikeControl m_BikeControl;

	public Transform handleTrigger;

	private Transform door;

	private Transform sitPoint;

	public Transform playerCameraParent;

	private GameObject _mobj;

	private Transform Mydoor;

	private bool runonce;

	private IEnumerator Delaytime()
	{
		for (int i = 0; i < 3; i++)
		{
			AIContoller.manager.vehicleCamera.transform.localPosition = Vector3.zero;
			AIContoller.manager.vehicleCamera.transform.localEulerAngles = Vector3.zero;
			yield return new WaitForSeconds(0.4f);
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("HandleTrigger"))
		{
			if (!PlayerPrefs.HasKey("firsttimeGettingIna"))
			{
				PlayerPrefs.SetString("firsttimeGettingIna", "false");
				Leveldata.mee._helpObj.SetActive(true);
				Leveldata.mee._helpObj.GetComponent<HelpIngame>().ShowcarHelp();
			}
			GameControl.manager.getInVehicle.SetActive(true);
			if ((GameControl.manager.controlMode == ControlMode.simple && Input.GetKey(KeyCode.F)) || (GameControl.manager.controlMode == ControlMode.touch && GameControl.driving))
			{
				if ((bool)other.transform.parent.parent.GetComponent<CarComponents>())
				{
					_mobj = other.transform.parent.parent.gameObject;
					_mobj.transform.parent = null;
				}
				if ((bool)other.transform.root.GetComponent<CarComponents>())
				{
					carComponents = other.transform.root.GetComponent<CarComponents>();
					m_AIVehicle = other.transform.root.GetComponent<AIVehicle>();
					m_VehicleControl = other.transform.root.GetComponent<VehicleControl>();
					door = carComponents.door;
					handleTrigger = carComponents.handleTrigger;
					sitPoint = carComponents.sitPoint;
					gettingOnCar = true;
					gettingOnBike = false;
					GameControl.manager.getInVehicle.SetActive(false);
				}
				if ((bool)other.transform.parent.parent.parent && (bool)other.transform.parent.parent.parent.GetComponent<BikeComponents>())
				{
					_mobj = other.transform.parent.parent.parent.gameObject;
					_mobj.transform.parent = null;
				}
				if ((bool)other.transform.root.GetComponent<BikeComponents>())
				{
					bikeComponents = other.transform.root.GetComponent<BikeComponents>();
					m_AIVehicle = other.transform.root.GetComponent<AIVehicle>();
					m_BikeControl = other.transform.root.GetComponent<BikeControl>();
					handleTrigger = bikeComponents.handleTrigger;
					sitPoint = bikeComponents.sitPoint;
					gettingOnBike = true;
					gettingOnCar = false;
					GameControl.manager.getInVehicle.SetActive(false);
				}
			}
		}
		if (!other.CompareTag("HandleTriggerRight"))
		{
			return;
		}
		GameControl.manager.getInVehicle.SetActive(true);
		if ((GameControl.manager.controlMode == ControlMode.simple && Input.GetKey(KeyCode.F)) || (GameControl.manager.controlMode == ControlMode.touch && GameControl.driving))
		{
			if ((bool)other.transform.parent)
			{
				_mobj = other.transform.parent.parent.gameObject;
				_mobj.transform.parent = null;
			}
			if ((bool)other.transform.root.GetComponent<CarComponents>())
			{
				carComponents = other.transform.root.GetComponent<CarComponents>();
				m_AIVehicle = other.transform.root.GetComponent<AIVehicle>();
				m_VehicleControl = other.transform.root.GetComponent<VehicleControl>();
				door = carComponents.Rightdoor;
				handleTrigger = carComponents.handleTriggerright;
				sitPoint = carComponents.sitPoint;
				gettingOnCar = true;
				gettingOnBike = false;
				GameControl.manager.getInVehicle.SetActive(false);
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("HandleTrigger"))
		{
			GameControl.manager.getInVehicle.SetActive(false);
		}
	}

	public void ComponentsStatus(bool active)
	{
		characterComponents.myPlayerBehaviour.enabled = active;
		characterComponents.myController.enabled = active;
		characterComponents.myCameraBehaviour.enabled = active;
		characterComponents.myHUDBehaviour.enabled = active;
		characterComponents.myTransformPathMaker.enabled = active;
		characterComponents.myPlayerAnimationListener.enabled = active;
		characterComponents.myRagdollHelper.enabled = active;
		characterComponents.myIKControl.enabled = active;
		characterComponents.myNavMeshObstacle.enabled = active;
		characterComponents.myRigidbody.isKinematic = !active;
		characterComponents.myCollider.enabled = active;
		characterComponents.aimHelper.SetActive(active);
	}

	private void Start()
	{
	}

	public void GetinCar()
	{
		switch (playerCarStatus)
		{
		case PlayerCarStatus.Idle:
			Debug.Log(string.Concat(carComponents.gameObject.GetComponent<VehicleHealth>(), " in idle.....", carComponents.gameObject));
			m_Animator.SetLayerWeight(0, 0f);
			ComponentsStatus(false);
			base.transform.position = handleTrigger.position;
			base.transform.rotation = handleTrigger.rotation;
			m_Animator.transform.position = handleTrigger.position;
			m_Animator.transform.rotation = handleTrigger.rotation;
			base.transform.parent = carComponents.sitPoint.transform;
			Leveldata.mee.PresentVehicle = carComponents.gameObject;
			base.transform.position = Vector3.MoveTowards(base.transform.position, handleTrigger.position, Time.deltaTime * 3f);
			base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, handleTrigger.rotation, Time.deltaTime * 250f);
			if (base.transform.position == handleTrigger.position && base.transform.rotation == handleTrigger.rotation)
			{
				m_Animator.ForceStateNormalizedTime(0f);
				m_Animator.SetFloat("CarStatus", 1f);
				m_Animator.SetBool("DriveCar", true);
				m_Animator.Play("Drive Car", 0);
				m_VehicleControl.carSounds.openDoor.Play();
				playerCarStatus++;
			}
			break;
		case PlayerCarStatus.OpenDoor:
			if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
			{
				m_Animator.SetFloat("CarStatus", 2f);
				m_Animator.ForceStateNormalizedTime(0f);
				playerCarStatus++;
			}
			else if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.6f)
			{
				Mydoor = door;
				if (door == carComponents.Rightdoor)
				{
					door.localRotation = Quaternion.RotateTowards(door.localRotation, Quaternion.Euler(0f, -45f, 0f), Time.deltaTime * 300f);
				}
				else
				{
					door.localRotation = Quaternion.RotateTowards(door.localRotation, Quaternion.Euler(0f, 45f, 0f), Time.deltaTime * 300f);
				}
			}
			break;
		case PlayerCarStatus.inCar:
			carComponents.driving = false;
			if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
			{
				m_Animator.SetFloat("CarStatus", 3f);
				m_Animator.ForceStateNormalizedTime(0f);
				playerCarStatus++;
			}
			else if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.3f)
			{
				base.transform.position = Vector3.MoveTowards(base.transform.position, sitPoint.position, Time.deltaTime * 3f);
				base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, sitPoint.rotation, Time.deltaTime * 250f);
			}
			else
			{
				base.transform.localRotation = Quaternion.RotateTowards(base.transform.localRotation, Quaternion.Euler(0f, 0f, 0f), Time.deltaTime * 500f);
			}
			break;
		case PlayerCarStatus.RollDoor:
			if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
			{
				m_Animator.SetFloat("CarStatus", 4f);
				m_Animator.ForceStateNormalizedTime(0f);
				m_VehicleControl.carSounds.closeDoor.Play();
				playerCarStatus++;
			}
			else if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f)
			{
				Mydoor.localRotation = Quaternion.RotateTowards(Mydoor.localRotation, Quaternion.Euler(0f, 0f, 0f), Time.deltaTime * 250f);
			}
			break;
		case PlayerCarStatus.Sit:
		{
			AIContoller.manager.vehicleCamera.transform.parent = null;
			AIContoller.manager.vehicleCamera.cameraSwitchView = carComponents.cameraViewSetting.cameraViews;
			AIContoller.manager.vehicleCamera.distance = carComponents.cameraViewSetting.distance;
			AIContoller.manager.vehicleCamera.height = carComponents.cameraViewSetting.height;
			AIContoller.manager.vehicleCamera.Angle = carComponents.cameraViewSetting.Angle;
			AIContoller.manager.vehicleCamera.target = handleTrigger.root.transform;
			AIContoller.manager.vehicleCamera.enabled = true;
			m_AIVehicle.vehicleStatus = VehicleStatus.Player;
			int vehiclehealth = carComponents.gameObject.GetComponent<VehicleHealth>().Vehiclehealth;
			if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && ((GameControl.manager.controlMode == ControlMode.simple && Input.GetKey(KeyCode.F)) || (GameControl.manager.controlMode == ControlMode.touch && !GameControl.driving) || GameControl.CarGetDownForce))
			{
				m_Animator.SetFloat("CarStatus", 5f);
				m_Animator.ForceStateNormalizedTime(0f);
				m_AIVehicle.vehicleStatus = VehicleStatus.EmptyOn;
				m_VehicleControl.carSounds.openDoor.Play();
				playerCarStatus++;
				GameControl.CarGetDownForce = false;
			}
			break;
		}
		case PlayerCarStatus.OutCar:
			if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
			{
				m_Animator.SetFloat("CarStatus", 6f);
				m_Animator.ForceStateNormalizedTime(0f);
				StopCoroutine(Delaytime());
				StartCoroutine(Delaytime());
				playerCarStatus++;
			}
			else if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.3f)
			{
				base.transform.position = Vector3.MoveTowards(base.transform.position, handleTrigger.position, Time.deltaTime * 3f);
				base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, handleTrigger.rotation, Time.deltaTime * 250f);
			}
			else if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.1f)
			{
				door = carComponents.door;
				handleTrigger = carComponents.handleTrigger;
				door.localRotation = Quaternion.RotateTowards(door.localRotation, Quaternion.Euler(0f, 45f, 0f), Time.deltaTime * 250f);
			}
			break;
		case PlayerCarStatus.CloseDoor:
			if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f)
			{
				AIContoller.manager.vehicleCamera.transform.parent = playerCameraParent;
				AIContoller.manager.vehicleCamera.enabled = false;
				Debug.Log("clos........");
				gettingOnCar = false;
				base.transform.parent = null;
				Leveldata.mee.PresentVehicle = null;
				ComponentsStatus(true);
				m_VehicleControl.carSounds.closeDoor.Play();
				base.transform.eulerAngles = new Vector3(0f, base.transform.eulerAngles.y, 0f);
				playerCarStatus = PlayerCarStatus.Idle;
			}
			else if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.2f)
			{
				handleTrigger.root.GetComponent<CarComponents>().door.localRotation = Quaternion.RotateTowards(handleTrigger.root.GetComponent<CarComponents>().door.localRotation, Quaternion.Euler(0f, 0f, 0f), Time.deltaTime * 250f);
				m_Animator.SetBool("DriveCar", false);
			}
			break;
		}
	}

	private void ShowVehicleHealthOneTime()
	{
	}

	public void GetinBike()
	{
		switch (playerBikeStatus)
		{
		case PlayerBikeStatus.Idle:
			ComponentsStatus(false);
			base.transform.position = handleTrigger.position;
			base.transform.rotation = handleTrigger.rotation;
			m_Animator.transform.position = handleTrigger.position;
			m_Animator.transform.rotation = handleTrigger.rotation;
			base.transform.parent = bikeComponents.sitPoint.transform;
			Leveldata.mee.PresentVehicle = bikeComponents.gameObject;
			base.transform.position = Vector3.MoveTowards(base.transform.position, handleTrigger.position, Time.deltaTime * 3f);
			base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, handleTrigger.rotation, Time.deltaTime * 250f);
			if (base.transform.position == handleTrigger.position && base.transform.rotation == handleTrigger.rotation)
			{
				Debug.Log(string.Concat(playerBikeStatus, "A ---status "));
				m_Animator.ForceStateNormalizedTime(0f);
				m_Animator.SetFloat("BikeStatus", 1f);
				m_Animator.SetBool("DriveBike", true);
				m_Animator.Play("Drive Bike", 0);
				playerBikeStatus++;
				Debug.Log(string.Concat(playerBikeStatus, " ---status "));
			}
			break;
		case PlayerBikeStatus.GettingOn:
			bikeComponents.driving = false;
			if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
			{
				m_Animator.SetFloat("BikeStatus", 2f);
				m_Animator.ForceStateNormalizedTime(0f);
				playerBikeStatus++;
			}
			else if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.4f)
			{
				base.transform.position = Vector3.MoveTowards(base.transform.position, sitPoint.position, Time.deltaTime * 3f);
				base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, sitPoint.rotation, Time.deltaTime * 250f);
			}
			break;
		case PlayerBikeStatus.Sit:
		{
			if (!runonce)
			{
				AIContoller.manager.vehicleCamera.transform.parent = null;
				AIContoller.manager.vehicleCamera.cameraSwitchView = bikeComponents.cameraViewSetting.cameraViews;
				AIContoller.manager.vehicleCamera.distance = bikeComponents.cameraViewSetting.distance;
				AIContoller.manager.vehicleCamera.height = bikeComponents.cameraViewSetting.height;
				AIContoller.manager.vehicleCamera.Angle = bikeComponents.cameraViewSetting.Angle;
				AIContoller.manager.vehicleCamera.target = handleTrigger.root.transform;
				AIContoller.manager.vehicleCamera.enabled = true;
				m_AIVehicle.vehicleStatus = VehicleStatus.Player;
				runonce = !runonce;
			}
			int bikeHealth = m_AIVehicle.gameObject.transform.GetComponent<BikeComponents>().BikeHealth;
			GameUI.Instance.ShowVehicleHealth(bikeHealth);
			if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && ((GameControl.manager.controlMode == ControlMode.simple && Input.GetKey(KeyCode.F)) || (GameControl.manager.controlMode == ControlMode.touch && !GameControl.driving) || GameControl.bikeGetDownForce))
			{
				m_Animator.SetFloat("BikeStatus", 3f);
				m_Animator.ForceStateNormalizedTime(0f);
				m_AIVehicle.vehicleStatus = VehicleStatus.EmptyOn;
				playerBikeStatus++;
				GameControl.bikeGetDownForce = false;
				runonce = !runonce;
			}
			break;
		}
		case PlayerBikeStatus.GettingOff:
			if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8f)
			{
				AIContoller.manager.vehicleCamera.transform.parent = playerCameraParent;
				AIContoller.manager.vehicleCamera.enabled = false;
				gettingOnBike = false;
				base.transform.parent = null;
				Leveldata.mee.PresentVehicle = null;
				ComponentsStatus(true);
				base.transform.eulerAngles = new Vector3(0f, base.transform.eulerAngles.y, 0f);
				playerBikeStatus = PlayerBikeStatus.Idle;
				StopCoroutine(Delaytime());
				StartCoroutine(Delaytime());
			}
			else if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.4f)
			{
				base.transform.position = Vector3.MoveTowards(base.transform.position, handleTrigger.position, Time.deltaTime * 3f);
				base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, handleTrigger.rotation, Time.deltaTime * 250f);
				m_Animator.SetBool("DriveBike", false);
			}
			break;
		}
	}

	public void GetOutfromBike()
	{
		m_Animator.SetFloat("BikeStatus", 3f);
		m_Animator.ForceStateNormalizedTime(0f);
		m_AIVehicle.vehicleStatus = VehicleStatus.EmptyOn;
		playerBikeStatus++;
		runonce = !runonce;
	}

	private void Update()
	{
		if (gettingOnCar)
		{
			GetinCar();
		}
		else if (gettingOnBike)
		{
			GetinBike();
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
