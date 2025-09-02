using System;
using System.Runtime.InteropServices;

namespace GooglePlayGames.Native.Cwrapper
{
	internal static class MultiplayerParticipant
	{
		[DllImport("gpg")]
		internal static extern Types.ParticipantStatus MultiplayerParticipant_Status(HandleRef self);

		[DllImport("gpg")]
		internal static extern uint MultiplayerParticipant_MatchRank(HandleRef self);

		[DllImport("gpg")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool MultiplayerParticipant_IsConnectedToRoom(HandleRef self);

		[DllImport("gpg")]
		internal static extern UIntPtr MultiplayerParticipant_DisplayName(HandleRef self, [In][Out] byte[] out_arg, UIntPtr out_size);

		[DllImport("gpg")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool MultiplayerParticipant_HasPlayer(HandleRef self);

		[DllImport("gpg")]
		internal static extern UIntPtr MultiplayerParticipant_AvatarUrl(HandleRef self, Types.ImageResolution resolution, [In][Out] char[] out_arg, UIntPtr out_size);

		[DllImport("gpg")]
		internal static extern Types.MatchResult MultiplayerParticipant_MatchResult(HandleRef self);

		[DllImport("gpg")]
		internal static extern IntPtr MultiplayerParticipant_Player(HandleRef self);

		[DllImport("gpg")]
		internal static extern void MultiplayerParticipant_Dispose(HandleRef self);

		[DllImport("gpg")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool MultiplayerParticipant_Valid(HandleRef self);

		[DllImport("gpg")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool MultiplayerParticipant_HasMatchResult(HandleRef self);

		[DllImport("gpg")]
		internal static extern UIntPtr MultiplayerParticipant_Id(HandleRef self, [In][Out] byte[] out_arg, UIntPtr out_size);
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
