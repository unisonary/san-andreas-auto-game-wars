using UnityEngine;

public class TrafficLight : MonoBehaviour
{
	public Transform currentNode;

	public GameObject redLight;

	public GameObject yellowLight;

	public GameObject greenLight;

	private Node nodeComponent;

	public void Start()
	{
		nodeComponent = currentNode.GetComponent<Node>();
	}

	private void Update()
	{
		if (Vector3.Distance(AIContoller.manager.player.position, currentNode.position) > 200f)
		{
			greenLight.SetActive(false);
			yellowLight.SetActive(false);
			redLight.SetActive(false);
			return;
		}
		switch (nodeComponent.trafficMode)
		{
		case TrafficMode.Go:
			greenLight.SetActive(true);
			yellowLight.SetActive(false);
			redLight.SetActive(false);
			break;
		case TrafficMode.Wait:
			greenLight.SetActive(false);
			yellowLight.SetActive(true);
			redLight.SetActive(false);
			break;
		case TrafficMode.Stop:
			greenLight.SetActive(false);
			yellowLight.SetActive(false);
			redLight.SetActive(true);
			break;
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
