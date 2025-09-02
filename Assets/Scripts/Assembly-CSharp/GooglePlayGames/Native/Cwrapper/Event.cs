using System;
using System.Runtime.InteropServices;

namespace GooglePlayGames.Native.Cwrapper
{
	internal static class Event
	{
		[DllImport("gpg")]
		internal static extern ulong Event_Count(HandleRef self);

		[DllImport("gpg")]
		internal static extern UIntPtr Event_Description(HandleRef self, [In][Out] byte[] out_arg, UIntPtr out_size);

		[DllImport("gpg")]
		internal static extern UIntPtr Event_ImageUrl(HandleRef self, [In][Out] byte[] out_arg, UIntPtr out_size);

		[DllImport("gpg")]
		internal static extern Types.EventVisibility Event_Visibility(HandleRef self);

		[DllImport("gpg")]
		internal static extern UIntPtr Event_Id(HandleRef self, [In][Out] byte[] out_arg, UIntPtr out_size);

		[DllImport("gpg")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool Event_Valid(HandleRef self);

		[DllImport("gpg")]
		internal static extern void Event_Dispose(HandleRef self);

		[DllImport("gpg")]
		internal static extern IntPtr Event_Copy(HandleRef self);

		[DllImport("gpg")]
		internal static extern UIntPtr Event_Name(HandleRef self, [In][Out] byte[] out_arg, UIntPtr out_size);
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
