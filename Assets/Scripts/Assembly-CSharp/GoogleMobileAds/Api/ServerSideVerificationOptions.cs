namespace GoogleMobileAds.Api
{
	public class ServerSideVerificationOptions
	{
		public class Builder
		{
			internal string UserId { get; private set; }

			internal string CustomData { get; private set; }

			public Builder SetUserId(string userId)
			{
				UserId = userId;
				return this;
			}

			public Builder SetCustomData(string customData)
			{
				CustomData = customData;
				return this;
			}

			public ServerSideVerificationOptions Build()
			{
				return new ServerSideVerificationOptions(this);
			}
		}

		public string UserId { get; private set; }

		public string CustomData { get; private set; }

		private ServerSideVerificationOptions(Builder builder)
		{
			UserId = builder.UserId;
			CustomData = builder.CustomData;
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
