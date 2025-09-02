using UnityEngine;
using UnityEngine.UI;

public class LevelsInAppPage : MonoBehaviour
{
	public static LevelsInAppPage instance;

	public GameObject PopUp;

	public GameObject CloseBtn;

	public Text UnlockAllDesc;

	public Text DiscountDesc;

	public Text OriginalPrice;

	public Text DiscountPrice;

	public GameObject UnlockAllPop;

	public GameObject DiscountPop;

	public bool IsShowDiscountPop;

	private void Awake()
	{
		instance = this;
		base.gameObject.SetActive(false);
	}

	public void Open()
	{
		base.gameObject.SetActive(true);
		UnlockAllPop.SetActive(false);
		DiscountPop.SetActive(false);
		if (!IsShowDiscountPop)
		{
			UnlockAllDesc.text = "Unlock All Levels And Get More Fun!";
			UnlockAllPop.SetActive(true);
			IsShowDiscountPop = true;
		}
		else
		{
			DiscountPop.SetActive(true);
			DiscountDesc.text = "Unlock All Levels with 50% Discount";
			if (PlayerPrefs.HasKey("nonConsumableProducts_" + InAppController.instance.UnlockAllLevelsIndex))
			{
				OriginalPrice.text = PlayerPrefs.GetString("nonConsumableProducts_" + InAppController.instance.UnlockAllLevelsIndex, "BUY");
			}
			if (PlayerPrefs.HasKey("nonConsumableProducts_" + InAppController.instance.LevelsDiscountIndex))
			{
				DiscountPrice.text = PlayerPrefs.GetString("nonConsumableProducts_" + InAppController.instance.LevelsDiscountIndex, "BUY");
			}
			IsShowDiscountPop = false;
		}
		PopUp.transform.localPosition = Vector3.zero;
		iTween.MoveFrom(PopUp, iTween.Hash("y", 1000, "time", 0.4f, "islocal", true, "easetype", iTween.EaseType.spring));
		iTween.ScaleFrom(CloseBtn, iTween.Hash("x", 0, "y", 0, "time", 0.5, "delay", 0.5f, "easetype", iTween.EaseType.spring));
	}

	public void Close()
	{
		base.gameObject.SetActive(false);
	}

	private void OpenDiscountPop()
	{
		Open();
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
