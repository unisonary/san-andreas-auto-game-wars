using System;

namespace GooglePlayGames.BasicApi.Video
{
	public interface IVideoClient
	{
		void GetCaptureCapabilities(Action<ResponseStatus, VideoCapabilities> callback);

		void ShowCaptureOverlay();

		void GetCaptureState(Action<ResponseStatus, VideoCaptureState> callback);

		void IsCaptureAvailable(VideoCaptureMode captureMode, Action<ResponseStatus, bool> callback);

		bool IsCaptureSupported();

		void RegisterCaptureOverlayStateChangedListener(CaptureOverlayStateListener listener);

		void UnregisterCaptureOverlayStateChangedListener();
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
