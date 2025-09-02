namespace GooglePlayGames.BasicApi
{
	public class PlayerStats
	{
		private static float UNSET_VALUE = -1f;

		public bool Valid { get; set; }

		public int NumberOfPurchases { get; set; }

		public float AvgSessonLength { get; set; }

		public int DaysSinceLastPlayed { get; set; }

		public int NumberOfSessions { get; set; }

		public float SessPercentile { get; set; }

		public float SpendPercentile { get; set; }

		public float SpendProbability { get; set; }

		public float ChurnProbability { get; set; }

		public float HighSpenderProbability { get; set; }

		public float TotalSpendNext28Days { get; set; }

		public PlayerStats()
		{
			Valid = false;
		}

		public bool HasNumberOfPurchases()
		{
			return NumberOfPurchases != (int)UNSET_VALUE;
		}

		public bool HasAvgSessonLength()
		{
			return AvgSessonLength != UNSET_VALUE;
		}

		public bool HasDaysSinceLastPlayed()
		{
			return DaysSinceLastPlayed != (int)UNSET_VALUE;
		}

		public bool HasNumberOfSessions()
		{
			return NumberOfSessions != (int)UNSET_VALUE;
		}

		public bool HasSessPercentile()
		{
			return SessPercentile != UNSET_VALUE;
		}

		public bool HasSpendPercentile()
		{
			return SpendPercentile != UNSET_VALUE;
		}

		public bool HasChurnProbability()
		{
			return ChurnProbability != UNSET_VALUE;
		}

		public bool HasHighSpenderProbability()
		{
			return HighSpenderProbability != UNSET_VALUE;
		}

		public bool HasTotalSpendNext28Days()
		{
			return TotalSpendNext28Days != UNSET_VALUE;
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
