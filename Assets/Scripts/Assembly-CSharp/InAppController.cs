using System;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.Purchasing;

public class InAppController : MonoBehaviour, IStoreListener
{
	public delegate void InAppSuccessCheck();

	public delegate void InAppFailCheck();

	public IStoreController m_StoreController;

	public static IExtensionProvider m_StoreExtensionProvider;

	public static string kProductIDSubscription = "subscription";

	private static string kProductNameAppleSubscription = "com.unity3d.subscription.new";

	private static string kProductNameGooglePlaySubscription = "com.unity3d.subscription.original";

	public string[] ConsumableProducts;

	public string[] NonConsumableProducts;

	public int UnlockAllLevelsIndex;

	public int LevelsDiscountIndex;

	public int UnlockAllUpgradesIndex;

	public int UpgradesDiscountIndex;

	private GameObject ClickedBuyBtn;

	[CompilerGenerated]
	private static InAppSuccessCheck m_InAppSuccessCallBack;

	[CompilerGenerated]
	private static InAppFailCheck m_InAppSFailCallBack;

	private static InAppController _Instance;

	private string productId;

	public static InAppController instance
	{
		get
		{
			if (_Instance == null)
			{
				_Instance = UnityEngine.Object.FindObjectOfType<InAppController>();
			}
			return _Instance;
		}
	}

	public static event InAppSuccessCheck InAppSuccessCallBack
	{
		[CompilerGenerated]
		add
		{
			InAppSuccessCheck inAppSuccessCheck = InAppController.m_InAppSuccessCallBack;
			InAppSuccessCheck inAppSuccessCheck2;
			do
			{
				inAppSuccessCheck2 = inAppSuccessCheck;
				InAppSuccessCheck value2 = (InAppSuccessCheck)Delegate.Combine(inAppSuccessCheck2, value);
				inAppSuccessCheck = Interlocked.CompareExchange(ref InAppController.m_InAppSuccessCallBack, value2, inAppSuccessCheck2);
			}
			while (inAppSuccessCheck != inAppSuccessCheck2);
		}
		[CompilerGenerated]
		remove
		{
			InAppSuccessCheck inAppSuccessCheck = InAppController.m_InAppSuccessCallBack;
			InAppSuccessCheck inAppSuccessCheck2;
			do
			{
				inAppSuccessCheck2 = inAppSuccessCheck;
				InAppSuccessCheck value2 = (InAppSuccessCheck)Delegate.Remove(inAppSuccessCheck2, value);
				inAppSuccessCheck = Interlocked.CompareExchange(ref InAppController.m_InAppSuccessCallBack, value2, inAppSuccessCheck2);
			}
			while (inAppSuccessCheck != inAppSuccessCheck2);
		}
	}

	public static event InAppFailCheck InAppSFailCallBack
	{
		[CompilerGenerated]
		add
		{
			InAppFailCheck inAppFailCheck = InAppController.m_InAppSFailCallBack;
			InAppFailCheck inAppFailCheck2;
			do
			{
				inAppFailCheck2 = inAppFailCheck;
				InAppFailCheck value2 = (InAppFailCheck)Delegate.Combine(inAppFailCheck2, value);
				inAppFailCheck = Interlocked.CompareExchange(ref InAppController.m_InAppSFailCallBack, value2, inAppFailCheck2);
			}
			while (inAppFailCheck != inAppFailCheck2);
		}
		[CompilerGenerated]
		remove
		{
			InAppFailCheck inAppFailCheck = InAppController.m_InAppSFailCallBack;
			InAppFailCheck inAppFailCheck2;
			do
			{
				inAppFailCheck2 = inAppFailCheck;
				InAppFailCheck value2 = (InAppFailCheck)Delegate.Remove(inAppFailCheck2, value);
				inAppFailCheck = Interlocked.CompareExchange(ref InAppController.m_InAppSFailCallBack, value2, inAppFailCheck2);
			}
			while (inAppFailCheck != inAppFailCheck2);
		}
	}

	private void Awake()
	{
	}

	private void Start()
	{
		if (m_StoreController == null)
		{
			InitializePurchasing();
		}
	}

	public void InitializePurchasing()
	{
		if (!IsInitialized())
		{
			ConfigurationBuilder configurationBuilder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
			for (int i = 0; i < ConsumableProducts.Length; i++)
			{
				configurationBuilder.AddProduct(ConsumableProducts[i], ProductType.Consumable);
			}
			for (int j = 0; j < NonConsumableProducts.Length; j++)
			{
				configurationBuilder.AddProduct(NonConsumableProducts[j], ProductType.NonConsumable);
			}
			UnityPurchasing.Initialize(this, configurationBuilder);
		}
	}

	public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
	{
		m_StoreController = controller;
		m_StoreExtensionProvider = extensions;
		Debug.Log("--- OnInitialized");
		Debug.Log("products=" + m_StoreController.products);
		RestorePurchases();
		for (int i = 0; i < ConsumableProducts.Length; i++)
		{
			Product product = m_StoreController.products.WithID(ConsumableProducts[i]);
			PlayerPrefs.SetString("consumableProducts_" + i, product.metadata.localizedPriceString);
			Debug.Log("price of product=" + product.metadata.ToString() + "===" + product.metadata.localizedPrice + "::::" + product.metadata.localizedPriceString);
		}
		for (int j = 0; j < NonConsumableProducts.Length; j++)
		{
			Product product2 = m_StoreController.products.WithID(NonConsumableProducts[j]);
			PlayerPrefs.SetString("nonConsumableProducts_" + j, product2.metadata.localizedPriceString);
			Debug.Log("price of product=" + product2.ToString() + "===" + product2.metadata.localizedPrice + "::::" + product2.metadata.localizedPriceString);
		}
	}

	public void OnInitializeFailed(InitializationFailureReason error)
	{
		Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
	}

	public void RestorePurchases()
	{
		m_StoreExtensionProvider.GetExtension<IAppleExtensions>().RestoreTransactions(delegate(bool result)
		{
			if (result)
			{
				Debug.Log("--- OnInitialized RestoreProducts");
				for (int i = 0; i < NonConsumableProducts.Length; i++)
				{
					Product product = m_StoreController.products.WithID(NonConsumableProducts[i]);
					if (product != null && product.hasReceipt)
					{
						Debug.Log("Restored id is=" + NonConsumableProducts[i]);
						if (!PlayerPrefs.HasKey("IsRestored"))
						{
							AdManager.instance.ShowToast("Restored successfully");
							PlayerPrefs.SetString("IsRestored", "true");
						}
						CallbacksController.instance.InAppCallBacks(product.definition.id);
						checkUnlockAllPurchase(product.definition.id);
					}
				}
			}
		});
	}

	private bool IsInitialized()
	{
		if (m_StoreController != null)
		{
			return m_StoreExtensionProvider != null;
		}
		return false;
	}

	public void BuySubscription()
	{
		BuyProductID(kProductIDSubscription);
	}

	public void BuyProductID(string InAppID)
	{
		if (IsInitialized())
		{
			Product product = m_StoreController.products.WithID(InAppID);
			if (product != null && product.availableToPurchase)
			{
				Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
				m_StoreController.InitiatePurchase(InAppID);
			}
			else
			{
				Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
			}
		}
		else
		{
			Debug.Log("BuyProductID FAIL. Not initialized.");
		}
	}

	public void BuyProductID(int InAppIndex, bool IsNonConsumable, GameObject BuyBtn = null)
	{
		Debug.Log("--------- BuyProductID");
		if (!IsNonConsumable)
		{
			productId = ConsumableProducts[InAppIndex];
		}
		else
		{
			productId = NonConsumableProducts[InAppIndex];
		}
		ClickedBuyBtn = BuyBtn;
		if (IsInitialized())
		{
			Product product = m_StoreController.products.WithID(productId);
			if (product != null && product.availableToPurchase)
			{
				Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
				m_StoreController.InitiatePurchase(product);
			}
			else
			{
				Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
			}
		}
		else
		{
			Debug.Log("BuyProductID FAIL. Not initialized.");
		}
	}

	public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
	{
		Debug.Log("------------------ process purchase");
		//if (InAppController.InAppSuccessCallBack != null)
		//{
		//	InAppController.InAppSuccessCallBack();
		//}
		CallbacksController.instance.InAppCallBacks(args.purchasedProduct.definition.id);
		checkUnlockAllPurchase(args.purchasedProduct.definition.id);
		return PurchaseProcessingResult.Complete;
	}

	public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
	{
		//InAppController.InAppSFailCallBack();
		Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
	}

	public bool IsRestorableProduct(int Index)
	{
		Product product = m_StoreController.products.WithID(NonConsumableProducts[Index]);
		if (product != null && product.hasReceipt)
		{
			return true;
		}
		return false;
	}

	public void checkUnlockAllPurchase(string productId)
	{
		if (productId == NonConsumableProducts[UnlockAllUpgradesIndex] || productId == NonConsumableProducts[UpgradesDiscountIndex])
		{
			AdManager.UpgradeUnlocked = 1;
		}
		if (productId == NonConsumableProducts[UnlockAllLevelsIndex] || productId == NonConsumableProducts[LevelsDiscountIndex])
		{
			AdManager.LevelsUnlocked = 1;
		}
	}

    void IStoreListener.OnInitializeFailed(InitializationFailureReason error, string message)
    {
        throw new NotImplementedException();
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
