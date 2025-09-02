using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(BoxCollider))]
public class HoverEffect : MonoBehaviour
{
	public Texture NormalTexxture;

	public Texture HoverTexture;

	private void OnMouseOver()
	{
		if ((bool)HoverTexture)
		{
			GetComponent<Renderer>().material.mainTexture = HoverTexture;
		}
	}

	private void OnMouseExit()
	{
		if ((bool)NormalTexxture)
		{
			GetComponent<Renderer>().material.mainTexture = NormalTexxture;
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
