using System;
using System.Runtime.InteropServices;

namespace GooglePlayGames.Native.Cwrapper
{
	internal static class ScorePage
	{
		[DllImport("gpg")]
		internal static extern void ScorePage_Dispose(HandleRef self);

		[DllImport("gpg")]
		internal static extern Types.LeaderboardTimeSpan ScorePage_TimeSpan(HandleRef self);

		[DllImport("gpg")]
		internal static extern UIntPtr ScorePage_LeaderboardId(HandleRef self, [In][Out] byte[] out_arg, UIntPtr out_size);

		[DllImport("gpg")]
		internal static extern Types.LeaderboardCollection ScorePage_Collection(HandleRef self);

		[DllImport("gpg")]
		internal static extern Types.LeaderboardStart ScorePage_Start(HandleRef self);

		[DllImport("gpg")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool ScorePage_Valid(HandleRef self);

		[DllImport("gpg")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool ScorePage_HasPreviousScorePage(HandleRef self);

		[DllImport("gpg")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool ScorePage_HasNextScorePage(HandleRef self);

		[DllImport("gpg")]
		internal static extern IntPtr ScorePage_PreviousScorePageToken(HandleRef self);

		[DllImport("gpg")]
		internal static extern IntPtr ScorePage_NextScorePageToken(HandleRef self);

		[DllImport("gpg")]
		internal static extern UIntPtr ScorePage_Entries_Length(HandleRef self);

		[DllImport("gpg")]
		internal static extern IntPtr ScorePage_Entries_GetElement(HandleRef self, UIntPtr index);

		[DllImport("gpg")]
		internal static extern void ScorePage_Entry_Dispose(HandleRef self);

		[DllImport("gpg")]
		internal static extern UIntPtr ScorePage_Entry_PlayerId(HandleRef self, [In][Out] byte[] out_arg, UIntPtr out_size);

		[DllImport("gpg")]
		internal static extern ulong ScorePage_Entry_LastModified(HandleRef self);

		[DllImport("gpg")]
		internal static extern IntPtr ScorePage_Entry_Score(HandleRef self);

		[DllImport("gpg")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool ScorePage_Entry_Valid(HandleRef self);

		[DllImport("gpg")]
		internal static extern ulong ScorePage_Entry_LastModifiedTime(HandleRef self);

		[DllImport("gpg")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool ScorePage_ScorePageToken_Valid(HandleRef self);

		[DllImport("gpg")]
		internal static extern void ScorePage_ScorePageToken_Dispose(HandleRef self);
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
