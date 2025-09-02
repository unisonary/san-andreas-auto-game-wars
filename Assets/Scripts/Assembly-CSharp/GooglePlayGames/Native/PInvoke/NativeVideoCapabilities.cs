using System;
using System.Runtime.InteropServices;
using GooglePlayGames.Native.Cwrapper;

namespace GooglePlayGames.Native.PInvoke
{
	internal class NativeVideoCapabilities : BaseReferenceHolder
	{
		internal NativeVideoCapabilities(IntPtr selfPtr)
			: base(selfPtr)
		{
		}

		protected override void CallDispose(HandleRef selfPointer)
		{
			VideoCapabilities.VideoCapabilities_Dispose(selfPointer);
		}

		internal bool IsCameraSupported()
		{
			return VideoCapabilities.VideoCapabilities_IsCameraSupported(SelfPtr());
		}

		internal bool IsMicSupported()
		{
			return VideoCapabilities.VideoCapabilities_IsMicSupported(SelfPtr());
		}

		internal bool IsWriteStorageSupported()
		{
			return VideoCapabilities.VideoCapabilities_IsWriteStorageSupported(SelfPtr());
		}

		internal bool SupportsCaptureMode(Types.VideoCaptureMode captureMode)
		{
			return VideoCapabilities.VideoCapabilities_SupportsCaptureMode(SelfPtr(), captureMode);
		}

		internal bool SupportsQualityLevel(Types.VideoQualityLevel qualityLevel)
		{
			return VideoCapabilities.VideoCapabilities_SupportsQualityLevel(SelfPtr(), qualityLevel);
		}

		internal static NativeVideoCapabilities FromPointer(IntPtr pointer)
		{
			if (pointer.Equals(IntPtr.Zero))
			{
				return null;
			}
			return new NativeVideoCapabilities(pointer);
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
