using UnityEngine;

public class RadarObj : MonoBehaviour
{
	public bool NeedRadarIcon;

	public GameObject RadarRef;

	public GameObject MissionIcon;

	public VehicleHealth _VH;

	public bool IsfromOutSide;

	private void Start()
	{
		Invoke("ShowLocationIcon", 1f);
	}

	private void ShowLocationIcon()
	{
		if (NeedRadarIcon)
		{
			if (IsfromOutSide)
			{
				MissionIcon.transform.parent = null;
				RadarRef.transform.parent = null;
			}
			if (_VH != null && (bool)_VH.Health_obj)
			{
				_VH.Health_obj.transform.parent.gameObject.SetActive(true);
			}
			MissionIcon.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
			MissionIcon.transform.position = new Vector3(base.transform.position.x, Leveldata.mee._gameui.mapUI.mapPlane.position.y + 5f, base.transform.position.z);
			MissionIcon.transform.localScale = Vector3.one * 7f;
			RadarRef.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
			RadarRef.transform.position = new Vector3(AIContoller.manager.player.transform.position.x, Leveldata.mee._gameui.mapUI.mapPlane.position.y + 5f, AIContoller.manager.transform.position.z);
			RadarRef.transform.localScale = Vector3.one * 7f;
		}
	}

	private void Update()
	{
		if (NeedRadarIcon && RadarRef != null && MissionIcon != null)
		{
			updateLocationMission();
		}
	}

	private void updateLocationMission()
	{
		if (IsfromOutSide)
		{
			MissionIcon.transform.position = new Vector3(base.transform.position.x, Leveldata.mee._gameui.mapUI.mapPlane.position.y + 5f, base.transform.position.z);
		}
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
