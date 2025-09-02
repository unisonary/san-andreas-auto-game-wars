using System;
using System.Collections.Generic;
using System.Linq;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.Events;
using GooglePlayGames.Native.PInvoke;
using GooglePlayGames.OurUtils;

namespace GooglePlayGames.Native
{
	internal class NativeEventClient : IEventsClient
	{
		private readonly EventManager mEventManager;

		internal NativeEventClient(EventManager manager)
		{
			mEventManager = Misc.CheckNotNull(manager);
		}

		public void FetchAllEvents(DataSource source, Action<ResponseStatus, List<IEvent>> callback)
		{
			Misc.CheckNotNull(callback);
			callback = CallbackUtils.ToOnGameThread(callback);
			mEventManager.FetchAll(ConversionUtils.AsDataSource(source), delegate(EventManager.FetchAllResponse response)
			{
				ResponseStatus arg = ConversionUtils.ConvertResponseStatus(response.ResponseStatus());
				if (!response.RequestSucceeded())
				{
					callback(arg, new List<IEvent>());
				}
				else
				{
					callback(arg, Enumerable.ToList(Enumerable.Cast<IEvent>(response.Data())));
				}
			});
		}

		public void FetchEvent(DataSource source, string eventId, Action<ResponseStatus, IEvent> callback)
		{
			Misc.CheckNotNull(eventId);
			Misc.CheckNotNull(callback);
			mEventManager.Fetch(ConversionUtils.AsDataSource(source), eventId, delegate(EventManager.FetchResponse response)
			{
				ResponseStatus arg = ConversionUtils.ConvertResponseStatus(response.ResponseStatus());
				if (!response.RequestSucceeded())
				{
					callback(arg, null);
				}
				else
				{
					callback(arg, response.Data());
				}
			});
		}

		public void IncrementEvent(string eventId, uint stepsToIncrement)
		{
			Misc.CheckNotNull(eventId);
			mEventManager.Increment(eventId, stepsToIncrement);
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
