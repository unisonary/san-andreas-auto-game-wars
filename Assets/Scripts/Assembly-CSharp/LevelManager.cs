using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Water;

public class LevelManager : MonoBehaviour
{
	public bool Inpopup = true;

	public bool InpopupA;

	public int killEnemies_count;

	public int DropPerson_count;

	public int policekill_count;

	public int Personkill_count;

	public int starscollect_count;

	public int LootCash_count;

	public float Timer_count;

	public int EnemyVehiclesBlaststatic;

	public int EnemyVehiclesBlast_nonstatic;

	public int Helicopter_count;

	public static bool _islootMission;

	public static bool _isKillpeopleMission;

	public static bool _isKillPoliceMission;

	public bool Time_over;

	public Text _missionInfo;

	public GameObject MainPlayer;

	private bool ShowCompleteOnce;

	public static LevelManager mee;

	public GameObject Freemode;

	public GameObject[] AllLevels_obj;

	public GameObject PausePage;

	public WaterBase _wb;

	public GameObject ShowHint;

	[Header("Audio")]
	public AudioClip[] Sounds_m;

	public AudioSource[] audioSource;

	public GameObject PlayerVehicle;

	public void Btn_Sound(int _index)
	{
		audioSource[0].PlayOneShot(Sounds_m[_index]);
	}

	public void Bg_Sound(int _index)
	{
		audioSource[1].Stop();
		audioSource[_index].Play();
	}

	public void stopBg_Sound()
	{
		audioSource[1].Stop();
	}

	public void PlayBg_Sound()
	{
		audioSource[1].Play();
	}

	private void Start()
	{
		mee = this;
		ShowHint.SetActive(false);
		MenuPageHandler.menusoundplaying = false;
		Debug.Log("---- " + LevelSelectionHandler.CurrentLevel);
		_wb.enabled = true;
		Invoke("disableWaterUpdate", 1f);
		if (LevelSelectionHandler.CurrentLevel == 50)
		{
			Freemode.SetActive(true);
		}
		else
		{
			AllLevels_obj[LevelSelectionHandler.CurrentLevel - 1].SetActive(true);
		}
	}

	private void disableWaterUpdate()
	{
		_wb.enabled = false;
	}

	public void Continue_mission()
	{
		Debug.Log("---- " + LevelSelectionHandler.CurrentLevel);
		Leveldata.mee.CountinueMiissionNow();
	}

	private void Update()
	{
		if (Leveldata.startGame && killEnemies_count == 0 && DropPerson_count == 0 && policekill_count == 0 && starscollect_count == 0 && LootCash_count == 0 && !ShowCompleteOnce && EnemyVehiclesBlaststatic == 0 && EnemyVehiclesBlast_nonstatic == 0 && Helicopter_count == 0)
		{
			ShowCompleteOnce = true;
			Debug.Log("Show Complete");
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (PausePage.activeInHierarchy)
			{
				PausePage.SetActive(true);
				Time.timeScale = 0f;
			}
			else
			{
				PausePage.SetActive(false);
				Time.timeScale = 1f;
			}
		}
	}

	public void PauseEnable()
	{
		PausePage.SetActive(true);
		Time.timeScale = 0f;
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
