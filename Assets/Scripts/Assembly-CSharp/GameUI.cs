using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
	[Serializable]
	public class Panels
	{
		public GameObject tachometer;

		public GameObject miniMap;

		public GameObject bigMap;

		public GameObject vehicleControl;

		public GameObject playerControl;

		public GameObject MissionIntro;

		public GameObject MissionComplete;

		public GameObject MissionInfo;
	}

	[Serializable]
	public class MapUI
	{
		public GameObject playerIcon;

		public Camera miniMapView;

		public Camera bigMapView;

		public Transform mapPlane;

		public GameObject RadarIcon;

		public GameObject MissionRadarIcon;
	}

	[Serializable]
	public class LocationUI
	{
		public levelsData[] Total_levels;

		public GameObject[] spot_places;
	}

	[Serializable]
	public class levelsData
	{
		public Missiondata[] Mission_place;
	}

	[Serializable]
	public class Missiondata
	{
		public GameObject _Place;

		public GameObject _icon;
	}

	[Serializable]
	public class VehicleUI
	{
		public Image tachometerNeedle;

		public Image barShiftGUI;

		public Text speedText;

		public Text gearText;

		public Image VehicleHealthBar;

		public Text VehicleHealth_txt;
	}

	public static GameObject instPlayerIcon;

	public static GameObject storeIcon;

	public Panels panels;

	public MapUI mapUI;

	public VehicleUI vehicleUI;

	public LocationUI locationUI;

	public Transform player;

	public Transform playerAnim;

	public Transform camera;

	private int gearst;

	private float thisAngle = -150f;

	private AIVehicle AIVehicleComponent;

	private Vector3 curPosBigMap;

	public static GameUI Instance;

	public GameObject[] Coins_obj;

	public Image Playerhealth;

	public Text PlayerHealth_txt;

	public Text IngameCoins_txt;

	public Text timerText;

	private float secondsCount;

	private int minuteCount;

	private int hourCount;

	private int CurrentLevel = 1;

	private List<GameObject> _dummy;

	private GameObject _Missionref;

	private GameObject _ref2;

	private bool Createonce;

	public Text fallDownTimer_txt;

	private float fdseconds;

	private float fdmiliseconds;

	public void ShowVehicleUI()
	{
		AIVehicleComponent = AIContoller.manager.vehicleCamera.target.GetComponent<AIVehicle>();
		if (!panels.tachometer.activeSelf)
		{
			panels.tachometer.SetActive(true);
		}
		gearst = AIVehicleComponent.currentGear;
		vehicleUI.speedText.text = ((int)AIVehicleComponent.vehicleSpeed).ToString();
		if (AIVehicleComponent.automaticGear)
		{
			if (gearst > 0 && AIVehicleComponent.vehicleSpeed > 1f)
			{
				vehicleUI.gearText.color = Color.green;
				vehicleUI.gearText.text = gearst.ToString();
			}
			else if (AIVehicleComponent.vehicleSpeed > 1f)
			{
				vehicleUI.gearText.color = Color.red;
				vehicleUI.gearText.text = "R";
			}
			else
			{
				vehicleUI.gearText.color = Color.white;
				vehicleUI.gearText.text = "N";
			}
		}
		else if (AIVehicleComponent.neutralGear)
		{
			vehicleUI.gearText.color = Color.white;
			vehicleUI.gearText.text = "N";
		}
		else if (AIVehicleComponent.currentGear != 0)
		{
			vehicleUI.gearText.color = Color.green;
			vehicleUI.gearText.text = gearst.ToString();
		}
		else
		{
			vehicleUI.gearText.color = Color.red;
			vehicleUI.gearText.text = "R";
		}
		thisAngle = AIVehicleComponent.motorRPM / 20f - 175f;
		thisAngle = Mathf.Clamp(thisAngle, -180f, 90f);
		vehicleUI.tachometerNeedle.rectTransform.rotation = Quaternion.Euler(0f, 0f, 0f - thisAngle);
		vehicleUI.barShiftGUI.rectTransform.localScale = new Vector3(AIVehicleComponent.powerShift / 100f, 1f, 1f);
	}

	public void ShowMiniMapUI()
	{
		instPlayerIcon.transform.rotation = Quaternion.Euler(90f, playerAnim.eulerAngles.y, 0f);
		instPlayerIcon.transform.position = new Vector3(player.transform.position.x, mapUI.mapPlane.position.y + 5f, player.transform.position.z);
		mapUI.miniMapView.transform.rotation = Quaternion.Euler(90f, camera.eulerAngles.y + 180f, 0f);
		mapUI.miniMapView.transform.position = new Vector3(player.transform.position.x, mapUI.mapPlane.position.y + 10f, player.transform.position.z);
	}

	public void ShowBigMap(bool active)
	{
		mapUI.bigMapView.transform.position = curPosBigMap;
		if ((bool)mapUI.mapPlane.GetComponent<MoveMap>())
		{
			mapUI.mapPlane.GetComponent<MoveMap>().enabled = active;
		}
		panels.bigMap.SetActive(active);
		panels.miniMap.SetActive(!active);
		panels.tachometer.SetActive(!active);
		if ((bool)panels.playerControl)
		{
			panels.playerControl.SetActive(!active);
		}
		if ((bool)panels.vehicleControl)
		{
			panels.vehicleControl.SetActive(!active);
		}
	}

	public void MapSize(float value)
	{
		mapUI.bigMapView.orthographicSize += value;
	}

	private void OnEnable()
	{
		iTween.MoveFrom(panels.MissionIntro.gameObject.transform.GetChild(0).gameObject, iTween.Hash("x", -1000, "easetype", iTween.EaseType.easeOutBack, "delay", 0.2f, "islocal", true));
	}

	public void StartGame(GameObject _obj = null)
	{
		if (Leveldata.mee.EnableObj != null)
		{
			Leveldata.mee.EnableObj.enabled = true;
			StartCoroutine("startC_game", _obj);
		}
		else if ((bool)_obj)
		{
			Debug.Log("stat.....");
			LevelManager.mee.Inpopup = false;
			iTween.MoveTo(panels.MissionIntro.gameObject.transform.GetChild(0).gameObject, iTween.Hash("x", -1000, "easetype", iTween.EaseType.easeOutBack, "delay", 0.2f, "islocal", true));
			UnityEngine.Object.Destroy(_obj.transform.parent.parent.gameObject, 0.5f);
			Leveldata.startGame = true;
		}
	}

	private IEnumerator startC_game(GameObject _obj = null)
	{
		yield return new WaitForSeconds(0.1f);
		Debug.Log("stat.....aaaaaa");
		if ((bool)_obj)
		{
			iTween.MoveTo(panels.MissionIntro.gameObject.transform.GetChild(0).gameObject, iTween.Hash("x", -1000, "easetype", iTween.EaseType.easeOutBack, "delay", 0.2f, "islocal", true));
			UnityEngine.Object.Destroy(_obj.transform.parent.parent.gameObject, 0.5f);
			if (!PlayerPrefs.HasKey("firsttimehelp"))
			{
				PlayerPrefs.SetString("firsttimehelp", "true");
			}
			if (Leveldata.mee.HelpNum == 0 || PlayerPrefs.GetString("firsttimehelp") == "false")
			{
				Leveldata.startGame = true;
				LevelManager.mee.Inpopup = false;
			}
			else
			{
				PlayerPrefs.SetString("firsttimehelp", "false");
				yield return new WaitForSeconds(3.1f);
				Leveldata.mee._helpObj.SetActive(true);
			}
		}
	}

	private void Start()
	{
		Instance = this;
		curPosBigMap = mapUI.bigMapView.transform.position;
		player = AIContoller.manager.player;
		playerAnim = player.GetComponent<DriveVehicle>().m_Animator.transform;
		UpdateCoins();
		instPlayerIcon = UnityEngine.Object.Instantiate(mapUI.playerIcon, Vector3.zero, Quaternion.identity);
		panels.MissionComplete.SetActive(false);
		panels.MissionInfo.SetActive(false);
		ShowMapStaticIcons();
		Invoke("ShowMissionsinMap", 0.5f);
	}

	public void UpdateCoins()
	{
		IngameCoins_txt.text = "$ " + PlayerPrefs.GetInt(StoreManager.KEY_COINS);
	}

	private void ShowMapStaticIcons()
	{
		if (locationUI.spot_places.Length >= 1)
		{
			GameObject[] spot_places = locationUI.spot_places;
			foreach (GameObject gameObject in spot_places)
			{
				gameObject.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
				gameObject.transform.position = new Vector3(gameObject.transform.position.x, mapUI.mapPlane.position.y + 5f, gameObject.transform.position.z);
				gameObject.transform.localScale = Vector3.one * 7f;
			}
		}
		mapUI.RadarIcon.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
		mapUI.RadarIcon.transform.position = new Vector3(player.transform.position.x, mapUI.mapPlane.position.y + 5f, player.transform.position.z);
		mapUI.RadarIcon.transform.localScale = Vector3.one * 7f;
		mapUI.RadarIcon.transform.GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
	}

	private void updateLocationMission()
	{
		if (Createonce && (bool)_Missionref)
		{
			mapUI.RadarIcon.transform.position = new Vector3(player.transform.position.x, mapUI.mapPlane.position.y + 5f, player.transform.position.z);
			mapUI.RadarIcon.transform.LookAt(_Missionref.transform);
			if (Vector3.Distance(_Missionref.transform.position, mapUI.RadarIcon.transform.position) <= 85f)
			{
				mapUI.RadarIcon.transform.GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
			}
			else
			{
				mapUI.RadarIcon.transform.GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
			}
		}
	}

	private void ShowMissionsinMap()
	{
		int num = CurrentLevel - 1;
		Debug.Log("---" + locationUI.Total_levels[num].Mission_place.Length);
		for (int i = 0; i < locationUI.Total_levels.Length; i++)
		{
			if (i == num)
			{
				for (int j = 0; j < locationUI.Total_levels[num].Mission_place.Length; j++)
				{
					_Missionref = UnityEngine.Object.Instantiate(locationUI.Total_levels[num].Mission_place[j]._icon, Vector3.zero, Quaternion.identity);
					_ref2 = locationUI.Total_levels[num].Mission_place[j]._Place;
					_Missionref.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
					_Missionref.transform.position = new Vector3(_ref2.transform.position.x, mapUI.mapPlane.position.y + 5f, _ref2.transform.position.z);
					Createonce = true;
				}
			}
		}
	}

	public void DecreaseVehicleHealth(int _health)
	{
		float fillAmount = (float)_health / 100f;
		Debug.Log("Decrease Value::" + _health + "GivenValue:" + (float)_health / 100f);
		vehicleUI.VehicleHealthBar.fillAmount = fillAmount;
		if (_health <= 0)
		{
			_health = 0;
		}
		vehicleUI.VehicleHealth_txt.text = string.Concat(_health);
	}

	public void ShowVehicleHealth(int _CurrentHealth)
	{
		float fillAmount = (float)_CurrentHealth / 100f;
		vehicleUI.VehicleHealthBar.fillAmount = fillAmount;
		if (_CurrentHealth <= 0)
		{
			_CurrentHealth = 0;
		}
		vehicleUI.VehicleHealth_txt.text = string.Concat(_CurrentHealth);
	}

	public void ShowPlayerHealth()
	{
		Debug.Log("health " + player.GetComponent<PlayerBehaviour>().life);
		Playerhealth.fillAmount = player.GetComponent<PlayerBehaviour>().life / 100f;
		if (player.GetComponent<PlayerBehaviour>().life <= 0f)
		{
			player.GetComponent<PlayerBehaviour>().life = 0f;
		}
		PlayerHealth_txt.text = string.Concat(player.GetComponent<PlayerBehaviour>().life);
	}

	private void Update()
	{
		if (!panels.bigMap.activeSelf)
		{
			ShowMiniMapUI();
			if (AIContoller.manager.vehicleCamera.enabled)
			{
				ShowVehicleUI();
				if ((bool)panels.vehicleControl)
				{
					panels.vehicleControl.SetActive(true);
				}
				if ((bool)panels.playerControl)
				{
					panels.playerControl.SetActive(false);
				}
			}
			else
			{
				panels.tachometer.SetActive(false);
				if ((bool)panels.vehicleControl)
				{
					panels.vehicleControl.SetActive(false);
				}
				if ((bool)panels.playerControl)
				{
					panels.playerControl.SetActive(true);
				}
			}
		}
		else
		{
			mapUI.bigMapView.orthographicSize = Mathf.Clamp(mapUI.bigMapView.orthographicSize, -1200f, -200f);
		}
		if (Leveldata.startGame && Leveldata.Runtimer && !LevelManager.mee.Inpopup)
		{
			UpdateTimerUI();
		}
		if (Leveldata.mee.NeedFallTime && Leveldata.startGame && !LevelManager.mee.Inpopup)
		{
			fallDownTimer_txt.gameObject.SetActive(true);
			Falldowntimer();
		}
	}

	public void hideTimer()
	{
		fallDownTimer_txt.gameObject.SetActive(false);
	}

	public void UpdateTimerUI()
	{
		secondsCount += Time.deltaTime;
		timerText.text = string.Format("{0:00}:{1:00}", minuteCount, secondsCount);
		if (secondsCount >= 60f)
		{
			minuteCount++;
			secondsCount = 0f;
		}
		else if (minuteCount >= 60)
		{
			hourCount++;
			minuteCount = 0;
		}
	}

	public void Falldowntimer()
	{
		if (fdmiliseconds <= 0f)
		{
			if (fdseconds <= 0f)
			{
				Leveldata.mee.fdminutes -= 1f;
				fdseconds = 59f;
			}
			else if (fdseconds >= 0f)
			{
				fdseconds -= 1f;
			}
			fdmiliseconds = 100f;
		}
		fdmiliseconds -= Time.deltaTime * 100f;
		fallDownTimer_txt.text = string.Format("{0:00}:{1:00}", Leveldata.mee.fdminutes, fdseconds);
		if (fdseconds <= 0f && Leveldata.mee.fdminutes == 0f)
		{
			Leveldata.mee.NeedFallTime = false;
			LevelManager.mee.Timer_count = 0f;
			Debug.Log("fail3");
			StartCoroutine(YouAreDeadPage.Instance.Open("You Killed Your Self", 0f, true));
			Leveldata.MissionFailed = true;
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
