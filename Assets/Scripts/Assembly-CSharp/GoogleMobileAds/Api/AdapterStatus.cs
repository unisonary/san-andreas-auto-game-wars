namespace GoogleMobileAds.Api
{
	public class AdapterStatus
	{
		public AdapterState InitializationState { get; private set; }

		public string Description { get; private set; }

		public int Latency { get; private set; }

		internal AdapterStatus(AdapterState state, string description, int latency)
		{
			InitializationState = state;
			Description = description;
			Latency = latency;
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
