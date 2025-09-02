using GooglePlayGames.OurUtils;

namespace GooglePlayGames.BasicApi.Nearby
{
	public struct ConnectionResponse
	{
		public enum Status
		{
			Accepted = 0,
			Rejected = 1,
			ErrorInternal = 2,
			ErrorNetworkNotConnected = 3,
			ErrorEndpointNotConnected = 4,
			ErrorAlreadyConnected = 5
		}

		private static readonly byte[] EmptyPayload = new byte[0];

		private readonly long mLocalClientId;

		private readonly string mRemoteEndpointId;

		private readonly Status mResponseStatus;

		private readonly byte[] mPayload;

		public long LocalClientId
		{
			get
			{
				return mLocalClientId;
			}
		}

		public string RemoteEndpointId
		{
			get
			{
				return mRemoteEndpointId;
			}
		}

		public Status ResponseStatus
		{
			get
			{
				return mResponseStatus;
			}
		}

		public byte[] Payload
		{
			get
			{
				return mPayload;
			}
		}

		private ConnectionResponse(long localClientId, string remoteEndpointId, Status code, byte[] payload)
		{
			mLocalClientId = localClientId;
			mRemoteEndpointId = Misc.CheckNotNull(remoteEndpointId);
			mResponseStatus = code;
			mPayload = Misc.CheckNotNull(payload);
		}

		public static ConnectionResponse Rejected(long localClientId, string remoteEndpointId)
		{
			return new ConnectionResponse(localClientId, remoteEndpointId, Status.Rejected, EmptyPayload);
		}

		public static ConnectionResponse NetworkNotConnected(long localClientId, string remoteEndpointId)
		{
			return new ConnectionResponse(localClientId, remoteEndpointId, Status.ErrorNetworkNotConnected, EmptyPayload);
		}

		public static ConnectionResponse InternalError(long localClientId, string remoteEndpointId)
		{
			return new ConnectionResponse(localClientId, remoteEndpointId, Status.ErrorInternal, EmptyPayload);
		}

		public static ConnectionResponse EndpointNotConnected(long localClientId, string remoteEndpointId)
		{
			return new ConnectionResponse(localClientId, remoteEndpointId, Status.ErrorEndpointNotConnected, EmptyPayload);
		}

		public static ConnectionResponse Accepted(long localClientId, string remoteEndpointId, byte[] payload)
		{
			return new ConnectionResponse(localClientId, remoteEndpointId, Status.Accepted, payload);
		}

		public static ConnectionResponse AlreadyConnected(long localClientId, string remoteEndpointId)
		{
			return new ConnectionResponse(localClientId, remoteEndpointId, Status.ErrorAlreadyConnected, EmptyPayload);
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
