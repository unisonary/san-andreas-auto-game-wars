using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using CnControls;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TransformPathMaker))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(CapsuleCollider))]
[ExecuteInEditMode]
public class PlayerBehaviour : MonoBehaviour
{
	public enum Direction
	{
		Forward = 0,
		Back = 1,
		Up = 2,
		Down = 3,
		Left = 4,
		Right = 5
	}

	[HideInInspector]
	public Transform aimHelper;

	[HideInInspector]
	public Transform aimHelperSpine;

	public Animator playerAnimator;

	[HideInInspector]
	public RagdollHelper ragdollh;

	[HideInInspector]
	public Rigidbody rb;

	[HideInInspector]
	public CapsuleCollider capsuleC;

	[HideInInspector]
	public IKControl ikControll;

	[HideInInspector]
	public TransformPathMaker pathMaker;

	[HideInInspector]
	public Controller controller;

	[HideInInspector]
	public CameraBehaviour cameraBehaviour;

	[HideInInspector]
	public Transform transformToRotate;

	[HideInInspector]
	public Vector3 moveAxis;

	[HideInInspector]
	public Rigidbody[] boneRb;

	[HideInInspector]
	public Transform hipsParent;

	private PhysicMaterial pM;

	[HideInInspector]
	public Transform cameraParent;

	[HideInInspector]
	public Transform cam;

	[HideInInspector]
	public Transform[] camPivot = new Transform[2];

	[Header("Player Settings")]
	[Range(0f, 100f)]
	public float life = 100f;

	[SerializeField]
	public float crouchSpeed = 6f;

	[SerializeField]
	public float walkSpeed = 2.3f;

	[SerializeField]
	public float runSpeed = 4.6f;

	[SerializeField]
	public float aimWalkSpeed = 1.5f;

	public bool dead;

	[HideInInspector]
	public bool crouch;

	[HideInInspector]
	public bool aim;

	public float jumpForce = 7f;

	private float jumpForce2 = 15f;

	public int bagLimit = 5;

	public float switchWeaponTime = 0.5f;

	public bool ragdollWhenFall = true;

	private float characterHeight = 1f;

	[Range(0f, 2f)]
	public float crouchHeight = 0.75f;

	[Range(-1f, 1f)]
	public float bellyOffset;

	[Header("Change this if holding weapons looks weird")]
	public Direction spineFacingDirection;

	[Header("Audio")]
	public AudioClip footStepAudio;

	[HideInInspector]
	public AudioSource audioSource;

	[HideInInspector]
	public Transform leftFoot;

	[HideInInspector]
	public Transform rightFoot;

	private bool leftCanStep;

	private bool rightCanStep;

	[HideInInspector]
	public float factor;

	[CompilerGenerated]
	private Action m_OnWeaponSwitch;

	private bool equippedbefore;

	private float climbY;

	private float xAxis;

	private float yAxis;

	[HideInInspector]
	public Quaternion rotationAux;

	[HideInInspector]
	public Quaternion aimRotationSpineAux;

	[HideInInspector]
	public Quaternion aimRotationAux;

	private float lean;

	[HideInInspector]
	public float recoil;

	private float _capsuleSize;

	private float currentMovementState;

	private float runKeyPressed;

	private AnimatorStateInfo currentAnimatorState;

	[HideInInspector]
	public bool grounded;

	[HideInInspector]
	public bool inMoveState;

	[HideInInspector]
	public bool climbing;

	[HideInInspector]
	public bool climbHit;

	[HideInInspector]
	public bool switchingWeapons;

	[HideInInspector]
	public bool halfSwitchingWeapons;

	private GameObject collidedWith;

	public List<WeaponBase> weapons = new List<WeaponBase>();

	[HideInInspector]
	public WeaponBase currentWeapon;

	[HideInInspector]
	public int currentWeaponID;

	[HideInInspector]
	public bool equippedWeapon;

	[HideInInspector]
	public Transform leftHandInWeapon;

	[HideInInspector]
	public Transform rightHandInWeapon;

	public static bool isCriminal;

	public static bool CanDrift = false;

	public static float driftamount = 0f;

	public static int Totaldrifts = 2;

	private Quaternion startSpineRot = new Quaternion(0f, 0f, 0f, 1f);

	private static PlayerBehaviour _instance;

	public Text _Textobj;

	public GameObject NightTheme;

	public GameObject MainCity;

	public GameObject DessertCity;

	private bool nighttheme_bool;

	private bool canShoot;

	[HideInInspector]
	public int numberPressed = -1;

	private bool Isswim;

	private bool Punchit = true;

	public BoxCollider myhand;

	public GameObject player_Dummy;

	public GameObject Player_Mesh;

	[HideInInspector]
	public GameObject player_DummyInstantiate;

	public static bool policeKilledPlayer = false;

	public static PlayerBehaviour Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = UnityEngine.Object.FindObjectOfType<PlayerBehaviour>();
			}
			return _instance;
		}
	}

	public event Action OnWeaponSwitch
	{
		[CompilerGenerated]
		add
		{
			Action action = this.m_OnWeaponSwitch;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref this.m_OnWeaponSwitch, value2, action2);
			}
			while (action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action action = this.m_OnWeaponSwitch;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref this.m_OnWeaponSwitch, value2, action2);
			}
			while (action != action2);
		}
	}

	public void ResetPlayer(GameObject _pos = null)
	{
		life = 100f;
		dead = false;
		Player_Mesh.transform.gameObject.SetActive(true);
		policeKilledPlayer = false;
		GameUI.Instance.ShowPlayerHealth();
		if (player_DummyInstantiate != null)
		{
			player_DummyInstantiate.SetActive(false);
		}
		if (_pos != null)
		{
			base.transform.position = _pos.transform.position;
		}
	}

	private void Start()
	{
		isCriminal = false;
		if (!Application.isPlaying)
		{
			return;
		}
		factor = 0.45f;
		startSpineRot = aimHelperSpine.rotation;
		rotationAux = new Quaternion(0f, 0f, 0f, 1f);
		aimRotationAux = rotationAux;
		aimRotationSpineAux = rotationAux;
		life = 100f;
		dead = false;
		crouch = false;
		halfSwitchingWeapons = true;
		Rigidbody[] array = boneRb;
		foreach (Rigidbody obj in array)
		{
			BoxCollider component = obj.GetComponent<BoxCollider>();
			SphereCollider[] components = obj.GetComponents<SphereCollider>();
			if (component != null)
			{
				Physics.IgnoreCollision(capsuleC, component);
			}
			if (components != null)
			{
				SphereCollider[] array2 = components;
				foreach (SphereCollider collider in array2)
				{
					Physics.IgnoreCollision(capsuleC, collider);
				}
			}
		}
		pM = capsuleC.material;
	}

	private void FootStepAudio()
	{
		if (grounded && !climbing)
		{
			float num = Vector3.Distance(leftFoot.position, rightFoot.position);
			if (num > factor)
			{
				leftCanStep = true;
			}
			if (leftCanStep && num < factor)
			{
				leftCanStep = false;
				audioSource.PlayOneShot(footStepAudio);
			}
		}
	}

	private void Update()
	{
		PlayerMovement();
		GroundCheck();
		Gravity();
		FootStepAudio();
	}

	private void LateUpdate()
	{
		if (!Application.isPlaying)
		{
			return;
		}
		recoil = Mathf.Lerp(recoil, 0f, 5f * Time.deltaTime);
		if (dead)
		{
			return;
		}
		Vector3 vector = cam.forward - cam.up / 5f;
		Vector3 forward = cam.forward;
		if (aim)
		{
			if (!cameraBehaviour.aimIsRightSide)
			{
				forward += cam.right / 3f;
			}
			vector.y = Mathf.Clamp(vector.y, -0.4f, 0.35f);
			if (SomethingInFront())
			{
				vector.y = Mathf.Clamp(vector.y, 0f, 0f);
				forward.y = Mathf.Clamp(forward.y, 0f, 1f);
			}
			if (SomethingInFrontAim(2f) && (bool)currentWeapon && !currentWeapon.reloadProgress)
			{
				if (cameraBehaviour.aimIsRightSide)
				{
					lean = -0.2f;
				}
				else
				{
					lean = 0.2f;
				}
			}
			else
			{
				lean = 0f;
			}
			if (crouch)
			{
				forward.y = Mathf.Clamp(forward.y, -0.7f, 0.4f);
				if (!cameraBehaviour.aimIsRightSide)
				{
					vector -= cam.right * 0.3f;
				}
				else
				{
					vector += cam.right * 0.3f;
				}
				if (!SomethingInFront())
				{
					vector.y = Mathf.Clamp(vector.y, -0.5f, -0.5f);
				}
			}
			aimRotationAux = Quaternion.Lerp(aimRotationAux, Quaternion.LookRotation(transformToRotate.position + forward + cam.up * recoil / 10f - transformToRotate.position), 5f * Time.deltaTime);
			aimRotationSpineAux = Quaternion.Lerp(aimRotationSpineAux, Quaternion.LookRotation(transformToRotate.position + vector + cam.up * recoil / 5f - transformToRotate.position) * new Quaternion(0f, 0f, lean, 1f) * startSpineRot, 5f * Time.deltaTime);
		}
		else
		{
			lean = 0f;
			aimRotationSpineAux = Quaternion.Lerp(aimRotationSpineAux, aimHelperSpine.rotation, 20f * Time.deltaTime);
			Vector3 vector2 = Vector3.zero;
			if (spineFacingDirection == Direction.Forward)
			{
				vector2 = aimHelperSpine.forward;
			}
			else if (spineFacingDirection == Direction.Back)
			{
				vector2 = -aimHelperSpine.forward;
			}
			else if (spineFacingDirection == Direction.Up)
			{
				vector2 = aimHelperSpine.up;
			}
			else if (spineFacingDirection == Direction.Down)
			{
				vector2 = -aimHelperSpine.up;
			}
			else if (spineFacingDirection == Direction.Left)
			{
				vector2 = -aimHelperSpine.right;
			}
			else if (spineFacingDirection == Direction.Right)
			{
				vector2 = aimHelperSpine.right;
			}
			vector2.y = Mathf.Clamp(vector2.y, 0f, 5f);
			if (crouch)
			{
				vector2 -= transformToRotate.right * 0.3f;
			}
			aimRotationAux = Quaternion.Lerp(aimRotationAux, Quaternion.LookRotation(aimHelper.position + vector2 - aimHelper.position), 5f * Time.deltaTime);
		}
		if (playerAnimator.enabled)
		{
			aimHelperSpine.rotation = aimRotationSpineAux;
		}
	}

	private void OnTriggerEnter(Collider _obj)
	{
		if (_obj.name == "nighT_theme")
		{
			Debug.Log(_obj.name + " ------gh");
			nighttheme_bool = !nighttheme_bool;
			Debug.Log(nighttheme_bool);
			NightTheme.SetActive(nighttheme_bool);
			MainCity.SetActive(!nighttheme_bool);
			DessertCity.SetActive(!nighttheme_bool);
		}
	}

	private void PlayerMovement()
	{
		if (dead)
		{
			return;
		}
		AnimatorMovementState();
		Climb();
		RagdollWhenFall();
		StandUp();
		Punch();
		xAxis = controller.xAxis;
		yAxis = controller.yAxis;
		if (ragdollh.state == RagdollHelper.RagdollState.blendToAnim)
		{
			transformToRotate.localPosition = Vector3.Lerp(transformToRotate.localPosition, Vector3.zero, 20f * Time.deltaTime);
		}
		if (equippedWeapon && !climbing && !switchingWeapons && ((Input.GetKey(controller.ShootKey) && GameControl.manager.controlMode == ControlMode.simple) || (CnInputManager.GetButton("Shoot2") && GameControl.manager.controlMode == ControlMode.touch)))
		{
			currentWeapon.Shoot();
		}
		if (!inMoveState || climbing)
		{
			return;
		}
		Vector3 vector = xAxis * cam.right;
		Vector3 vector2 = yAxis * cam.forward;
		vector.y = 0f;
		vector2.y = 0f;
		moveAxis = vector2 + vector;
		Vector3 forward = cam.forward;
		if (aim)
		{
			if (!cameraBehaviour.aimIsRightSide && crouch)
			{
				forward -= cam.right / 2f;
			}
			forward.y = 0f;
			rotationAux = Quaternion.LookRotation(transformToRotate.position + forward - transformToRotate.position);
		}
		transformToRotate.rotation = Quaternion.Lerp(playerAnimator.transform.rotation, rotationAux, 5f * Time.deltaTime);
		if (moveAxis != Vector3.zero && !aim)
		{
			rotationAux = Quaternion.LookRotation(transformToRotate.position + moveAxis - transformToRotate.position);
		}
		float num = 0f;
		if (currentMovementState < 0.5f)
		{
			num = crouchSpeed;
		}
		else if (currentMovementState < 1.5f)
		{
			num = ((!(runKeyPressed > 1.5f) || crouch || aim || Isswim) ? walkSpeed : runSpeed);
		}
		else if (currentMovementState < 2.5f)
		{
			num = ((!(runKeyPressed > 1.5f)) ? aimWalkSpeed : aimWalkSpeed);
		}
		if (!SomethingInFront())
		{
			if (moveAxis != Vector3.zero)
			{
				LerpSpeed(2f);
			}
			else
			{
				LerpSpeed(1f);
			}
			if (grounded)
			{
				Vector3 vector3 = moveAxis.normalized * num;
				rb.velocity = new Vector3(vector3.x, rb.velocity.y, vector3.z);
			}
		}
		else if (aim && grounded)
		{
			Vector3 vector4 = moveAxis.normalized * num;
			rb.velocity = new Vector3(vector4.x, rb.velocity.y, vector4.z);
		}
		Jump();
		SwimIt();
		Crouch();
		SwitchWeapon();
		PickUpWeapon();
		if (!switchingWeapons)
		{
			if (Input.GetKeyDown(controller.EquipWeaponKey) && weapons.Count > 0)
			{
				EquipWeaponToggle();
			}
			if (equippedWeapon && ((Input.GetKeyDown(controller.ReloadKey) && GameControl.manager.controlMode == ControlMode.simple) || (CnInputManager.GetButtonDown("Reload2") && GameControl.manager.controlMode == ControlMode.touch)))
			{
				currentWeapon.Reload();
			}
		}
		Aim();
	}

	public void ShootToggle()
	{
		canShoot = !canShoot;
	}

	public void EquipWeaponToggle()
	{
		Debug.Log(canShoot + " toggle wepon " + equippedWeapon);
		HUDBehaviour.instance.ZoominOut(1);
		equippedWeapon = !equippedWeapon;
		if (weapons.Count > 0)
		{
			if (equippedWeapon)
			{
				currentWeapon = GetCurrentWeapon();
				leftHandInWeapon = currentWeapon.leftHand;
				rightHandInWeapon = currentWeapon.rightHand;
			}
			currentWeapon.ToggleRenderer(equippedWeapon);
		}
		//if (this.OnWeaponSwitch != null)
		//{
		//	this.OnWeaponSwitch();
		//}
	}

	private void SwitchWeapon()
	{
		bool flag = false;
		if (GameControl.manager.controlMode == ControlMode.simple)
		{
			for (int i = 0; i < controller.keyCodes.Length; i++)
			{
				if (Input.GetKeyDown(controller.keyCodes[i]))
				{
					numberPressed = i;
					flag = true;
				}
			}
		}
		else if (GameControl.manager.controlMode == ControlMode.touch && CnInputManager.GetButtonDown("SelectGun2"))
		{
			EquipWeaponToggle();
			Debug.Log("Weapon Count::" + weapons.Count + " : " + numberPressed);
		}
	}

	private IEnumerator WeaponSwitchProgress(int numberP)
	{
		switchingWeapons = true;
		halfSwitchingWeapons = false;
		yield return new WaitForSeconds(switchWeaponTime / 2f);
		halfSwitchingWeapons = true;
		if ((bool)currentWeapon)
		{
			currentWeapon.ToggleRenderer(false);
		}
		currentWeaponID = numberP;
		currentWeapon = GetCurrentWeapon();
		//this.OnWeaponSwitch();
		if (equippedWeapon)
		{
			currentWeapon.ToggleRenderer(true);
			leftHandInWeapon = currentWeapon.leftHand;
			rightHandInWeapon = currentWeapon.rightHand;
		}
		yield return new WaitForSeconds(switchWeaponTime);
		switchingWeapons = false;
	}

	private void PickUpWeapon()
	{
		if (((!Input.GetKeyDown(controller.PickUpWeaponKey) || weapons.Count >= bagLimit) && (!controller.automaticPickUp || weapons.Count >= bagLimit)) || !(collidedWith != null))
		{
			return;
		}
		if (collidedWith.tag == "Weapon")
		{
			MonoBehaviour.print("9999999999999999999999999");
			WeaponBase component = collidedWith.GetComponent<WeaponBase>();
			bool flag = false;
			int index = 0;
			for (int i = 0; i < weapons.Count; i++)
			{
				if (weapons[i].weapon == component.weapon)
				{
					flag = true;
					index = i;
				}
			}
			if (flag)
			{
				weapons[index].reloadBullets += component.reloadBullets + component.currentAmmo;
				UnityEngine.Object.Destroy(component.gameObject);
			}
			else
			{
				component.transform.parent = aimHelper;
				component.pB = this;
				component.PutInInventory();
				component.ToggleRenderer(false);
				weapons.Add(component);
			}
			collidedWith = null;
		}
		if (collidedWith.tag == "watersurface" && !Isswim)
		{
			crouch = true;
		}
		else
		{
			crouch = false;
		}
	}

	public void AddWeapon(WeaponBase WB)
	{
		if (weapons.Count >= bagLimit && (!controller.automaticPickUp || weapons.Count >= bagLimit))
		{
			return;
		}
		MonoBehaviour.print("88888888888888888888");
		bool flag = false;
		int index = 0;
		for (int i = 0; i < weapons.Count; i++)
		{
			if (weapons[i].weapon == WB.weapon)
			{
				flag = true;
				index = i;
			}
		}
		if (flag)
		{
			weapons[index].reloadBullets += WB.reloadBullets + WB.currentAmmo;
			UnityEngine.Object.Destroy(WB.gameObject);
			return;
		}
		Debug.Log("Add Weapon");
		WB.transform.parent = aimHelper;
		WB.pB = this;
		WB.PutInInventory();
		WB.ToggleRenderer(false);
		weapons.Add(WB);
	}

	private void OnCollisionStay(Collision col)
	{
		collidedWith = col.gameObject;
	}

	private void OnCollisionExit()
	{
		collidedWith = null;
	}

	private void AnimatorMovementState()
	{
		currentAnimatorState = playerAnimator.GetCurrentAnimatorStateInfo(0);
		inMoveState = currentAnimatorState.IsName("Grounded");
		playerAnimator.SetBool("Grounded", grounded);
		playerAnimator.SetFloat("Speed", runKeyPressed);
		playerAnimator.SetBool("HoldingWeapon", equippedWeapon);
		currentMovementState = playerAnimator.GetFloat("State");
		if (crouch)
		{
			playerAnimator.SetFloat("State", Mathf.Lerp(currentMovementState, 0f, 5f * Time.deltaTime));
		}
		else if (aim)
		{
			playerAnimator.SetFloat("State", Mathf.Lerp(currentMovementState, 2f, 5f * Time.deltaTime));
		}
		else if (Isswim)
		{
			playerAnimator.SetFloat("State", Mathf.Lerp(currentMovementState, 3f, 5f * Time.deltaTime));
		}
		else
		{
			playerAnimator.SetFloat("State", Mathf.Lerp(currentMovementState, 1f, 5f * Time.deltaTime));
		}
		if (!SomethingInFront())
		{
			float num = Mathf.Clamp01(Mathf.Abs(xAxis) + Mathf.Abs(yAxis));
			playerAnimator.SetFloat("Move", Mathf.Lerp(playerAnimator.GetFloat("Move"), num * runKeyPressed, 10f * Time.deltaTime));
			playerAnimator.SetFloat("AxisX", Mathf.Lerp(playerAnimator.GetFloat("AxisX"), xAxis, 10f * Time.deltaTime));
			playerAnimator.SetFloat("AxisY", Mathf.Lerp(playerAnimator.GetFloat("AxisY"), yAxis, 10f * Time.deltaTime));
		}
		else if (aim)
		{
			float value = yAxis;
			value = Mathf.Clamp(value, -1f, 0f);
			float num2 = Mathf.Clamp01(Mathf.Abs(xAxis) + Mathf.Abs(value));
			playerAnimator.SetFloat("Move", Mathf.Lerp(playerAnimator.GetFloat("Move"), num2 * runKeyPressed, 10f * Time.deltaTime));
			playerAnimator.SetFloat("AxisX", Mathf.Lerp(playerAnimator.GetFloat("AxisX"), xAxis, 10f * Time.deltaTime));
			playerAnimator.SetFloat("AxisY", Mathf.Lerp(playerAnimator.GetFloat("AxisY"), value, 10f * Time.deltaTime));
		}
		else if (Isswim)
		{
			float value2 = yAxis;
			value2 = Mathf.Clamp(value2, -1f, 0f);
			float num3 = Mathf.Clamp01(Mathf.Abs(xAxis) + Mathf.Abs(value2));
			playerAnimator.SetFloat("Move", Mathf.Lerp(playerAnimator.GetFloat("Move"), num3 * runKeyPressed, 10f * Time.deltaTime));
			playerAnimator.SetFloat("AxisX", Mathf.Lerp(playerAnimator.GetFloat("AxisX"), xAxis, 10f * Time.deltaTime));
			playerAnimator.SetFloat("AxisY", Mathf.Lerp(playerAnimator.GetFloat("AxisY"), value2, 10f * Time.deltaTime));
		}
		else
		{
			playerAnimator.SetFloat("Move", Mathf.Lerp(playerAnimator.GetFloat("Move"), 0f, 5f * Time.deltaTime));
			playerAnimator.SetFloat("AxisX", Mathf.Lerp(playerAnimator.GetFloat("AxisX"), 0f, 10f * Time.deltaTime));
			playerAnimator.SetFloat("AxisY", Mathf.Lerp(playerAnimator.GetFloat("AxisY"), 0f, 10f * Time.deltaTime));
		}
	}

	public bool SomethingInFront()
	{
		return Physics.Raycast(transformToRotate.position + transformToRotate.up * 0.5f, transformToRotate.forward, 0.5f);
	}

	public bool SomethingInFrontAim(float distance)
	{
		Vector3 forward = cam.forward;
		forward.y = 0f;
		Vector3 vector = -cam.right * 0.15f;
		if (!cameraBehaviour.aimIsRightSide)
		{
			vector = cam.right * 0.15f;
		}
		Vector3 vector2 = transformToRotate.position + transformToRotate.up * 0.5f;
		if (Physics.Raycast(vector2, forward + vector, distance))
		{
			return !Physics.Raycast(vector2 + vector * -5f, forward + vector * -5f, distance);
		}
		return false;
	}

	public void Aim()
	{
		if (!climbing && grounded && !ragdollh.ragdolled && equippedWeapon)
		{
			WeaponBase weaponBase = currentWeapon;
			if (controller.aimMode == Controller.AimMode.Hold)
			{
				aim = Input.GetKey(controller.AimKey) || (Input.GetKey(controller.ShootKey) && GameControl.manager.controlMode == ControlMode.simple) || (CnInputManager.GetButton("Shoot2") && GameControl.manager.controlMode == ControlMode.touch) || weaponBase.reloadProgress;
			}
			if (Input.GetKeyDown(controller.AimKey))
			{
				weaponBase.AimAudio();
			}
			if (Input.GetKeyUp(controller.AimKey))
			{
				weaponBase.AimAudio();
			}
		}
		if (equippedWeapon)
		{
			if (!aim)
			{
				currentWeapon.MoveTo(transformToRotate);
			}
			else
			{
				currentWeapon.MoveTo(aimHelper);
			}
			aimHelper.rotation = aimRotationAux;
		}
	}

	public void SwimIt()
	{
		Physics.Raycast(base.transform.position + base.transform.up * 0.5f, base.transform.up, 1.4f);
		if (Isswim)
		{
			_capsuleSize = Mathf.Lerp(_capsuleSize, crouchHeight, 5f * Time.deltaTime);
		}
		else
		{
			_capsuleSize = Mathf.Lerp(_capsuleSize, characterHeight, 5f * Time.deltaTime);
		}
		capsuleC.center = new Vector3(0f, 0.9f * _capsuleSize, 0f);
		capsuleC.height = 1.8f * _capsuleSize;
	}

	public void Crouch()
	{
		if (!controller.canCrouch)
		{
			return;
		}
		bool flag = Physics.Raycast(base.transform.position + base.transform.up * 0.5f, base.transform.up, 1.4f);
		if (Input.GetKeyDown(controller.CrouchKey))
		{
			if (crouch && !flag)
			{
				crouch = false;
			}
			else
			{
				crouch = true;
			}
		}
		if (((Input.GetKeyDown(controller.JumpKey) && GameControl.manager.controlMode == ControlMode.simple) || (CnInputManager.GetButtonDown("Jump2") && GameControl.manager.controlMode == ControlMode.touch)) && crouch && !flag)
		{
			crouch = false;
		}
		if (flag)
		{
			crouch = true;
		}
		if (crouch)
		{
			_capsuleSize = Mathf.Lerp(_capsuleSize, crouchHeight, 5f * Time.deltaTime);
		}
		else
		{
			_capsuleSize = Mathf.Lerp(_capsuleSize, characterHeight, 5f * Time.deltaTime);
		}
		capsuleC.center = new Vector3(0f, 0.9f * _capsuleSize, 0f);
		capsuleC.height = 1.8f * _capsuleSize;
	}

	public void Jump()
	{
		bool flag = true;
		if (currentWeapon != null && currentWeapon.reloadProgress)
		{
			flag = false;
		}
		if (grounded && inMoveState && !climbing && !crouch && !aim && !ragdollh.ragdolled && !Isswim && flag && ((Input.GetKeyDown(controller.JumpKey) && GameControl.manager.controlMode == ControlMode.simple) || (CnInputManager.GetButtonDown("Jump2") && GameControl.manager.controlMode == ControlMode.touch)))
		{
			playerAnimator.SetTrigger("Jump Forward");
			if (moveAxis != Vector3.zero && !SomethingInFront())
			{
				rb.velocity = transformToRotate.up * jumpForce + transformToRotate.forward * 4f;
			}
			else if (moveAxis != Vector3.zero && SomethingInFront())
			{
				rb.velocity = transformToRotate.up * jumpForce2 + transformToRotate.forward * 4f;
			}
			else
			{
				rb.velocity = transformToRotate.up * jumpForce / 1.1f;
			}
		}
	}

	public void punchagain()
	{
		Debug.Log("Punch...a");
		playerAnimator.ForceStateNormalizedTime(0f);
		playerAnimator.SetFloat("punchstatus", 3f);
	}

	public void punchidle()
	{
		Debug.Log("Punch...e");
		myhand.enabled = false;
		Punchit = true;
		playerAnimator.SetBool("punchhit", false);
	}

	public void Punch()
	{
		if (grounded && !climbHit && !aim && !ragdollh.ragdolled && Punchit && ((Input.GetKeyDown(controller.PunchKey) && GameControl.manager.controlMode == ControlMode.simple) || (CnInputManager.GetButtonDown("Punch1") && GameControl.manager.controlMode == ControlMode.touch)))
		{
			Debug.Log("Punch...");
			myhand.enabled = true;
			Punchit = false;
			playerAnimator.ForceStateNormalizedTime(0f);
			playerAnimator.SetBool("punchhit", true);
			playerAnimator.SetFloat("punchstatus", 2f);
			playerAnimator.Play("punching");
		}
	}

	private void makedelay()
	{
		Debug.Log("Punch...a");
		playerAnimator.SetFloat("punchstatus", 1f);
	}

	public void Climb()
	{
		bool flag = true;
		if (currentWeapon != null && currentWeapon.reloadProgress)
		{
			flag = false;
		}
		RaycastHit hitInfo;
		if (Physics.Raycast(base.transform.position + transformToRotate.forward * 0.45f + transformToRotate.up * 2.1f * characterHeight, -base.transform.up, out hitInfo, 1.8f) && !ragdollh.ragdolled && flag)
		{
			climbHit = true;
			climbY = hitInfo.point.y;
			float num = climbY - base.transform.position.y;
			if (hitInfo.collider.tag == "Climbable" && (controller.automaticClimb || (Input.GetKeyDown(controller.JumpKey) && GameControl.manager.controlMode == ControlMode.simple) || (CnInputManager.GetButtonDown("Jump2") && GameControl.manager.controlMode == ControlMode.touch)) && !pathMaker.play)
			{
				equippedbefore = equippedWeapon;
				if (equippedWeapon)
				{
					EquipWeaponToggle();
				}
				if (num > 1f)
				{
					climbing = true;
					aim = false;
					playerAnimator.SetTrigger("Climb");
					pathMaker.pointsTime[0] = Vector3.Distance(base.transform.position, pathMaker.points[0]);
					pathMaker.points[0].y = climbY - 1.5f;
					pathMaker.pointsTime[1] = 1f;
					pathMaker.points[1].y = climbY + 0.8f;
					pathMaker.points[1].z = 1f;
					pathMaker.pointsTime[2] = 1f;
					pathMaker.points[2].y = climbY + 1.3f;
					pathMaker.points[2].z = 1f;
					pathMaker.Play();
					return;
				}
			}
			if (climbing)
			{
				ikControll.LerpHandWeight(1f, 3f);
				ikControll.leftHandPos = hitInfo.point + transformToRotate.right * -0.3f + transformToRotate.forward * -0.3f;
				ikControll.rightHandPos = hitInfo.point + transformToRotate.right * 0.3f + transformToRotate.forward * -0.3f;
			}
		}
		else
		{
			climbHit = false;
			climbing = false;
			ikControll.LerpHandWeight(0f, 5f);
			if (equippedbefore)
			{
				equippedbefore = false;
				EquipWeaponToggle();
			}
		}
	}

	public void StandUp()
	{
		if (boneRb[0].transform.parent == null && ragdollh.ragdolled)
		{
			base.transform.position = boneRb[0].position;
		}
		RaycastHit hitInfo;
		if (ragdollh.ragdolled && ((Input.GetKeyDown(controller.JumpKey) && GameControl.manager.controlMode == ControlMode.simple) || (CnInputManager.GetButtonDown("Jump2") && GameControl.manager.controlMode == ControlMode.touch)) && Physics.SphereCast(base.transform.position + base.transform.up * 1f, 0.2f, -base.transform.up, out hitInfo, 3f))
		{
			ToggleRagdoll();
		}
	}

	public void ToggleRagdoll()
	{
		if (boneRb[0].velocity.magnitude > 1f)
		{
			return;
		}
		bool flag = !ragdollh.ragdolled;
		Rigidbody[] array = boneRb;
		foreach (Rigidbody rigidbody in array)
		{
			if (!flag)
			{
				capsuleC.enabled = true;
				ragdollh.ragdolled = false;
				rigidbody.isKinematic = true;
				rigidbody.velocity = Vector3.zero;
				boneRb[0].transform.parent = hipsParent;
				cameraParent.parent = base.transform;
				continue;
			}
			if (equippedWeapon)
			{
				EquipWeaponToggle();
			}
			crouch = false;
			ragdollh.ragdolled = true;
			aim = false;
			pathMaker.Reset();
			rb.useGravity = false;
			rigidbody.isKinematic = false;
			rigidbody.velocity = rb.velocity * 1.5f;
			playerAnimator.SetFloat("Move", 0f);
			playerAnimator.enabled = false;
			rb.velocity = Vector3.zero;
			rb.isKinematic = true;
			capsuleC.enabled = false;
			boneRb[0].transform.parent = null;
			cameraParent.parent = null;
		}
	}

	public void RagdollWhenFall()
	{
		if (!ragdollh.ragdolled && ragdollWhenFall && rb.velocity.y < -25f)
		{
			Damage(100f);
		}
	}

	public void Damage(float amount)
	{
		if (!dead)
		{
			life -= amount;
			GameUI.Instance.ShowPlayerHealth();
			if (life <= 0f)
			{
				Die();
			}
		}
	}

	public void Die()
	{
		dead = true;
		life = 0f;
		GameUI.Instance.ShowPlayerHealth();
		Player_Mesh.transform.gameObject.SetActive(false);
		policeKilledPlayer = true;
		player_DummyInstantiate = UnityEngine.Object.Instantiate(player_Dummy, base.transform.position, base.transform.rotation);
		Debug.Log("fail2");
		StartCoroutine(YouAreDeadPage.Instance.Open("You Killed Your Self", 1f));
		Leveldata.MissionFailed = true;
	}

	public void Revive()
	{
		if (dead)
		{
			Start();
			ToggleRagdoll();
		}
	}

	private void GroundCheck()
	{
		RaycastHit hitInfo;
		if (Physics.SphereCast(base.transform.position + base.transform.up * 2f, 0.15f, -base.transform.up, out hitInfo, 2.5f) && pM != null)
		{
			grounded = true;
			if (moveAxis == Vector3.zero || ragdollh.state == RagdollHelper.RagdollState.blendToAnim)
			{
				pM.staticFriction = 3f;
				pM.dynamicFriction = 3f;
			}
			else
			{
				pM.staticFriction = 0f;
				pM.dynamicFriction = 0f;
			}
		}
		else
		{
			grounded = false;
		}
	}

	private void LerpSpeed(float final)
	{
		runKeyPressed = Mathf.Lerp(runKeyPressed, final, 10f * Time.deltaTime);
	}

	private void Gravity()
	{
		if (ragdollh.state == RagdollHelper.RagdollState.animated)
		{
			Vector3 velocity = rb.velocity;
			velocity.y -= 10f * Time.deltaTime;
			rb.velocity = velocity;
		}
	}

	public WeaponBase GetCurrentWeapon()
	{
		if (weapons.Count > 0)
		{
			return weapons[PlayerPrefs.GetInt(StoreManager.selectedWeaponIndex)];
		}
		return null;
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
