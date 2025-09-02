using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

[AddComponentMenu("Unity IAP/Demo")]
public class IAPDemo : MonoBehaviour, IStoreListener
{
	[Serializable]
	public class UnityChannelPurchaseError
	{
		public string error;

		public UnityChannelPurchaseInfo purchaseInfo;
	}

	[Serializable]
	public class UnityChannelPurchaseInfo
	{
		public string productCode;

		public string gameOrderId;

		public string orderQueryToken;
	}

	

	private IStoreController m_Controller;

	private IAppleExtensions m_AppleExtensions;


	private IMicrosoftExtensions m_MicrosoftExtensions;


	private ITransactionHistoryExtensions m_TransactionHistoryExtensions;

	private bool m_IsGooglePlayStoreSelected;

	private bool m_IsSamsungAppsStoreSelected;

	private bool m_IsCloudMoolahStoreSelected;

	private bool m_IsUnityChannelSelected;

	private string m_LastTransactionID;

	private bool m_IsLoggedIn;


	private bool m_FetchReceiptPayloadOnPurchase;

	private bool m_PurchaseInProgress;

	private Dictionary<string, IAPDemoProductUI> m_ProductUIs = new Dictionary<string, IAPDemoProductUI>();

	public GameObject productUITemplate;

	public RectTransform contentRect;

	public Button restoreButton;

	public Button loginButton;

	public Button validateButton;

	public Text versionText;

	public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
	{
		m_Controller = controller;
		m_AppleExtensions = extensions.GetExtension<IAppleExtensions>();

		m_MicrosoftExtensions = extensions.GetExtension<IMicrosoftExtensions>();

		m_TransactionHistoryExtensions = extensions.GetExtension<ITransactionHistoryExtensions>();
		InitUI(controller.products.all);
		m_AppleExtensions.RegisterPurchaseDeferredListener(OnDeferred);
		Debug.Log("Available items:");
		Product[] all = controller.products.all;
		foreach (Product product in all)
		{
			if (product.availableToPurchase)
			{
				Debug.Log(string.Join(" - ", new string[7]
				{
					product.metadata.localizedTitle,
					product.metadata.localizedDescription,
					product.metadata.isoCurrencyCode,
					product.metadata.localizedPrice.ToString(),
					product.metadata.localizedPriceString,
					product.transactionID,
					product.receipt
				}));
			}
		}
		AddProductUIs(m_Controller.products.all);
		LogProductDefinitions();
	}

	public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)
	{
		Debug.Log("Purchase OK: " + e.purchasedProduct.definition.id);
		Debug.Log("Receipt: " + e.purchasedProduct.receipt);
		m_LastTransactionID = e.purchasedProduct.transactionID;
		m_PurchaseInProgress = false;
		if (m_IsUnityChannelSelected)
		{
			UnifiedReceipt unifiedReceipt = JsonUtility.FromJson<UnifiedReceipt>(e.purchasedProduct.receipt);
			if (unifiedReceipt != null && !string.IsNullOrEmpty(unifiedReceipt.Payload))
			{
				}
		}
		UpdateProductUI(e.purchasedProduct);
		return PurchaseProcessingResult.Complete;
	}

	public void OnPurchaseFailed(Product item, PurchaseFailureReason r)
	{
		Debug.Log("Purchase failed: " + item.definition.id);
		Debug.Log(r);
		Debug.Log("Store specific error code: " + m_TransactionHistoryExtensions.GetLastStoreSpecificPurchaseErrorCode());
		if (m_TransactionHistoryExtensions.GetLastPurchaseFailureDescription() != null)
		{
			Debug.Log("Purchase failure description message: " + m_TransactionHistoryExtensions.GetLastPurchaseFailureDescription().message);
		}
		if (m_IsUnityChannelSelected)
		{


		}
		m_PurchaseInProgress = false;
	}

	public void OnInitializeFailed(InitializationFailureReason error)
	{
		Debug.Log("Billing failed to initialize!");
		switch (error)
		{
		case InitializationFailureReason.AppNotKnown:
			Debug.LogError("Is your App correctly uploaded on the relevant publisher console?");
			break;
		case InitializationFailureReason.PurchasingUnavailable:
			Debug.Log("Billing disabled!");
			break;
		case InitializationFailureReason.NoProductsAvailable:
			Debug.Log("No products available for purchase!");
			break;
		}
	}

	public void Awake()
	{
		StandardPurchasingModule standardPurchasingModule = StandardPurchasingModule.Instance();
		standardPurchasingModule.useFakeStoreUIMode = FakeStoreUIMode.StandardUser;
		ConfigurationBuilder builder = ConfigurationBuilder.Instance(standardPurchasingModule);
		builder.Configure<IMicrosoftConfiguration>().useMockBillingSystem = false;
		m_IsGooglePlayStoreSelected = Application.platform == RuntimePlatform.Android && standardPurchasingModule.appStore == AppStore.GooglePlay;

		ProductCatalog productCatalog = ProductCatalog.LoadDefaultCatalog();
		foreach (ProductCatalogItem allValidProduct in productCatalog.allValidProducts)
		{
			if (allValidProduct.allStoreIDs.Count > 0)
			{
				IDs ds = new IDs();
				foreach (StoreID allStoreID in allValidProduct.allStoreIDs)
				{
					ds.Add(allStoreID.id, allStoreID.store);
				}
				builder.AddProduct(allValidProduct.id, allValidProduct.type, ds);
			}
			else
			{
				builder.AddProduct(allValidProduct.id, allValidProduct.type);
			}
		}
		builder.AddProduct("100.gold.coins", ProductType.Consumable, new IDs
		{
			{ "com.unity3d.unityiap.unityiapdemo.100goldcoins.7", "MacAppStore" },
			{ "000000596586", "TizenStore" },
			{ "com.ff", "MoolahAppStore" },
			{ "100.gold.coins", "AmazonApps" }
		});
		builder.AddProduct("500.gold.coins", ProductType.Consumable, new IDs
		{
			{ "com.unity3d.unityiap.unityiapdemo.500goldcoins.7", "MacAppStore" },
			{ "000000596581", "TizenStore" },
			{ "com.ee", "MoolahAppStore" },
			{ "500.gold.coins", "AmazonApps" }
		});
		builder.AddProduct("sword", ProductType.NonConsumable, new IDs
		{
			{ "com.unity3d.unityiap.unityiapdemo.sword.7", "MacAppStore" },
			{ "000000596583", "TizenStore" },
			{ "sword", "AmazonApps" }
		});

		Action initializeUnityIap = delegate
		{
			UnityPurchasing.Initialize(this, builder);
		};
		if (!m_IsUnityChannelSelected)
		{
			initializeUnityIap();
			return;
		}
		
	}

	private void OnTransactionsRestored(bool success)
	{
		Debug.Log("Transactions restored.");
	}

	private void OnDeferred(Product item)
	{
		Debug.Log("Purchase deferred: " + item.definition.id);
	}

	private void InitUI(IEnumerable<Product> items)
	{
		restoreButton.gameObject.SetActive(NeedRestoreButton());
		loginButton.gameObject.SetActive(NeedLoginButton());
		validateButton.gameObject.SetActive(NeedValidateButton());
		ClearProductUIs();
		restoreButton.onClick.AddListener(RestoreButtonClick);
		loginButton.onClick.AddListener(LoginButtonClick);
		validateButton.onClick.AddListener(ValidateButtonClick);
		versionText.text = "Unity version: " + Application.unityVersion + "\nIAP version: 1.20.0";
	}

	public void PurchaseButtonClick(string productID)
	{
		if (m_PurchaseInProgress)
		{
			Debug.Log("Please wait, purchase in progress");
			return;
		}
		if (m_Controller == null)
		{
			Debug.LogError("Purchasing is not initialized");
			return;
		}
		if (m_Controller.products.WithID(productID) == null)
		{
			Debug.LogError("No product has id " + productID);
			return;
		}
		if (NeedLoginButton() && !m_IsLoggedIn)
		{
			Debug.LogWarning("Purchase notifications will not be forwarded server-to-server. Login incomplete.");
		}
		m_PurchaseInProgress = true;
		m_Controller.InitiatePurchase(m_Controller.products.WithID(productID), "aDemoDeveloperPayload");
	}

	public void RestoreButtonClick()
	{
		if (m_IsCloudMoolahStoreSelected)
		{
			if (!m_IsLoggedIn)
			{
				Debug.LogError("CloudMoolah purchase restoration aborted. Login incomplete.");
				return;
			}

		}
		else if (m_IsSamsungAppsStoreSelected)
		{

		}
		else if (Application.platform == RuntimePlatform.MetroPlayerX86 || Application.platform == RuntimePlatform.MetroPlayerX64 || Application.platform == RuntimePlatform.MetroPlayerARM)
		{
			m_MicrosoftExtensions.RestoreTransactions();
		}
		else
		{
			m_AppleExtensions.RestoreTransactions(OnTransactionsRestored);
		}
	}

	public void LoginButtonClick()
	{
		if (!m_IsUnityChannelSelected)
		{
			Debug.Log("Login is only required for the Xiaomi store");
			return;
		}
	}

	public void ValidateButtonClick()
	{
		if (!m_IsUnityChannelSelected)
		{
			Debug.Log("Remote purchase validation is only supported for the Xiaomi store");
			return;
		}
		string txId = m_LastTransactionID;

	}

	private void ClearProductUIs()
	{
		foreach (KeyValuePair<string, IAPDemoProductUI> productUI in m_ProductUIs)
		{
			UnityEngine.Object.Destroy(productUI.Value.gameObject);
		}
		m_ProductUIs.Clear();
	}

	private void AddProductUIs(Product[] products)
	{
		ClearProductUIs();
		RectTransform component = productUITemplate.GetComponent<RectTransform>();
		float height = component.rect.height;
		Vector3 localPosition = component.localPosition;
		contentRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, (float)products.Length * height);
		foreach (Product product in products)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(productUITemplate.gameObject);
			gameObject.transform.SetParent(productUITemplate.transform.parent, false);
			RectTransform component2 = gameObject.GetComponent<RectTransform>();
			component2.localPosition = localPosition;
			localPosition += Vector3.down * height;
			gameObject.SetActive(true);
			IAPDemoProductUI component3 = gameObject.GetComponent<IAPDemoProductUI>();
			component3.SetProduct(product, PurchaseButtonClick);
			m_ProductUIs[product.definition.id] = component3;
		}
	}

	private void UpdateProductUI(Product p)
	{
		if (m_ProductUIs.ContainsKey(p.definition.id))
		{
			m_ProductUIs[p.definition.id].SetProduct(p, PurchaseButtonClick);
		}
	}

	private void UpdateProductPendingUI(Product p, int secondsRemaining)
	{
		if (m_ProductUIs.ContainsKey(p.definition.id))
		{
			m_ProductUIs[p.definition.id].SetPendingTime(secondsRemaining);
		}
	}

	private bool NeedRestoreButton()
	{
		return Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.tvOS || Application.platform == RuntimePlatform.MetroPlayerX86 || Application.platform == RuntimePlatform.MetroPlayerX64 || Application.platform == RuntimePlatform.MetroPlayerARM || m_IsSamsungAppsStoreSelected || m_IsCloudMoolahStoreSelected;
	}

	private bool NeedLoginButton()
	{
		return m_IsUnityChannelSelected;
	}

	private bool NeedValidateButton()
	{
		return m_IsUnityChannelSelected;
	}

	private void LogProductDefinitions()
	{
		Product[] all = m_Controller.products.all;
		Product[] array = all;
		foreach (Product product in array)
		{
			Debug.Log(string.Format("id: {0}\nstore-specific id: {1}\ntype: {2}\nenabled: {3}\n", product.definition.id, product.definition.storeSpecificId, product.definition.type.ToString(), (!product.definition.enabled) ? "disabled" : "enabled"));
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
