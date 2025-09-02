using System;
using System.Runtime.InteropServices;

namespace GooglePlayGames.Native.Cwrapper
{
	internal static class RealTimeRoomConfigBuilder
	{
		[DllImport("gpg")]
		internal static extern void RealTimeRoomConfig_Builder_PopulateFromPlayerSelectUIResponse(HandleRef self, IntPtr response);

		[DllImport("gpg")]
		internal static extern void RealTimeRoomConfig_Builder_SetVariant(HandleRef self, uint variant);

		[DllImport("gpg")]
		internal static extern void RealTimeRoomConfig_Builder_AddPlayerToInvite(HandleRef self, string player_id);

		[DllImport("gpg")]
		internal static extern IntPtr RealTimeRoomConfig_Builder_Construct();

		[DllImport("gpg")]
		internal static extern void RealTimeRoomConfig_Builder_SetExclusiveBitMask(HandleRef self, ulong exclusive_bit_mask);

		[DllImport("gpg")]
		internal static extern void RealTimeRoomConfig_Builder_SetMaximumAutomatchingPlayers(HandleRef self, uint maximum_automatching_players);

		[DllImport("gpg")]
		internal static extern IntPtr RealTimeRoomConfig_Builder_Create(HandleRef self);

		[DllImport("gpg")]
		internal static extern void RealTimeRoomConfig_Builder_SetMinimumAutomatchingPlayers(HandleRef self, uint minimum_automatching_players);

		[DllImport("gpg")]
		internal static extern void RealTimeRoomConfig_Builder_Dispose(HandleRef self);
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
