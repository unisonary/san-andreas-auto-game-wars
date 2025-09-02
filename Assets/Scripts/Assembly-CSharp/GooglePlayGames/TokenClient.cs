using System;

namespace GooglePlayGames
{
	internal interface TokenClient
	{
		string GetEmail();

		string GetAuthCode();

		string GetIdToken();

		void GetAnotherServerAuthCode(bool reAuthenticateIfNeeded, Action<string> callback);

		void Signout();

		void SetRequestAuthCode(bool flag, bool forceRefresh);

		void SetRequestEmail(bool flag);

		void SetRequestIdToken(bool flag);

		void SetWebClientId(string webClientId);

		void SetAccountName(string accountName);

		void AddOauthScopes(params string[] scopes);

		void SetHidePopups(bool flag);

		void FetchTokens(bool silent, Action<int> callback);
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
