using UnityEngine;
using UnityEngine.UI;

public class InGameSample : MonoBehaviour
{
	public Text LvlNo;

	public static int CurrentLvl;

	public GameObject LCBtn;

	public GameObject LFBtn;

	private void Awake()
	{
		LCBtn.GetComponent<Button>().interactable = false;
		LFBtn.GetComponent<Button>().interactable = false;
	}

	private void Start()
	{
		LvlNo.text = "Level" + CurrentLvl;
		AdManager.instance.RunActions(AdManager.PageType.InGame, CurrentLvl);
		Invoke("EnableBtns", 3f);
	}

	private void EnableBtns()
	{
		LCBtn.GetComponent<Button>().interactable = true;
		LFBtn.GetComponent<Button>().interactable = true;
	}

	public void LCClick()
	{
		LevelCompleteSample.instance.Open();
	}

	public void LFClick()
	{
		PreLFPage.instance.Open();
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
