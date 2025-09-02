using System;
using System.Runtime.InteropServices;
using GooglePlayGames.Native.Cwrapper;

namespace GooglePlayGames.Native.PInvoke
{
	internal class GameServices : BaseReferenceHolder
	{
		internal GameServices(IntPtr selfPointer)
			: base(selfPointer)
		{
		}

		internal bool IsAuthenticated()
		{
			return GooglePlayGames.Native.Cwrapper.GameServices.GameServices_IsAuthorized(SelfPtr());
		}

		internal void SignOut()
		{
			GooglePlayGames.Native.Cwrapper.GameServices.GameServices_SignOut(SelfPtr());
		}

		internal void StartAuthorizationUI()
		{
			GooglePlayGames.Native.Cwrapper.GameServices.GameServices_StartAuthorizationUI(SelfPtr());
		}

		public AchievementManager AchievementManager()
		{
			return new AchievementManager(this);
		}

		public LeaderboardManager LeaderboardManager()
		{
			return new LeaderboardManager(this);
		}

		public PlayerManager PlayerManager()
		{
			return new PlayerManager(this);
		}

		public StatsManager StatsManager()
		{
			return new StatsManager(this);
		}

		internal HandleRef AsHandle()
		{
			return SelfPtr();
		}

		protected override void CallDispose(HandleRef selfPointer)
		{
			GooglePlayGames.Native.Cwrapper.GameServices.GameServices_Dispose(selfPointer);
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
