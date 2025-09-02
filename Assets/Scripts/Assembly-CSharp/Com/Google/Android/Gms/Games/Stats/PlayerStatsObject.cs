using System;
using Google.Developers;

namespace Com.Google.Android.Gms.Games.Stats
{
	public class PlayerStatsObject : JavaObjWrapper, PlayerStats
	{
		private const string CLASS_NAME = "com/google/android/gms/games/stats/PlayerStats";

		public static float UNSET_VALUE
		{
			get
			{
				return JavaObjWrapper.GetStaticFloatField("com/google/android/gms/games/stats/PlayerStats", "UNSET_VALUE");
			}
		}

		public static int CONTENTS_FILE_DESCRIPTOR
		{
			get
			{
				return JavaObjWrapper.GetStaticIntField("com/google/android/gms/games/stats/PlayerStats", "CONTENTS_FILE_DESCRIPTOR");
			}
		}

		public static int PARCELABLE_WRITE_RETURN_VALUE
		{
			get
			{
				return JavaObjWrapper.GetStaticIntField("com/google/android/gms/games/stats/PlayerStats", "PARCELABLE_WRITE_RETURN_VALUE");
			}
		}

		public PlayerStatsObject(IntPtr ptr)
			: base(ptr)
		{
		}

		public float getAverageSessionLength()
		{
			return InvokeCall<float>("getAverageSessionLength", "()F", Array.Empty<object>());
		}

		public float getChurnProbability()
		{
			return InvokeCall<float>("getChurnProbability", "()F", Array.Empty<object>());
		}

		public int getDaysSinceLastPlayed()
		{
			return InvokeCall<int>("getDaysSinceLastPlayed", "()I", Array.Empty<object>());
		}

		public int getNumberOfPurchases()
		{
			return InvokeCall<int>("getNumberOfPurchases", "()I", Array.Empty<object>());
		}

		public int getNumberOfSessions()
		{
			return InvokeCall<int>("getNumberOfSessions", "()I", Array.Empty<object>());
		}

		public float getSessionPercentile()
		{
			return InvokeCall<float>("getSessionPercentile", "()F", Array.Empty<object>());
		}

		public float getSpendPercentile()
		{
			return InvokeCall<float>("getSpendPercentile", "()F", Array.Empty<object>());
		}

		public float getSpendProbability()
		{
			return InvokeCall<float>("getSpendProbability", "()F", Array.Empty<object>());
		}

		public float getHighSpenderProbability()
		{
			return InvokeCall<float>("getHighSpenderProbability", "()F", Array.Empty<object>());
		}

		public float getTotalSpendNext28Days()
		{
			return InvokeCall<float>("getTotalSpendNext28Days", "()F", Array.Empty<object>());
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
