using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using GooglePlayGames.Native.Cwrapper;

namespace GooglePlayGames.Native.PInvoke
{
	internal class TurnBasedMatchConfig : BaseReferenceHolder
	{
		internal TurnBasedMatchConfig(IntPtr selfPointer)
			: base(selfPointer)
		{
		}

		private string PlayerIdAtIndex(UIntPtr index)
		{
			return PInvokeUtilities.OutParamsToString((byte[] out_string, UIntPtr size) => GooglePlayGames.Native.Cwrapper.TurnBasedMatchConfig.TurnBasedMatchConfig_PlayerIdsToInvite_GetElement(SelfPtr(), index, out_string, size));
		}

		internal IEnumerator<string> PlayerIdsToInvite()
		{
			return PInvokeUtilities.ToEnumerator(GooglePlayGames.Native.Cwrapper.TurnBasedMatchConfig.TurnBasedMatchConfig_PlayerIdsToInvite_Length(SelfPtr()), PlayerIdAtIndex);
		}

		internal uint Variant()
		{
			return GooglePlayGames.Native.Cwrapper.TurnBasedMatchConfig.TurnBasedMatchConfig_Variant(SelfPtr());
		}

		internal long ExclusiveBitMask()
		{
			return GooglePlayGames.Native.Cwrapper.TurnBasedMatchConfig.TurnBasedMatchConfig_ExclusiveBitMask(SelfPtr());
		}

		internal uint MinimumAutomatchingPlayers()
		{
			return GooglePlayGames.Native.Cwrapper.TurnBasedMatchConfig.TurnBasedMatchConfig_MinimumAutomatchingPlayers(SelfPtr());
		}

		internal uint MaximumAutomatchingPlayers()
		{
			return GooglePlayGames.Native.Cwrapper.TurnBasedMatchConfig.TurnBasedMatchConfig_MaximumAutomatchingPlayers(SelfPtr());
		}

		protected override void CallDispose(HandleRef selfPointer)
		{
			GooglePlayGames.Native.Cwrapper.TurnBasedMatchConfig.TurnBasedMatchConfig_Dispose(selfPointer);
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
