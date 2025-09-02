using UnityEngine;

public class passRayCastNow : MonoBehaviour
{
	public GameObject bullet;

	public GameObject PistolFire;

	public GameObject Myparent;

	public GameObject _obj;

	public Vector3 TargetPos;

	public float Xpos;

	public float zpos;

	private void Start()
	{
		Debug.Log("Enable " + Myparent);
		TargetPos = GameObject.FindGameObjectWithTag("Player").transform.position + new Vector3(0f, 2f, 0f);
	}

	private void OnEnable()
	{
		InvokeRepeating("passRaycastPolice", 3f, 3f);
	}

	private void Update()
	{
	}

	private void passRaycastPolice()
	{
		bullet.SetActive(true);
		PistolFire.gameObject.SetActive(true);
		Invoke("hideBullet", 0.5f);
	}

	private void hideBullet()
	{
		bullet.gameObject.SetActive(false);
		PistolFire.gameObject.SetActive(false);
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
