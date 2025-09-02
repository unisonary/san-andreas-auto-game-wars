using UnityEngine;

public class MakeMoney : MonoBehaviour
{
	public int Value;

	private void OnTriggerEnter(Collider collider)
	{
		if (!(collider.gameObject.tag == "Player"))
		{
			return;
		}
		StoreManager.AddCoins(Value);
		Debug.Log("---" + LevelManager._islootMission);
		if (LevelManager.mee.LootCash_count > 0 && LevelManager._islootMission)
		{
			LevelManager.mee.LootCash_count -= Value;
			Leveldata.mee.Hint_mission[1].gameObject.SetActive(true);
			Leveldata.mee.Hint_mission[1].text = Leveldata.mee.Moneytoloot - LevelManager.mee.LootCash_count + "/" + Leveldata.mee.Moneytoloot;
			if (LevelManager.mee.LootCash_count <= 0)
			{
				Leveldata.mee.Lootcompleted(0, true, true, "Well Done", "Mission Completed");
				LevelManager._islootMission = false;
			}
			Debug.Log("loot amount " + LevelManager.mee.LootCash_count);
		}
		Object.Destroy(base.gameObject);
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
