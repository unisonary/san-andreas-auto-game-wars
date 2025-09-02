using System.Collections.Generic;

namespace Facebook.Unity.Example
{
	internal class AppEvents : MenuBase
	{
		protected override void GetGui()
		{
			if (Button("Log FB App Event"))
			{
				base.Status = "Logged FB.AppEvent";
				FB.LogAppEvent("fb_mobile_achievement_unlocked", null, new Dictionary<string, object> { { "fb_description", "Clicked 'Log AppEvent' button" } });
				LogView.AddLog("You may see results showing up at https://www.facebook.com/analytics/" + FB.AppId);
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
