using System;
using System.Runtime.InteropServices;

namespace GooglePlayGames.Native.Cwrapper
{
	internal static class RealTimeRoom
	{
		[DllImport("gpg")]
		internal static extern Types.RealTimeRoomStatus RealTimeRoom_Status(HandleRef self);

		[DllImport("gpg")]
		internal static extern UIntPtr RealTimeRoom_Description(HandleRef self, [In][Out] char[] out_arg, UIntPtr out_size);

		[DllImport("gpg")]
		internal static extern uint RealTimeRoom_Variant(HandleRef self);

		[DllImport("gpg")]
		internal static extern ulong RealTimeRoom_CreationTime(HandleRef self);

		[DllImport("gpg")]
		internal static extern UIntPtr RealTimeRoom_Participants_Length(HandleRef self);

		[DllImport("gpg")]
		internal static extern IntPtr RealTimeRoom_Participants_GetElement(HandleRef self, UIntPtr index);

		[DllImport("gpg")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool RealTimeRoom_Valid(HandleRef self);

		[DllImport("gpg")]
		internal static extern uint RealTimeRoom_RemainingAutomatchingSlots(HandleRef self);

		[DllImport("gpg")]
		internal static extern ulong RealTimeRoom_AutomatchWaitEstimate(HandleRef self);

		[DllImport("gpg")]
		internal static extern IntPtr RealTimeRoom_CreatingParticipant(HandleRef self);

		[DllImport("gpg")]
		internal static extern UIntPtr RealTimeRoom_Id(HandleRef self, [In][Out] byte[] out_arg, UIntPtr out_size);

		[DllImport("gpg")]
		internal static extern void RealTimeRoom_Dispose(HandleRef self);
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
