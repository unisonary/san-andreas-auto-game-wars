using System;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class RatePage : MonoBehaviour
{
	public delegate void RateSuccessCheck();

	public static RatePage instance;

	public GameObject PopUp;

	public GameObject[] FillStars;

	public GameObject RateBtn;

	public GameObject ThankYouBtn;

	public Text Desc;

	[CompilerGenerated]
	private static RateSuccessCheck m_RateSuccessCallBack;

	public static event RateSuccessCheck RateSuccessCallBack
	{
		[CompilerGenerated]
		add
		{
			RateSuccessCheck rateSuccessCheck = RatePage.m_RateSuccessCallBack;
			RateSuccessCheck rateSuccessCheck2;
			do
			{
				rateSuccessCheck2 = rateSuccessCheck;
				RateSuccessCheck value2 = (RateSuccessCheck)Delegate.Combine(rateSuccessCheck2, value);
				rateSuccessCheck = Interlocked.CompareExchange(ref RatePage.m_RateSuccessCallBack, value2, rateSuccessCheck2);
			}
			while (rateSuccessCheck != rateSuccessCheck2);
		}
		[CompilerGenerated]
		remove
		{
			RateSuccessCheck rateSuccessCheck = RatePage.m_RateSuccessCallBack;
			RateSuccessCheck rateSuccessCheck2;
			do
			{
				rateSuccessCheck2 = rateSuccessCheck;
				RateSuccessCheck value2 = (RateSuccessCheck)Delegate.Remove(rateSuccessCheck2, value);
				rateSuccessCheck = Interlocked.CompareExchange(ref RatePage.m_RateSuccessCallBack, value2, rateSuccessCheck2);
			}
			while (rateSuccessCheck != rateSuccessCheck2);
		}
	}

	private void Awake()
	{
		instance = this;
		base.gameObject.SetActive(false);
	}

	public void Open()
	{
		base.gameObject.SetActive(true);
		for (int i = 0; i < FillStars.Length; i++)
		{
			FillStars[i].SetActive(false);
		}
		ThankYouBtn.SetActive(false);
		RateBtn.SetActive(false);
		if (AdManager.instance.RateDesc != string.Empty)
		{
			Desc.text = AdManager.instance.RateDesc;
		}
		PopUp.transform.localPosition = Vector3.zero;
		iTween.MoveFrom(PopUp, iTween.Hash("y", 1000, "time", 0.4f, "islocal", true, "easetype", iTween.EaseType.spring));
	}

	public void Close()
	{
		base.gameObject.SetActive(false);
	}

	public void StarClick(int StarCount)
	{
		RateBtn.SetActive(false);
		ThankYouBtn.SetActive(false);
		for (int i = 0; i < FillStars.Length; i++)
		{
			if (i < StarCount)
			{
				FillStars[i].SetActive(true);
			}
		}
		if (StarCount > 3)
		{
			RateBtn.SetActive(true);
		}
		else
		{
			ThankYouBtn.SetActive(true);
		}
	}

	public void ThankYouClick()
	{
		PlayerPrefs.SetString("IsRated", "true");
		//if (RatePage.RateSuccessCallBack != null)
		//{
		//	RatePage.RateSuccessCallBack();
		//}
		Close();
	}

	public void RateClick()
	{
		PlayerPrefs.SetString("IsRated", "true");
		Application.OpenURL("market://details?id=" + Application.identifier);
		if (AdManager.instance.RateCoins > 0)
		{
			AdManager.instance.StartCoroutine(AdManager.instance.AddCoinsWithDelay(2f, AdManager.instance.RateCoins, AdManager.RewardDescType.Rating));
		}
		//if (RatePage.RateSuccessCallBack != null)
		//{
		//	RatePage.RateSuccessCallBack();
		//}
		Close();
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
