using System;
using GooglePlayGames.BasicApi.Events;
using GooglePlayGames.BasicApi.Multiplayer;
using GooglePlayGames.BasicApi.SavedGame;
using GooglePlayGames.BasicApi.Video;
using UnityEngine.SocialPlatforms;

namespace GooglePlayGames.BasicApi
{
	public interface IPlayGamesClient
	{
		void Authenticate(Action<bool, string> callback, bool silent);

		bool IsAuthenticated();

		void SignOut();

		string GetUserId();

		void LoadFriends(Action<bool> callback);

		string GetUserDisplayName();

		string GetIdToken();

		string GetServerAuthCode();

		void GetAnotherServerAuthCode(bool reAuthenticateIfNeeded, Action<string> callback);

		string GetUserEmail();

		string GetUserImageUrl();

		void GetPlayerStats(Action<CommonStatusCodes, PlayerStats> callback);

		void LoadUsers(string[] userIds, Action<IUserProfile[]> callback);

		void LoadAchievements(Action<Achievement[]> callback);

		void UnlockAchievement(string achievementId, Action<bool> successOrFailureCalllback);

		void RevealAchievement(string achievementId, Action<bool> successOrFailureCalllback);

		void IncrementAchievement(string achievementId, int steps, Action<bool> successOrFailureCalllback);

		void SetStepsAtLeast(string achId, int steps, Action<bool> callback);

		void ShowAchievementsUI(Action<UIStatus> callback);

		void ShowLeaderboardUI(string leaderboardId, LeaderboardTimeSpan span, Action<UIStatus> callback);

		void LoadScores(string leaderboardId, LeaderboardStart start, int rowCount, LeaderboardCollection collection, LeaderboardTimeSpan timeSpan, Action<LeaderboardScoreData> callback);

		void LoadMoreScores(ScorePageToken token, int rowCount, Action<LeaderboardScoreData> callback);

		int LeaderboardMaxResults();

		void SubmitScore(string leaderboardId, long score, Action<bool> successOrFailureCalllback);

		void SubmitScore(string leaderboardId, long score, string metadata, Action<bool> successOrFailureCalllback);

		IRealTimeMultiplayerClient GetRtmpClient();

		ITurnBasedMultiplayerClient GetTbmpClient();

		ISavedGameClient GetSavedGameClient();

		IEventsClient GetEventsClient();

		IVideoClient GetVideoClient();

		void RegisterInvitationDelegate(InvitationReceivedDelegate invitationDelegate);

		IUserProfile[] GetFriends();

		IntPtr GetApiClient();

		void SetGravityForPopups(Gravity gravity);
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
