using System;
using System.Collections.Generic;

namespace GooglePlayGames.BasicApi.Multiplayer
{
	public interface IRealTimeMultiplayerClient
	{
		void CreateQuickGame(uint minOpponents, uint maxOpponents, uint variant, RealTimeMultiplayerListener listener);

		void CreateQuickGame(uint minOpponents, uint maxOpponents, uint variant, ulong exclusiveBitMask, RealTimeMultiplayerListener listener);

		void CreateWithInvitationScreen(uint minOpponents, uint maxOppponents, uint variant, RealTimeMultiplayerListener listener);

		void ShowWaitingRoomUI();

		void GetAllInvitations(Action<Invitation[]> callback);

		void AcceptFromInbox(RealTimeMultiplayerListener listener);

		void AcceptInvitation(string invitationId, RealTimeMultiplayerListener listener);

		void SendMessageToAll(bool reliable, byte[] data);

		void SendMessageToAll(bool reliable, byte[] data, int offset, int length);

		void SendMessage(bool reliable, string participantId, byte[] data);

		void SendMessage(bool reliable, string participantId, byte[] data, int offset, int length);

		List<Participant> GetConnectedParticipants();

		Participant GetSelf();

		Participant GetParticipant(string participantId);

		Invitation GetInvitation();

		void LeaveRoom();

		bool IsRoomConnected();

		void DeclineInvitation(string invitationId);
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
