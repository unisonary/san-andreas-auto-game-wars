using System.Collections.Generic;

public interface OneSignalPlatform
{
	void SetLogLevel(OneSignal.LOG_LEVEL logLevel, OneSignal.LOG_LEVEL visualLevel);

	void RegisterForPushNotifications();

	void promptForPushNotificationsWithUserResponse();

	void SendTag(string tagName, string tagValue);

	void SendTags(IDictionary<string, string> tags);

	void GetTags();

	void DeleteTag(string key);

	void DeleteTags(IList<string> keys);

	void IdsAvailable();

	void SetSubscription(bool enable);

	void PostNotification(Dictionary<string, object> data);

	void SyncHashedEmail(string email);

	void PromptLocation();

	void SetLocationShared(bool shared);

	void SetEmail(string email);

	void SetEmail(string email, string emailAuthToken);

	void LogoutEmail();

	void SetInFocusDisplaying(OneSignal.OSInFocusDisplayOption display);

	void UserDidProvideConsent(bool consent);

	bool UserProvidedConsent();

	void SetRequiresUserPrivacyConsent(bool required);

	void SetExternalUserId(string externalId);

	void RemoveExternalUserId();

	void addPermissionObserver();

	void removePermissionObserver();

	void addSubscriptionObserver();

	void removeSubscriptionObserver();

	void addEmailSubscriptionObserver();

	void removeEmailSubscriptionObserver();

	OSPermissionSubscriptionState getPermissionSubscriptionState();

	OSPermissionState parseOSPermissionState(object stateDict);

	OSSubscriptionState parseOSSubscriptionState(object stateDict);

	OSEmailSubscriptionState parseOSEmailSubscriptionState(object stateDict);

	OSPermissionStateChanges parseOSPermissionStateChanges(string stateChangesJSONString);

	OSSubscriptionStateChanges parseOSSubscriptionStateChanges(string stateChangesJSONString);

	OSEmailSubscriptionStateChanges parseOSEmailSubscriptionStateChanges(string stateChangesJSONString);
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
