using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class CFX_AutoDestructShuriken : MonoBehaviour
{
	public bool OnlyDeactivate;

	private void OnEnable()
	{
		StartCoroutine("CheckIfAlive");
	}

	private IEnumerator CheckIfAlive()
	{
		do
		{
			yield return new WaitForSeconds(0.5f);
		}
		while (GetComponent<ParticleSystem>().IsAlive(true));
		if (OnlyDeactivate)
		{
			base.gameObject.SetActive(false);
		}
		else
		{
			Object.Destroy(base.gameObject);
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
