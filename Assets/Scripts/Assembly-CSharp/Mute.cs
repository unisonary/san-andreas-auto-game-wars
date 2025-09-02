using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{
	public static bool mute;

	public Sprite muteSprite;

	public Sprite unmuteSprite;

	public Image musicSprite;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void taggleMute()
	{
		mute = !mute;
		if (mute)
		{
			MonoBehaviour.print("mute");
			AudioListener.volume = 0f;
			musicSprite.sprite = muteSprite;
		}
		else
		{
			AudioListener.volume = 1f;
			musicSprite.sprite = unmuteSprite;
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
