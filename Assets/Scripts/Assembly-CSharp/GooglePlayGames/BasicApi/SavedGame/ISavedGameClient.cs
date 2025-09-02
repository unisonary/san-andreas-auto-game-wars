using System;
using System.Collections.Generic;

namespace GooglePlayGames.BasicApi.SavedGame
{
	public interface ISavedGameClient
	{
		void OpenWithAutomaticConflictResolution(string filename, DataSource source, ConflictResolutionStrategy resolutionStrategy, Action<SavedGameRequestStatus, ISavedGameMetadata> callback);

		void OpenWithManualConflictResolution(string filename, DataSource source, bool prefetchDataOnConflict, ConflictCallback conflictCallback, Action<SavedGameRequestStatus, ISavedGameMetadata> completedCallback);

		void ReadBinaryData(ISavedGameMetadata metadata, Action<SavedGameRequestStatus, byte[]> completedCallback);

		void ShowSelectSavedGameUI(string uiTitle, uint maxDisplayedSavedGames, bool showCreateSaveUI, bool showDeleteSaveUI, Action<SelectUIStatus, ISavedGameMetadata> callback);

		void CommitUpdate(ISavedGameMetadata metadata, SavedGameMetadataUpdate updateForMetadata, byte[] updatedBinaryData, Action<SavedGameRequestStatus, ISavedGameMetadata> callback);

		void FetchAllSavedGames(DataSource source, Action<SavedGameRequestStatus, List<ISavedGameMetadata>> callback);

		void Delete(ISavedGameMetadata metadata);
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
