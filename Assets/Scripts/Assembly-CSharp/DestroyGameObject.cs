using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
	public float clearDistance = 150f;

	public GameObject myRoot;

	public Renderer myBody;

	public bool human;

	public bool vehicle;

	public RadarObj _radr;

	private void Update()
	{
		if ((bool)AIContoller.manager.player && Vector3.Distance(base.transform.position, AIContoller.manager.player.transform.position) > clearDistance && !myBody.isVisible)
		{
			if (human && AIContoller.manager.currentHumans >= 1)
			{
				AIContoller.manager.currentHumans--;
			}
			if (vehicle)
			{
				AIContoller.manager.currentVehicles--;
			}
			Object.Destroy(myRoot, 0.1f);
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
