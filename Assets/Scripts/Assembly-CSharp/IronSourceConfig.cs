using System;
using System.Collections.Generic;
using IronSourceJSON;
using UnityEngine;

public class IronSourceConfig
{
	private const string unsupportedPlatformStr = "Unsupported Platform";

	private static IronSourceConfig _instance;

	private static AndroidJavaObject _androidBridge;

	private static readonly string AndroidBridge = "com.ironsource.unity.androidbridge.AndroidBridge";

	public static IronSourceConfig Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new IronSourceConfig();
			}
			return _instance;
		}
	}

	public IronSourceConfig()
	{
		using (AndroidJavaClass androidJavaClass = new AndroidJavaClass(AndroidBridge))
		{
			_androidBridge = androidJavaClass.CallStatic<AndroidJavaObject>("getInstance", Array.Empty<object>());
		}
	}

	public void setLanguage(string language)
	{
		_androidBridge.Call("setLanguage", language);
	}

	public void setClientSideCallbacks(bool status)
	{
		_androidBridge.Call("setClientSideCallbacks", status);
	}

	public void setRewardedVideoCustomParams(Dictionary<string, string> rewardedVideoCustomParams)
	{
		string text = Json.Serialize(rewardedVideoCustomParams);
		_androidBridge.Call("setRewardedVideoCustomParams", text);
	}

	public void setOfferwallCustomParams(Dictionary<string, string> offerwallCustomParams)
	{
		string text = Json.Serialize(offerwallCustomParams);
		_androidBridge.Call("setOfferwallCustomParams", text);
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
