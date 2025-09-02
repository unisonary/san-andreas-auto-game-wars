using System;
using System.Runtime.InteropServices;
using GooglePlayGames.Native.Cwrapper;

namespace GooglePlayGames.Native.PInvoke
{
	internal class NativeLeaderboard : BaseReferenceHolder
	{
		internal NativeLeaderboard(IntPtr selfPtr)
			: base(selfPtr)
		{
		}

		protected override void CallDispose(HandleRef selfPointer)
		{
			Leaderboard.Leaderboard_Dispose(selfPointer);
		}

		internal string Title()
		{
			return PInvokeUtilities.OutParamsToString((byte[] out_string, UIntPtr out_size) => Leaderboard.Leaderboard_Name(SelfPtr(), out_string, out_size));
		}

		internal static NativeLeaderboard FromPointer(IntPtr pointer)
		{
			if (pointer.Equals(IntPtr.Zero))
			{
				return null;
			}
			return new NativeLeaderboard(pointer);
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
