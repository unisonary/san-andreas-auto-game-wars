using System;
using System.Runtime.InteropServices;
using GooglePlayGames.Native.Cwrapper;

namespace GooglePlayGames.Native.PInvoke
{
	internal class NativeScore : BaseReferenceHolder
	{
		private const ulong MinusOne = ulong.MaxValue;

		internal NativeScore(IntPtr selfPtr)
			: base(selfPtr)
		{
		}

		protected override void CallDispose(HandleRef selfPointer)
		{
			Score.Score_Dispose(SelfPtr());
		}

		internal ulong GetDate()
		{
			return ulong.MaxValue;
		}

		internal string GetMetadata()
		{
			return PInvokeUtilities.OutParamsToString((byte[] out_string, UIntPtr out_size) => Score.Score_Metadata(SelfPtr(), out_string, out_size));
		}

		internal ulong GetRank()
		{
			return Score.Score_Rank(SelfPtr());
		}

		internal ulong GetValue()
		{
			return Score.Score_Value(SelfPtr());
		}

		internal PlayGamesScore AsScore(string leaderboardId, string selfPlayerId)
		{
			DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
			ulong num = GetDate();
			if (num == ulong.MaxValue)
			{
				num = 0uL;
			}
			return new PlayGamesScore(dateTime.AddMilliseconds(num), leaderboardId, GetRank(), selfPlayerId, GetValue(), GetMetadata());
		}

		internal static NativeScore FromPointer(IntPtr pointer)
		{
			if (pointer.Equals(IntPtr.Zero))
			{
				return null;
			}
			return new NativeScore(pointer);
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
