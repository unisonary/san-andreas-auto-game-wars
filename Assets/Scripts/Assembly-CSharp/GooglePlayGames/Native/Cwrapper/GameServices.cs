using System;
using System.Runtime.InteropServices;

namespace GooglePlayGames.Native.Cwrapper
{
	internal static class GameServices
	{
		internal delegate void FlushCallback(CommonErrorStatus.FlushStatus arg0, IntPtr arg1);

		[DllImport("gpg")]
		internal static extern void GameServices_Flush(HandleRef self, FlushCallback callback, IntPtr callback_arg);

		[DllImport("gpg")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool GameServices_IsAuthorized(HandleRef self);

		[DllImport("gpg")]
		internal static extern void GameServices_Dispose(HandleRef self);

		[DllImport("gpg")]
		internal static extern void GameServices_SignOut(HandleRef self);

		[DllImport("gpg")]
		internal static extern void GameServices_StartAuthorizationUI(HandleRef self);
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
