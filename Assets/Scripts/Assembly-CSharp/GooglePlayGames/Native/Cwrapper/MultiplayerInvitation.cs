using System;
using System.Runtime.InteropServices;

namespace GooglePlayGames.Native.Cwrapper
{
	internal static class MultiplayerInvitation
	{
		[DllImport("gpg")]
		internal static extern uint MultiplayerInvitation_AutomatchingSlotsAvailable(HandleRef self);

		[DllImport("gpg")]
		internal static extern IntPtr MultiplayerInvitation_InvitingParticipant(HandleRef self);

		[DllImport("gpg")]
		internal static extern uint MultiplayerInvitation_Variant(HandleRef self);

		[DllImport("gpg")]
		internal static extern ulong MultiplayerInvitation_CreationTime(HandleRef self);

		[DllImport("gpg")]
		internal static extern UIntPtr MultiplayerInvitation_Participants_Length(HandleRef self);

		[DllImport("gpg")]
		internal static extern IntPtr MultiplayerInvitation_Participants_GetElement(HandleRef self, UIntPtr index);

		[DllImport("gpg")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool MultiplayerInvitation_Valid(HandleRef self);

		[DllImport("gpg")]
		internal static extern Types.MultiplayerInvitationType MultiplayerInvitation_Type(HandleRef self);

		[DllImport("gpg")]
		internal static extern UIntPtr MultiplayerInvitation_Id(HandleRef self, [In][Out] byte[] out_arg, UIntPtr out_size);

		[DllImport("gpg")]
		internal static extern void MultiplayerInvitation_Dispose(HandleRef self);
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
