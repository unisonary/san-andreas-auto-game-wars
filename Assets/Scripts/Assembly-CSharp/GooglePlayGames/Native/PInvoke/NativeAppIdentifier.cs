using System;
using System.Runtime.InteropServices;
using GooglePlayGames.Native.Cwrapper;

namespace GooglePlayGames.Native.PInvoke
{
	internal class NativeAppIdentifier : BaseReferenceHolder
	{
		[DllImport("gpg")]
		internal static extern IntPtr NearbyUtils_ConstructAppIdentifier(string appId);

		internal NativeAppIdentifier(IntPtr pointer)
			: base(pointer)
		{
		}

		internal string Id()
		{
			return PInvokeUtilities.OutParamsToString((byte[] out_arg, UIntPtr out_size) => NearbyConnectionTypes.AppIdentifier_GetIdentifier(SelfPtr(), out_arg, out_size));
		}

		protected override void CallDispose(HandleRef selfPointer)
		{
			NearbyConnectionTypes.AppIdentifier_Dispose(selfPointer);
		}

		internal static NativeAppIdentifier FromString(string appId)
		{
			return new NativeAppIdentifier(NearbyUtils_ConstructAppIdentifier(appId));
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
