using System;
using GooglePlayGames.BasicApi.Nearby;
using GooglePlayGames.Native;
using GooglePlayGames.Native.Cwrapper;
using GooglePlayGames.OurUtils;
using UnityEngine;

namespace GooglePlayGames
{
	public static class NearbyConnectionClientFactory
	{
		public static void Create(Action<INearbyConnectionClient> callback)
		{
			if (Application.isEditor)
			{
				GooglePlayGames.OurUtils.Logger.d("Creating INearbyConnection in editor, using DummyClient.");
				callback(new DummyNearbyConnectionClient());
			}
			GooglePlayGames.OurUtils.Logger.d("Creating real INearbyConnectionClient");
			NativeNearbyConnectionClientFactory.Create(callback);
		}

		private static InitializationStatus ToStatus(NearbyConnectionsStatus.InitializationStatus status)
		{
			switch (status)
			{
			case NearbyConnectionsStatus.InitializationStatus.VALID:
				return InitializationStatus.Success;
			case NearbyConnectionsStatus.InitializationStatus.ERROR_INTERNAL:
				return InitializationStatus.InternalError;
			case NearbyConnectionsStatus.InitializationStatus.ERROR_VERSION_UPDATE_REQUIRED:
				return InitializationStatus.VersionUpdateRequired;
			default:
				GooglePlayGames.OurUtils.Logger.w("Unknown initialization status: " + status);
				return InitializationStatus.InternalError;
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
