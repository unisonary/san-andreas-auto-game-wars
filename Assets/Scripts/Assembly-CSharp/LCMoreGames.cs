using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LCMoreGames : MonoBehaviour
{
	public List<GameObject> MGList = new List<GameObject>();

	public static LCMoreGames instance;

	public bool IsCreatedMGList;

	private int MgListCount;

	private void Awake()
	{
		instance = this;
		IsCreatedMGList = false;
		base.gameObject.SetActive(false);
	}

	public void CreateMGList(int count)
	{
		IsCreatedMGList = true;
		MgListCount = count;
		for (int i = 0; i < AdManager.instance.MgImgList.Count; i++)
		{
			MGList[i].GetComponent<Image>().sprite = AdManager.instance.MgImgList[i];
		}
	}

	public void Open()
	{
		if (AdManager.instance.MgImgList.Count > 0)
		{
			base.gameObject.SetActive(true);
			for (int i = 0; i < MGList.Count; i++)
			{
				MGList[i].SetActive(false);
			}
			SetMGList();
		}
	}

	public void Close()
	{
		base.gameObject.SetActive(false);
	}

	private void SetMGList()
	{
		if (MGList.Count != 0)
		{
			int @int = PlayerPrefs.GetInt("LastShownMGIndex", -1);
			@int++;
			if (@int >= MgListCount)
			{
				@int = 0;
			}
			MGList[@int].SetActive(true);
			PlayerPrefs.SetInt("LastShownMGIndex", @int);
		}
	}

	public void MGBtnClick(int index)
	{
		Application.OpenURL(AdManager.instance.MgLinkToList[index]);
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
