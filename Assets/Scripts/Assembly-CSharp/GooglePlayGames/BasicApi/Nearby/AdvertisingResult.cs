using GooglePlayGames.OurUtils;

namespace GooglePlayGames.BasicApi.Nearby
{
	public struct AdvertisingResult
	{
		private readonly ResponseStatus mStatus;

		private readonly string mLocalEndpointName;

		public bool Succeeded
		{
			get
			{
				return mStatus == ResponseStatus.Success;
			}
		}

		public ResponseStatus Status
		{
			get
			{
				return mStatus;
			}
		}

		public string LocalEndpointName
		{
			get
			{
				return mLocalEndpointName;
			}
		}

		public AdvertisingResult(ResponseStatus status, string localEndpointName)
		{
			mStatus = status;
			mLocalEndpointName = Misc.CheckNotNull(localEndpointName);
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
