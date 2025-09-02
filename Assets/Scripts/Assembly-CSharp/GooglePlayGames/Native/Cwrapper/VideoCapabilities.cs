using System.Runtime.InteropServices;

namespace GooglePlayGames.Native.Cwrapper
{
	internal static class VideoCapabilities
	{
		[DllImport("gpg")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool VideoCapabilities_IsCameraSupported(HandleRef self);

		[DllImport("gpg")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool VideoCapabilities_IsMicSupported(HandleRef self);

		[DllImport("gpg")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool VideoCapabilities_IsWriteStorageSupported(HandleRef self);

		[DllImport("gpg")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool VideoCapabilities_SupportsCaptureMode(HandleRef self, Types.VideoCaptureMode capture_mode);

		[DllImport("gpg")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool VideoCapabilities_SupportsQualityLevel(HandleRef self, Types.VideoQualityLevel quality_level);

		[DllImport("gpg")]
		internal static extern void VideoCapabilities_Dispose(HandleRef self);

		[DllImport("gpg")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool VideoCapabilities_Valid(HandleRef self);
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
