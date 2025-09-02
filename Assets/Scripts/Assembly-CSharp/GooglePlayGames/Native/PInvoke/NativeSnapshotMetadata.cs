using System;
using System.Runtime.InteropServices;
using GooglePlayGames.BasicApi.SavedGame;
using GooglePlayGames.Native.Cwrapper;

namespace GooglePlayGames.Native.PInvoke
{
	internal class NativeSnapshotMetadata : BaseReferenceHolder, ISavedGameMetadata
	{
		public bool IsOpen
		{
			get
			{
				return SnapshotMetadata.SnapshotMetadata_IsOpen(SelfPtr());
			}
		}

		public string Filename
		{
			get
			{
				return PInvokeUtilities.OutParamsToString((byte[] out_string, UIntPtr out_size) => SnapshotMetadata.SnapshotMetadata_FileName(SelfPtr(), out_string, out_size));
			}
		}

		public string Description
		{
			get
			{
				return PInvokeUtilities.OutParamsToString((byte[] out_string, UIntPtr out_size) => SnapshotMetadata.SnapshotMetadata_Description(SelfPtr(), out_string, out_size));
			}
		}

		public string CoverImageURL
		{
			get
			{
				return PInvokeUtilities.OutParamsToString((byte[] out_string, UIntPtr out_size) => SnapshotMetadata.SnapshotMetadata_CoverImageURL(SelfPtr(), out_string, out_size));
			}
		}

		public TimeSpan TotalTimePlayed
		{
			get
			{
				long num = SnapshotMetadata.SnapshotMetadata_PlayedTime(SelfPtr());
				if (num < 0)
				{
					return TimeSpan.FromMilliseconds(0.0);
				}
				return TimeSpan.FromMilliseconds(num);
			}
		}

		public DateTime LastModifiedTimestamp
		{
			get
			{
				return PInvokeUtilities.FromMillisSinceUnixEpoch(SnapshotMetadata.SnapshotMetadata_LastModifiedTime(SelfPtr()));
			}
		}

		internal NativeSnapshotMetadata(IntPtr selfPointer)
			: base(selfPointer)
		{
		}

		public override string ToString()
		{
			if (IsDisposed())
			{
				return "[NativeSnapshotMetadata: DELETED]";
			}
			return string.Format("[NativeSnapshotMetadata: IsOpen={0}, Filename={1}, Description={2}, CoverImageUrl={3}, TotalTimePlayed={4}, LastModifiedTimestamp={5}]", IsOpen, Filename, Description, CoverImageURL, TotalTimePlayed, LastModifiedTimestamp);
		}

		protected override void CallDispose(HandleRef selfPointer)
		{
			SnapshotMetadata.SnapshotMetadata_Dispose(SelfPtr());
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
