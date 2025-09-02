using System;
using System.Collections.Generic;
using OneSignalPush.MiniJSON;
using UnityEngine;

public class OneSignal : MonoBehaviour
{
	public delegate void NotificationReceived(OSNotification notification);

	public delegate void OnSetEmailSuccess();

	public delegate void OnSetEmailFailure(Dictionary<string, object> error);

	public delegate void OnLogoutEmailSuccess();

	public delegate void OnLogoutEmailFailure(Dictionary<string, object> error);

	public delegate void NotificationOpened(OSNotificationOpenedResult result);

	public delegate void IdsAvailableCallback(string playerID, string pushToken);

	public delegate void TagsReceived(Dictionary<string, object> tags);

	public delegate void PromptForPushNotificationsUserResponse(bool accepted);

	public delegate void OnPostNotificationSuccess(Dictionary<string, object> response);

	public delegate void OnPostNotificationFailure(Dictionary<string, object> response);

	public delegate void PermissionObservable(OSPermissionStateChanges stateChanges);

	public delegate void SubscriptionObservable(OSSubscriptionStateChanges stateChanges);

	public delegate void EmailSubscriptionObservable(OSEmailSubscriptionStateChanges stateChanges);

	public enum LOG_LEVEL
	{
		NONE = 0,
		FATAL = 1,
		ERROR = 2,
		WARN = 3,
		INFO = 4,
		DEBUG = 5,
		VERBOSE = 6
	}

	public enum OSInFocusDisplayOption
	{
		None = 0,
		InAppAlert = 1,
		Notification = 2
	}

	public class UnityBuilder
	{
		public string appID;

		public string googleProjectNumber;

		public Dictionary<string, bool> iOSSettings;

		public NotificationReceived notificationReceivedDelegate;

		public NotificationOpened notificationOpenedDelegate;

		public UnityBuilder HandleNotificationReceived(NotificationReceived inNotificationReceivedDelegate)
		{
			notificationReceivedDelegate = inNotificationReceivedDelegate;
			return this;
		}

		public UnityBuilder HandleNotificationOpened(NotificationOpened inNotificationOpenedDelegate)
		{
			notificationOpenedDelegate = inNotificationOpenedDelegate;
			return this;
		}

		public UnityBuilder InFocusDisplaying(OSInFocusDisplayOption display)
		{
			inFocusDisplayType = display;
			return this;
		}

		public UnityBuilder Settings(Dictionary<string, bool> settings)
		{
			return this;
		}

		public void EndInit()
		{
			Init();
		}

		public UnityBuilder SetRequiresUserPrivacyConsent(bool required)
		{
			requiresUserConsent = true;
			return this;
		}
	}

	public static IdsAvailableCallback idsAvailableDelegate = null;

	public static TagsReceived tagsReceivedDelegate = null;

	private static PromptForPushNotificationsUserResponse notificationUserResponseDelegate;

	private static PermissionObservable internalPermissionObserver;

	private static bool addedPermissionObserver;

	private static SubscriptionObservable internalSubscriptionObserver;

	private static bool addedSubscriptionObserver;

	private static EmailSubscriptionObservable internalEmailSubscriptionObserver;

	private static bool addedEmailSubscriptionObserver;

	public const string kOSSettingsAutoPrompt = "kOSSettingsAutoPrompt";

	public const string kOSSettingsInAppLaunchURL = "kOSSettingsInAppLaunchURL";

	internal static UnityBuilder builder = null;

	private static OneSignalPlatform oneSignalPlatform = null;

	private const string gameObjectName = "OneSignalRuntimeObject_KEEP";

	private static LOG_LEVEL logLevel = LOG_LEVEL.INFO;

	private static LOG_LEVEL visualLogLevel = LOG_LEVEL.NONE;

	internal static bool requiresUserConsent = false;

	internal static OnPostNotificationSuccess postNotificationSuccessDelegate = null;

	internal static OnPostNotificationFailure postNotificationFailureDelegate = null;

	internal static OnSetEmailSuccess setEmailSuccessDelegate = null;

	internal static OnSetEmailFailure setEmailFailureDelegate = null;

	internal static OnLogoutEmailSuccess logoutEmailSuccessDelegate = null;

	internal static OnLogoutEmailFailure logoutEmailFailureDelegate = null;

	private static OSInFocusDisplayOption _inFocusDisplayType = OSInFocusDisplayOption.InAppAlert;

	public static OSInFocusDisplayOption inFocusDisplayType
	{
		get
		{
			return _inFocusDisplayType;
		}
		set
		{
			_inFocusDisplayType = value;
			if (oneSignalPlatform != null)
			{
				oneSignalPlatform.SetInFocusDisplaying(_inFocusDisplayType);
			}
		}
	}

	public static event PermissionObservable permissionObserver
	{
		add
		{
			if (oneSignalPlatform != null)
			{
				internalPermissionObserver = (PermissionObservable)Delegate.Combine(internalPermissionObserver, value);
				addPermissionObserver();
			}
		}
		remove
		{
			if (oneSignalPlatform != null)
			{
				internalPermissionObserver = (PermissionObservable)Delegate.Remove(internalPermissionObserver, value);
				if (addedPermissionObserver && internalPermissionObserver.GetInvocationList().Length == 0)
				{
					addedPermissionObserver = false;
					oneSignalPlatform.removePermissionObserver();
				}
			}
		}
	}

	public static event SubscriptionObservable subscriptionObserver
	{
		add
		{
			if (oneSignalPlatform != null)
			{
				internalSubscriptionObserver = (SubscriptionObservable)Delegate.Combine(internalSubscriptionObserver, value);
				addSubscriptionObserver();
			}
		}
		remove
		{
			if (oneSignalPlatform != null)
			{
				internalSubscriptionObserver = (SubscriptionObservable)Delegate.Remove(internalSubscriptionObserver, value);
				if (addedSubscriptionObserver && internalSubscriptionObserver.GetInvocationList().Length == 0)
				{
					oneSignalPlatform.removeSubscriptionObserver();
				}
			}
		}
	}

	public static event EmailSubscriptionObservable emailSubscriptionObserver
	{
		add
		{
			if (oneSignalPlatform != null)
			{
				internalEmailSubscriptionObserver = (EmailSubscriptionObservable)Delegate.Combine(internalEmailSubscriptionObserver, value);
				addEmailSubscriptionObserver();
			}
		}
		remove
		{
			if (oneSignalPlatform != null)
			{
				internalEmailSubscriptionObserver = (EmailSubscriptionObservable)Delegate.Remove(internalEmailSubscriptionObserver, value);
				if (addedEmailSubscriptionObserver && internalEmailSubscriptionObserver.GetInvocationList().Length == 0)
				{
					oneSignalPlatform.removeEmailSubscriptionObserver();
				}
			}
		}
	}

	private static void addPermissionObserver()
	{
		if (!addedPermissionObserver && internalPermissionObserver != null && internalPermissionObserver.GetInvocationList().Length != 0)
		{
			addedPermissionObserver = true;
			oneSignalPlatform.addPermissionObserver();
		}
	}

	private static void addSubscriptionObserver()
	{
		if (!addedSubscriptionObserver && internalSubscriptionObserver != null && internalSubscriptionObserver.GetInvocationList().Length != 0)
		{
			addedSubscriptionObserver = true;
			oneSignalPlatform.addSubscriptionObserver();
		}
	}

	private static void addEmailSubscriptionObserver()
	{
		if (!addedEmailSubscriptionObserver && internalEmailSubscriptionObserver != null && internalEmailSubscriptionObserver.GetInvocationList().Length != 0)
		{
			addedEmailSubscriptionObserver = true;
			oneSignalPlatform.addEmailSubscriptionObserver();
		}
	}

	public static UnityBuilder StartInit(string appID, string googleProjectNumber = null)
	{
		if (builder == null)
		{
			builder = new UnityBuilder();
		}
		builder.appID = appID;
		builder.googleProjectNumber = googleProjectNumber;
		return builder;
	}

	private static void Init()
	{
		initOneSignalPlatform();
	}

	private static void initOneSignalPlatform()
	{
		if (oneSignalPlatform == null && builder != null)
		{
			initAndroid();
			GameObject obj = new GameObject("OneSignalRuntimeObject_KEEP");
			obj.AddComponent<OneSignal>();
			UnityEngine.Object.DontDestroyOnLoad(obj);
			addPermissionObserver();
			addSubscriptionObserver();
		}
	}

	private static void initAndroid()
	{
		oneSignalPlatform = new OneSignalAndroid("OneSignalRuntimeObject_KEEP", builder.googleProjectNumber, builder.appID, inFocusDisplayType, logLevel, visualLogLevel, requiresUserConsent);
	}

	private static void initUnityEditor()
	{
		MonoBehaviour.print("Please run OneSignal on a device to see push notifications.");
	}

	public static void SetLogLevel(LOG_LEVEL inLogLevel, LOG_LEVEL inVisualLevel)
	{
		logLevel = inLogLevel;
		visualLogLevel = inVisualLevel;
	}

	public static void SetLocationShared(bool shared)
	{
		Debug.Log("Called OneSignal.cs SetLocationShared");
		oneSignalPlatform.SetLocationShared(shared);
	}

	public static void SendTag(string tagName, string tagValue)
	{
		oneSignalPlatform.SendTag(tagName, tagValue);
	}

	public static void SendTags(Dictionary<string, string> tags)
	{
		oneSignalPlatform.SendTags(tags);
	}

	public static void GetTags(TagsReceived inTagsReceivedDelegate)
	{
		tagsReceivedDelegate = inTagsReceivedDelegate;
		oneSignalPlatform.GetTags();
	}

	public static void GetTags()
	{
		oneSignalPlatform.GetTags();
	}

	public static void DeleteTag(string key)
	{
		oneSignalPlatform.DeleteTag(key);
	}

	public static void DeleteTags(IList<string> keys)
	{
		oneSignalPlatform.DeleteTags(keys);
	}

	public static void RegisterForPushNotifications()
	{
		oneSignalPlatform.RegisterForPushNotifications();
	}

	public static void PromptForPushNotificationsWithUserResponse(PromptForPushNotificationsUserResponse inDelegate)
	{
		notificationUserResponseDelegate = inDelegate;
		oneSignalPlatform.promptForPushNotificationsWithUserResponse();
	}

	public static void IdsAvailable(IdsAvailableCallback inIdsAvailableDelegate)
	{
		idsAvailableDelegate = inIdsAvailableDelegate;
		oneSignalPlatform.IdsAvailable();
	}

	public static void IdsAvailable()
	{
		oneSignalPlatform.IdsAvailable();
	}

	public static void EnableVibrate(bool enable)
	{
		((OneSignalAndroid)oneSignalPlatform).EnableVibrate(enable);
	}

	public static void EnableSound(bool enable)
	{
		((OneSignalAndroid)oneSignalPlatform).EnableSound(enable);
	}

	public static void ClearOneSignalNotifications()
	{
		((OneSignalAndroid)oneSignalPlatform).ClearOneSignalNotifications();
	}

	public static void SetSubscription(bool enable)
	{
		oneSignalPlatform.SetSubscription(enable);
	}

	public static void PostNotification(Dictionary<string, object> data)
	{
		PostNotification(data, null, null);
	}

	public static void SetEmail(string email, OnSetEmailSuccess successDelegate, OnSetEmailFailure failureDelegate)
	{
		setEmailSuccessDelegate = successDelegate;
		setEmailFailureDelegate = failureDelegate;
		oneSignalPlatform.SetEmail(email);
	}

	public static void SetEmail(string email, string emailAuthToken, OnSetEmailSuccess successDelegate, OnSetEmailFailure failureDelegate)
	{
		setEmailSuccessDelegate = successDelegate;
		setEmailFailureDelegate = failureDelegate;
		oneSignalPlatform.SetEmail(email, emailAuthToken);
	}

	public static void LogoutEmail(OnLogoutEmailSuccess successDelegate, OnLogoutEmailFailure failureDelegate)
	{
		logoutEmailSuccessDelegate = successDelegate;
		logoutEmailFailureDelegate = failureDelegate;
		oneSignalPlatform.LogoutEmail();
	}

	public static void SetEmail(string email)
	{
		oneSignalPlatform.SetEmail(email);
	}

	public static void SetEmail(string email, string emailAuthToken)
	{
		oneSignalPlatform.SetEmail(email, emailAuthToken);
	}

	public static void LogoutEmail()
	{
		oneSignalPlatform.LogoutEmail();
	}

	public static void PostNotification(Dictionary<string, object> data, OnPostNotificationSuccess inOnPostNotificationSuccess, OnPostNotificationFailure inOnPostNotificationFailure)
	{
		postNotificationSuccessDelegate = inOnPostNotificationSuccess;
		postNotificationFailureDelegate = inOnPostNotificationFailure;
		oneSignalPlatform.PostNotification(data);
	}

	public static void SyncHashedEmail(string email)
	{
		oneSignalPlatform.SyncHashedEmail(email);
	}

	public static void PromptLocation()
	{
		oneSignalPlatform.PromptLocation();
	}

	public static OSPermissionSubscriptionState GetPermissionSubscriptionState()
	{
		return oneSignalPlatform.getPermissionSubscriptionState();
	}

	public static void UserDidProvideConsent(bool consent)
	{
		oneSignalPlatform.UserDidProvideConsent(consent);
	}

	public static bool UserProvidedConsent()
	{
		return oneSignalPlatform.UserProvidedConsent();
	}

	public static void SetRequiresUserPrivacyConsent(bool required)
	{
		requiresUserConsent = required;
	}

	public static void SetExternalUserId(string externalId)
	{
		oneSignalPlatform.SetExternalUserId(externalId);
	}

	public static void RemoveExternalUserId()
	{
		oneSignalPlatform.RemoveExternalUserId();
	}

	private OSNotification DictionaryToNotification(Dictionary<string, object> jsonObject)
	{
		OSNotification oSNotification = new OSNotification();
		OSNotificationPayload oSNotificationPayload = new OSNotificationPayload();
		Dictionary<string, object> dictionary = jsonObject["payload"] as Dictionary<string, object>;
		if (dictionary.ContainsKey("notificationID"))
		{
			oSNotificationPayload.notificationID = dictionary["notificationID"] as string;
		}
		if (dictionary.ContainsKey("sound"))
		{
			oSNotificationPayload.sound = dictionary["sound"] as string;
		}
		if (dictionary.ContainsKey("title"))
		{
			oSNotificationPayload.title = dictionary["title"] as string;
		}
		if (dictionary.ContainsKey("body"))
		{
			oSNotificationPayload.body = dictionary["body"] as string;
		}
		if (dictionary.ContainsKey("subtitle"))
		{
			oSNotificationPayload.subtitle = dictionary["subtitle"] as string;
		}
		if (dictionary.ContainsKey("launchURL"))
		{
			oSNotificationPayload.launchURL = dictionary["launchURL"] as string;
		}
		if (dictionary.ContainsKey("additionalData"))
		{
			if (dictionary["additionalData"] is string)
			{
				oSNotificationPayload.additionalData = Json.Deserialize(dictionary["additionalData"] as string) as Dictionary<string, object>;
			}
			else
			{
				oSNotificationPayload.additionalData = dictionary["additionalData"] as Dictionary<string, object>;
			}
		}
		if (dictionary.ContainsKey("actionButtons"))
		{
			if (dictionary["actionButtons"] is string)
			{
				oSNotificationPayload.actionButtons = Json.Deserialize(dictionary["actionButtons"] as string) as Dictionary<string, object>;
			}
			else
			{
				oSNotificationPayload.actionButtons = dictionary["actionButtons"] as Dictionary<string, object>;
			}
		}
		if (dictionary.ContainsKey("contentAvailable"))
		{
			oSNotificationPayload.contentAvailable = (bool)dictionary["contentAvailable"];
		}
		if (dictionary.ContainsKey("badge"))
		{
			oSNotificationPayload.badge = Convert.ToInt32(dictionary["badge"]);
		}
		if (dictionary.ContainsKey("smallIcon"))
		{
			oSNotificationPayload.smallIcon = dictionary["smallIcon"] as string;
		}
		if (dictionary.ContainsKey("largeIcon"))
		{
			oSNotificationPayload.largeIcon = dictionary["largeIcon"] as string;
		}
		if (dictionary.ContainsKey("bigPicture"))
		{
			oSNotificationPayload.bigPicture = dictionary["bigPicture"] as string;
		}
		if (dictionary.ContainsKey("smallIconAccentColor"))
		{
			oSNotificationPayload.smallIconAccentColor = dictionary["smallIconAccentColor"] as string;
		}
		if (dictionary.ContainsKey("ledColor"))
		{
			oSNotificationPayload.ledColor = dictionary["ledColor"] as string;
		}
		if (dictionary.ContainsKey("lockScreenVisibility"))
		{
			oSNotificationPayload.lockScreenVisibility = Convert.ToInt32(dictionary["lockScreenVisibility"]);
		}
		if (dictionary.ContainsKey("groupKey"))
		{
			oSNotificationPayload.groupKey = dictionary["groupKey"] as string;
		}
		if (dictionary.ContainsKey("groupMessage"))
		{
			oSNotificationPayload.groupMessage = dictionary["groupMessage"] as string;
		}
		if (dictionary.ContainsKey("fromProjectNumber"))
		{
			oSNotificationPayload.fromProjectNumber = dictionary["fromProjectNumber"] as string;
		}
		oSNotification.payload = oSNotificationPayload;
		if (jsonObject.ContainsKey("isAppInFocus"))
		{
			oSNotification.isAppInFocus = (bool)jsonObject["isAppInFocus"];
		}
		if (jsonObject.ContainsKey("shown"))
		{
			oSNotification.shown = (bool)jsonObject["shown"];
		}
		if (jsonObject.ContainsKey("silentNotification"))
		{
			oSNotification.silentNotification = (bool)jsonObject["silentNotification"];
		}
		if (jsonObject.ContainsKey("androidNotificationId"))
		{
			oSNotification.androidNotificationId = Convert.ToInt32(jsonObject["androidNotificationId"]);
		}
		if (jsonObject.ContainsKey("displayType"))
		{
			oSNotification.displayType = (OSNotification.DisplayType)Convert.ToInt32(jsonObject["displayType"]);
		}
		return oSNotification;
	}

	private void onPushNotificationReceived(string jsonString)
	{
		if (builder.notificationReceivedDelegate != null)
		{
			Dictionary<string, object> jsonObject = Json.Deserialize(jsonString) as Dictionary<string, object>;
			builder.notificationReceivedDelegate(DictionaryToNotification(jsonObject));
		}
	}

	private void onPushNotificationOpened(string jsonString)
	{
		if (builder.notificationOpenedDelegate == null)
		{
			return;
		}
		Dictionary<string, object> dictionary = Json.Deserialize(jsonString) as Dictionary<string, object>;
		OSNotificationAction oSNotificationAction = new OSNotificationAction();
		if (dictionary.ContainsKey("action"))
		{
			Dictionary<string, object> dictionary2 = dictionary["action"] as Dictionary<string, object>;
			if (dictionary2.ContainsKey("actionID"))
			{
				oSNotificationAction.actionID = dictionary2["actionID"] as string;
			}
			if (dictionary2.ContainsKey("type"))
			{
				oSNotificationAction.type = (OSNotificationAction.ActionType)Convert.ToInt32(dictionary2["type"]);
			}
		}
		OSNotificationOpenedResult oSNotificationOpenedResult = new OSNotificationOpenedResult();
		oSNotificationOpenedResult.notification = DictionaryToNotification((Dictionary<string, object>)dictionary["notification"]);
		oSNotificationOpenedResult.action = oSNotificationAction;
		builder.notificationOpenedDelegate(oSNotificationOpenedResult);
	}

	private void onIdsAvailable(string jsonString)
	{
		if (idsAvailableDelegate != null)
		{
			Dictionary<string, object> dictionary = Json.Deserialize(jsonString) as Dictionary<string, object>;
			idsAvailableDelegate((string)dictionary["userId"], (string)dictionary["pushToken"]);
		}
	}

	private void onTagsReceived(string jsonString)
	{
		if (tagsReceivedDelegate != null)
		{
			tagsReceivedDelegate(Json.Deserialize(jsonString) as Dictionary<string, object>);
		}
	}

	private void onPostNotificationSuccess(string response)
	{
		if (postNotificationSuccessDelegate != null)
		{
			OnPostNotificationSuccess obj = postNotificationSuccessDelegate;
			postNotificationFailureDelegate = null;
			postNotificationSuccessDelegate = null;
			obj(Json.Deserialize(response) as Dictionary<string, object>);
		}
	}

	private void onSetEmailSuccess()
	{
		if (setEmailSuccessDelegate != null)
		{
			OnSetEmailSuccess obj = setEmailSuccessDelegate;
			setEmailSuccessDelegate = null;
			setEmailFailureDelegate = null;
			obj();
		}
	}

	private void onSetEmailFailure(string error)
	{
		if (setEmailFailureDelegate != null)
		{
			OnSetEmailFailure obj = setEmailFailureDelegate;
			setEmailFailureDelegate = null;
			setEmailSuccessDelegate = null;
			obj(Json.Deserialize(error) as Dictionary<string, object>);
		}
	}

	private void onLogoutEmailSuccess()
	{
		if (logoutEmailSuccessDelegate != null)
		{
			OnLogoutEmailSuccess obj = logoutEmailSuccessDelegate;
			logoutEmailSuccessDelegate = null;
			logoutEmailFailureDelegate = null;
			obj();
		}
	}

	private void onLogoutEmailFailure(string error)
	{
		if (logoutEmailFailureDelegate != null)
		{
			OnLogoutEmailFailure obj = logoutEmailFailureDelegate;
			logoutEmailFailureDelegate = null;
			logoutEmailSuccessDelegate = null;
			obj(Json.Deserialize(error) as Dictionary<string, object>);
		}
	}

	private void onPostNotificationFailed(string response)
	{
		if (postNotificationFailureDelegate != null)
		{
			OnPostNotificationFailure onPostNotificationFailure = postNotificationFailureDelegate;
			postNotificationFailureDelegate = null;
			postNotificationSuccessDelegate = null;
			onPostNotificationFailure(Json.Deserialize(response) as Dictionary<string, object>);
		}
	}

	private void onOSPermissionChanged(string stateChangesJSONString)
	{
		OSPermissionStateChanges stateChanges = oneSignalPlatform.parseOSPermissionStateChanges(stateChangesJSONString);
		internalPermissionObserver(stateChanges);
	}

	private void onOSSubscriptionChanged(string stateChangesJSONString)
	{
		OSSubscriptionStateChanges stateChanges = oneSignalPlatform.parseOSSubscriptionStateChanges(stateChangesJSONString);
		internalSubscriptionObserver(stateChanges);
	}

	private void onOSEmailSubscriptionChanged(string stateChangesJSONString)
	{
		OSEmailSubscriptionStateChanges stateChanges = oneSignalPlatform.parseOSEmailSubscriptionStateChanges(stateChangesJSONString);
		internalEmailSubscriptionObserver(stateChanges);
	}

	private void onPromptForPushNotificationsWithUserResponse(string accepted)
	{
		notificationUserResponseDelegate(Convert.ToBoolean(accepted));
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
