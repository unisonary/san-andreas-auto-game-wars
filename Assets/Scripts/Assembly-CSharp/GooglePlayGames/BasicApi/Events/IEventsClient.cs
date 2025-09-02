using System;
using System.Collections.Generic;

namespace GooglePlayGames.BasicApi.Events
{
	public interface IEventsClient
	{
		void FetchAllEvents(DataSource source, Action<ResponseStatus, List<IEvent>> callback);

		void FetchEvent(DataSource source, string eventId, Action<ResponseStatus, IEvent> callback);

		void IncrementEvent(string eventId, uint stepsToIncrement);
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
