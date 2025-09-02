using System;
using System.Collections;
using System.Xml;
using UnityEngine;

public class XMLReader : MonoBehaviour
{
	private XmlNode MainNode;

	private XmlNode MainMenuAdNode;

	private XmlNode MoreGamesNode;

	private int NextMGIndex;

	private void Start()
	{
		StartCoroutine("LoadAllCommonXML");
		StartCoroutine("LoadMenuAdXML");
	}

	private IEnumerator LoadAllCommonXML()
	{
		if (AdManager.instance.isWifi_OR_Data_Availble())
		{
			Debug.LogError("------------------------XML Reader Start");
			WWW xmlData = new WWW(AdManager.instance.AllCommonUrl);
			yield return xmlData;
			if (xmlData.error != null)
			{
				Debug.LogError("---------- error DoSomething");
				yield break;
			}
			Debug.LogError("implement code");
			XmlDocument xmlDocument = new XmlDocument();
			try
			{
				xmlDocument.LoadXml(xmlData.text);
			}
			catch (Exception ex)
			{
				Debug.LogError("----------------Error loading :\n" + ex);
			}
			finally
			{
				Debug.LogError("------------------------ loaded");
				MainNode = xmlDocument.SelectSingleNode("GameData");
				ReadAllCommonXmlData();
			}
		}
		else
		{
			Debug.Log("No Internet Connection to get XML data");
		}
	}

	private IEnumerator LoadMenuAdXML()
	{
		if (AdManager.instance.isWifi_OR_Data_Availble())
		{
			Debug.LogError("------------------------MenuAdXML Reader Start");
			WWW xmlData = new WWW(AdManager.instance.MenuAdUrl);
			yield return xmlData;
			if (xmlData.error != null)
			{
				Debug.LogError("---------- error DoSomething");
				yield break;
			}
			Debug.LogError("implement code");
			XmlDocument xmlDocument = new XmlDocument();
			try
			{
				xmlDocument.LoadXml(xmlData.text);
			}
			catch (Exception ex)
			{
				Debug.LogError("----------------Error loading :\n" + ex);
				NotificationController.instance.initOneSignalLocally();
			}
			finally
			{
				Debug.LogError("------------------------ loaded");
				MainMenuAdNode = xmlDocument.SelectSingleNode("games");
				ReadMenuAdXmlData();
			}
		}
		else
		{
			Debug.Log("No Internet Connection to get XML data");
		}
	}

	private void ReadAllCommonXmlData()
	{
		Debug.LogError("---------- ReadingXmlData ------------");
		XmlNode xmlNode = MainNode.SelectSingleNode("PopUpLvls");
		string[] array = xmlNode.Attributes.GetNamedItem("RateInLvls").Value.Split('_');
		AdManager.instance.RatingPopInLevels.Clear();
		for (int i = 0; i < array.Length; i++)
		{
			AdManager.instance.RatingPopInLevels.Add(int.Parse(array[i]));
		}
		string[] array2 = xmlNode.Attributes.GetNamedItem("ShareInLvls").Value.Split('_');
		AdManager.instance.SharingPopInLevels.Clear();
		for (int j = 0; j < array2.Length; j++)
		{
			AdManager.instance.SharingPopInLevels.Add(int.Parse(array2[j]));
		}
		XmlNode xmlNode2 = MainNode.SelectSingleNode("Coins");
		string value = xmlNode2.Attributes.GetNamedItem("RateCoins").Value;
		AdManager.instance.RateCoins = int.Parse(value);
		string value2 = xmlNode2.Attributes.GetNamedItem("ShareCoins").Value;
		AdManager.instance.ShareCoins = int.Parse(value2);
		XmlNode xmlNode3 = MainNode.SelectSingleNode("DiscountPop");
		string[] array3 = xmlNode3.Attributes.GetNamedItem("Menu").Value.Split('_');
		AdManager.instance.DiscountPopInMenu.Clear();
		for (int k = 0; k < array3.Length; k++)
		{
			AdManager.instance.DiscountPopInMenu.Add(int.Parse(array3[k]));
		}
		string[] array4 = xmlNode3.Attributes.GetNamedItem("UPLS").Value.Split('_');
		for (int l = 0; l < array4.Length; l++)
		{
			AdManager.instance.UnlockPopIn_UP_LS[l] = int.Parse(array4[l]);
		}
		XmlNode xmlNode4 = MainNode.SelectSingleNode("AdType");
		string[] array5 = xmlNode4.Attributes.GetNamedItem("RotationType").Value.Split('_');
		AdManager.instance.RotationAdsList.Clear();
		for (int m = 0; m < array5.Length; m++)
		{
			AdManager.instance.RotationAdsList.Add(int.Parse(array5[m]));
		}
		string[] array6 = xmlNode4.Attributes.GetNamedItem("RotationRewardType").Value.Split('_');
		AdManager.instance.RotationVideoAdsList.Clear();
		for (int n = 0; n < array6.Length; n++)
		{
			AdManager.instance.RotationVideoAdsList.Add(int.Parse(array6[n]));
		}
		AdManager.instance.SetInitialAdIndex();
		XmlNode xmlNode5 = MainNode.SelectSingleNode("Desc");
		AdManager.instance.RateDesc = xmlNode5.Attributes.GetNamedItem("RateDesc").Value;
		AdManager.instance.ShareDesc = xmlNode5.Attributes.GetNamedItem("ShareDesc").Value;
		XmlNode xmlNode6 = MainNode.SelectSingleNode("Addelay");
		AdManager.instance.LcAdDelay = float.Parse(xmlNode6.Attributes.GetNamedItem("lcaddelay").Value);
		AdManager.instance.LfAdDelay = float.Parse(xmlNode6.Attributes.GetNamedItem("lfaddelay").Value);
		AdManager.instance.PreLfAdDelay = float.Parse(xmlNode6.Attributes.GetNamedItem("prelfdelay").Value);
		AdManager.instance.LsAdDelay = float.Parse(xmlNode6.Attributes.GetNamedItem("upldelay").Value);
		AdManager.instance.UpgradeAdDelay = float.Parse(xmlNode6.Attributes.GetNamedItem("upldelay").Value);
		AdManager.instance.AdDelay = int.Parse(xmlNode6.Attributes.GetNamedItem("Addelay").Value);
		AdManager.instance.LastAdShownTime = -AdManager.instance.AdDelay;
		XmlNode xmlNode7 = MainNode.SelectSingleNode("shareLink");
		AdManager.instance.ShareUrl = xmlNode7.Attributes.GetNamedItem("urlFB").Value;
		string[] array7 = MainNode.SelectSingleNode("AdIn").Attributes.GetNamedItem("pages").Value.Split('_');
		for (int num = 0; num < array7.Length; num++)
		{
			AdManager.instance.AdInPages[num] = int.Parse(array7[num]);
		}
		if (MainNode.SelectSingleNode("Notification") != null)
		{
			string[] array8 = MainNode.SelectSingleNode("Notification").Attributes.GetNamedItem("onesignal").Value.Split('_');
			NotificationController.instance.OneSignalAppID = array8[0];
			NotificationController.instance.GoogleProjectID = array8[1];
		}
		if (MainNode.SelectSingleNode("moregames") == null)
		{
			return;
		}
		MoreGamesNode = MainNode.SelectSingleNode("moregames");
		AdManager.instance.MgImgLinkList.Clear();
		for (int num2 = 0; num2 < 10; num2++)
		{
			if (MoreGamesNode.Attributes.GetNamedItem("mgImgLink" + (num2 + 1)) != null)
			{
				string value3 = MoreGamesNode.Attributes.GetNamedItem("mgImgLink" + (num2 + 1)).Value;
				AdManager.instance.MgImgLinkList.Add(value3);
			}
		}
		AdManager.instance.MgLinkToList.Clear();
		for (int num3 = 0; num3 < AdManager.instance.MgImgLinkList.Count; num3++)
		{
			if (MoreGamesNode.Attributes.GetNamedItem("mgLinkto" + (num3 + 1)) != null)
			{
				string value4 = MoreGamesNode.Attributes.GetNamedItem("mgLinkto" + (num3 + 1)).Value;
				AdManager.instance.MgLinkToList.Add(value4);
			}
		}
		AdManager.instance.MgImgList.Clear();
		for (int num4 = 0; num4 < AdManager.instance.MgImgLinkList.Count; num4++)
		{
			AdManager.instance.MgImgList.Add(null);
		}
		StartCoroutine(DownloadImg(AdManager.instance.MgImgLinkList[0], 0));
	}

	private void ReadMenuAdXmlData()
	{
		XmlNode xmlNode = null;
		xmlNode = MainMenuAdNode.SelectSingleNode(Application.identifier);
		if (xmlNode == null)
		{
			Debug.Log("not found");
			xmlNode = MainMenuAdNode.SelectSingleNode("common");
		}
		else
		{
			Debug.Log("---------- found");
			if (xmlNode.Attributes.GetNamedItem("onesignal") != null)
			{
				string[] array = xmlNode.Attributes.GetNamedItem("onesignal").Value.Split('_');
				NotificationController.instance.OneSignalAppID = array[0];
				NotificationController.instance.GoogleProjectID = array[1];
			}
		}
		AdManager.instance.MenuAdImgLink = xmlNode.Attributes.GetNamedItem("mimg").Value;
		AdManager.instance.MenuAdLinkTo = xmlNode.Attributes.GetNamedItem("linkto").Value;
		AdManager.instance.MgLink = xmlNode.Attributes.GetNamedItem("MgLink").Value;
		AdManager.instance.ExitLink = xmlNode.Attributes.GetNamedItem("exitLink").Value;
		WebViewController.instance.LoadDummyUrls();
		if (AdManager.instance.MenuAdImgLink != string.Empty)
		{
			StartCoroutine(LoadMenuAd());
		}
		NotificationController.instance.initOneSignalLocally();
	}

	private IEnumerator LoadMenuAd()
	{
		WWW menuAdView = new WWW(AdManager.instance.MenuAdImgLink);
		yield return menuAdView;
		if (string.IsNullOrEmpty(menuAdView.error))
		{
			Debug.Log("---------- OpenMenuScene from XML Reader is Menuloaded=" + AdManager.instance.IsMenuLoaded);
			Texture2D texture = menuAdView.texture;
			AdManager.instance.menuAdImg = Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), new Vector2(0f, 0f));
			MenuAdPage.instance.SetMenuAdTexture();
			if (!WelcomeGiftPage.instance.gameObject.activeInHierarchy && PlayerPrefs.GetString("IsGotWelcomeGift", "false") == "true")
			{
				AdManager.instance.StartCoroutine(AdManager.instance.OpenMenuScene(0f, true));
			}
		}
		else
		{
			MonoBehaviour.print("menuAd not loaded=" + menuAdView.error);
		}
	}

	private IEnumerator DownloadImg(string url, int Index)
	{
		int num = IsFoundMGLink(Index);
		if (num == -1)
		{
			NextMGIndex = Index + 1;
			WWW menuAdView = new WWW(url);
			yield return menuAdView;
			Texture2D texture = menuAdView.texture;
			AdManager.instance.MgImgList[Index] = Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), new Vector2(0f, 0f));
			if (NextMGIndex < AdManager.instance.MgLinkToList.Count)
			{
				StartCoroutine(DownloadImg(AdManager.instance.MgImgLinkList[NextMGIndex], NextMGIndex));
			}
			if (!LCMoreGames.instance.IsCreatedMGList && NextMGIndex >= AdManager.instance.MgImgList.Count)
			{
				LCMoreGames.instance.CreateMGList(AdManager.instance.MgImgList.Count);
			}
		}
		else
		{
			NextMGIndex = Index + 1;
			AdManager.instance.MgImgList[Index] = AdManager.instance.MgImgList[num];
			if (NextMGIndex < AdManager.instance.MgLinkToList.Count)
			{
				StartCoroutine(DownloadImg(AdManager.instance.MgImgLinkList[NextMGIndex], NextMGIndex));
			}
		}
	}

	private int IsFoundMGLink(int Index)
	{
		for (int i = 0; i < AdManager.instance.MgImgLinkList.Count; i++)
		{
			if (Index != i && AdManager.instance.MgImgLinkList[Index] == AdManager.instance.MgImgLinkList[i] && AdManager.instance.MgImgList[i] != null)
			{
				return i;
			}
		}
		return -1;
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
