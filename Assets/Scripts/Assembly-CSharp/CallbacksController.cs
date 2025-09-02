using System;
using UnityEngine;

public class CallbacksController : MonoBehaviour
{
	public static CallbacksController instance;

	private void Awake()
	{
		instance = this;
	}

	public void VideoRewardCallback(bool isRewarded)
	{
		if (isRewarded)
		{
			switch (AdManager.instance.VideoRewardType)
			{
			case AdManager.RewardType.Coins:
				Debug.Log("------ Give coins as reward");
				AddCoins(AdManager.instance.VideoRewardCoins);
				break;
			case AdManager.RewardType.DoubleCoins:
				Debug.Log("----- Give Double coins as reward");
				break;
			case AdManager.RewardType.Resume:
				Debug.Log("----- Resume Game play");
				break;
			}
		}
	}

	public void InAppCallBacks(string productID)
	{
		PlayerPrefs.SetString("NoAds", "true");
		if (string.Equals(productID, InAppController.instance.ConsumableProducts[0], StringComparison.Ordinal))
		{
			PlayerPrefs.SetInt(GlobalVariables.sTotalCoinsAvaliable, PlayerPrefs.GetInt(GlobalVariables.sTotalCoinsAvaliable) + 25000);
			PlayerPrefs.SetInt(StoreManager.KEY_COINS, PlayerPrefs.GetInt(StoreManager.KEY_COINS) + 25000);
			Debug.Log("Purchase Success product ID=" + productID);
		}
		else if (string.Equals(productID, InAppController.instance.ConsumableProducts[1], StringComparison.Ordinal))
		{
			PlayerPrefs.SetInt(StoreManager.KEY_COINS, PlayerPrefs.GetInt(StoreManager.KEY_COINS) + 50000);
			PlayerPrefs.SetInt(GlobalVariables.sTotalCoinsAvaliable, PlayerPrefs.GetInt(GlobalVariables.sTotalCoinsAvaliable) + 50000);
			Debug.Log("Purchase Success product ID=" + productID);
		}
		if (string.Equals(productID, InAppController.instance.NonConsumableProducts[0], StringComparison.Ordinal))
		{
			Debug.Log("Purchase Success product ID=" + productID);
			PlayerPrefs.SetString("NoAds", "true");
		}
		else if (string.Equals(productID, InAppController.instance.NonConsumableProducts[1], StringComparison.Ordinal))
		{
			Debug.Log("Purchase Success product ID=" + productID);
			for (int i = 0; i < StoreManager.weaponsUnlockSystem.Length; i++)
			{
				PlayerPrefs.SetInt(StoreManager.weaponsUnlockSystem[i], 1);
			}
			PlayerPrefs.SetString("weaponsunlocked", "true");
		}
		else if (string.Equals(productID, InAppController.instance.NonConsumableProducts[2], StringComparison.Ordinal))
		{
			for (int j = 0; j < 20; j++)
			{
				PlayerPrefs.SetInt("levelsUnlocked" + j, 1);
			}
			PlayerPrefs.SetString("levelUnlocked", "true");
			PlayerPrefs.SetString("NoAds", "true");
			Debug.Log("Purchase Success product ID=" + productID);
		}
		else if (string.Equals(productID, InAppController.instance.NonConsumableProducts[3], StringComparison.Ordinal))
		{
			for (int k = 0; k < 20; k++)
			{
				PlayerPrefs.SetInt("levelsUnlocked" + k, 1);
			}
			for (int l = 0; l < StoreManager.weaponsUnlockSystem.Length; l++)
			{
				PlayerPrefs.SetInt(StoreManager.weaponsUnlockSystem[l], 1);
			}
			PlayerPrefs.SetString("levelUnlocked", "true");
			PlayerPrefs.SetString("weaponsunlocked", "true");
			PlayerPrefs.SetString("NoAds", "true");
		}
	}

	public void AddCoins(int coins, AdManager.RewardDescType rewardDescType = AdManager.RewardDescType.WatchVideo, AdManager.RewardType rewardType = AdManager.RewardType.Coins)
	{
		PlayerPrefs.SetInt(GlobalVariables.sTotalCoinsAvaliable, PlayerPrefs.GetInt(GlobalVariables.sTotalCoinsAvaliable) + coins);
		PlayerPrefs.SetInt(StoreManager.KEY_COINS, PlayerPrefs.GetInt(StoreManager.KEY_COINS) + coins);
		if (rewardType != AdManager.RewardType.WatchVideoAgain && rewardType != 0)
		{
			CoinsAddedPopUp.instance.Open(coins, rewardDescType);
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
