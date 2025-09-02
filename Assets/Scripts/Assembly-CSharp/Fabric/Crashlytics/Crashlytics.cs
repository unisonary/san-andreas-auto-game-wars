using System.Diagnostics;
using Fabric.Crashlytics.Internal;

namespace Fabric.Crashlytics
{
	public class Crashlytics
	{
		private static readonly Impl impl;

		static Crashlytics()
		{
			impl = Impl.Make();
		}

		public static void SetDebugMode(bool debugMode)
		{
			impl.SetDebugMode(debugMode);
		}

		public static void Crash()
		{
			impl.Crash();
		}

		public static void ThrowNonFatal()
		{
			impl.ThrowNonFatal();
		}

		public static void Log(string message)
		{
			impl.Log(message);
		}

		public static void SetKeyValue(string key, string value)
		{
			impl.SetKeyValue(key, value);
		}

		public static void SetUserIdentifier(string identifier)
		{
			impl.SetUserIdentifier(identifier);
		}

		public static void SetUserEmail(string email)
		{
			impl.SetUserEmail(email);
		}

		public static void SetUserName(string name)
		{
			impl.SetUserName(name);
		}

		public static void RecordCustomException(string name, string reason, StackTrace stackTrace)
		{
			impl.RecordCustomException(name, reason, stackTrace);
		}

		public static void RecordCustomException(string name, string reason, string stackTraceString)
		{
			impl.RecordCustomException(name, reason, stackTraceString);
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
