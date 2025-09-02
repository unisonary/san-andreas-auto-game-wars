using System;
using System.Runtime.InteropServices;

namespace GooglePlayGames.Native.Cwrapper
{
	internal static class CaptureOverlayStateListenerHelper
	{
		internal delegate void OnCaptureOverlayStateChangedCallback(Types.VideoCaptureOverlayState arg0, IntPtr arg1);

		[DllImport("gpg")]
		internal static extern void CaptureOverlayStateListenerHelper_SetOnCaptureOverlayStateChangedCallback(HandleRef self, OnCaptureOverlayStateChangedCallback callback, IntPtr callback_arg);

		[DllImport("gpg")]
		internal static extern IntPtr CaptureOverlayStateListenerHelper_Construct();

		[DllImport("gpg")]
		internal static extern void CaptureOverlayStateListenerHelper_Dispose(HandleRef self);
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
