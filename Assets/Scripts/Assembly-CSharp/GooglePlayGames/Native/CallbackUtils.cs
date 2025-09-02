using System;
using GooglePlayGames.OurUtils;

namespace GooglePlayGames.Native
{
	internal static class CallbackUtils
	{
		internal static Action<T> ToOnGameThread<T>(Action<T> toConvert)
		{
			if (toConvert == null)
			{
				return delegate
				{
				};
			}
			return delegate(T val)
			{
				PlayGamesHelperObject.RunOnGameThread(delegate
				{
					toConvert(val);
				});
			};
		}

		internal static Action<T1, T2> ToOnGameThread<T1, T2>(Action<T1, T2> toConvert)
		{
			if (toConvert == null)
			{
				return delegate
				{
				};
			}
			return delegate(T1 val1, T2 val2)
			{
				PlayGamesHelperObject.RunOnGameThread(delegate
				{
					toConvert(val1, val2);
				});
			};
		}

		internal static Action<T1, T2, T3> ToOnGameThread<T1, T2, T3>(Action<T1, T2, T3> toConvert)
		{
			if (toConvert == null)
			{
				return delegate
				{
				};
			}
			return delegate(T1 val1, T2 val2, T3 val3)
			{
				PlayGamesHelperObject.RunOnGameThread(delegate
				{
					toConvert(val1, val2, val3);
				});
			};
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
