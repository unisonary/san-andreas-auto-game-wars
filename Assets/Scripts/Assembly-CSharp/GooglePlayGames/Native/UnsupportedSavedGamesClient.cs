using System;
using System.Collections.Generic;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using GooglePlayGames.OurUtils;

namespace GooglePlayGames.Native
{
	internal class UnsupportedSavedGamesClient : ISavedGameClient
	{
		private readonly string mMessage;

		public UnsupportedSavedGamesClient(string message)
		{
			mMessage = Misc.CheckNotNull(message);
		}

		public void OpenWithAutomaticConflictResolution(string filename, DataSource source, ConflictResolutionStrategy resolutionStrategy, Action<SavedGameRequestStatus, ISavedGameMetadata> callback)
		{
			throw new NotImplementedException(mMessage);
		}

		public void OpenWithManualConflictResolution(string filename, DataSource source, bool prefetchDataOnConflict, ConflictCallback conflictCallback, Action<SavedGameRequestStatus, ISavedGameMetadata> completedCallback)
		{
			throw new NotImplementedException(mMessage);
		}

		public void ReadBinaryData(ISavedGameMetadata metadata, Action<SavedGameRequestStatus, byte[]> completedCallback)
		{
			throw new NotImplementedException(mMessage);
		}

		public void ShowSelectSavedGameUI(string uiTitle, uint maxDisplayedSavedGames, bool showCreateSaveUI, bool showDeleteSaveUI, Action<SelectUIStatus, ISavedGameMetadata> callback)
		{
			throw new NotImplementedException(mMessage);
		}

		public void CommitUpdate(ISavedGameMetadata metadata, SavedGameMetadataUpdate updateForMetadata, byte[] updatedBinaryData, Action<SavedGameRequestStatus, ISavedGameMetadata> callback)
		{
			throw new NotImplementedException(mMessage);
		}

		public void FetchAllSavedGames(DataSource source, Action<SavedGameRequestStatus, List<ISavedGameMetadata>> callback)
		{
			throw new NotImplementedException(mMessage);
		}

		public void Delete(ISavedGameMetadata metadata)
		{
			throw new NotImplementedException(mMessage);
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
