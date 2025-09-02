using System;
using System.Runtime.InteropServices;

namespace GooglePlayGames.Native.Cwrapper
{
	internal static class ScoreSummary
	{
		[DllImport("gpg")]
		internal static extern ulong ScoreSummary_ApproximateNumberOfScores(HandleRef self);

		[DllImport("gpg")]
		internal static extern Types.LeaderboardTimeSpan ScoreSummary_TimeSpan(HandleRef self);

		[DllImport("gpg")]
		internal static extern UIntPtr ScoreSummary_LeaderboardId(HandleRef self, [In][Out] char[] out_arg, UIntPtr out_size);

		[DllImport("gpg")]
		internal static extern Types.LeaderboardCollection ScoreSummary_Collection(HandleRef self);

		[DllImport("gpg")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool ScoreSummary_Valid(HandleRef self);

		[DllImport("gpg")]
		internal static extern IntPtr ScoreSummary_CurrentPlayerScore(HandleRef self);

		[DllImport("gpg")]
		internal static extern void ScoreSummary_Dispose(HandleRef self);
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
