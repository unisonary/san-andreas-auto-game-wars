using System;
using System.Runtime.InteropServices;

namespace GooglePlayGames.Native.Cwrapper
{
	internal static class MessageListenerHelper
	{
		internal delegate void OnMessageReceivedCallback(long arg0, string arg1, IntPtr arg2, UIntPtr arg3, [MarshalAs(UnmanagedType.I1)] bool arg4, IntPtr arg5);

		internal delegate void OnDisconnectedCallback(long arg0, string arg1, IntPtr arg2);

		[DllImport("gpg")]
		internal static extern void MessageListenerHelper_SetOnMessageReceivedCallback(HandleRef self, OnMessageReceivedCallback callback, IntPtr callback_arg);

		[DllImport("gpg")]
		internal static extern void MessageListenerHelper_SetOnDisconnectedCallback(HandleRef self, OnDisconnectedCallback callback, IntPtr callback_arg);

		[DllImport("gpg")]
		internal static extern IntPtr MessageListenerHelper_Construct();

		[DllImport("gpg")]
		internal static extern void MessageListenerHelper_Dispose(HandleRef self);
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
