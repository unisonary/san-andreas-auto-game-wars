using System;
using System.Runtime.InteropServices;
using GooglePlayGames.Native.Cwrapper;

namespace GooglePlayGames.Native.PInvoke
{
	internal class IsCaptureAvailableResponse : BaseReferenceHolder
	{
		internal IsCaptureAvailableResponse(IntPtr selfPointer)
			: base(selfPointer)
		{
		}

		protected override void CallDispose(HandleRef selfPointer)
		{
			GooglePlayGames.Native.Cwrapper.VideoManager.VideoManager_IsCaptureAvailableResponse_Dispose(selfPointer);
		}

		internal CommonErrorStatus.ResponseStatus GetStatus()
		{
			return GooglePlayGames.Native.Cwrapper.VideoManager.VideoManager_IsCaptureAvailableResponse_GetStatus(SelfPtr());
		}

		internal bool RequestSucceeded()
		{
			return GetStatus() > (CommonErrorStatus.ResponseStatus)0;
		}

		internal bool IsCaptureAvailable()
		{
			return GooglePlayGames.Native.Cwrapper.VideoManager.VideoManager_IsCaptureAvailableResponse_GetIsCaptureAvailable(SelfPtr());
		}

		internal static IsCaptureAvailableResponse FromPointer(IntPtr pointer)
		{
			if (pointer.Equals(IntPtr.Zero))
			{
				return null;
			}
			return new IsCaptureAvailableResponse(pointer);
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
