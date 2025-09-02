using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[ExecuteInEditMode]
public class WeaponBase : MonoBehaviour
{
	[AttributeUsage(AttributeTargets.Field)]
	public class SettingsGroup : Attribute
	{
	}

	[AttributeUsage(AttributeTargets.Field)]
	public class AdvancedSetting : Attribute
	{
	}

	[Serializable]
	public struct CurrentPositioning
	{
		public Vector3 defaultPosition;

		public Quaternion defaultRotation;

		public Vector3 aimingPosition;

		public Quaternion aimingRotation;

		public static CurrentPositioning defaultSettings
		{
			get
			{
				CurrentPositioning result = default(CurrentPositioning);
				result.defaultPosition = Vector3.zero;
				result.defaultRotation = Quaternion.identity;
				result.aimingPosition = Vector3.zero;
				result.aimingRotation = Quaternion.identity;
				return result;
			}
		}
	}

	public enum PositioningPresets
	{
		PistolPreset = 0,
		RiflePreset = 1,
		RPGPreset = 2,
		Custom = 3
	}

	public enum ShootingMode
	{
		Raycast = 0,
		Projectile = 1
	}

	public enum UseLeftHand
	{
		No = 0,
		Yes = 1
	}

	private GameObject mesh;

	private Rigidbody rb;

	private BoxCollider bc;

	private Transform barrel;

	[HideInInspector]
	public bool usingLeftHand;

	[HideInInspector]
	public bool canShoot;

	public PlayerBehaviour pB;

	[HideInInspector]
	public Transform leftHand;

	[HideInInspector]
	public Transform rightHand;

	[HideInInspector]
	public Mesh leftHandMesh;

	[HideInInspector]
	public Mesh rightHandMesh;

	[HideInInspector]
	public Animator animator;

	[HideInInspector]
	public bool shootProgress;

	[HideInInspector]
	public bool isColliding;

	[HideInInspector]
	public bool reloadProgress;

	[Header("Settings")]
	public string weapon;

	[Range(1f, 16f)]
	public int raysPerShot = 1;

	public ShootingMode shootingMode;

	public GameObject projectile;

	public int maxInClipBullets;

	public int reloadBullets;

	public float fireRate;

	public float recoil;

	public float reloadTime;

	public int currentAmmo;

	[Header("Positioning")]
	public bool previewHands;

	public UseLeftHand useLeftHand = UseLeftHand.Yes;

	public bool updatePreset;

	public PositioningPresets PositioningPreset;

	private Vector3 inventoryPos = new Vector3(0f, -0.5f, 0.2f);

	private Quaternion inventoryRot = new Quaternion(0.5f, -0.35f, 0f, 1f);

	[SettingsGroup]
	public CurrentPositioning currentPositioning = CurrentPositioning.defaultSettings;

	[HideInInspector]
	public Vector3[] startPos = new Vector3[2];

	[HideInInspector]
	public Quaternion[] startRot = new Quaternion[2];

	private Vector3 defaultPositionPistol = new Vector3(0f, -0.7f, 0.2f);

	private Quaternion defaultRotationPistol = new Quaternion(0.45f, -0.47f, 0.25f, 1f);

	private Vector3 aimingPositionPistol = new Vector3(0.2f, -0.15f, 0.55f);

	private Quaternion aimingRotationPistol = new Quaternion(0f, 0f, 0f, 1f);

	private Vector3 defaultPositionRifle = new Vector3(0f, -0.45f, 0.2f);

	private Quaternion defaultRotationRifle = new Quaternion(0.35f, -0.7f, 0.25f, 1f);

	private Vector3 aimingPositionRifle = new Vector3(0.2f, -0.15f, 0.35f);

	private Quaternion aimingRotationRifle = new Quaternion(0f, 0f, 0f, 1f);

	private Vector3 defaultPositionRPG = new Vector3(0.1f, -0.05f, 0.25f);

	private Quaternion defaultRotationRPG = new Quaternion(0f, 0f, 0f, 1f);

	private Vector3 aimingPositionRPG = new Vector3(0.1f, -0.05f, 0.5f);

	private Quaternion aimingRotationRPG = new Quaternion(0f, 0f, 0f, 1f);

	[HideInInspector]
	public float currentRecoil;

	private AudioSource audioS;

	[Header("Audio")]
	public AudioClip pickUpAudio;

	public AudioClip shotAudio;

	public AudioClip noAmmoAudio;

	public AudioClip reloadAudio;

	public AudioClip aimAudio;

	public AudioClip switchAudio;

	[Header("Extras")]
	public Sprite icon;

	public Sprite centerCross;

	public ParticleSystem[] ShootParticles;

	private void Awake()
	{
		if (Application.isPlaying)
		{
			if (useLeftHand == UseLeftHand.Yes)
			{
				usingLeftHand = true;
			}
			animator = base.transform.GetChild(0).GetComponent<Animator>();
			leftHand = animator.transform.Find("LeftHand");
			rightHand = animator.transform.Find("RightHand");
			currentAmmo = maxInClipBullets;
			mesh = animator.transform.Find("Mesh").gameObject;
			barrel = animator.transform.Find("Barrel");
			rb = GetComponent<Rigidbody>();
			bc = GetComponent<BoxCollider>();
			audioS = GetComponent<AudioSource>();
			startPos[0] = leftHand.localPosition;
			startPos[1] = rightHand.localPosition;
			startRot[0] = leftHand.localRotation;
			startRot[1] = rightHand.localRotation;
		}
	}

	private void SetDefaultPositioning(Vector3 defaultPos, Quaternion defaultRot, Vector3 aimPos, Quaternion aimRot)
	{
		currentPositioning.defaultPosition = defaultPos;
		currentPositioning.defaultRotation = defaultRot;
		currentPositioning.aimingPosition = aimPos;
		currentPositioning.aimingRotation = aimRot;
	}

	private void OnDrawGizmos()
	{
		if (!previewHands)
		{
			return;
		}
		if (!animator)
		{
			animator = base.transform.GetChild(0).GetComponent<Animator>();
		}
		else
		{
			if (!leftHand)
			{
				leftHand = animator.transform.Find("LeftHand");
			}
			if (!rightHand)
			{
				rightHand = animator.transform.Find("RightHand");
			}
		}
		if ((bool)leftHand && (bool)rightHand)
		{
			if (!leftHandMesh)
			{
				GameObject gameObject = Resources.Load("Editor/Mesh/LeftHand") as GameObject;
				leftHandMesh = gameObject.GetComponent<MeshFilter>().sharedMesh;
			}
			if (!rightHandMesh)
			{
				GameObject gameObject2 = Resources.Load("Editor/Mesh/RightHand") as GameObject;
				rightHandMesh = gameObject2.GetComponent<MeshFilter>().sharedMesh;
			}
			if ((bool)leftHandMesh && (bool)rightHandMesh)
			{
				Gizmos.DrawMesh(leftHandMesh, leftHand.position, leftHand.rotation);
				Gizmos.DrawMesh(rightHandMesh, rightHand.position, rightHand.rotation);
			}
		}
	}

	private void Update()
	{
		if (updatePreset)
		{
			if (PositioningPreset == PositioningPresets.PistolPreset)
			{
				SetDefaultPositioning(defaultPositionPistol, defaultRotationPistol, aimingPositionPistol, aimingRotationPistol);
			}
			else if (PositioningPreset == PositioningPresets.RiflePreset)
			{
				SetDefaultPositioning(defaultPositionRifle, defaultRotationRifle, aimingPositionRifle, aimingRotationRifle);
			}
			else if (PositioningPreset == PositioningPresets.RPGPreset)
			{
				SetDefaultPositioning(defaultPositionRPG, defaultRotationRPG, aimingPositionRPG, aimingRotationRPG);
			}
			updatePreset = false;
		}
	}

	private void FixedUpdate()
	{
		if (raysPerShot == 1)
		{
			currentRecoil = Mathf.Lerp(currentRecoil, 0f, 0.02f);
		}
		else
		{
			currentRecoil = Mathf.Lerp(currentRecoil, 0.025f, 0.03f);
		}
		if ((bool)pB && pB.currentWeapon == this)
		{
			if (useLeftHand == UseLeftHand.No)
			{
				usingLeftHand = (pB.aim ? true : false);
			}
			isColliding = Physics.Linecast(base.transform.position - base.transform.forward * bc.size.z * 2f, base.transform.position + base.transform.forward * bc.size.z);
		}
	}

	public void Shoot()
	{
		if (isColliding)
		{
			return;
		}
		if (currentAmmo > 0 && !reloadProgress && !shootProgress)
		{
			StartCoroutine(ShootProgress());
		}
		else if (currentAmmo == 0 && !reloadProgress && !shootProgress)
		{
			if (!audioS.isPlaying)
			{
				audioS.PlayOneShot(noAmmoAudio);
			}
			Reload();
		}
	}

	private IEnumerator ShootProgress()
	{
		shootProgress = true;
		if (!pB.aim)
		{
			yield return new WaitForSeconds(0.25f);
		}
		if (!pB.aim)
		{
			shootProgress = false;
			StopCoroutine(ShootProgress());
			yield break;
		}
		animator.Rebind();
		animator.Play("Shoot");
		pB.recoil = UnityEngine.Random.Range(recoil, recoil * 2f);
		audioS.PlayOneShot(shotAudio);
		currentAmmo--;
		if (shootingMode == ShootingMode.Projectile)
		{
			ProjectileShoot();
		}
		else
		{
			RaycastShoot();
		}
		if (currentRecoil < recoil)
		{
			currentRecoil += 0.02f;
		}
		yield return new WaitForSeconds(fireRate);
		shootProgress = false;
		leftHand.localPosition = startPos[0];
		leftHand.localRotation = startRot[0];
		rightHand.localPosition = startPos[1];
		rightHand.localRotation = startRot[1];
	}

	private void RaycastShoot()
	{
		if (ShootParticles.Length != 0)
		{
			ShootParticles[0].Play();
			ShootParticles[1].Play();
			ShootParticles[2].Play();
		}
		for (int i = 0; i < raysPerShot; i++)
		{
			Vector3 vector = UnityEngine.Random.insideUnitSphere * currentRecoil;
			if (i > 0)
			{
				vector *= (float)i;
			}
			RaycastHit hitInfo;
			if (Physics.Raycast(pB.cam.position, pB.cam.forward + vector, out hitInfo))
			{
				RaycastHit hitInfo2;
				Physics.Linecast(barrel.position, hitInfo.point + pB.cam.forward, out hitInfo2);
				if (hitInfo2.transform == null)
				{
					break;
				}
				HandleHit(hitInfo2);
				ShotVisuals(hitInfo2);
			}
		}
	}

	private void HandleHit(RaycastHit h)
	{
	}

	private void ShotVisuals(RaycastHit h)
	{
		string text = h.transform.tag;
		if (text != "" && text != "Weapon" && text != "Player" && text != "Human" && text != "Police" && text != "Vehicle" && text != "Enemy")
		{
			int nextBulletHole = HUDBehaviour.instance.nextBulletHole;
			GameObject gameObject = HUDBehaviour.instance.bulletHoles[nextBulletHole];
			gameObject.transform.position = h.point;
			gameObject.transform.rotation = Quaternion.identity;
			gameObject.transform.rotation = Quaternion.FromToRotation(-gameObject.transform.forward, h.normal);
			gameObject.SetActive(true);
			HUDBehaviour.instance.nextBulletHole++;
			if (HUDBehaviour.instance.nextBulletHole > HUDBehaviour.instance.bulletHoles.Count - 1)
			{
				HUDBehaviour.instance.nextBulletHole = 0;
			}
			if (h.collider.gameObject.name.StartsWith("star_board"))
			{
				Debug.Log(string.Concat(base.transform.root, " : rot"));
				h.transform.gameObject.GetComponent<StarObj>().Unfreeze();
				h.transform.gameObject.GetComponent<StarObj>().OnTriggerEnter(base.transform.root.GetComponent<Collider>());
				UnityEngine.Object.Destroy(h.transform.gameObject, 2f);
			}
			return;
		}
		switch (text)
		{
		case "Vehicle":
			Debug.Log(string.Concat(h.collider.gameObject, " 090 ", h.transform.gameObject.GetComponent<VehicleHealth>()));
			if ((bool)h.transform.GetComponent<VehicleHealth>())
			{
				h.transform.gameObject.GetComponent<VehicleHealth>().OnShootVehicle();
				Debug.Log(text + "----------" + h.transform.GetComponent<VehicleHealth>().Vehiclehealth);
			}
			break;
		case "Human":
			if ((bool)h.transform.GetComponent<AICharacterControl>())
			{
				h.transform.GetComponent<AICharacterControl>().Damage(30f);
			}
			if ((bool)h.transform.GetComponent<NavMeshAgent>())
			{
				h.transform.GetComponent<NavMeshAgent>().speed = 2f;
			}
			break;
		case "Police":
			if ((bool)h.transform.GetComponent<PoliceBehaviour>())
			{
				h.transform.GetComponent<PoliceBehaviour>().Damage(30f);
			}
			break;
		case "Enemy":
			if ((bool)h.transform.GetComponent<EnemyBehaviour>())
			{
				h.transform.GetComponent<EnemyBehaviour>().Damage(30f);
			}
			break;
		}
	}

	private void ProjectileShoot()
	{
		RaycastHit hitInfo;
		Physics.Raycast(pB.cam.position, pB.cam.forward, out hitInfo);
		GameObject gameObject = UnityEngine.Object.Instantiate(projectile, barrel.position, barrel.rotation);
		if (!(hitInfo.transform == null) && pB.aim)
		{
			gameObject.transform.LookAt(hitInfo.point);
		}
	}

	public void Reload()
	{
		if (currentAmmo < maxInClipBullets && reloadBullets > 0 && !reloadProgress)
		{
			StartCoroutine(ReloadProgress());
		}
	}

	private IEnumerator ReloadProgress()
	{
		int toRefill = maxInClipBullets - currentAmmo;
		shootProgress = false;
		reloadProgress = true;
		animator.Play("Reload");
		audioS.PlayOneShot(reloadAudio);
		yield return new WaitForSeconds(reloadTime);
		if (toRefill <= reloadBullets)
		{
			reloadBullets -= toRefill;
			currentAmmo += toRefill;
		}
		else
		{
			currentAmmo += reloadBullets;
			reloadBullets = 0;
		}
		reloadProgress = false;
		leftHand.localPosition = startPos[0];
		leftHand.localRotation = startRot[0];
		rightHand.localPosition = startPos[1];
		rightHand.localRotation = startRot[1];
	}

	public void AimAudio()
	{
		audioS.PlayOneShot(aimAudio);
	}

	public void PutInInventory()
	{
		if ((bool)audioS)
		{
			audioS.PlayOneShot(pickUpAudio);
		}
		UnityEngine.Object.Destroy(rb);
		bc.enabled = false;
		base.transform.localPosition = inventoryPos;
		base.transform.localRotation = inventoryRot;
		Debug.Log("PutInvetory");
	}

	public void RemoveFromInventory()
	{
		base.gameObject.AddComponent<Rigidbody>();
		bc.enabled = true;
	}

	public void ToggleRenderer(bool value)
	{
		mesh.SetActive(value);
		if (value)
		{
			audioS.PlayOneShot(switchAudio);
		}
		if (!value)
		{
			base.transform.localPosition = inventoryPos;
			base.transform.localRotation = inventoryRot;
			Debug.Log("Set Invetory");
		}
	}

	public void MoveTo(Transform reference)
	{
		Vector3 b = currentPositioning.defaultPosition;
		Quaternion b2 = Quaternion.identity;
		if (pB.aim || reloadProgress)
		{
			if (reloadProgress)
			{
				usingLeftHand = true;
			}
			if (pB.halfSwitchingWeapons)
			{
				b = currentPositioning.aimingPosition;
				b2 = currentPositioning.aimingRotation;
			}
		}
		else
		{
			if (!pB.crouch)
			{
				if (pB.grounded)
				{
					b = currentPositioning.defaultPosition;
				}
				else
				{
					b = currentPositioning.defaultPosition;
					b.y += 0.3f;
					b.z += 0.1f;
				}
			}
			else
			{
				b.z -= 0.1f;
			}
			b2 = currentPositioning.defaultRotation;
		}
		if (pB.switchingWeapons && !pB.halfSwitchingWeapons)
		{
			b = inventoryPos;
			b2 = inventoryRot;
		}
		base.transform.localPosition = Vector3.Slerp(base.transform.localPosition, b, 6f * Time.deltaTime);
		base.transform.localRotation = Quaternion.Slerp(base.transform.localRotation, b2, 8f * Time.deltaTime);
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
