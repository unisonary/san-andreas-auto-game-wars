using System;
using System.Runtime.InteropServices;
using GooglePlayGames.Native.Cwrapper;

namespace GooglePlayGames.Native.PInvoke
{
	internal class NativeScoreEntry : BaseReferenceHolder
	{
		private const ulong MinusOne = ulong.MaxValue;

		internal NativeScoreEntry(IntPtr selfPtr)
			: base(selfPtr)
		{
		}

		protected override void CallDispose(HandleRef selfPointer)
		{
			ScorePage.ScorePage_Entry_Dispose(selfPointer);
		}

		internal ulong GetLastModifiedTime()
		{
			return ScorePage.ScorePage_Entry_LastModifiedTime(SelfPtr());
		}

		internal string GetPlayerId()
		{
			return PInvokeUtilities.OutParamsToString((byte[] out_string, UIntPtr out_size) => ScorePage.ScorePage_Entry_PlayerId(SelfPtr(), out_string, out_size));
		}

		internal NativeScore GetScore()
		{
			return new NativeScore(ScorePage.ScorePage_Entry_Score(SelfPtr()));
		}

		internal PlayGamesScore AsScore(string leaderboardId)
		{
			DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
			ulong num = GetLastModifiedTime();
			if (num == ulong.MaxValue)
			{
				num = 0uL;
			}
			return new PlayGamesScore(dateTime.AddMilliseconds(num), leaderboardId, GetScore().GetRank(), GetPlayerId(), GetScore().GetValue(), GetScore().GetMetadata());
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
