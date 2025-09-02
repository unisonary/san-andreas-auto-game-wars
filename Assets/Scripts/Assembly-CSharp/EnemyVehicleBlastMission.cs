using UnityEngine;

public class EnemyVehicleBlastMission : MonoBehaviour
{
	public bool NotOnPath;

	public Node[] Onpath_vehicle;

	public GameObject[] NotOnPath_vehicle;

	public GameObject Helicopter_obj;

	private void Start()
	{
		Debug.Log("Enemy Created");
		if (NotOnPath)
		{
			for (int i = 0; i < NotOnPath_vehicle.Length; i++)
			{
				CreateAI.mee.CreateEnemyVehicles_OnSide(NotOnPath_vehicle[i]);
			}
		}
		else
		{
			for (int j = 0; j < Onpath_vehicle.Length; j++)
			{
				CreateAI.mee.CreateEnemyVehicles(Onpath_vehicle[j]);
			}
		}
		if (Helicopter_obj != null)
		{
			Helicopter_obj.SetActive(true);
		}
	}

	private void Update()
	{
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
