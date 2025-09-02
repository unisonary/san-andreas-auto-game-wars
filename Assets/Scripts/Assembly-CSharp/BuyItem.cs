using UnityEngine;
using UnityEngine.UI;

public class BuyItem : MonoBehaviour
{
	public enum InAppCategory
	{
		Consumable = 0,
		NonConsumable = 1
	}

	public int Index;

	public Text PriceTxt;

	public bool ShowPrice = true;

	private int DiscountIndex = -1;

	public InAppCategory inAppCategory;

	private void OnEnable()
	{
		if (PriceTxt == null && ShowPrice && base.gameObject.transform.childCount > 0)
		{
			PriceTxt = GetComponentInChildren<Text>();
		}
		if (inAppCategory == InAppCategory.NonConsumable)
		{
			if (InAppController.instance.m_StoreController != null)
			{
				base.gameObject.GetComponent<Button>().interactable = true;
				if (InAppController.instance.IsRestorableProduct(Index))
				{
					Debug.Log("------------ It is purchased Already");
					base.gameObject.GetComponent<Button>().interactable = false;
				}
				else
				{
					if (Index == InAppController.instance.UnlockAllLevelsIndex)
					{
						DiscountIndex = InAppController.instance.LevelsDiscountIndex;
					}
					else if (Index == InAppController.instance.UnlockAllUpgradesIndex)
					{
						DiscountIndex = InAppController.instance.UpgradesDiscountIndex;
					}
					if (DiscountIndex != -1 && InAppController.instance.IsRestorableProduct(DiscountIndex))
					{
						base.gameObject.GetComponent<Button>().interactable = false;
					}
				}
			}
			if (PlayerPrefs.HasKey("nonConsumableProducts_" + Index) && ShowPrice)
			{
				PriceTxt.text = PlayerPrefs.GetString("nonConsumableProducts_" + Index, "BUY");
			}
		}
		else
		{
			base.gameObject.GetComponent<Button>().interactable = true;
			if (PlayerPrefs.HasKey("consumableProducts_" + Index) && ShowPrice)
			{
				PriceTxt.text = PlayerPrefs.GetString("consumableProducts_" + Index, "BUY");
			}
		}
	}

	private void OnDisable()
	{
		InAppController.InAppSuccessCallBack -= SuccessCallBack;
		InAppController.InAppSFailCallBack -= FailCallBack;
	}

	private void Start()
	{
		base.gameObject.GetComponent<Button>().onClick.AddListener(delegate
		{
			BuyClicked(Index);
		});
	}

	public void BuyClicked(int InAppIndex)
	{
		Debug.Log("----- BuyClicked");
		if (inAppCategory == InAppCategory.NonConsumable)
		{
			InAppController.InAppSuccessCallBack += SuccessCallBack;
			InAppController.InAppSFailCallBack += FailCallBack;
		}
		if (inAppCategory == InAppCategory.NonConsumable)
		{
			AdManager.instance.BuyItem(InAppIndex, true, base.gameObject);
		}
		else
		{
			AdManager.instance.BuyItem(InAppIndex, false, base.gameObject);
		}
	}

	public void SuccessCallBack()
	{
		Debug.Log("-------------- InAppSuccessCallBack");
		InAppController.InAppSuccessCallBack -= SuccessCallBack;
		InAppController.InAppSFailCallBack -= FailCallBack;
		if (inAppCategory == InAppCategory.NonConsumable)
		{
			base.gameObject.GetComponent<Button>().interactable = false;
		}
		else
		{
			base.gameObject.GetComponent<Button>().interactable = true;
		}
	}

	public void FailCallBack()
	{
		Debug.Log("-------------- InAppFailedCallBack");
		base.gameObject.GetComponent<Button>().interactable = true;
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
