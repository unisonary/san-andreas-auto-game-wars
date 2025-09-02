using System;
using Fabric.Crashlytics;
using Fabric.Internal.Runtime;
using UnityEngine;

namespace Fabric.Internal.Crashlytics
{
	public class CrashlyticsInit : MonoBehaviour
	{
		private static readonly string kitName = "Crashlytics";

		private static CrashlyticsInit instance;

		private void Awake()
		{
			if (instance == null)
			{
				AwakeOnce();
				instance = this;
				UnityEngine.Object.DontDestroyOnLoad(this);
			}
			else if (instance != this)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}

		private void AwakeOnce()
		{
			RegisterExceptionHandlers();
		}

		private static void RegisterExceptionHandlers()
		{
			if (IsSDKInitialized())
			{
				Utils.Log(kitName, "Registering exception handlers");
				AppDomain.CurrentDomain.UnhandledException += HandleException;
				Application.logMessageReceived += HandleLog;
			}
			else
			{
				Utils.Log(kitName, "Did not register exception handlers: Crashlytics SDK was not initialized");
			}
		}

		private static bool IsSDKInitialized()
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.crashlytics.android.Crashlytics");
			AndroidJavaObject androidJavaObject = null;
			try
			{
				androidJavaObject = androidJavaClass.CallStatic<AndroidJavaObject>("getInstance", Array.Empty<object>());
			}
			catch
			{
				androidJavaObject = null;
			}
			return androidJavaObject != null;
		}

		private static void HandleException(object sender, UnhandledExceptionEventArgs eArgs)
		{
			Exception ex = (Exception)eArgs.ExceptionObject;
			HandleLog(ex.Message.ToString(), ex.StackTrace.ToString(), LogType.Exception);
		}

		private static void HandleLog(string message, string stackTraceString, LogType type)
		{
			if (type == LogType.Exception)
			{
				Utils.Log(kitName, "Recording exception: " + message);
				Utils.Log(kitName, "Exception stack trace: " + stackTraceString);
				string[] messageParts = getMessageParts(message);
				Fabric.Crashlytics.Crashlytics.RecordCustomException(messageParts[0], messageParts[1], stackTraceString);
			}
		}

		private static string[] getMessageParts(string message)
		{
			char[] separator = new char[1] { ':' };
			string[] array = message.Split(separator, 2, StringSplitOptions.None);
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].Trim();
			}
			if (array.Length == 2)
			{
				return array;
			}
			return new string[2] { "Exception", message };
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
