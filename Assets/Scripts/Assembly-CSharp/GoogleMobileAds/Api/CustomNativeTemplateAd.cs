using System.Collections.Generic;
using GoogleMobileAds.Common;
using UnityEngine;

namespace GoogleMobileAds.Api
{
	public class CustomNativeTemplateAd
	{
		private ICustomNativeTemplateClient client;

		internal CustomNativeTemplateAd(ICustomNativeTemplateClient client)
		{
			this.client = client;
		}

		public List<string> GetAvailableAssetNames()
		{
			return client.GetAvailableAssetNames();
		}

		public string GetCustomTemplateId()
		{
			return client.GetTemplateId();
		}

		public Texture2D GetTexture2D(string key)
		{
			byte[] imageByteArray = client.GetImageByteArray(key);
			if (imageByteArray == null)
			{
				return null;
			}
			return Utils.GetTexture2DFromByteArray(imageByteArray);
		}

		public string GetText(string key)
		{
			return client.GetText(key);
		}

		public void PerformClick(string assetName)
		{
			client.PerformClick(assetName);
		}

		public void RecordImpression()
		{
			client.RecordImpression();
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
