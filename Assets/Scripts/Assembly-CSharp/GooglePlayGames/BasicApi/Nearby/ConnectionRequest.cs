using GooglePlayGames.OurUtils;

namespace GooglePlayGames.BasicApi.Nearby
{
	public struct ConnectionRequest
	{
		private readonly EndpointDetails mRemoteEndpoint;

		private readonly byte[] mPayload;

		public EndpointDetails RemoteEndpoint
		{
			get
			{
				return mRemoteEndpoint;
			}
		}

		public byte[] Payload
		{
			get
			{
				return mPayload;
			}
		}

		public ConnectionRequest(string remoteEndpointId, string remoteEndpointName, string serviceId, byte[] payload)
		{
			Logger.d("Constructing ConnectionRequest");
			mRemoteEndpoint = new EndpointDetails(remoteEndpointId, remoteEndpointName, serviceId);
			mPayload = Misc.CheckNotNull(payload);
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
