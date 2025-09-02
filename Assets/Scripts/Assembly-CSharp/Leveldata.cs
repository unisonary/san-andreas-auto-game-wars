using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leveldata : MonoBehaviour
{
	public int Levelrewards;

	public int HelpNum;

	public GameObject _helpObj;

	public GameObject _PlayerPos;

	public static bool ArjMission_start = false;

	public GameObject[] Level_Missions;

	public string[] Level_Missions_txt;

	public GameUI _gameui;

	public missionCheck CurrentMission;

	public int CurrentMission_index;

	public static Leveldata mee;

	public List<GameObject> Radar_level = new List<GameObject>();

	private GameObject radarObj;

	public static bool MissionFailed = false;

	public static int TotalMissions;

	public Text[] MissionInfo_txt;

	public Text[] IngameMission_Info_txt;

	public Text[] Hint_mission;

	public int Moneytoloot;

	public int Personstokill;

	public Text reward_txt;

	public static List<GameObject> Myradars = new List<GameObject>();

	public static bool startGame = false;

	public static bool Runtimer = true;

	public GameObject PresentVehicle;

	public static int _cashcollected = 0;

	public GameObject[] ObjectsNeededInlevel;

	public bool NeedFallTime;

	public float fdminutes = 5f;

	public MakeitEnable EnableObj;

	public PlayerBehaviour MAinPlayer;

	public bool CanKillOnFall;

	public Color mycolor;

	public Image[] myCheckMark;

	private float DetimeA = 2f;

	private void Awake()
	{
		mee = this;
	}

	private void Start()
	{
		MissionFailed = false;
		startGame = false;
		_cashcollected = 0;
		Moneytoloot = 0;
		for (int i = 0; i < Level_Missions.Length; i++)
		{
			Debug.Log("Missions a " + i);
			radarObj = new GameObject();
			radarObj = Object.Instantiate(_gameui.mapUI.RadarIcon, Vector3.zero, Quaternion.identity);
			radarObj.name = "rada" + i;
			Radar_level.Add(radarObj);
			MissionInfo_txt[i].text = Level_Missions_txt[i];
			IngameMission_Info_txt[i].text = Level_Missions_txt[i];
		}
		reward_txt.text = "Reward : " + Levelrewards;
		TotalMissions = Level_Missions.Length;
		Invoke("afterdelay", 0.5f);
		if (ObjectsNeededInlevel.Length != 0)
		{
			for (int j = 0; j < ObjectsNeededInlevel.Length; j++)
			{
				ObjectsNeededInlevel[j].transform.parent = null;
			}
		}
		if (CanKillOnFall)
		{
			MAinPlayer.ragdollWhenFall = true;
		}
	}

	private void afterdelay()
	{
		LevelManager.mee.MainPlayer.transform.position = _PlayerPos.transform.position;
	}

	public void MissionCompletedSetUp(int i = -1, string _header = "", string _msg = "")
	{
		if (i >= 0)
		{
			myCheckMark[i].color = mycolor;
		}
		VehicleControl.fbrake = true;
		DetimeA = 2f;
		StartCoroutine("hideMissionComplete");
	}

	public void CountinueMiissionNow()
	{
		LevelManager.mee.Inpopup = false;
		DetimeA = 0.1f;
		StartCoroutine("hideMissionComplete");
	}

	private IEnumerator hideMissionComplete()
	{
		yield return new WaitForSeconds(0.1f);
		LevelManager.mee.Inpopup = false;
		VehicleControl.fbrake = false;
		ShowAllMissions();
		_gameui.panels.MissionComplete.SetActive(false);
		if (LevelManager.mee.PlayerVehicle != null)
		{
			LevelManager.mee.PlayerVehicle.GetComponent<Rigidbody>().isKinematic = false;
			LevelManager.mee.PlayerVehicle = null;
		}
		yield return new WaitForSeconds(1f);
		Debug.Log("mission complete..." + missionCheck.mee.AutoStartNext);
		if (missionCheck.mee.AutoStartNext)
		{
			Level_Missions[1].GetComponent<missionCheck>().startthemission();
		}
	}

	private void numUpdate(float newValue)
	{
	}

	public void Lootcompleted(int num = -1, bool _needStrip = true, bool passtext = false, string _header = "Well Done", string _msg = "mission completed")
	{
		Debug.Log("mcomplete........");
		TotalMissions--;
		if (_needStrip)
		{
			if (!passtext)
			{
				MissionCompletedSetUp(num);
			}
			else
			{
				MissionCompletedSetUp(num, _header, _msg);
			}
		}
		if (TotalMissions <= 0)
		{
			Invoke("Show_LevelComplete_page", 3f);
		}
	}

	public void Show_LevelComplete_page()
	{
		Debug.Log("Level Completed");
		LevelManager.mee.Inpopup = true;
		LevelManager.mee.Bg_Sound(2);
		LevelComplete.Instance.Open();
	}

	private void Update()
	{
	}

	public void HideRemainingMissions(GameObject _cmission)
	{
		GameObject[] level_Missions = Level_Missions;
		foreach (GameObject gameObject in level_Missions)
		{
			if (_cmission != gameObject && gameObject != null)
			{
				gameObject.SetActive(false);
			}
		}
	}

	public void ShowAllMissions()
	{
		GameObject[] level_Missions = Level_Missions;
		foreach (GameObject gameObject in level_Missions)
		{
			if (gameObject != null)
			{
				gameObject.SetActive(true);
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
