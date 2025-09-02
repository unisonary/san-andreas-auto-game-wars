using System;
using System.Runtime.InteropServices;

namespace GooglePlayGames.Native.Cwrapper
{
	internal static class SnapshotMetadataChange
	{
		[DllImport("gpg")]
		internal static extern UIntPtr SnapshotMetadataChange_Description(HandleRef self, [In][Out] char[] out_arg, UIntPtr out_size);

		[DllImport("gpg")]
		internal static extern IntPtr SnapshotMetadataChange_Image(HandleRef self);

		[DllImport("gpg")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool SnapshotMetadataChange_PlayedTimeIsChanged(HandleRef self);

		[DllImport("gpg")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool SnapshotMetadataChange_Valid(HandleRef self);

		[DllImport("gpg")]
		internal static extern ulong SnapshotMetadataChange_PlayedTime(HandleRef self);

		[DllImport("gpg")]
		internal static extern void SnapshotMetadataChange_Dispose(HandleRef self);

		[DllImport("gpg")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool SnapshotMetadataChange_ImageIsChanged(HandleRef self);

		[DllImport("gpg")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool SnapshotMetadataChange_DescriptionIsChanged(HandleRef self);
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
