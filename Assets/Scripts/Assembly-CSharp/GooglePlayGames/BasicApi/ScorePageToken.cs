namespace GooglePlayGames.BasicApi
{
	public class ScorePageToken
	{
		private string mId;

		private object mInternalObject;

		private LeaderboardCollection mCollection;

		private LeaderboardTimeSpan mTimespan;

		public LeaderboardCollection Collection
		{
			get
			{
				return mCollection;
			}
		}

		public LeaderboardTimeSpan TimeSpan
		{
			get
			{
				return mTimespan;
			}
		}

		public string LeaderboardId
		{
			get
			{
				return mId;
			}
		}

		internal object InternalObject
		{
			get
			{
				return mInternalObject;
			}
		}

		internal ScorePageToken(object internalObject, string id, LeaderboardCollection collection, LeaderboardTimeSpan timespan)
		{
			mInternalObject = internalObject;
			mId = id;
			mCollection = collection;
			mTimespan = timespan;
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
