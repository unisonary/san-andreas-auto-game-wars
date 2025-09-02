using UnityEngine;
using UnityEngine.SceneManagement;

public class AdsCheckSamplePage : MonoBehaviour
{
	public void AdmobInterstitalLoad()
	{
		Debug.Log("---- AdmobInterstitalLoad");
		AdsDisplayCheck.instance.RequestAdmobInterstitial();
	}

	public void AdmobInterstitialShow()
	{
		Debug.Log("---- AdmobInterstitialShow");
		AdsDisplayCheck.instance.ShowAdmobInterstitial();
	}

	public void AdmobRewardedlLoad()
	{
		Debug.Log("---- AdmobRewardedlLoad");
		AdsDisplayCheck.instance.RequestAdmobRewardBasedVideo();
	}

	public void AdmobRewardedShow()
	{
		Debug.Log("---- AdmobRewardedShow");
		AdsDisplayCheck.instance.ShowAdmobRewardBasedVideo();
	}

	public void UnityInterstitalShow()
	{
		Debug.Log("---- UnityInterstitalShow");
		AdsDisplayCheck.instance.ShowUnityAd();
	}

	public void UnityRewardedShow()
	{
		Debug.Log("----UnityRewardedShow ");
		AdsDisplayCheck.instance.ShowUnityRewardedVideoAd();
	}

	public void IronSourceInterstitalLoad()
	{
		Debug.Log("---- IronSourceInterstitalLoad");
		AdsDisplayCheck.instance.LoadIronSourceInterstitial();
	}

	public void IronSourceInterstitialShow()
	{
		Debug.Log("---- IronSourceInterstitialShow");
		AdsDisplayCheck.instance.ShowIronSourceInterstitial();
	}

	public void IronSourceRewardedShow()
	{
		Debug.Log("---- IronSourceRewardedShow");
		AdsDisplayCheck.instance.ShowIronSourceRewardVideo();
	}

	public void IronSourceValidate()
	{
		Debug.Log("---- IronSourceValidate");
		AdsDisplayCheck.instance.ValidateIntegration();
	}

	public void BackClick()
	{
		SceneManager.LoadScene("MenuSample");
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
