using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDBehaviour : MonoBehaviour
{
	public static HUDBehaviour instance;

	private PlayerBehaviour pB;

	public GameObject weaponInfo;

	public GameObject HandIcon;

	public GameObject HandIcon2;

	public Text weaponAmmo;

	public Image weaponIcon;

	public Image weaponIcon2;

	public Image centerCross;

	private WeaponBase currentWeapon;

	public int maxBulletHolesInScene = 256;

	[HideInInspector]
	public int nextBulletHole;

	[HideInInspector]
	public List<GameObject> bulletHoles = new List<GameObject>();

	public Camera _myCamera;

	public static bool ZoomIn;

	public GameObject[] fullHealthImage;

	private void Start()
	{
		instance = this;
		GameObject gameObject = new GameObject("Bullet Hole Repository");
		GameObject original = (GameObject)Resources.Load("Prefabs/Particles/BulletHole");
		for (int i = 0; i < maxBulletHolesInScene; i++)
		{
			GameObject gameObject2 = Object.Instantiate(original, gameObject.transform.position, Quaternion.identity);
			gameObject2.SetActive(false);
			gameObject2.transform.parent = gameObject.transform;
			bulletHoles.Add(gameObject2);
		}
		pB = GetComponent<PlayerBehaviour>();
		pB.OnWeaponSwitch += GetWeaponSprites;
	}

	public void ZoominOut(int aa = 0)
	{
		if (aa == 1)
		{
			ZoomIn = true;
		}
		ZoomIn = !ZoomIn;
		if (ZoomIn)
		{
			_myCamera.fieldOfView = 15f;
			fullHealthImage[0].SetActive(false);
			fullHealthImage[1].SetActive(false);
		}
		else
		{
			_myCamera.fieldOfView = 70f;
			fullHealthImage[0].SetActive(true);
			fullHealthImage[1].SetActive(true);
		}
	}

	private void Update()
	{
		WeaponInfo();
	}

	private void WeaponInfo()
	{
		if ((bool)currentWeapon && pB.equippedWeapon)
		{
			if (pB.aim)
			{
				centerCross.enabled = true;
			}
			else
			{
				centerCross.enabled = false;
			}
			weaponInfo.SetActive(true);
			HandIcon.SetActive(false);
			HandIcon2.SetActive(false);
			float num = currentWeapon.currentRecoil * 4f;
			centerCross.transform.localScale = new Vector3(num + 0.3f, num + 0.3f, 1f);
			weaponAmmo.text = currentWeapon.currentAmmo.ToString();
		}
		else
		{
			weaponInfo.SetActive(false);
			HandIcon.SetActive(true);
			HandIcon2.SetActive(true);
			centerCross.enabled = false;
		}
	}

	private void GetWeaponSprites()
	{
		currentWeapon = pB.currentWeapon;
		if ((bool)currentWeapon.centerCross)
		{
			centerCross.sprite = currentWeapon.centerCross;
		}
		if ((bool)currentWeapon.icon)
		{
			weaponIcon.enabled = true;
			weaponIcon.sprite = currentWeapon.icon;
			weaponIcon2.sprite = currentWeapon.icon;
		}
		else
		{
			weaponIcon.enabled = false;
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
