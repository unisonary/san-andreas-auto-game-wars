using System;
using System.Runtime.InteropServices;
using AOT;
using GooglePlayGames.Native.Cwrapper;
using GooglePlayGames.OurUtils;

namespace GooglePlayGames.Native.PInvoke
{
	internal class StatsManager
	{
		internal class FetchForPlayerResponse : BaseReferenceHolder
		{
			internal FetchForPlayerResponse(IntPtr selfPointer)
				: base(selfPointer)
			{
			}

			internal CommonErrorStatus.ResponseStatus Status()
			{
				return GooglePlayGames.Native.Cwrapper.StatsManager.StatsManager_FetchForPlayerResponse_GetStatus(SelfPtr());
			}

			internal NativePlayerStats PlayerStats()
			{
				return new NativePlayerStats(GooglePlayGames.Native.Cwrapper.StatsManager.StatsManager_FetchForPlayerResponse_GetData(SelfPtr()));
			}

			protected override void CallDispose(HandleRef selfPointer)
			{
				GooglePlayGames.Native.Cwrapper.StatsManager.StatsManager_FetchForPlayerResponse_Dispose(selfPointer);
			}

			internal static FetchForPlayerResponse FromPointer(IntPtr pointer)
			{
				if (pointer.Equals(IntPtr.Zero))
				{
					return null;
				}
				return new FetchForPlayerResponse(pointer);
			}
		}

		private readonly GameServices mServices;

		internal StatsManager(GameServices services)
		{
			mServices = Misc.CheckNotNull(services);
		}

		internal void FetchForPlayer(Action<FetchForPlayerResponse> callback)
		{
			Misc.CheckNotNull(callback);
			GooglePlayGames.Native.Cwrapper.StatsManager.StatsManager_FetchForPlayer(mServices.AsHandle(), Types.DataSource.CACHE_OR_NETWORK, InternalFetchForPlayerCallback, Callbacks.ToIntPtr(callback, FetchForPlayerResponse.FromPointer));
		}

		[AOT.MonoPInvokeCallback(typeof(GooglePlayGames.Native.Cwrapper.StatsManager.FetchForPlayerCallback))]
		private static void InternalFetchForPlayerCallback(IntPtr response, IntPtr data)
		{
			Callbacks.PerformInternalCallback("StatsManager#InternalFetchForPlayerCallback", Callbacks.Type.Temporary, response, data);
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
