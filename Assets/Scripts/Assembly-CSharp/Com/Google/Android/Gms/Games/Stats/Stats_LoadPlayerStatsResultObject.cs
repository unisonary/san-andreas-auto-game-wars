using System;
using Com.Google.Android.Gms.Common.Api;
using Google.Developers;

namespace Com.Google.Android.Gms.Games.Stats
{
	public class Stats_LoadPlayerStatsResultObject : JavaObjWrapper, Stats_LoadPlayerStatsResult, Result
	{
		private const string CLASS_NAME = "com/google/android/gms/games/stats/Stats$LoadPlayerStatsResult";

		public Stats_LoadPlayerStatsResultObject(IntPtr ptr)
			: base(ptr)
		{
		}

		public PlayerStats getPlayerStats()
		{
			return new PlayerStatsObject(InvokeCall<IntPtr>("getPlayerStats", "()Lcom/google/android/gms/games/stats/PlayerStats;", Array.Empty<object>()));
		}

		public Status getStatus()
		{
			return new Status(InvokeCall<IntPtr>("getStatus", "()Lcom/google/android/gms/common/api/Status;", Array.Empty<object>()));
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
