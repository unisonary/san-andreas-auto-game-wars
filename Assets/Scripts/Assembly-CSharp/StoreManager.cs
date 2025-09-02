using UnityEngine;

public class StoreManager : MonoBehaviour
{
	private static int Coins;

	public static string KEY_COINS = "STORECOINS";

	public static string LevelsUnlock = "LEVELSUNLOCK";

	public static string selectedWeaponIndex = "SELECTEDWEAPON";

	public static string ContinueAllTime = "ContinueAllTime";

	public static string[] weaponsUnlockSystem = new string[6] { "w1", "w2", "w3", "w4", "w5", "w6" };

	public static string[] VideoKeys = new string[6] { "v1", "v2", "v3", "v4", "v5", "v6" };

	public static int[] VideoCounts = new int[6] { 0, 2, 3, 4, 5, 6 };

	public static int[] weaponPrice = new int[6] { 3800, 2500, 5000, 10000, 12000, 15000 };

	public static string[] weaponNames = new string[6] { "MP5", "M14", "Beretta Pigeon", "CA94", "Grenade", "AK47" };

	public static string freeResumesPurchased = "freeResumesPurchased";

	public static int oldWeaponIndex = 0;

	public static void AddCoins(int addedcoins)
	{
		Coins = PlayerPrefs.GetInt(KEY_COINS);
		Coins += addedcoins;
		PlayerPrefs.SetInt(KEY_COINS, Coins);
		if (addedcoins > 0)
		{
			Debug.Log(addedcoins + " Coins Added");
		}
	}

	public static void DeductCoins(int DeductedCoins)
	{
		Coins = PlayerPrefs.GetInt(KEY_COINS);
		Coins -= DeductedCoins;
		PlayerPrefs.SetInt(KEY_COINS, Coins);
	}

	public static int SHOWCOINS()
	{
		Coins = PlayerPrefs.GetInt(KEY_COINS);
		return Coins;
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
