using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using GooglePlayGames.Native.Cwrapper;

namespace GooglePlayGames.Native.PInvoke
{
	internal class NativeRealTimeRoom : BaseReferenceHolder
	{
		internal NativeRealTimeRoom(IntPtr selfPointer)
			: base(selfPointer)
		{
		}

		internal string Id()
		{
			return PInvokeUtilities.OutParamsToString((byte[] out_string, UIntPtr size) => RealTimeRoom.RealTimeRoom_Id(SelfPtr(), out_string, size));
		}

		internal IEnumerable<MultiplayerParticipant> Participants()
		{
			return PInvokeUtilities.ToEnumerable(RealTimeRoom.RealTimeRoom_Participants_Length(SelfPtr()), (UIntPtr index) => new MultiplayerParticipant(RealTimeRoom.RealTimeRoom_Participants_GetElement(SelfPtr(), index)));
		}

		internal uint ParticipantCount()
		{
			return RealTimeRoom.RealTimeRoom_Participants_Length(SelfPtr()).ToUInt32();
		}

		internal Types.RealTimeRoomStatus Status()
		{
			return RealTimeRoom.RealTimeRoom_Status(SelfPtr());
		}

		protected override void CallDispose(HandleRef selfPointer)
		{
			RealTimeRoom.RealTimeRoom_Dispose(selfPointer);
		}

		internal static NativeRealTimeRoom FromPointer(IntPtr selfPointer)
		{
			if (selfPointer.Equals(IntPtr.Zero))
			{
				return null;
			}
			return new NativeRealTimeRoom(selfPointer);
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
