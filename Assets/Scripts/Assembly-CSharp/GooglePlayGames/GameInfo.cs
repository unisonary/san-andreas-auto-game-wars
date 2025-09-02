namespace GooglePlayGames
{
	public static class GameInfo
	{
		private const string UnescapedApplicationId = "APP_ID";

		private const string UnescapedIosClientId = "IOS_CLIENTID";

		private const string UnescapedWebClientId = "WEB_CLIENTID";

		private const string UnescapedNearbyServiceId = "NEARBY_SERVICE_ID";

		public const string ApplicationId = "340166165509";

		public const string IosClientId = "__IOS_CLIENTID__";

		public const string WebClientId = "";

		public const string NearbyConnectionServiceId = "";

		public static bool ApplicationIdInitialized()
		{
			if (!string.IsNullOrEmpty("340166165509"))
			{
				return !"340166165509".Equals(ToEscapedToken("APP_ID"));
			}
			return false;
		}

		public static bool IosClientIdInitialized()
		{
			if (!string.IsNullOrEmpty("__IOS_CLIENTID__"))
			{
				return !"__IOS_CLIENTID__".Equals(ToEscapedToken("IOS_CLIENTID"));
			}
			return false;
		}

		public static bool WebClientIdInitialized()
		{
			if (!string.IsNullOrEmpty(""))
			{
				return !"".Equals(ToEscapedToken("WEB_CLIENTID"));
			}
			return false;
		}

		public static bool NearbyConnectionsInitialized()
		{
			if (!string.IsNullOrEmpty(""))
			{
				return !"".Equals(ToEscapedToken("NEARBY_SERVICE_ID"));
			}
			return false;
		}

		private static string ToEscapedToken(string token)
		{
			return string.Format("__{0}__", token);
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
