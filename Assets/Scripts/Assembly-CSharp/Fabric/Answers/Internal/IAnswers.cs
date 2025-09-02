using System.Collections.Generic;

namespace Fabric.Answers.Internal
{
	internal interface IAnswers
	{
		void LogSignUp(string method, bool? success, Dictionary<string, object> customAttributes);

		void LogLogin(string method, bool? success, Dictionary<string, object> customAttributes);

		void LogShare(string method, string contentName, string contentType, string contentId, Dictionary<string, object> customAttributes);

		void LogInvite(string method, Dictionary<string, object> customAttributes);

		void LogLevelStart(string level, Dictionary<string, object> customAttributes);

		void LogLevelEnd(string level, double? score, bool? success, Dictionary<string, object> customAttributes);

		void LogPurchase(decimal? price, string currency, bool? success, string itemName, string itemType, string itemId, Dictionary<string, object> customAttributes);

		void LogAddToCart(decimal? itemPrice, string currency, string itemName, string itemType, string itemId, Dictionary<string, object> customAttributes);

		void LogStartCheckout(decimal? totalPrice, string currency, int? itemCount, Dictionary<string, object> customAttributes);

		void LogRating(int? rating, string contentName, string contentType, string contentId, Dictionary<string, object> customAttributes);

		void LogContentView(string contentName, string contentType, string contentId, Dictionary<string, object> customAttributes);

		void LogSearch(string query, Dictionary<string, object> customAttributes);

		void LogCustom(string eventName, Dictionary<string, object> customAttributes);
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
