using System;
using System.Runtime.InteropServices;
using AOT;
using GooglePlayGames.Native.Cwrapper;
using GooglePlayGames.OurUtils;

namespace GooglePlayGames.Native.PInvoke
{
	internal sealed class AndroidPlatformConfiguration : PlatformConfiguration
	{
		private delegate void IntentHandlerInternal(IntPtr intent, IntPtr userData);

		private AndroidPlatformConfiguration(IntPtr selfPointer)
			: base(selfPointer)
		{
		}

		internal void SetActivity(IntPtr activity)
		{
			GooglePlayGames.Native.Cwrapper.AndroidPlatformConfiguration.AndroidPlatformConfiguration_SetActivity(SelfPtr(), activity);
		}

		internal void SetOptionalIntentHandlerForUI(Action<IntPtr> intentHandler)
		{
			Misc.CheckNotNull(intentHandler);
			GooglePlayGames.Native.Cwrapper.AndroidPlatformConfiguration.AndroidPlatformConfiguration_SetOptionalIntentHandlerForUI(SelfPtr(), InternalIntentHandler, Callbacks.ToIntPtr(intentHandler));
		}

		internal void SetOptionalViewForPopups(IntPtr view)
		{
			GooglePlayGames.Native.Cwrapper.AndroidPlatformConfiguration.AndroidPlatformConfiguration_SetOptionalViewForPopups(SelfPtr(), view);
		}

		protected override void CallDispose(HandleRef selfPointer)
		{
			GooglePlayGames.Native.Cwrapper.AndroidPlatformConfiguration.AndroidPlatformConfiguration_Dispose(selfPointer);
		}

		[AOT.MonoPInvokeCallback(typeof(IntentHandlerInternal))]
		private static void InternalIntentHandler(IntPtr intent, IntPtr userData)
		{
			Callbacks.PerformInternalCallback("AndroidPlatformConfiguration#InternalIntentHandler", Callbacks.Type.Permanent, intent, userData);
		}

		internal static AndroidPlatformConfiguration Create()
		{
			return new AndroidPlatformConfiguration(GooglePlayGames.Native.Cwrapper.AndroidPlatformConfiguration.AndroidPlatformConfiguration_Construct());
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
