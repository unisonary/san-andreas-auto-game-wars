using System;
using System.Runtime.InteropServices;

namespace GooglePlayGames.Native.Cwrapper
{
	internal static class TurnBasedMatchConfig
	{
		[DllImport("gpg")]
		internal static extern UIntPtr TurnBasedMatchConfig_PlayerIdsToInvite_Length(HandleRef self);

		[DllImport("gpg")]
		internal static extern UIntPtr TurnBasedMatchConfig_PlayerIdsToInvite_GetElement(HandleRef self, UIntPtr index, [In][Out] byte[] out_arg, UIntPtr out_size);

		[DllImport("gpg")]
		internal static extern uint TurnBasedMatchConfig_Variant(HandleRef self);

		[DllImport("gpg")]
		internal static extern long TurnBasedMatchConfig_ExclusiveBitMask(HandleRef self);

		[DllImport("gpg")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool TurnBasedMatchConfig_Valid(HandleRef self);

		[DllImport("gpg")]
		internal static extern uint TurnBasedMatchConfig_MaximumAutomatchingPlayers(HandleRef self);

		[DllImport("gpg")]
		internal static extern uint TurnBasedMatchConfig_MinimumAutomatchingPlayers(HandleRef self);

		[DllImport("gpg")]
		internal static extern void TurnBasedMatchConfig_Dispose(HandleRef self);
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
