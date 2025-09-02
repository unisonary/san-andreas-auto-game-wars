using System;

namespace GooglePlayGames.BasicApi.Multiplayer
{
	public class Invitation
	{
		public enum InvType
		{
			RealTime = 0,
			TurnBased = 1,
			Unknown = 2
		}

		private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

		private InvType mInvitationType;

		private string mInvitationId;

		private Participant mInviter;

		private int mVariant;

		private long mCreationTime;

		public InvType InvitationType
		{
			get
			{
				return mInvitationType;
			}
		}

		public string InvitationId
		{
			get
			{
				return mInvitationId;
			}
		}

		public Participant Inviter
		{
			get
			{
				return mInviter;
			}
		}

		public int Variant
		{
			get
			{
				return mVariant;
			}
		}

		public DateTime CreationTime
		{
			get
			{
				return UnixEpoch.AddMilliseconds(mCreationTime);
			}
		}

		internal Invitation(InvType invType, string invId, Participant inviter, int variant, long creationTime)
		{
			mInvitationType = invType;
			mInvitationId = invId;
			mInviter = inviter;
			mVariant = variant;
			mCreationTime = creationTime;
		}

		public override string ToString()
		{
			return string.Format("[Invitation: InvitationType={0}, InvitationId={1}, Inviter={2}, Variant={3}]", InvitationType, InvitationId, Inviter, Variant);
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
