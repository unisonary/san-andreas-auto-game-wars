using System;
using System.Runtime.InteropServices;

namespace GooglePlayGames.Native.Cwrapper
{
	internal static class StatsManager
	{
		internal delegate void FetchForPlayerCallback(IntPtr arg0, IntPtr arg1);

		[DllImport("gpg")]
		internal static extern void StatsManager_FetchForPlayer(HandleRef self, Types.DataSource data_source, FetchForPlayerCallback callback, IntPtr callback_arg);

		[DllImport("gpg")]
		internal static extern void StatsManager_FetchForPlayerResponse_Dispose(HandleRef self);

		[DllImport("gpg")]
		internal static extern CommonErrorStatus.ResponseStatus StatsManager_FetchForPlayerResponse_GetStatus(HandleRef self);

		[DllImport("gpg")]
		internal static extern IntPtr StatsManager_FetchForPlayerResponse_GetData(HandleRef self);
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
