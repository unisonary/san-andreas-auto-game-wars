using System;
using System.Collections.Generic;

namespace GooglePlayGames.BasicApi.Nearby
{
	public interface INearbyConnectionClient
	{
		int MaxUnreliableMessagePayloadLength();

		int MaxReliableMessagePayloadLength();

		void SendReliable(List<string> recipientEndpointIds, byte[] payload);

		void SendUnreliable(List<string> recipientEndpointIds, byte[] payload);

		void StartAdvertising(string name, List<string> appIdentifiers, TimeSpan? advertisingDuration, Action<AdvertisingResult> resultCallback, Action<ConnectionRequest> connectionRequestCallback);

		void StopAdvertising();

		void SendConnectionRequest(string name, string remoteEndpointId, byte[] payload, Action<ConnectionResponse> responseCallback, IMessageListener listener);

		void AcceptConnectionRequest(string remoteEndpointId, byte[] payload, IMessageListener listener);

		void StartDiscovery(string serviceId, TimeSpan? advertisingTimeout, IDiscoveryListener listener);

		void StopDiscovery(string serviceId);

		void RejectConnectionRequest(string requestingEndpointId);

		void DisconnectFromEndpoint(string remoteEndpointId);

		void StopAllConnections();

		string GetAppBundleId();

		string GetServiceId();
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
