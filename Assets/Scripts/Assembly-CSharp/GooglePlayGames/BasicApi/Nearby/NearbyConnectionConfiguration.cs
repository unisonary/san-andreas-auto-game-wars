using System;
using GooglePlayGames.OurUtils;

namespace GooglePlayGames.BasicApi.Nearby
{
	public struct NearbyConnectionConfiguration
	{
		public const int MaxUnreliableMessagePayloadLength = 1168;

		public const int MaxReliableMessagePayloadLength = 4096;

		private readonly Action<InitializationStatus> mInitializationCallback;

		private readonly long mLocalClientId;

		public long LocalClientId
		{
			get
			{
				return mLocalClientId;
			}
		}

		public Action<InitializationStatus> InitializationCallback
		{
			get
			{
				return mInitializationCallback;
			}
		}

		public NearbyConnectionConfiguration(Action<InitializationStatus> callback, long localClientId)
		{
			mInitializationCallback = Misc.CheckNotNull(callback);
			mLocalClientId = localClientId;
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
