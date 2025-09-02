using System;
using System.Runtime.InteropServices;
using GooglePlayGames.BasicApi.Nearby;
using GooglePlayGames.Native.Cwrapper;

namespace GooglePlayGames.Native.PInvoke
{
	internal class NativeConnectionRequest : BaseReferenceHolder
	{
		internal NativeConnectionRequest(IntPtr pointer)
			: base(pointer)
		{
		}

		internal string RemoteEndpointId()
		{
			return PInvokeUtilities.OutParamsToString((byte[] out_arg, UIntPtr out_size) => NearbyConnectionTypes.ConnectionRequest_GetRemoteEndpointId(SelfPtr(), out_arg, out_size));
		}

		internal string RemoteEndpointName()
		{
			return PInvokeUtilities.OutParamsToString((byte[] out_arg, UIntPtr out_size) => NearbyConnectionTypes.ConnectionRequest_GetRemoteEndpointName(SelfPtr(), out_arg, out_size));
		}

		internal byte[] Payload()
		{
			return PInvokeUtilities.OutParamsToArray((byte[] out_arg, UIntPtr out_size) => NearbyConnectionTypes.ConnectionRequest_GetPayload(SelfPtr(), out_arg, out_size));
		}

		protected override void CallDispose(HandleRef selfPointer)
		{
			NearbyConnectionTypes.ConnectionRequest_Dispose(selfPointer);
		}

		internal ConnectionRequest AsRequest()
		{
			return new ConnectionRequest(RemoteEndpointId(), RemoteEndpointName(), NearbyConnectionsManager.ServiceId, Payload());
		}

		internal static NativeConnectionRequest FromPointer(IntPtr pointer)
		{
			if (pointer == IntPtr.Zero)
			{
				return null;
			}
			return new NativeConnectionRequest(pointer);
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
