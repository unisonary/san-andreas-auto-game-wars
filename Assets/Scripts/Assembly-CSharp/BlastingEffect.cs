using UnityEngine;

public class BlastingEffect : MonoBehaviour
{
	public GameObject Explosion_obj;

	public GameObject[] radar_obj;

	public Rigidbody myRigid;

	private void Start()
	{
	}

	public void Explod()
	{
		Explosion_obj.SetActive(true);
		for (int i = 0; i < radar_obj.Length; i++)
		{
			Object.Destroy(radar_obj[i]);
		}
		GetComponent<BezierController>().enabled = false;
		GetComponent<BoxCollider>().enabled = false;
		myRigid.AddExplosionForce(5000f, base.transform.position, 100f);
		LevelManager.mee.Helicopter_count--;
		if (LevelManager.mee.Helicopter_count <= 0)
		{
			Leveldata.mee.Lootcompleted(0, true, true, "Well Done", "Mission Completed");
		}
		Object.Destroy(base.gameObject, 5f);
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
