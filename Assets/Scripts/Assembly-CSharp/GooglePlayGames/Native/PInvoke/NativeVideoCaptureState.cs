using System;
using System.Runtime.InteropServices;
using GooglePlayGames.Native.Cwrapper;

namespace GooglePlayGames.Native.PInvoke
{
	internal class NativeVideoCaptureState : BaseReferenceHolder
	{
		internal NativeVideoCaptureState(IntPtr selfPtr)
			: base(selfPtr)
		{
		}

		protected override void CallDispose(HandleRef selfPointer)
		{
			VideoCaptureState.VideoCaptureState_Dispose(selfPointer);
		}

		internal bool IsCapturing()
		{
			return VideoCaptureState.VideoCaptureState_IsCapturing(SelfPtr());
		}

		internal Types.VideoCaptureMode CaptureMode()
		{
			return VideoCaptureState.VideoCaptureState_CaptureMode(SelfPtr());
		}

		internal Types.VideoQualityLevel QualityLevel()
		{
			return VideoCaptureState.VideoCaptureState_QualityLevel(SelfPtr());
		}

		internal bool IsOverlayVisible()
		{
			return VideoCaptureState.VideoCaptureState_IsOverlayVisible(SelfPtr());
		}

		internal bool IsPaused()
		{
			return VideoCaptureState.VideoCaptureState_IsPaused(SelfPtr());
		}

		internal static NativeVideoCaptureState FromPointer(IntPtr pointer)
		{
			if (pointer.Equals(IntPtr.Zero))
			{
				return null;
			}
			return new NativeVideoCaptureState(pointer);
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
