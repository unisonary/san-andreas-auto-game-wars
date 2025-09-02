namespace Facebook.Unity.Example
{
	internal class AppLinks : MenuBase
	{
		protected override void GetGui()
		{
			if (Button("Get App Link"))
			{
				FB.GetAppLink(base.HandleResult);
			}
			if (Constants.IsMobile && Button("Fetch Deferred App Link"))
			{
				FB.Mobile.FetchDeferredAppLinkData(base.HandleResult);
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
