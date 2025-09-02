using GooglePlayGames.OurUtils;

namespace GooglePlayGames.BasicApi.Nearby
{
	public struct EndpointDetails
	{
		private readonly string mEndpointId;

		private readonly string mName;

		private readonly string mServiceId;

		public string EndpointId
		{
			get
			{
				return mEndpointId;
			}
		}

		public string Name
		{
			get
			{
				return mName;
			}
		}

		public string ServiceId
		{
			get
			{
				return mServiceId;
			}
		}

		public EndpointDetails(string endpointId, string name, string serviceId)
		{
			mEndpointId = Misc.CheckNotNull(endpointId);
			mName = Misc.CheckNotNull(name);
			mServiceId = Misc.CheckNotNull(serviceId);
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
