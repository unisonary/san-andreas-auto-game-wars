namespace GooglePlayGames.BasicApi.Multiplayer
{
	public interface RealTimeMultiplayerListener
	{
		void OnRoomSetupProgress(float percent);

		void OnRoomConnected(bool success);

		void OnLeftRoom();

		void OnParticipantLeft(Participant participant);

		void OnPeersConnected(string[] participantIds);

		void OnPeersDisconnected(string[] participantIds);

		void OnRealTimeMessageReceived(bool isReliable, string senderId, byte[] data);
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
