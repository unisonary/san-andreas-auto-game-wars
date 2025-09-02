using System;
using System.Runtime.InteropServices;

namespace GooglePlayGames.Native.Cwrapper
{
	internal static class SnapshotMetadata
	{
		[DllImport("gpg")]
		internal static extern void SnapshotMetadata_Dispose(HandleRef self);

		[DllImport("gpg")]
		internal static extern UIntPtr SnapshotMetadata_CoverImageURL(HandleRef self, [In][Out] byte[] out_arg, UIntPtr out_size);

		[DllImport("gpg")]
		internal static extern UIntPtr SnapshotMetadata_Description(HandleRef self, [In][Out] byte[] out_arg, UIntPtr out_size);

		[DllImport("gpg")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool SnapshotMetadata_IsOpen(HandleRef self);

		[DllImport("gpg")]
		internal static extern UIntPtr SnapshotMetadata_FileName(HandleRef self, [In][Out] byte[] out_arg, UIntPtr out_size);

		[DllImport("gpg")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool SnapshotMetadata_Valid(HandleRef self);

		[DllImport("gpg")]
		internal static extern long SnapshotMetadata_PlayedTime(HandleRef self);

		[DllImport("gpg")]
		internal static extern long SnapshotMetadata_LastModifiedTime(HandleRef self);
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
