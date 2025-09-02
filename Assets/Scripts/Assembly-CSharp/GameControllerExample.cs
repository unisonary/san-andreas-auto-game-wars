using System;
using System.Collections.Generic;
using OneSignalPush.MiniJSON;
using UnityEngine;

public class GameControllerExample : MonoBehaviour
{
	private static string extraMessage;

	public string email = "Email Address";

	public string externalId = "External User ID";

	private static bool requiresUserPrivacyConsent;

	private void Start()
	{
		extraMessage = null;
		OneSignal.SetLogLevel(OneSignal.LOG_LEVEL.VERBOSE, OneSignal.LOG_LEVEL.NONE);
		OneSignal.SetRequiresUserPrivacyConsent(requiresUserPrivacyConsent);
		OneSignal.StartInit("78e8aff3-7ce2-401f-9da0-2d41f287ebaf").HandleNotificationReceived(HandleNotificationReceived).HandleNotificationOpened(HandleNotificationOpened)
			.EndInit();
		OneSignal.inFocusDisplayType = OneSignal.OSInFocusDisplayOption.Notification;
		OneSignal.permissionObserver += OneSignal_permissionObserver;
		OneSignal.subscriptionObserver += OneSignal_subscriptionObserver;
		OneSignal.emailSubscriptionObserver += OneSignal_emailSubscriptionObserver;
		OneSignal.GetPermissionSubscriptionState();
	}

	private void OneSignal_subscriptionObserver(OSSubscriptionStateChanges stateChanges)
	{
		Debug.Log("SUBSCRIPTION stateChanges: " + stateChanges);
		Debug.Log("SUBSCRIPTION stateChanges.to.userId: " + stateChanges.to.userId);
		Debug.Log("SUBSCRIPTION stateChanges.to.subscribed: " + stateChanges.to.subscribed);
	}

	private void OneSignal_permissionObserver(OSPermissionStateChanges stateChanges)
	{
		Debug.Log("PERMISSION stateChanges.from.status: " + stateChanges.from.status);
		Debug.Log("PERMISSION stateChanges.to.status: " + stateChanges.to.status);
	}

	private void OneSignal_emailSubscriptionObserver(OSEmailSubscriptionStateChanges stateChanges)
	{
		Debug.Log("EMAIL stateChanges.from.status: " + stateChanges.from.emailUserId + ", " + stateChanges.from.emailAddress);
		Debug.Log("EMAIL stateChanges.to.status: " + stateChanges.to.emailUserId + ", " + stateChanges.to.emailAddress);
	}

	private static void HandleNotificationReceived(OSNotification notification)
	{
		OSNotificationPayload payload = notification.payload;
		string body = payload.body;
		MonoBehaviour.print("GameControllerExample:HandleNotificationReceived: " + body);
		MonoBehaviour.print("displayType: " + notification.displayType);
		extraMessage = "Notification received with text: " + body;
		Dictionary<string, object> additionalData = payload.additionalData;
		if (additionalData == null)
		{
			Debug.Log("[HandleNotificationReceived] Additional Data == null");
		}
		else
		{
			Debug.Log("[HandleNotificationReceived] message " + body + ", additionalData: " + Json.Serialize(additionalData));
		}
	}

	public static void HandleNotificationOpened(OSNotificationOpenedResult result)
	{
		OSNotificationPayload payload = result.notification.payload;
		string body = payload.body;
		string actionID = result.action.actionID;
		MonoBehaviour.print("GameControllerExample:HandleNotificationOpened: " + body);
		extraMessage = "Notification opened with text: " + body;
		Dictionary<string, object> additionalData = payload.additionalData;
		if (additionalData == null)
		{
			Debug.Log("[HandleNotificationOpened] Additional Data == null");
		}
		else
		{
			Debug.Log("[HandleNotificationOpened] message " + body + ", additionalData: " + Json.Serialize(additionalData));
		}
		if (actionID != null)
		{
			extraMessage = "Pressed ButtonId: " + actionID;
		}
	}

	private void OnGUI()
	{
		GUIStyle gUIStyle = new GUIStyle("button");
		gUIStyle.fontSize = 30;
		GUIStyle gUIStyle2 = new GUIStyle("box");
		gUIStyle2.fontSize = 30;
		new GUIStyle("textField").fontSize = 30;
		float x = 50f;
		float width = (float)Screen.width - 120f;
		float width2 = (float)Screen.width - 20f;
		float num = 120f;
		float num2 = (requiresUserPrivacyConsent ? 980f : 890f);
		float num3 = 200f;
		float num4 = 90f;
		float height = 60f;
		GUI.Box(new Rect(10f, num, width2, num2), "Test Menu", gUIStyle2);
		float num5 = 0f;
		if (GUI.Button(new Rect(x, num3 + num5 * num4, width, height), "SendTags", gUIStyle))
		{
			OneSignal.SendTag("UnityTestKey", "TestValue");
			OneSignal.SendTags(new Dictionary<string, string>
			{
				{ "UnityTestKey2", "value2" },
				{ "UnityTestKey3", "value3" }
			});
		}
		num5 += 1f;
		if (GUI.Button(new Rect(x, num3 + num5 * num4, width, height), "GetIds", gUIStyle))
		{
			OneSignal.IdsAvailable(delegate(string userId, string pushToken)
			{
				extraMessage = "UserID:\n" + userId + "\n\nPushToken:\n" + pushToken;
			});
		}
		num5 += 1f;
		if (GUI.Button(new Rect(x, num3 + num5 * num4, width, height), "TestNotification", gUIStyle))
		{
			extraMessage = "Waiting to get a OneSignal userId. Uncomment OneSignal.SetLogLevel in the Start method if it hangs here to debug the issue.";
			OneSignal.IdsAvailable(delegate(string userId, string pushToken)
			{
				if (pushToken != null)
				{
					Dictionary<string, object> dictionary = new Dictionary<string, object>();
					dictionary["contents"] = new Dictionary<string, string> { { "en", "Test Message" } };
					dictionary["include_player_ids"] = new List<string> { userId };
					dictionary["send_after"] = DateTime.Now.ToUniversalTime().AddSeconds(30.0).ToString("U");
					extraMessage = "Posting test notification now.";
					OneSignal.PostNotification(dictionary, delegate(Dictionary<string, object> responseSuccess)
					{
						extraMessage = "Notification posted successful! Delayed by about 30 secounds to give you time to press the home button to see a notification vs an in-app alert.\n" + Json.Serialize(responseSuccess);
					}, delegate(Dictionary<string, object> responseFailure)
					{
						extraMessage = "Notification failed to post:\n" + Json.Serialize(responseFailure);
					});
				}
				else
				{
					extraMessage = "ERROR: Device is not registered.";
				}
			});
		}
		num5 += 1f;
		email = GUI.TextField(new Rect(x, num3 + num5 * num4, width, height), email, gUIStyle);
		num5 += 1f;
		if (GUI.Button(new Rect(x, num3 + num5 * num4, width, height), "SetEmail", gUIStyle))
		{
			extraMessage = "Setting email to " + email;
			OneSignal.SetEmail(email, delegate
			{
				Debug.Log("Successfully set email");
			}, delegate(Dictionary<string, object> error)
			{
				Debug.Log("Encountered error setting email: " + Json.Serialize(error));
			});
		}
		num5 += 1f;
		if (GUI.Button(new Rect(x, num3 + num5 * num4, width, height), "LogoutEmail", gUIStyle))
		{
			extraMessage = "Logging Out of example@example.com";
			OneSignal.LogoutEmail(delegate
			{
				Debug.Log("Successfully logged out of email");
			}, delegate(Dictionary<string, object> error)
			{
				Debug.Log("Encountered error logging out of email: " + Json.Serialize(error));
			});
		}
		num5 += 1f;
		externalId = GUI.TextField(new Rect(x, num3 + num5 * num4, width, height), externalId, gUIStyle);
		num5 += 1f;
		if (GUI.Button(new Rect(x, num3 + num5 * num4, width, height), "SetExternalId", gUIStyle))
		{
			extraMessage = "Setting External User Id";
			OneSignal.SetExternalUserId(externalId);
		}
		num5 += 1f;
		if (GUI.Button(new Rect(x, num3 + num5 * num4, width, height), "RemoveExternalId", gUIStyle))
		{
			extraMessage = "Removing External User Id";
			OneSignal.RemoveExternalUserId();
		}
		if (requiresUserPrivacyConsent)
		{
			num5 += 1f;
			if (GUI.Button(new Rect(x, num3 + num5 * num4, width, height), OneSignal.UserProvidedConsent() ? "Revoke Privacy Consent" : "Provide Privacy Consent", gUIStyle))
			{
				extraMessage = "Providing user privacy consent";
				OneSignal.UserDidProvideConsent(!OneSignal.UserProvidedConsent());
			}
		}
		if (extraMessage != null)
		{
			gUIStyle2.alignment = TextAnchor.UpperLeft;
			gUIStyle2.wordWrap = true;
			GUI.Box(new Rect(10f, num + num2 + 20f, Screen.width - 20, (float)Screen.height - (num + num2 + 40f)), extraMessage, gUIStyle2);
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
