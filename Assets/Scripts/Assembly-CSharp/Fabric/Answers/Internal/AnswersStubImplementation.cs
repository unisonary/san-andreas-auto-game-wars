using System.Collections.Generic;
using UnityEngine;

namespace Fabric.Answers.Internal
{
	internal class AnswersStubImplementation : IAnswers
	{
		public AnswersStubImplementation()
		{
			Debug.Log("Answers will no-op because it was initialized for a non-Android, non-Apple platform.");
		}

		public void LogSignUp(string method, bool? success, Dictionary<string, object> customAttributes)
		{
		}

		public void LogLogin(string method, bool? success, Dictionary<string, object> customAttributes)
		{
		}

		public void LogShare(string method, string contentName, string contentType, string contentId, Dictionary<string, object> customAttributes)
		{
		}

		public void LogInvite(string method, Dictionary<string, object> customAttributes)
		{
		}

		public void LogLevelStart(string level, Dictionary<string, object> customAttributes)
		{
		}

		public void LogLevelEnd(string level, double? score, bool? success, Dictionary<string, object> customAttributes)
		{
		}

		public void LogAddToCart(decimal? itemPrice, string currency, string itemName, string itemType, string itemId, Dictionary<string, object> customAttributes)
		{
		}

		public void LogPurchase(decimal? price, string currency, bool? success, string itemName, string itemType, string itemId, Dictionary<string, object> customAttributes)
		{
		}

		public void LogStartCheckout(decimal? totalPrice, string currency, int? itemCount, Dictionary<string, object> customAttributes)
		{
		}

		public void LogRating(int? rating, string contentName, string contentType, string contentId, Dictionary<string, object> customAttributes)
		{
		}

		public void LogContentView(string contentName, string contentType, string contentId, Dictionary<string, object> customAttributes)
		{
		}

		public void LogSearch(string query, Dictionary<string, object> customAttributes)
		{
		}

		public void LogCustom(string eventName, Dictionary<string, object> customAttributes)
		{
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
