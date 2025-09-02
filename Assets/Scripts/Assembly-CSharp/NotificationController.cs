using System;
using System.Collections.Generic;
using OneSignalPush.MiniJSON;
using UnityEngine;

public class NotificationController : MonoBehaviour
{
	public enum RewardType
	{
		None = 0,
		Coins = 1,
		DiscountUpgrades = 2,
		DiscountLevels = 3,
		NoAds = 4
	}

	public List<string> LocalNotifications = new List<string>();

	public List<RewardType> RewardTypeList = new List<RewardType>();

	public List<int> RewardCoins = new List<int>();

	public int duration = 48;

	[HideInInspector]
	public string OneSignalAppID;

	[HideInInspector]
	public string GoogleProjectID;

	public static NotificationController instance;

	private int NotificationIndex;

	private static string keyy = "NotificationTime";

	private static DateTime lasttime;

	private static DateTime currentTime;

	private DateTime nextTime;

	private int NoOfNotificationsToSet;

	private int TotalNotivationsCount = 1;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		Debug.LogError("-------------- DateNow=" + DateTime.Now);
		OneSignal.SetLogLevel(OneSignal.LOG_LEVEL.VERBOSE, OneSignal.LOG_LEVEL.NONE);
	}

	public void initOneSignalLocally()
	{
		Debug.Log("---------- initOneSignalLocally OneSignalAppID=" + OneSignalAppID);
		if (OneSignalAppID != string.Empty)
		{
			Debug.Log("----- init onesignal with external values");
			initOneSignalWithDisID(OneSignalAppID, GoogleProjectID);
		}
		else if (AdManager.instance.Game_Category == AdManager.GameCategory.Action)
		{
			initOneSignalWithDisID("66bd2835-fba8-4214-9d1d-df321a3c2e40", "443441248561");
		}
		else if (AdManager.instance.Game_Category == AdManager.GameCategory.Casual)
		{
			initOneSignalWithDisID("d74a295a-0c18-4450-81c0-e63e6b91d14a", "443441248561");
		}
		else if (AdManager.instance.Game_Category == AdManager.GameCategory.Driving)
		{
			initOneSignalWithDisID("908f7c97-2421-496f-8cb5-21837902e62e", "443441248561");
		}
		else if (AdManager.instance.Game_Category == AdManager.GameCategory.Other)
		{
			initOneSignalWithDisID("66bd2835-fba8-4214-9d1d-df321a3c2e40", "443441248561");
		}
		else if (AdManager.instance.Game_Category == AdManager.GameCategory.Match3)
		{
			initOneSignalWithDisID("2b898910-b90a-42cb-bd25-509c67a1883e", "443441248561");
		}
		else if (AdManager.instance.Game_Category == AdManager.GameCategory.Racing)
		{
			initOneSignalWithDisID("1933e412-004a-402d-8583-18d2a47b1b09", "443441248561");
		}
		else if (AdManager.instance.Game_Category == AdManager.GameCategory.Simulation)
		{
			initOneSignalWithDisID("7f36a62e-4e1c-44fb-933c-5668b0b22cb0", "443441248561");
		}
		else if (AdManager.instance.Game_Category == AdManager.GameCategory.Tapping)
		{
			initOneSignalWithDisID("66bd2835-fba8-4214-9d1d-df321a3c2e40", "443441248561");
		}
	}

	public void initOneSignalWithDisID(string appID, string googleId)
	{
		Debug.Log("-------- initOneSignalWithDisID");
		OneSignal.StartInit(appID).HandleNotificationReceived(HandleNotificationReceived).HandleNotificationOpened(HandleNotificationOpened)
			.EndInit();
		OneSignal.inFocusDisplayType = OneSignal.OSInFocusDisplayOption.Notification;
		OneSignal.permissionObserver += OneSignal_permissionObserver;
		OneSignal.subscriptionObserver += OneSignal_subscriptionObserver;
		OneSignal.emailSubscriptionObserver += OneSignal_emailSubscriptionObserver;
		OSPermissionSubscriptionState permissionSubscriptionState = OneSignal.GetPermissionSubscriptionState();
		Debug.Log("pushState.subscriptionStatus.subscribed : " + permissionSubscriptionState.subscriptionStatus.subscribed);
		Debug.Log("pushState.subscriptionStatus.userId : " + permissionSubscriptionState.subscriptionStatus.userId);
		GetTimeNSetNotification();
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
		Dictionary<string, object> additionalData = payload.additionalData;
		if (additionalData == null)
		{
			Debug.Log("[HandleNotificationOpened] Additional Data == null");
		}
		else
		{
			Debug.Log("[HandleNotificationOpened] message " + body + ", additionalData: " + Json.Serialize(additionalData));
			if (additionalData.ContainsKey("coins"))
			{
				string text = additionalData["coins"].ToString();
				Debug.Log("coinsValue=" + text);
				int num = int.Parse(text);
				CallbacksController.instance.AddCoins(num);
				Debug.Log("coins=" + num);
			}
			else if (additionalData.ContainsKey("discount"))
			{
				switch (additionalData["discount"].ToString())
				{
				case "upgrade":
					Debug.Log("----- Got Upgrade Discount Notification");
					AdManager.instance.IsOpenUpgradeDiscountFrmPush = true;
					break;
				case "levels":
					Debug.Log("----- Got Levels Discount Notification");
					AdManager.instance.IsOpenLevelDiscountFrmPush = true;
					break;
				case "noads":
					Debug.Log("----- Got Levels Discount Notification");
					break;
				}
			}
		}
		OneSignal.ClearOneSignalNotifications();
	}

	public void sendTestNotification(int TimeValue)
	{
		Debug.Log("sendTestNotification");
		OneSignal.IdsAvailable(delegate(string userId, string pushToken)
		{
			if (pushToken != null)
			{
				NotificationIndex = PlayerPrefs.GetInt("LastUsedNotificationID", 0);
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				switch (RewardTypeList[NotificationIndex])
				{
				case RewardType.Coins:
					dictionary["data"] = new Dictionary<string, string> { 
					{
						"coins",
						string.Concat(RewardCoins[NotificationIndex])
					} };
					break;
				case RewardType.DiscountUpgrades:
					if (AdManager.UpgradeUnlocked == 1)
					{
						GoToNextNotification();
						sendTestNotification(TimeValue);
						return;
					}
					dictionary["data"] = new Dictionary<string, string> { { "discount", "upgrade" } };
					break;
				case RewardType.DiscountLevels:
					if (AdManager.LevelsUnlocked == 1)
					{
						GoToNextNotification();
						sendTestNotification(TimeValue);
						return;
					}
					dictionary["data"] = new Dictionary<string, string> { { "discount", "levels" } };
					break;
				}
				dictionary["contents"] = new Dictionary<string, string> { 
				{
					"en",
					LocalNotifications[NotificationIndex]
				} };
				dictionary["include_player_ids"] = new List<string> { userId };
				dictionary["send_after"] = DateTime.Now.ToUniversalTime().AddSeconds(TimeValue).ToString("U");
				OneSignal.PostNotification(dictionary, delegate
				{
					Debug.Log("GameControllerExample Notification Posted Successful");
					GoToNextNotification();
				}, delegate
				{
					Debug.Log("Notification Falied to post");
				});
			}
			else
			{
				Debug.Log("Error Device not recognised");
			}
		});
	}

	private void GoToNextNotification()
	{
		NotificationIndex++;
		if (NotificationIndex > LocalNotifications.Count - 1)
		{
			NotificationIndex = 0;
		}
		PlayerPrefs.SetInt("LastUsedNotificationID", NotificationIndex);
	}

	public void GetTimeNSetNotification()
	{
		if (!PlayerPrefs.HasKey("firstTime"))
		{
			Debug.Log("--------------- GetTimeNSetNotifications for firstTime");
			PlayerPrefs.SetString("firstTime", "false");
			NoOfNotificationsToSet = TotalNotivationsCount;
			lasttime = DateTime.Now;
			currentTime = DateTime.Now;
			SetNotification(NoOfNotificationsToSet);
			PlayerPrefs.SetString(keyy, lasttime.ToString());
			return;
		}
		currentTime = DateTime.Now;
		TimeSpan timeSpan = DateTime.Parse(PlayerPrefs.GetString(keyy)) - currentTime;
		Debug.Log("hours=" + timeSpan.Hours);
		double totalHours = timeSpan.TotalHours;
		Debug.LogError(string.Concat("--------GetNSetNotifications diff=", timeSpan, "::hours=", totalHours));
		lasttime = DateTime.Parse(PlayerPrefs.GetString(keyy));
		int num = 0;
		if (totalHours / (double)duration > 1.0)
		{
			num = (((int)Math.Round(totalHours) % duration != 0) ? (duration - (int)Math.Round(totalHours) % duration) : ((int)Math.Round(totalHours) % duration));
			Debug.LogError("extraTime=" + num);
			NoOfNotificationsToSet = (TotalNotivationsCount * duration - (int)totalHours) / duration;
			NoOfNotificationsToSet = Mathf.Clamp(NoOfNotificationsToSet, 0, TotalNotivationsCount);
			Debug.LogError("Notification setCount 22222=" + NoOfNotificationsToSet);
			lasttime = currentTime.AddHours((TotalNotivationsCount - NoOfNotificationsToSet) * duration);
			lasttime = lasttime.AddHours(-num);
			SetNotification(NoOfNotificationsToSet);
		}
		else if (totalHours <= 0.0)
		{
			NoOfNotificationsToSet = TotalNotivationsCount;
			lasttime = DateTime.Now;
			currentTime = DateTime.Now;
			SetNotification(NoOfNotificationsToSet);
		}
	}

	public static TimeSpan GetFromLastTimer()
	{
		TimeSpan result = default(TimeSpan);
		Debug.Log("--Has keyy " + PlayerPrefs.HasKey(keyy));
		if (PlayerPrefs.HasKey(keyy))
		{
			DateTime dateTime = DateTime.Parse(PlayerPrefs.GetString(keyy));
			return DateTime.Now - dateTime;
		}
		MonoBehaviour.print("Not saved time..");
		return result;
	}

	public void SetNotification(int NotificationsCount)
	{
		OneSignal.IdsAvailable(delegate(string userId, string pushToken)
		{
			if (pushToken != null)
			{
				nextTime = lasttime.AddHours(duration);
				double totalHours = (nextTime - currentTime).TotalHours;
				Debug.LogError("SetNotification nextTime=" + totalHours + ":::tm=" + totalHours);
				NotificationIndex = PlayerPrefs.GetInt("LastUsedNotificationID", 0);
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				switch (RewardTypeList[NotificationIndex])
				{
				case RewardType.Coins:
					dictionary["data"] = new Dictionary<string, string> { 
					{
						"coins",
						string.Concat(RewardCoins[NotificationIndex])
					} };
					break;
				case RewardType.DiscountUpgrades:
				case RewardType.NoAds:
					if (AdManager.UpgradeUnlocked == 1)
					{
						GoToNextNotification();
						nextTime = lasttime.AddHours(-duration);
						SetNotification(NotificationsCount);
						return;
					}
					dictionary["data"] = new Dictionary<string, string> { { "discount", "upgrade" } };
					break;
				case RewardType.DiscountLevels:
					if (AdManager.LevelsUnlocked == 1)
					{
						GoToNextNotification();
						nextTime = lasttime.AddHours(-duration);
						SetNotification(NotificationsCount);
						return;
					}
					dictionary["data"] = new Dictionary<string, string> { { "discount", "levels" } };
					break;
				}
				dictionary["contents"] = new Dictionary<string, string> { 
				{
					"en",
					LocalNotifications[NotificationIndex]
				} };
				dictionary["include_player_ids"] = new List<string> { userId };
				dictionary["send_after"] = DateTime.Now.ToUniversalTime().AddHours(totalHours).ToString("U");
				OneSignal.PostNotification(dictionary, delegate
				{
					GoToNextNotification();
					lasttime = nextTime;
					NotificationsCount--;
					Debug.Log("Notification Posted Successful NotificationCount=" + NotificationsCount);
					if (NotificationsCount > 0)
					{
						SetNotification(NotificationsCount);
					}
					else
					{
						PlayerPrefs.SetString(keyy, lasttime.ToString());
					}
				}, delegate
				{
					Debug.Log("Notification Falied to post");
					PlayerPrefs.SetString(keyy, lasttime.ToString());
				});
			}
			else
			{
				Debug.Log("Error Device not recognised");
			}
		});
	}

	public void checkNotificationTime(int NotificationsCount)
	{
		nextTime = lasttime.AddHours(duration);
		double totalHours = (nextTime - currentTime).TotalHours;
		TimeSpan timeOfDay = nextTime.TimeOfDay;
		Debug.LogWarning(string.Concat("------ checkNotificationTime nextTime=", nextTime, ":::hours=", totalHours));
		lasttime = nextTime;
		NotificationsCount--;
		if (NotificationsCount > 0)
		{
			checkNotificationTime(NotificationsCount);
		}
		else
		{
			PlayerPrefs.SetString(keyy, lasttime.ToString());
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
