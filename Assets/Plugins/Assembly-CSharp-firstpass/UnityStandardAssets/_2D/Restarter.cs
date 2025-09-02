using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
	public class Restarter : MonoBehaviour
	{
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "Player")
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
