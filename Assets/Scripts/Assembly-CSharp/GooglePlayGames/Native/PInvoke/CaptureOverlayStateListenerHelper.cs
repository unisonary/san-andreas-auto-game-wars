using System;
using System.Runtime.InteropServices;
using AOT;
using GooglePlayGames.Native.Cwrapper;
using GooglePlayGames.OurUtils;

namespace GooglePlayGames.Native.PInvoke
{
	internal class CaptureOverlayStateListenerHelper : BaseReferenceHolder
	{
		internal CaptureOverlayStateListenerHelper(IntPtr selfPointer)
			: base(selfPointer)
		{
		}

		protected override void CallDispose(HandleRef selfPointer)
		{
			GooglePlayGames.Native.Cwrapper.CaptureOverlayStateListenerHelper.CaptureOverlayStateListenerHelper_Dispose(selfPointer);
		}

		internal CaptureOverlayStateListenerHelper SetOnCaptureOverlayStateChangedCallback(Action<Types.VideoCaptureOverlayState> callback)
		{
			GooglePlayGames.Native.Cwrapper.CaptureOverlayStateListenerHelper.CaptureOverlayStateListenerHelper_SetOnCaptureOverlayStateChangedCallback(SelfPtr(), InternalOnCaptureOverlayStateChangedCallback, Callbacks.ToIntPtr(callback));
			return this;
		}

		[AOT.MonoPInvokeCallback(typeof(GooglePlayGames.Native.Cwrapper.CaptureOverlayStateListenerHelper.OnCaptureOverlayStateChangedCallback))]
		internal static void InternalOnCaptureOverlayStateChangedCallback(Types.VideoCaptureOverlayState response, IntPtr data)
		{
			Action<Types.VideoCaptureOverlayState> action = Callbacks.IntPtrToPermanentCallback<Action<Types.VideoCaptureOverlayState>>(data);
			try
			{
				action(response);
			}
			catch (Exception ex)
			{
				Logger.e("Error encountered executing InternalOnCaptureOverlayStateChangedCallback. Smothering to avoid passing exception into Native: " + ex);
			}
		}

		internal static CaptureOverlayStateListenerHelper Create()
		{
			return new CaptureOverlayStateListenerHelper(GooglePlayGames.Native.Cwrapper.CaptureOverlayStateListenerHelper.CaptureOverlayStateListenerHelper_Construct());
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
