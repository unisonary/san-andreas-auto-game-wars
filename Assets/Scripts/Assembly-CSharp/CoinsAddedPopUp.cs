using UnityEngine;
using UnityEngine.UI;

public class CoinsAddedPopUp : MonoBehaviour
{
	public static CoinsAddedPopUp instance;

	public GameObject PopUp;

	public GameObject CloseBtn;

	public Text Desc;

	public Text RewardDesc;

	private void Awake()
	{
		instance = this;
		base.gameObject.SetActive(false);
	}

	public void Open(int Coins, AdManager.RewardDescType rewardType)
	{
		base.gameObject.SetActive(true);
		switch (rewardType)
		{
		case AdManager.RewardDescType.WatchVideo:
			Desc.text = "Thank you for Watching!";
			break;
		case AdManager.RewardDescType.Sharing:
			Desc.text = "Thank you for Sharing!";
			break;
		case AdManager.RewardDescType.Rating:
			Desc.text = "Thank you for Rating!";
			break;
		case AdManager.RewardDescType.Notification:
			Desc.text = "";
			break;
		case AdManager.RewardDescType.Other:
			Desc.text = "";
			break;
		}
		RewardDesc.text = "Your reward " + Coins + " Coins";
		PopUp.transform.localPosition = Vector3.zero;
		iTween.MoveFrom(PopUp, iTween.Hash("y", 1000, "time", 0.4f, "islocal", true, "easetype", iTween.EaseType.spring));
		iTween.Stop(CloseBtn);
		CloseBtn.transform.localScale = Vector3.one;
		iTween.ScaleFrom(CloseBtn, iTween.Hash("x", 0, "y", 0, "time", 0.5, "delay", 2.5f, "easetype", iTween.EaseType.spring));
	}

	public void Close()
	{
		base.gameObject.SetActive(false);
	}

	public void WatchVideoClick()
	{
		AdManager.instance.ShowRewardVideoWithCallback(delegate(bool result)
		{
			if (result)
			{
				CallbacksController.instance.AddCoins(AdManager.instance.RewardToWatchAnotherVideo, AdManager.RewardDescType.WatchVideo, AdManager.RewardType.WatchVideoAgain);
				AdManager.instance.ShowToast(AdManager.instance.RewardToWatchAnotherVideo + " coins added successfully");
				Close();
				AdManager.instance.ShowToast(AdManager.instance.RewardToWatchAnotherVideo + " Coins added successfully");
			}
		});
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
