using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class missionCheck : MonoBehaviour
{
	public bool FullComplete;

	public bool savepointNeed;

	public MissionType _missionType = MissionType.killEnemies;

	public int _lootCash;

	public int _killpersonCount;

	public float _Timetoreach;

	public GameObject MissionIcon;

	public Sprite MissionTexture;

	public bool IsTargetMoves;

	public bool NeedIconINmap;

	public GameObject Missiontargets;

	public GameObject CheckMark;

	public Mycar_own ExclusiveCar;

	public GameObject Missioneffect;

	public GameObject Savepoint;

	public static missionCheck mee;

	public GameObject WaterObj;

	public bool AutoStartNext;

	public static bool MissionStarted;

	public Color mycolor;

	private float _delayA;

	private float _delayB = 2f;

	public Node myNode;

	public GameObject RadarRef;

	private void Start()
	{
		mee = this;
		Debug.Log(base.transform.name + " Count ");
		Debug.Log("missioncount" + Leveldata.TotalMissions);
		ShowLocationIcon();
		Invoke("Showwater", 1f);
		if ((bool)AdManager.instance)
		{
			MonoBehaviour.print("call add ingame nawaz " + LevelSelectionHandler.CurrentLevel);
			AdManager.instance.RunActions(AdManager.PageType.InGame, LevelSelectionHandler.CurrentLevel);
		}
	}

	public void startthemission()
	{
		Debug.Log("human startMission---->----");
		if (Missioneffect != null)
		{
			Missioneffect.SetActive(false);
		}
		if (ExclusiveCar != null)
		{
			ExclusiveCar.DisableThings();
		}
		LevelManager.mee.Inpopup = true;
		GetComponent<MeshRenderer>().enabled = false;
		GetComponent<BoxCollider>().enabled = false;
		MissionStarted = true;
		Missiontargets.SetActive(true);
		Leveldata.mee.CurrentMission = this;
		RemoveLocationIcon(MissionIcon);
		Leveldata.mee.HideRemainingMissions(base.gameObject);
		base.enabled = false;
		VehicleControl.fbrake = true;
		for (int i = 0; i < Leveldata.mee.Level_Missions.Length; i++)
		{
			Debug.Log(string.Concat(Leveldata.mee.Level_Missions[i].gameObject, "---asd ", Leveldata.mee.CurrentMission.gameObject));
			if (Leveldata.mee.Level_Missions[i].gameObject == Leveldata.mee.CurrentMission.gameObject)
			{
				if (_Timetoreach > 0f)
				{
					Leveldata.mee.NeedFallTime = true;
					Leveldata.mee.fdminutes = _Timetoreach;
				}
				MonoBehaviour.print(i);
				Leveldata.mee.CurrentMission_index = i;
				LevelManager.mee._missionInfo.text = Leveldata.mee.Level_Missions_txt[i] ?? "";
			}
		}
		Leveldata.mee._gameui.panels.MissionInfo.SetActive(true);
		iTween.ValueTo(base.gameObject, iTween.Hash("from", 0f, "to", 0.98f, "time", 1f, "onupdate", "numUpdate2"));
		StartCoroutine("hideMissioninfo");
	}

	private void OnTriggerEnter(Collider aa)
	{
		Debug.Log(aa.tag + " start mission " + aa.transform.name + " : " + base.name);
		if (aa.tag == "Human" || aa.tag == "Police")
		{
			return;
		}
		bool flag = false;
		if (aa.tag == "Vehicle" && (bool)aa.gameObject.GetComponent<AIVehicle>() && aa.gameObject.GetComponent<AIVehicle>().vehicleStatus == VehicleStatus.Player)
		{
			flag = true;
		}
		if ((!(aa.gameObject.tag == "Player") && !flag) || AutoStartNext)
		{
			return;
		}
		Debug.Log("human startMission---->");
		if (Missioneffect != null)
		{
			Missioneffect.SetActive(false);
		}
		if (ExclusiveCar != null)
		{
			ExclusiveCar.DisableThings();
		}
		LevelManager.mee.Inpopup = true;
		GetComponent<MeshRenderer>().enabled = false;
		GetComponent<BoxCollider>().enabled = false;
		MissionStarted = true;
		Missiontargets.SetActive(true);
		Leveldata.mee.CurrentMission = this;
		RemoveLocationIcon(MissionIcon);
		Leveldata.mee.HideRemainingMissions(base.gameObject);
		base.enabled = false;
		VehicleControl.fbrake = true;
		for (int i = 0; i < Leveldata.mee.Level_Missions.Length; i++)
		{
			Debug.Log(string.Concat(Leveldata.mee.Level_Missions[i].gameObject, "---asd ", Leveldata.mee.CurrentMission.gameObject));
			if (Leveldata.mee.Level_Missions[i].gameObject == Leveldata.mee.CurrentMission.gameObject)
			{
				if (_Timetoreach > 0f)
				{
					Leveldata.mee.NeedFallTime = true;
					Leveldata.mee.fdminutes = _Timetoreach;
				}
				MonoBehaviour.print(i);
				Leveldata.mee.CurrentMission_index = i;
				LevelManager.mee._missionInfo.text = Leveldata.mee.Level_Missions_txt[i] ?? "";
			}
		}
		Leveldata.mee._gameui.panels.MissionInfo.SetActive(true);
		iTween.ValueTo(base.gameObject, iTween.Hash("from", 0f, "to", 0.98f, "time", 1f, "onupdate", "numUpdate2"));
		StartCoroutine("hideMissioninfo");
	}

	public void HideTheMission()
	{
		StartCoroutine("hideMissionComplete", true);
	}

	private IEnumerator hideMissionComplete(bool showmissions = false)
	{
		yield return new WaitForSeconds(_delayB);
		LevelManager.mee.Inpopup = false;
		VehicleControl.fbrake = false;
		Leveldata.mee._gameui.panels.MissionComplete.SetActive(false);
		yield return new WaitForSeconds(0.1f);
		if (Leveldata.TotalMissions <= 0)
		{
			Leveldata.mee.Show_LevelComplete_page();
		}
		yield return new WaitForSeconds(0.2f);
		if (showmissions)
		{
			Leveldata.mee.ShowAllMissions();
		}
	}

	private void numUpdate(float newValue)
	{
	}

	private void numUpdate2(float newValue)
	{
		Leveldata.mee._gameui.panels.MissionInfo.transform.GetChild(0).gameObject.GetComponent<Image>().fillAmount = newValue;
	}

	private IEnumerator hideMissioninfo()
	{
		yield return new WaitForSeconds(2f);
		iTween.ValueTo(base.gameObject, iTween.Hash("from", 0.98f, "to", 0f, "time", 1f, "onupdate", "numUpdate2"));
		yield return new WaitForSeconds(1f);
		LevelManager.mee.Inpopup = false;
		VehicleControl.fbrake = false;
		Leveldata.mee._gameui.panels.MissionInfo.SetActive(false);
		Leveldata.ArjMission_start = true;
	}

	private void callLCAd()
	{
	}

	private void ShowAd()
	{
		if ((bool)AdManager.instance)
		{
			MonoBehaviour.print("call add ingame nawaz " + LevelSelectionHandler.CurrentLevel);
			AdManager.instance.RunActions(AdManager.PageType.LF, LevelSelectionHandler.CurrentLevel);
		}
	}

	private IEnumerator MissionStatus(string _type)
	{
		if (_type == "mission")
		{
			yield return new WaitForSeconds(1f);
			_delayA = 2f;
			_delayB = 1f;
			Debug.Log(Leveldata.mee.CurrentMission.Missiontargets.transform.childCount + " status------------------" + Missiontargets.transform.childCount);
			if (Leveldata.mee.CurrentMission.Missiontargets.transform.childCount <= 0)
			{
				Leveldata.mee.CurrentMission.gameObject.gameObject.transform.parent = null;
				Debug.Log(string.Concat(base.gameObject, " Mission Completed", Leveldata.mee.CurrentMission, " : ", Leveldata.mee.CurrentMission.CheckMark));
				Leveldata.mee.CurrentMission.CheckMark.GetComponent<Image>().color = mycolor;
				MissionStarted = false;
				Leveldata.TotalMissions--;
				if (Leveldata.TotalMissions > 0 && !FullComplete)
				{
					Debug.Log("go for next");
					Invoke("ShowAd", 0.1f);
					Leveldata.mee._gameui.panels.MissionComplete.SetActive(true);
					LevelManager.mee.Inpopup = true;
					VehicleControl.fbrake = true;
				}
				else
				{
					Debug.Log("JKbnikjbnkjkj");
					LevelManager.mee.Inpopup = true;
					VehicleControl.fbrake = true;
					if (FullComplete)
					{
						Leveldata.TotalMissions = 0;
					}
					_delayA = 0.9f;
					StartCoroutine("hideMissionComplete", false);
					yield return new WaitForSeconds(1f);
					Leveldata.mee._gameui.panels.MissionComplete.SetActive(false);
				}
				GameUI.Instance.hideTimer();
			}
		}
		if (_type == "Nostrip")
		{
			yield return new WaitForSeconds(0.2f);
			_delayA = 0.1f;
			_delayB = 0.1f;
			Leveldata.mee.CurrentMission.gameObject.gameObject.transform.parent = null;
			Debug.Log(string.Concat(base.gameObject, " Mission Completed", Leveldata.mee.CurrentMission, " : ", Leveldata.mee.CurrentMission.CheckMark));
			Leveldata.mee.CurrentMission.CheckMark.GetComponent<Image>().color = mycolor;
			MissionStarted = false;
			Leveldata.TotalMissions--;
			if (Leveldata.TotalMissions > 0)
			{
				Debug.Log("go for next");
				VehicleControl.fbrake = true;
				LevelManager.mee.Inpopup = false;
				StartCoroutine("hideMissionComplete", true);
			}
		}
		if (_type == "level")
		{
			Debug.Log(base.transform.parent.transform.name + " Count " + base.transform.parent.transform.childCount);
		}
	}

	public void CheckMissionStatus(string Mstatus = "mission")
	{
		Debug.Log("status------------------");
		StartCoroutine("MissionStatus", Mstatus);
		Debug.Log("CheckMissionStatus" + Leveldata.TotalMissions);
	}

	public bool CheckNextMission()
	{
		Debug.Log("CheckNextMission" + Leveldata.TotalMissions);
		int num = 0;
		Debug.Log(Leveldata.mee.Level_Missions.Length + " : " + Leveldata.mee.CurrentMission);
		Debug.Log(string.Concat(Leveldata.mee.CurrentMission.gameObject, " : "));
		for (int i = 0; i < Leveldata.mee.Level_Missions.Length; i++)
		{
			if (!(Leveldata.mee.Level_Missions[i].gameObject == null))
			{
				Debug.Log(string.Concat(Leveldata.mee.Level_Missions[i].transform.parent, "next------------------"));
				if (Leveldata.mee.Level_Missions[i].transform.parent == Leveldata.mee.gameObject.transform)
				{
					num++;
				}
			}
		}
		Leveldata.mee.CurrentMission = null;
		Debug.Log(num);
		if (num >= 1)
		{
			return true;
		}
		return false;
	}

	private void ShowLocationIcon()
	{
		switch (_missionType)
		{
		case MissionType.starscollect:
			LevelManager.mee.starscollect_count = Missiontargets.transform.childCount;
			break;
		case MissionType.personKill:
			LevelManager._isKillpeopleMission = true;
			LevelManager.mee.Personkill_count = _killpersonCount;
			Leveldata.mee.Personstokill = _killpersonCount;
			Leveldata.mee.Hint_mission[1].gameObject.SetActive(true);
			Leveldata.mee.Hint_mission[1].text = Leveldata.mee.Personstokill - LevelManager.mee.Personkill_count + "/" + Leveldata.mee.Personstokill;
			break;
		case MissionType.policekill:
			LevelManager._isKillPoliceMission = true;
			LevelManager.mee.policekill_count = Missiontargets.transform.childCount;
			break;
		case MissionType.LootCash:
			Debug.Log("loot cash...");
			LevelManager._islootMission = true;
			LevelManager.mee.LootCash_count = _lootCash;
			Leveldata.mee.Moneytoloot = _lootCash;
			Leveldata.mee.Hint_mission[1].gameObject.SetActive(true);
			Leveldata.mee.Hint_mission[1].text = Leveldata.mee.Moneytoloot - LevelManager.mee.LootCash_count + "/" + Leveldata.mee.Moneytoloot;
			Object.Destroy(base.gameObject);
			break;
		case MissionType.reachintime:
			LevelManager.mee.Timer_count = _Timetoreach;
			break;
		case MissionType.blastVehiclesStatic:
			LevelManager.mee.EnemyVehiclesBlaststatic = Missiontargets.GetComponent<EnemyVehicleBlastMission>().NotOnPath_vehicle.Length;
			Debug.Log("Total... " + LevelManager.mee.EnemyVehiclesBlaststatic);
			break;
		case MissionType.blastVehicleNonStatic:
			LevelManager.mee.EnemyVehiclesBlast_nonstatic = Missiontargets.GetComponent<EnemyVehicleBlastMission>().Onpath_vehicle.Length;
			break;
		case MissionType.BlastHelicopter:
			LevelManager.mee.Helicopter_count = 1;
			break;
		case MissionType.killEnemies:
			LevelManager.mee.killEnemies_count = _killpersonCount;
			break;
		}
		Debug.Log(LevelManager.mee.Timer_count);
		if (NeedIconINmap)
		{
			MissionIcon.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
			if ((bool)Leveldata.mee._gameui.mapUI.mapPlane)
			{
				MissionIcon.transform.position = new Vector3(base.transform.position.x, Leveldata.mee._gameui.mapUI.mapPlane.position.y + 5f, base.transform.position.z);
				MissionIcon.transform.localScale = Vector3.one * 7f;
			}
			else
			{
				Debug.Log("ososkdfoksfkflkf");
			}
			RadarRef.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
			RadarRef.transform.position = new Vector3(AIContoller.manager.player.transform.position.x, Leveldata.mee._gameui.mapUI.mapPlane.position.y + 5f, AIContoller.manager.transform.position.z);
			RadarRef.transform.localScale = Vector3.one * 7f;
		}
	}

	private void Showwater()
	{
		if (WaterObj != null)
		{
			WaterObj.SetActive(true);
			waterwalls.showwater = false;
		}
	}

	private void RemoveLocationIcon(GameObject _obj)
	{
		Object.Destroy(_obj);
	}

	private void Update()
	{
		if (Leveldata.startGame && NeedIconINmap)
		{
			updateLocationMission();
		}
	}

	private void updateLocationMission()
	{
		RadarRef.transform.position = new Vector3(AIContoller.manager.player.transform.position.x, Leveldata.mee._gameui.mapUI.mapPlane.position.y + 5f, AIContoller.manager.player.transform.position.z);
		RadarRef.transform.LookAt(MissionIcon.transform);
		if (Vector3.Distance(MissionIcon.transform.position, RadarRef.transform.position) <= 85f)
		{
			RadarRef.transform.GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
		}
		else
		{
			RadarRef.transform.GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
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
