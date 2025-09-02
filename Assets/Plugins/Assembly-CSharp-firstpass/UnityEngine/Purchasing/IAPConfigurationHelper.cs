using System.Collections.Generic;

namespace UnityEngine.Purchasing
{
	public static class IAPConfigurationHelper
	{
		public static void PopulateConfigurationBuilder(ref ConfigurationBuilder builder, ProductCatalog catalog)
		{
			foreach (ProductCatalogItem allValidProduct in catalog.allValidProducts)
			{
				IDs ds = null;
				if (allValidProduct.allStoreIDs.Count > 0)
				{
					ds = new IDs();
					foreach (StoreID allStoreID in allValidProduct.allStoreIDs)
					{
						ds.Add(allStoreID.id, allStoreID.store);
					}
				}
				List<PayoutDefinition> list = new List<PayoutDefinition>();
				foreach (ProductCatalogPayout payout in allValidProduct.Payouts)
				{
					list.Add(new PayoutDefinition(payout.typeString, payout.subtype, payout.quantity, payout.data));
				}
				builder.AddProduct(allValidProduct.id, allValidProduct.type, ds, list.ToArray());
			}
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
