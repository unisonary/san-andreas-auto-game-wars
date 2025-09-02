using System;
using System.Runtime.InteropServices;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.Nearby;
using GooglePlayGames.Native.Cwrapper;

namespace GooglePlayGames.Native.PInvoke
{
	internal class NativeStartAdvertisingResult : BaseReferenceHolder
	{
		internal NativeStartAdvertisingResult(IntPtr pointer)
			: base(pointer)
		{
		}

		internal int GetStatus()
		{
			return NearbyConnectionTypes.StartAdvertisingResult_GetStatus(SelfPtr());
		}

		internal string LocalEndpointName()
		{
			return PInvokeUtilities.OutParamsToString((byte[] out_arg, UIntPtr out_size) => NearbyConnectionTypes.StartAdvertisingResult_GetLocalEndpointName(SelfPtr(), out_arg, out_size));
		}

		protected override void CallDispose(HandleRef selfPointer)
		{
			NearbyConnectionTypes.StartAdvertisingResult_Dispose(selfPointer);
		}

		internal AdvertisingResult AsResult()
		{
			return new AdvertisingResult((ResponseStatus)Enum.ToObject(typeof(ResponseStatus), GetStatus()), LocalEndpointName());
		}

		internal static NativeStartAdvertisingResult FromPointer(IntPtr pointer)
		{
			if (pointer == IntPtr.Zero)
			{
				return null;
			}
			return new NativeStartAdvertisingResult(pointer);
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
