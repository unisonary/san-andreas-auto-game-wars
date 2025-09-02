using System;
using Com.Google.Android.Gms.Common.Api;
using Google.Developers;

namespace Com.Google.Android.Gms.Games
{
	public class Games_BaseGamesApiMethodImpl<R> : JavaObjWrapper where R : Result
	{
		private const string CLASS_NAME = "com/google/android/gms/games/Games$BaseGamesApiMethodImpl";

		public Games_BaseGamesApiMethodImpl(IntPtr ptr)
			: base(ptr)
		{
		}

		public Games_BaseGamesApiMethodImpl(GoogleApiClient arg_GoogleApiClient_1)
		{
			CreateInstance("com/google/android/gms/games/Games$BaseGamesApiMethodImpl", arg_GoogleApiClient_1);
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
