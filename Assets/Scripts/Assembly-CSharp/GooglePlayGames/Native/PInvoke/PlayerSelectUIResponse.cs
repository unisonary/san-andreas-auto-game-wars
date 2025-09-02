using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using GooglePlayGames.Native.Cwrapper;

namespace GooglePlayGames.Native.PInvoke
{
	internal class PlayerSelectUIResponse : BaseReferenceHolder, IEnumerable<string>, IEnumerable
	{
		internal PlayerSelectUIResponse(IntPtr selfPointer)
			: base(selfPointer)
		{
		}

		internal CommonErrorStatus.UIStatus Status()
		{
			return TurnBasedMultiplayerManager.TurnBasedMultiplayerManager_PlayerSelectUIResponse_GetStatus(SelfPtr());
		}

		private string PlayerIdAtIndex(UIntPtr index)
		{
			return PInvokeUtilities.OutParamsToString((byte[] out_string, UIntPtr size) => TurnBasedMultiplayerManager.TurnBasedMultiplayerManager_PlayerSelectUIResponse_GetPlayerIds_GetElement(SelfPtr(), index, out_string, size));
		}

		public IEnumerator<string> GetEnumerator()
		{
			return PInvokeUtilities.ToEnumerator(TurnBasedMultiplayerManager.TurnBasedMultiplayerManager_PlayerSelectUIResponse_GetPlayerIds_Length(SelfPtr()), PlayerIdAtIndex);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		internal uint MinimumAutomatchingPlayers()
		{
			return TurnBasedMultiplayerManager.TurnBasedMultiplayerManager_PlayerSelectUIResponse_GetMinimumAutomatchingPlayers(SelfPtr());
		}

		internal uint MaximumAutomatchingPlayers()
		{
			return TurnBasedMultiplayerManager.TurnBasedMultiplayerManager_PlayerSelectUIResponse_GetMaximumAutomatchingPlayers(SelfPtr());
		}

		protected override void CallDispose(HandleRef selfPointer)
		{
			TurnBasedMultiplayerManager.TurnBasedMultiplayerManager_PlayerSelectUIResponse_Dispose(selfPointer);
		}

		internal static PlayerSelectUIResponse FromPointer(IntPtr pointer)
		{
			if (PInvokeUtilities.IsNull(pointer))
			{
				return null;
			}
			return new PlayerSelectUIResponse(pointer);
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
