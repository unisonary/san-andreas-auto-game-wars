using System;
using System.Runtime.InteropServices;
using GooglePlayGames.Native.Cwrapper;

namespace GooglePlayGames.Native.PInvoke
{
	internal class RealtimeRoomConfig : BaseReferenceHolder
	{
		internal RealtimeRoomConfig(IntPtr selfPointer)
			: base(selfPointer)
		{
		}

		protected override void CallDispose(HandleRef selfPointer)
		{
			RealTimeRoomConfig.RealTimeRoomConfig_Dispose(selfPointer);
		}

		internal static RealtimeRoomConfig FromPointer(IntPtr selfPointer)
		{
			if (selfPointer.Equals(IntPtr.Zero))
			{
				return null;
			}
			return new RealtimeRoomConfig(selfPointer);
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
