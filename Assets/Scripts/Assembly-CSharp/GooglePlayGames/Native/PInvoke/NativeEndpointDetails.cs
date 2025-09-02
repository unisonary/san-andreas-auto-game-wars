using System;
using System.Runtime.InteropServices;
using GooglePlayGames.BasicApi.Nearby;
using GooglePlayGames.Native.Cwrapper;

namespace GooglePlayGames.Native.PInvoke
{
	internal class NativeEndpointDetails : BaseReferenceHolder
	{
		internal NativeEndpointDetails(IntPtr pointer)
			: base(pointer)
		{
		}

		internal string EndpointId()
		{
			return PInvokeUtilities.OutParamsToString((byte[] out_arg, UIntPtr out_size) => NearbyConnectionTypes.EndpointDetails_GetEndpointId(SelfPtr(), out_arg, out_size));
		}

		internal string Name()
		{
			return PInvokeUtilities.OutParamsToString((byte[] out_arg, UIntPtr out_size) => NearbyConnectionTypes.EndpointDetails_GetName(SelfPtr(), out_arg, out_size));
		}

		internal string ServiceId()
		{
			return PInvokeUtilities.OutParamsToString((byte[] out_arg, UIntPtr out_size) => NearbyConnectionTypes.EndpointDetails_GetServiceId(SelfPtr(), out_arg, out_size));
		}

		protected override void CallDispose(HandleRef selfPointer)
		{
			NearbyConnectionTypes.EndpointDetails_Dispose(selfPointer);
		}

		internal EndpointDetails ToDetails()
		{
			return new EndpointDetails(EndpointId(), Name(), ServiceId());
		}

		internal static NativeEndpointDetails FromPointer(IntPtr pointer)
		{
			if (pointer.Equals(IntPtr.Zero))
			{
				return null;
			}
			return new NativeEndpointDetails(pointer);
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
