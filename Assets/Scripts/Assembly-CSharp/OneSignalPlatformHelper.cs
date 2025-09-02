using System.Collections.Generic;
using OneSignalPush.MiniJSON;

internal class OneSignalPlatformHelper
{
	internal static OSPermissionSubscriptionState parsePermissionSubscriptionState(OneSignalPlatform platform, string jsonStr)
	{
		Dictionary<string, object> dictionary = Json.Deserialize(jsonStr) as Dictionary<string, object>;
		OSPermissionSubscriptionState oSPermissionSubscriptionState = new OSPermissionSubscriptionState();
		oSPermissionSubscriptionState.permissionStatus = platform.parseOSPermissionState(dictionary["permissionStatus"]);
		oSPermissionSubscriptionState.subscriptionStatus = platform.parseOSSubscriptionState(dictionary["subscriptionStatus"]);
		if (dictionary.ContainsKey("emailSubscriptionStatus"))
		{
			oSPermissionSubscriptionState.emailSubscriptionStatus = platform.parseOSEmailSubscriptionState(dictionary["emailSubscriptionStatus"]);
		}
		return oSPermissionSubscriptionState;
	}

	internal static OSPermissionStateChanges parseOSPermissionStateChanges(OneSignalPlatform platform, string stateChangesJSONString)
	{
		Dictionary<string, object> dictionary = Json.Deserialize(stateChangesJSONString) as Dictionary<string, object>;
		return new OSPermissionStateChanges
		{
			to = platform.parseOSPermissionState(dictionary["to"]),
			from = platform.parseOSPermissionState(dictionary["from"])
		};
	}

	internal static OSSubscriptionStateChanges parseOSSubscriptionStateChanges(OneSignalPlatform platform, string stateChangesJSONString)
	{
		Dictionary<string, object> dictionary = Json.Deserialize(stateChangesJSONString) as Dictionary<string, object>;
		return new OSSubscriptionStateChanges
		{
			to = platform.parseOSSubscriptionState(dictionary["to"]),
			from = platform.parseOSSubscriptionState(dictionary["from"])
		};
	}

	internal static OSEmailSubscriptionStateChanges parseOSEmailSubscriptionStateChanges(OneSignalPlatform platform, string stateChangesJSONString)
	{
		Dictionary<string, object> dictionary = Json.Deserialize(stateChangesJSONString) as Dictionary<string, object>;
		return new OSEmailSubscriptionStateChanges
		{
			to = platform.parseOSEmailSubscriptionState(dictionary["to"]),
			from = platform.parseOSEmailSubscriptionState(dictionary["from"])
		};
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
