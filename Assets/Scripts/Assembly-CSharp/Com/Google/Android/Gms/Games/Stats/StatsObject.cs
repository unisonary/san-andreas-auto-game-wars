using System;
using Com.Google.Android.Gms.Common.Api;
using Google.Developers;

namespace Com.Google.Android.Gms.Games.Stats
{
	public class StatsObject : JavaObjWrapper, Stats
	{
		private const string CLASS_NAME = "com/google/android/gms/games/stats/Stats";

		public StatsObject(IntPtr ptr)
			: base(ptr)
		{
		}

		public PendingResult<Stats_LoadPlayerStatsResultObject> loadPlayerStats(GoogleApiClient arg_GoogleApiClient_1, bool arg_bool_2)
		{
			return new PendingResult<Stats_LoadPlayerStatsResultObject>(InvokeCall<IntPtr>("loadPlayerStats", "(Lcom/google/android/gms/common/api/GoogleApiClient;Z)Lcom/google/android/gms/common/api/PendingResult;", new object[2] { arg_GoogleApiClient_1, arg_bool_2 }));
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
