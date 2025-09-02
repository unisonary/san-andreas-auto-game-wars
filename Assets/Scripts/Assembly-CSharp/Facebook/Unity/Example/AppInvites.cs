using System;

namespace Facebook.Unity.Example
{
	internal class AppInvites : MenuBase
	{
		protected override void GetGui()
		{
			if (Button("Android Invite"))
			{
				base.Status = "Logged FB.AppEvent";
				FB.Mobile.AppInvite(new Uri("https://fb.me/892708710750483"), null, base.HandleResult);
			}
			if (Button("Android Invite With Custom Image"))
			{
				base.Status = "Logged FB.AppEvent";
				FB.Mobile.AppInvite(new Uri("https://fb.me/892708710750483"), new Uri("http://i.imgur.com/zkYlB.jpg"), base.HandleResult);
			}
			if (Button("iOS Invite"))
			{
				base.Status = "Logged FB.AppEvent";
				FB.Mobile.AppInvite(new Uri("https://fb.me/810530068992919"), null, base.HandleResult);
			}
			if (Button("iOS Invite With Custom Image"))
			{
				base.Status = "Logged FB.AppEvent";
				FB.Mobile.AppInvite(new Uri("https://fb.me/810530068992919"), new Uri("http://i.imgur.com/zkYlB.jpg"), base.HandleResult);
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
