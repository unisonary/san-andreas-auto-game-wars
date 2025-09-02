using GooglePlayGames.BasicApi;
using GooglePlayGames.Native;
using GooglePlayGames.Native.Android;
using GooglePlayGames.OurUtils;
using UnityEngine;

namespace GooglePlayGames
{
	internal class PlayGamesClientFactory
	{
		internal static IPlayGamesClient GetPlatformPlayGamesClient(PlayGamesClientConfiguration config)
		{
			if (Application.isEditor)
			{
				GooglePlayGames.OurUtils.Logger.d("Creating IPlayGamesClient in editor, using DummyClient.");
				return new DummyClient();
			}
			GooglePlayGames.OurUtils.Logger.d("Creating Android IPlayGamesClient Client");
			return new NativeClient(config, new AndroidClient());
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
