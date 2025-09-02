using UnityEngine;

public class StarObj : MonoBehaviour
{
	public bool NeedRadarIcon = true;

	public bool isstar = true;

	public bool changeText_strip = true;

	public GameObject NextPointEnabler;

	public GameObject Coumpulsary_Obj;

	public bool DisableControlIcon;

	public GameObject PlayerControl;

	public float DelaycheckTime;

	public bool MissionComplete_need = true;

	public Rigidbody Unfreezerigid;

	public GameObject RadarRef;

	public GameObject MissionIcon;

	private void Start()
	{
		Debug.Log("start mis..............");
		ShowLocationIcon();
	}

	public void Unfreeze()
	{
		Unfreezerigid.isKinematic = false;
	}

	private void ShowLocationIcon()
	{
		if (NeedRadarIcon)
		{
			MissionIcon.transform.parent = null;
			MissionIcon.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
			MissionIcon.transform.position = new Vector3(base.transform.position.x, Leveldata.mee._gameui.mapUI.mapPlane.position.y + 5f, base.transform.position.z);
			MissionIcon.transform.localScale = Vector3.one * 7f;
			RadarRef.transform.parent = null;
			RadarRef.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
			RadarRef.transform.position = new Vector3(AIContoller.manager.player.transform.position.x, Leveldata.mee._gameui.mapUI.mapPlane.position.y + 5f, AIContoller.manager.transform.position.z);
			RadarRef.transform.localScale = Vector3.one * 7f;
		}
	}

	public void OnTriggerEnter(Collider collider)
	{
		Debug.Log(collider.gameObject.name + "---");
		if (!(collider.gameObject.tag == "Player"))
		{
			return;
		}
		Debug.Log("checkk star" + collider.gameObject.transform.root.gameObject.tag);
		if (isstar)
		{
			LevelManager.mee.starscollect_count--;
		}
		if (!DisableControlIcon)
		{
			if ((bool)PlayerControl)
			{
				PlayerControl.SetActive(true);
			}
		}
		else if ((bool)PlayerControl)
		{
			PlayerControl.SetActive(false);
		}
		NeedRadarIcon = false;
		Object.Destroy(RadarRef);
		Object.Destroy(MissionIcon);
		Object.Destroy(base.gameObject);
		LevelManager.mee.PlayerVehicle = null;
		if (Leveldata.mee.CurrentMission.savepointNeed)
		{
			Leveldata.mee.CurrentMission.Savepoint.transform.position = base.transform.position;
		}
		if (NextPointEnabler != null)
		{
			NextPointEnabler.SetActive(true);
		}
		Debug.Log(missionCheck.MissionStarted + " ----- " + changeText_strip);
		Debug.Log(MissionComplete_need.ToString() + " -----@ " + LevelManager.mee.starscollect_count);
		if (changeText_strip)
		{
			Leveldata.mee.Lootcompleted(0, true, true, "Well Done", "Drop the Passenger to destination ");
			changeText_strip = false;
		}
		else if (missionCheck.MissionStarted && MissionComplete_need)
		{
			Leveldata.mee.CurrentMission.CheckMissionStatus();
		}
		else if (isstar && LevelManager.mee.starscollect_count <= 0)
		{
			if (MissionComplete_need)
			{
				Leveldata.mee.CurrentMission.CheckMissionStatus();
				if (collider.gameObject.transform.root.gameObject.tag == "Vehicle")
				{
					LevelManager.mee.PlayerVehicle = collider.gameObject.transform.root.gameObject;
					collider.gameObject.transform.root.gameObject.GetComponent<Rigidbody>().isKinematic = true;
				}
			}
			else
			{
				Leveldata.mee.CurrentMission.CheckMissionStatus("Nostrip");
			}
		}
		LevelManager.mee.Btn_Sound(6);
	}

	private void Update()
	{
		if (NeedRadarIcon)
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
