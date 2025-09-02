using System;
using System.Runtime.InteropServices;
using GooglePlayGames.BasicApi.Multiplayer;
using GooglePlayGames.Native.Cwrapper;

namespace GooglePlayGames.Native.PInvoke
{
	internal class NativePlayer : BaseReferenceHolder
	{
		internal NativePlayer(IntPtr selfPointer)
			: base(selfPointer)
		{
		}

		internal string Id()
		{
			return PInvokeUtilities.OutParamsToString((byte[] out_string, UIntPtr out_size) => GooglePlayGames.Native.Cwrapper.Player.Player_Id(SelfPtr(), out_string, out_size));
		}

		internal string Name()
		{
			return PInvokeUtilities.OutParamsToString((byte[] out_string, UIntPtr out_size) => GooglePlayGames.Native.Cwrapper.Player.Player_Name(SelfPtr(), out_string, out_size));
		}

		internal string AvatarURL()
		{
			return PInvokeUtilities.OutParamsToString((byte[] out_string, UIntPtr out_size) => GooglePlayGames.Native.Cwrapper.Player.Player_AvatarUrl(SelfPtr(), Types.ImageResolution.ICON, out_string, out_size));
		}

		protected override void CallDispose(HandleRef selfPointer)
		{
			GooglePlayGames.Native.Cwrapper.Player.Player_Dispose(selfPointer);
		}

		internal GooglePlayGames.BasicApi.Multiplayer.Player AsPlayer()
		{
			return new GooglePlayGames.BasicApi.Multiplayer.Player(Name(), Id(), AvatarURL());
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
