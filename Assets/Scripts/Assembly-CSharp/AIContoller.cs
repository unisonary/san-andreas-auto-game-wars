using UnityEngine;

public class AIContoller : MonoBehaviour
{
	public static AIContoller manager;

	public bool showStatus = true;

	public int maxVehicles = 8;

	public int maxHumans = 8;

	public VehicleCamera vehicleCamera;

	public GameObject[] vehiclesPrefabs;

	public GameObject[] BoatPrefabs;

	public GameObject[] humansPrefabs;

	[HideInInspector]
	public int currentVehicles;

	[HideInInspector]
	public int currentHumans;

	public Transform player;

	private int frameCount;

	private float dt;

	private float fps;

	private float updateRate = 10f;

	private void Awake()
	{
		manager = this;
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
