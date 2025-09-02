using System;
using System.Runtime.InteropServices;
using GooglePlayGames.Native.Cwrapper;

namespace GooglePlayGames.Native.PInvoke
{
	internal class RealtimeRoomConfigBuilder : BaseReferenceHolder
	{
		internal RealtimeRoomConfigBuilder(IntPtr selfPointer)
			: base(selfPointer)
		{
		}

		internal RealtimeRoomConfigBuilder PopulateFromUIResponse(PlayerSelectUIResponse response)
		{
			RealTimeRoomConfigBuilder.RealTimeRoomConfig_Builder_PopulateFromPlayerSelectUIResponse(SelfPtr(), response.AsPointer());
			return this;
		}

		internal RealtimeRoomConfigBuilder SetVariant(uint variantValue)
		{
			uint variant = ((variantValue == 0) ? uint.MaxValue : variantValue);
			RealTimeRoomConfigBuilder.RealTimeRoomConfig_Builder_SetVariant(SelfPtr(), variant);
			return this;
		}

		internal RealtimeRoomConfigBuilder AddInvitedPlayer(string playerId)
		{
			RealTimeRoomConfigBuilder.RealTimeRoomConfig_Builder_AddPlayerToInvite(SelfPtr(), playerId);
			return this;
		}

		internal RealtimeRoomConfigBuilder SetExclusiveBitMask(ulong bitmask)
		{
			RealTimeRoomConfigBuilder.RealTimeRoomConfig_Builder_SetExclusiveBitMask(SelfPtr(), bitmask);
			return this;
		}

		internal RealtimeRoomConfigBuilder SetMinimumAutomatchingPlayers(uint minimum)
		{
			RealTimeRoomConfigBuilder.RealTimeRoomConfig_Builder_SetMinimumAutomatchingPlayers(SelfPtr(), minimum);
			return this;
		}

		internal RealtimeRoomConfigBuilder SetMaximumAutomatchingPlayers(uint maximum)
		{
			RealTimeRoomConfigBuilder.RealTimeRoomConfig_Builder_SetMaximumAutomatchingPlayers(SelfPtr(), maximum);
			return this;
		}

		internal RealtimeRoomConfig Build()
		{
			return new RealtimeRoomConfig(RealTimeRoomConfigBuilder.RealTimeRoomConfig_Builder_Create(SelfPtr()));
		}

		protected override void CallDispose(HandleRef selfPointer)
		{
			RealTimeRoomConfigBuilder.RealTimeRoomConfig_Builder_Dispose(selfPointer);
		}

		internal static RealtimeRoomConfigBuilder Create()
		{
			return new RealtimeRoomConfigBuilder(RealTimeRoomConfigBuilder.RealTimeRoomConfig_Builder_Construct());
		}
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
