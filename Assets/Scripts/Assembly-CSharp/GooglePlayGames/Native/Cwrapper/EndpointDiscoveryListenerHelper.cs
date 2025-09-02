using System;
using System.Runtime.InteropServices;

namespace GooglePlayGames.Native.Cwrapper
{
	internal static class EndpointDiscoveryListenerHelper
	{
		internal delegate void OnEndpointFoundCallback(long arg0, IntPtr arg1, IntPtr arg2);

		internal delegate void OnEndpointLostCallback(long arg0, string arg1, IntPtr arg2);

		[DllImport("gpg")]
		internal static extern IntPtr EndpointDiscoveryListenerHelper_Construct();

		[DllImport("gpg")]
		internal static extern void EndpointDiscoveryListenerHelper_SetOnEndpointLostCallback(HandleRef self, OnEndpointLostCallback callback, IntPtr callback_arg);

		[DllImport("gpg")]
		internal static extern void EndpointDiscoveryListenerHelper_SetOnEndpointFoundCallback(HandleRef self, OnEndpointFoundCallback callback, IntPtr callback_arg);

		[DllImport("gpg")]
		internal static extern void EndpointDiscoveryListenerHelper_Dispose(HandleRef self);
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
