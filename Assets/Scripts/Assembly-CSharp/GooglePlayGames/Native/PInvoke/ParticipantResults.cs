using System;
using System.Runtime.InteropServices;
using GooglePlayGames.Native.Cwrapper;

namespace GooglePlayGames.Native.PInvoke
{
	internal class ParticipantResults : BaseReferenceHolder
	{
		internal ParticipantResults(IntPtr selfPointer)
			: base(selfPointer)
		{
		}

		internal bool HasResultsForParticipant(string participantId)
		{
			return GooglePlayGames.Native.Cwrapper.ParticipantResults.ParticipantResults_HasResultsForParticipant(SelfPtr(), participantId);
		}

		internal uint PlacingForParticipant(string participantId)
		{
			return GooglePlayGames.Native.Cwrapper.ParticipantResults.ParticipantResults_PlaceForParticipant(SelfPtr(), participantId);
		}

		internal Types.MatchResult ResultsForParticipant(string participantId)
		{
			return GooglePlayGames.Native.Cwrapper.ParticipantResults.ParticipantResults_MatchResultForParticipant(SelfPtr(), participantId);
		}

		internal ParticipantResults WithResult(string participantId, uint placing, Types.MatchResult result)
		{
			return new ParticipantResults(GooglePlayGames.Native.Cwrapper.ParticipantResults.ParticipantResults_WithResult(SelfPtr(), participantId, placing, result));
		}

		protected override void CallDispose(HandleRef selfPointer)
		{
			GooglePlayGames.Native.Cwrapper.ParticipantResults.ParticipantResults_Dispose(selfPointer);
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
