using UnityEngine;

public class ShowInRadar : MonoBehaviour
{
	public bool NeedRadarIcon;

	public bool updateIcon = true;

	public GameObject RadarRef;

	public GameObject MissionIcon;

	private void Start()
	{
		ShowLocationIcon();
	}

	private void Update()
	{
		if (NeedRadarIcon && updateIcon)
		{
			updateLocationMission();
		}
	}

	private void updateLocationMission()
	{
		Debug.Log("Ram" + Leveldata.mee._gameui.mapUI.mapPlane);
		Debug.Log("RadarRef" + RadarRef.name + " : " + base.name + " " + AIContoller.manager.player);
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
