using System;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.Nearby;
using GooglePlayGames.Native.Android;
using GooglePlayGames.Native.Cwrapper;
using GooglePlayGames.Native.PInvoke;
using GooglePlayGames.OurUtils;
using UnityEngine;

namespace GooglePlayGames.Native
{
	public class NativeNearbyConnectionClientFactory
	{
		private static volatile NearbyConnectionsManager sManager;

		private static Action<INearbyConnectionClient> sCreationCallback;

		internal static NearbyConnectionsManager GetManager()
		{
			return sManager;
		}

		public static void Create(Action<INearbyConnectionClient> callback)
		{
			if (sManager == null)
			{
				sCreationCallback = callback;
				InitializeFactory();
			}
			else
			{
				callback(new NativeNearbyConnectionsClient(GetManager()));
			}
		}

		internal static void InitializeFactory()
		{
			PlayGamesHelperObject.CreateObject();
			NearbyConnectionsManager.ReadServiceId();
			NearbyConnectionsManagerBuilder nearbyConnectionsManagerBuilder = new NearbyConnectionsManagerBuilder();
			nearbyConnectionsManagerBuilder.SetOnInitializationFinished(OnManagerInitialized);
			PlatformConfiguration configuration = new AndroidClient().CreatePlatformConfiguration(PlayGamesClientConfiguration.DefaultConfiguration);
			Debug.Log("Building manager Now");
			sManager = nearbyConnectionsManagerBuilder.Build(configuration);
		}

		internal static void OnManagerInitialized(NearbyConnectionsStatus.InitializationStatus status)
		{
			Debug.Log(string.Concat("Nearby Init Complete: ", status, " sManager = ", sManager));
			if (status == NearbyConnectionsStatus.InitializationStatus.VALID)
			{
				if (sCreationCallback != null)
				{
					sCreationCallback(new NativeNearbyConnectionsClient(GetManager()));
					sCreationCallback = null;
				}
			}
			else
			{
				Debug.LogError("ERROR: NearbyConnectionManager not initialized: " + status);
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
