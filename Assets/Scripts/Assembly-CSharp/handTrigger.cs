using UnityEngine;
using UnityEngine.AI;

public class handTrigger : MonoBehaviour
{
	public static handTrigger mee;

	private void Start()
	{
		mee = this;
	}

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log(other.gameObject.name + "---- hand" + other.gameObject.transform.parent);
		if (other.gameObject.tag == "Human" || other.gameObject.tag == "Police")
		{
			other.gameObject.GetComponent<AICharacterControl>().Damage(50f);
			if ((bool)other.transform.GetComponent<NavMeshAgent>())
			{
				other.transform.GetComponent<NavMeshAgent>().speed = 2f;
			}
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
