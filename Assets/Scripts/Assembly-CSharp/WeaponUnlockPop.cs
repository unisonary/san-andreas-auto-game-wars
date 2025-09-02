using System;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUnlockPop : MonoBehaviour
{
	public static string SMininutes = "smin";

	public static string Ssec = "Ssec";

	public static string Smsec = "Smsec";

	public static WeaponUnlockPop mee;

	public Text fallDownTimer_txt;

	private float fdminutes = 24f;

	private float fdseconds;

	private float fdmiliseconds;

	private void Start()
	{
		mee = this;
		fdminutes = 24 - DateTime.Now.Hour;
	}

	private void Update()
	{
		Falldowntimer();
	}

	public void Falldowntimer()
	{
		if (fdmiliseconds <= 0f)
		{
			if (fdseconds <= 0f)
			{
				Leveldata.mee.fdminutes -= 1f;
				fdseconds = 59f;
			}
			else if (fdseconds >= 0f)
			{
				fdseconds -= 1f;
			}
			fdmiliseconds = 100f;
		}
		fdmiliseconds -= Time.deltaTime * 100f;
		fallDownTimer_txt.text = string.Format("{0:00}:{1:00}:{2:00}", fdminutes, fdseconds, fdmiliseconds);
		if (fdseconds <= 0f && fdminutes == 0f)
		{
			Close();
		}
	}

	public void Open()
	{
		if (!PlayerPrefs.HasKey(SMininutes))
		{
			PlayerPrefs.SetInt(SMininutes, 24);
			PlayerPrefs.SetInt(Ssec, 0);
			PlayerPrefs.SetInt(Smsec, 0);
		}
		Debug.Log("time " + DateTime.Today.Minute);
		fdminutes = 24 - DateTime.Now.Hour;
	}

	public void Continue()
	{
		PlayerPrefs.SetInt(SMininutes, int.Parse(fdminutes.ToString()));
	}

	public void Close()
	{
		PlayerPrefs.SetInt(SMininutes, int.Parse(fdminutes.ToString()));
		base.gameObject.SetActive(false);
		LevelComplete.Instance.ContinueNext();
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
