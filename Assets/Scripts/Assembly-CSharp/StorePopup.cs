using System;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class StorePopup : MonoBehaviour
{
	public delegate void CoinsUpdate();

	private string[] InApp_ids;

	public Text[] _btnStores;

	public Text[] PriceTexts;

	public Text CurrentCoins;

	public Color _mycolor;

	private static StorePopup _instance;

	public LevelSelectionHandler LS_obj;

	public WeaponSelection WS_obj;

	[CompilerGenerated]
	private static CoinsUpdate m_CoinsUpdateEvent;

	public static StorePopup Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = UnityEngine.Object.FindObjectOfType<StorePopup>();
			}
			return _instance;
		}
	}

	public static event CoinsUpdate CoinsUpdateEvent
	{
		[CompilerGenerated]
		add
		{
			CoinsUpdate coinsUpdate = StorePopup.m_CoinsUpdateEvent;
			CoinsUpdate coinsUpdate2;
			do
			{
				coinsUpdate2 = coinsUpdate;
				CoinsUpdate value2 = (CoinsUpdate)Delegate.Combine(coinsUpdate2, value);
				coinsUpdate = Interlocked.CompareExchange(ref StorePopup.m_CoinsUpdateEvent, value2, coinsUpdate2);
			}
			while (coinsUpdate != coinsUpdate2);
		}
		[CompilerGenerated]
		remove
		{
			CoinsUpdate coinsUpdate = StorePopup.m_CoinsUpdateEvent;
			CoinsUpdate coinsUpdate2;
			do
			{
				coinsUpdate2 = coinsUpdate;
				CoinsUpdate value2 = (CoinsUpdate)Delegate.Remove(coinsUpdate2, value);
				coinsUpdate = Interlocked.CompareExchange(ref StorePopup.m_CoinsUpdateEvent, value2, coinsUpdate2);
			}
			while (coinsUpdate != coinsUpdate2);
		}
	}

	private void Awake()
	{
		_instance = this;
		base.gameObject.SetActive(false);
	}

	public void Open()
	{
		base.gameObject.SetActive(true);
		SetUpDetails();
	}

	private void SetUpDetails()
	{
		CurrentCoins.text = PlayerPrefs.GetInt(StoreManager.KEY_COINS, 0).ToString();
		for (int i = 0; i < PriceTexts.Length; i++)
		{
		}
		CheckButtons();
	}

	public void Close()
	{
		base.gameObject.SetActive(false);
		Debug.Log("Stor Close....  " + LevelSelectionHandler.CPage);
		if (LevelSelectionHandler.CPage == "Ls")
		{
			LS_obj.Start_open();
		}
		if (LevelSelectionHandler.CPage == "Ws")
		{
			WS_obj.Open();
		}
	}

	public void Buy(int index)
	{
		Debug.Log("PackageId::" + index);
	}

	public void CheckButtons()
	{
		if (!PlayerPrefs.HasKey("levelUnlocked"))
		{
			PlayerPrefs.SetString("levelUnlocked", "false");
			PlayerPrefs.SetString("weaponsunlocked", "false");
		}
		if (PlayerPrefs.GetString("noadsdata") == "true")
		{
			PriceTexts[0].color = _mycolor;
			PriceTexts[0].transform.parent.gameObject.GetComponent<Image>().color = _mycolor;
			PriceTexts[0].transform.parent.GetChild(1).GetComponent<Image>().color = _mycolor;
		}
		if (PlayerPrefs.GetString("levelUnlocked") == "true")
		{
			PriceTexts[1].color = _mycolor;
			PriceTexts[1].transform.parent.gameObject.GetComponent<Image>().color = _mycolor;
			PriceTexts[1].transform.parent.GetChild(1).GetComponent<Image>().color = _mycolor;
		}
		if (PlayerPrefs.GetString("weaponsunlocked") == "true")
		{
			PriceTexts[2].color = _mycolor;
			PriceTexts[2].transform.parent.gameObject.GetComponent<Image>().color = _mycolor;
			PriceTexts[2].transform.parent.GetChild(1).GetComponent<Image>().color = _mycolor;
		}
		if (PlayerPrefs.GetString("levelUnlocked") == "true" && PlayerPrefs.GetString("weaponsunlocked") == "true")
		{
			PriceTexts[3].color = _mycolor;
			PriceTexts[3].transform.parent.gameObject.GetComponent<Image>().color = _mycolor;
			PriceTexts[3].transform.parent.GetChild(1).GetComponent<Image>().color = _mycolor;
		}
	}

	public void UpdateCoinsText()
	{
		if ((bool)CurrentCoins)
		{
			CurrentCoins.text = StoreManager.SHOWCOINS().ToString();
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
