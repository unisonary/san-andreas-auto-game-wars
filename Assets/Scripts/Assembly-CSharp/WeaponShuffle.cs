using UnityEngine;

public class WeaponShuffle : MonoBehaviour
{
	public GameObject player;

	public WeaponBase[] allWeapons;

	private void Start()
	{
		Invoke("createWeapons", 1f);
	}

	public void createWeapons()
	{
		for (int i = 0; i < allWeapons.Length; i++)
		{
			if (PlayerPrefs.GetInt(StoreManager.weaponsUnlockSystem[i]) == 1)
			{
				PlayerBehaviour.Instance.AddWeapon(allWeapons[i]);
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
