using System;
using System.Runtime.InteropServices;

namespace GooglePlayGames.Native.Cwrapper
{
	internal static class SnapshotMetadataChangeBuilder
	{
		[DllImport("gpg")]
		internal static extern void SnapshotMetadataChange_Builder_SetDescription(HandleRef self, string description);

		[DllImport("gpg")]
		internal static extern IntPtr SnapshotMetadataChange_Builder_Construct();

		[DllImport("gpg")]
		internal static extern void SnapshotMetadataChange_Builder_SetPlayedTime(HandleRef self, ulong played_time);

		[DllImport("gpg")]
		internal static extern void SnapshotMetadataChange_Builder_SetCoverImageFromPngData(HandleRef self, byte[] png_data, UIntPtr png_data_size);

		[DllImport("gpg")]
		internal static extern IntPtr SnapshotMetadataChange_Builder_Create(HandleRef self);

		[DllImport("gpg")]
		internal static extern void SnapshotMetadataChange_Builder_Dispose(HandleRef self);
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
