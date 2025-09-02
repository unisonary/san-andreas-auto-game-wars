using System.Runtime.InteropServices;

namespace GooglePlayGames.Native.Cwrapper
{
	internal static class VideoCaptureState
	{
		[DllImport("gpg")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool VideoCaptureState_IsCapturing(HandleRef self);

		[DllImport("gpg")]
		internal static extern Types.VideoCaptureMode VideoCaptureState_CaptureMode(HandleRef self);

		[DllImport("gpg")]
		internal static extern Types.VideoQualityLevel VideoCaptureState_QualityLevel(HandleRef self);

		[DllImport("gpg")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool VideoCaptureState_IsOverlayVisible(HandleRef self);

		[DllImport("gpg")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool VideoCaptureState_IsPaused(HandleRef self);

		[DllImport("gpg")]
		internal static extern void VideoCaptureState_Dispose(HandleRef self);

		[DllImport("gpg")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool VideoCaptureState_Valid(HandleRef self);
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
