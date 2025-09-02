using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class YouAreDeadPage : MonoBehaviour
{
	private static YouAreDeadPage _instance;

	public Text ReasonForDead;

	private Vector3 defualtPos;

	public GameObject[] movefrom_obj;

	public GameObject[] movefrom_obj2;

	public GameObject[] scalefrom_obj;

	public GameObject[] ResumeContainer;

	private bool Killedbytime;

	public GameObject watchVideoBtn;

	public GameObject ResumeNow;

	public static YouAreDeadPage Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = Object.FindObjectOfType<YouAreDeadPage>();
			}
			return _instance;
		}
	}

	private void OnEnable()
	{
		float num = 0.8f;
		GameObject[] array = movefrom_obj;
		foreach (GameObject gameObject in array)
		{
			if (gameObject != null)
			{
				iTween.MoveFrom(gameObject, iTween.Hash("y", gameObject.transform.position.y + 550f, "time", 0.2f, "delay", num));
			}
			num += 0.2f;
		}
		num = 1f;
		array = scalefrom_obj;
		for (int i = 0; i < array.Length; i++)
		{
			iTween.ScaleFrom(array[i], iTween.Hash("Scale", Vector3.zero, "time", 1f, "delay", num));
			num += 0.2f;
		}
		num = 0.5f;
		array = movefrom_obj2;
		foreach (GameObject gameObject2 in array)
		{
			if (gameObject2 != null)
			{
				iTween.MoveFrom(gameObject2, iTween.Hash("y", gameObject2.transform.position.y - 550f, "time", 0.2f, "delay", num));
			}
			num += 0.5f;
		}
		setUpDetails();
	}

	public void setUpDetails()
	{
		if (PlayerPrefs.GetString(StoreManager.freeResumesPurchased) == "true")
		{
			watchVideoBtn.gameObject.SetActive(false);
			ResumeNow.gameObject.SetActive(true);
		}
		else
		{
			watchVideoBtn.gameObject.SetActive(true);
			ResumeNow.gameObject.SetActive(false);
		}
	}

	private void Awake()
	{
		_instance = this;
		defualtPos = base.transform.localPosition;
		base.gameObject.SetActive(false);
	}

	public IEnumerator Open(string Reason, float waitTime, bool timeup = false)
	{
		if (!PlayerPrefs.HasKey(StoreManager.ContinueAllTime))
		{
			PlayerPrefs.SetString(StoreManager.ContinueAllTime, "false");
		}
		if (PlayerPrefs.GetString(StoreManager.ContinueAllTime) == "false")
		{
			ResumeContainer[0].SetActive(true);
		}
		else
		{
			ResumeContainer[1].SetActive(true);
		}
		yield return new WaitForSeconds(waitTime);
		Leveldata.Runtimer = false;
		LevelManager.mee.Inpopup = true;
		Leveldata.mee.NeedFallTime = false;
		base.gameObject.SetActive(true);
		ReasonForDead.text = Reason;
		if (timeup)
		{
			Killedbytime = true;
			ReasonForDead.text = "Time Up!";
		}
		iTween.MoveTo(base.gameObject, iTween.Hash("position", Vector3.zero, "time", 0.85f, "easeType", iTween.EaseType.linear, "islocal", true));
		yield return new WaitForSeconds(0.5f);
		LevelManager.mee.Btn_Sound(5);
		LevelManager.mee.stopBg_Sound();
	}

	private void callLFAd()
	{
	}

	public IEnumerator Close(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		iTween.MoveTo(base.gameObject, iTween.Hash("position", Vector3.zero, "time", 0.85f, "easeType", iTween.EaseType.linear, "islocal", true, "OnComplete", "Deactive"));
	}

	private void Deactive()
	{
		base.gameObject.SetActive(false);
		LevelFail.Instance.Open();
	}

	public void Makefail()
	{
		LevelManager.mee.Btn_Sound(1);
		base.gameObject.SetActive(false);
		LevelFail.Instance.Open();
	}

	private void MakeFullFail()
	{
		base.gameObject.SetActive(false);
		LevelFail.Instance.Open();
	}

	public void ContinueMission()
	{
		Debug.Log("nohealth");
		Debug.Log("---- MenuWatchVideo Click");
		AdManager.instance.ShowRewardVideoWithCallback(delegate(bool result)
		{
			if (result)
			{
				Time.timeScale = 1f;
				base.gameObject.SetActive(false);
				ContinueMission_afterAd();
				CancelInvoke("MakeFullFail");
			}
		});
		LevelManager.mee.Btn_Sound(1);
	}

	public void AllTimeContinue()
	{
	}

	public void ContinueMission_afterAd()
	{
		CancelInvoke("MakeFullFail");
		Debug.Log("After add");
		LevelManager.mee.Inpopup = false;
		base.gameObject.SetActive(false);
		if (Killedbytime)
		{
			Leveldata.mee.fdminutes = 2f;
		}
		Leveldata.mee.NeedFallTime = true;
		if (Leveldata.mee.PresentVehicle != null)
		{
			if (Leveldata.mee.CurrentMission.Savepoint != null)
			{
				Leveldata.mee.PresentVehicle.GetComponent<VehicleHealth>().ResetVehicle(Leveldata.mee.CurrentMission.Savepoint);
			}
			else
			{
				Leveldata.mee.PresentVehicle.GetComponent<VehicleHealth>().ResetVehicle();
			}
		}
		else if (Leveldata.mee.CurrentMission != null && Leveldata.mee.CurrentMission.Savepoint != null)
		{
			PlayerBehaviour.Instance.ResetPlayer(Leveldata.mee.CurrentMission.Savepoint);
		}
		else
		{
			PlayerBehaviour.Instance.ResetPlayer();
		}
		LevelManager.mee.PlayBg_Sound();
	}

	public void FullhealthAdd()
	{
		Debug.Log("fullleath");
		LevelManager.mee.Btn_Sound(1);
	}

	public void CoinsAdd()
	{
		LevelManager.mee.Btn_Sound(1);
		GameUI.Instance.Coins_obj[0].SetActive(false);
		GameUI.Instance.Coins_obj[1].SetActive(false);
	}

	public void GiveCoins()
	{
		StoreManager.AddCoins(200);
	}

	public void GiveFullHealth()
	{
		LevelManager.mee.Inpopup = false;
		Debug.Log("fulll health " + Leveldata.mee.PresentVehicle);
		LevelManager.mee.ShowHint.SetActive(false);
		if (Leveldata.mee.PresentVehicle != null)
		{
			Leveldata.mee.PresentVehicle.GetComponent<VehicleHealth>().ResetVehicle();
		}
		else
		{
			PlayerBehaviour.Instance.ResetPlayer();
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
