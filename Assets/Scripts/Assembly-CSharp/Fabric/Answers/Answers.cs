using System.Collections.Generic;
using Fabric.Answers.Internal;
using UnityEngine;

namespace Fabric.Answers
{
	public class Answers : MonoBehaviour
	{
		private static IAnswers implementation;

		private static IAnswers Implementation
		{
			get
			{
				if (implementation == null)
				{
					implementation = new AnswersAndroidImplementation();
				}
				return implementation;
			}
		}

		public static void LogSignUp(string method = null, bool? success = null, Dictionary<string, object> customAttributes = null)
		{
			if (customAttributes == null)
			{
				customAttributes = new Dictionary<string, object>();
			}
			Implementation.LogSignUp(method, success, customAttributes);
		}

		public static void LogLogin(string method = null, bool? success = null, Dictionary<string, object> customAttributes = null)
		{
			if (customAttributes == null)
			{
				customAttributes = new Dictionary<string, object>();
			}
			Implementation.LogLogin(method, success, customAttributes);
		}

		public static void LogShare(string method = null, string contentName = null, string contentType = null, string contentId = null, Dictionary<string, object> customAttributes = null)
		{
			if (customAttributes == null)
			{
				customAttributes = new Dictionary<string, object>();
			}
			Implementation.LogShare(method, contentName, contentType, contentId, customAttributes);
		}

		public static void LogInvite(string method = null, Dictionary<string, object> customAttributes = null)
		{
			if (customAttributes == null)
			{
				customAttributes = new Dictionary<string, object>();
			}
			Implementation.LogInvite(method, customAttributes);
		}

		public static void LogLevelStart(string level = null, Dictionary<string, object> customAttributes = null)
		{
			if (customAttributes == null)
			{
				customAttributes = new Dictionary<string, object>();
			}
			Implementation.LogLevelStart(level, customAttributes);
		}

		public static void LogLevelEnd(string level = null, double? score = null, bool? success = null, Dictionary<string, object> customAttributes = null)
		{
			if (customAttributes == null)
			{
				customAttributes = new Dictionary<string, object>();
			}
			Implementation.LogLevelEnd(level, score, success, customAttributes);
		}

		public static void LogAddToCart(decimal? itemPrice = null, string currency = null, string itemName = null, string itemType = null, string itemId = null, Dictionary<string, object> customAttributes = null)
		{
			if (customAttributes == null)
			{
				customAttributes = new Dictionary<string, object>();
			}
			Implementation.LogAddToCart(itemPrice, currency, itemName, itemType, itemId, customAttributes);
		}

		public static void LogPurchase(decimal? price = null, string currency = null, bool? success = null, string itemName = null, string itemType = null, string itemId = null, Dictionary<string, object> customAttributes = null)
		{
			if (customAttributes == null)
			{
				customAttributes = new Dictionary<string, object>();
			}
			Implementation.LogPurchase(price, currency, success, itemName, itemType, itemId, customAttributes);
		}

		public static void LogStartCheckout(decimal? totalPrice = null, string currency = null, int? itemCount = null, Dictionary<string, object> customAttributes = null)
		{
			if (customAttributes == null)
			{
				customAttributes = new Dictionary<string, object>();
			}
			Implementation.LogStartCheckout(totalPrice, currency, itemCount, customAttributes);
		}

		public static void LogRating(int? rating = null, string contentName = null, string contentType = null, string contentId = null, Dictionary<string, object> customAttributes = null)
		{
			if (customAttributes == null)
			{
				customAttributes = new Dictionary<string, object>();
			}
			Implementation.LogRating(rating, contentName, contentType, contentId, customAttributes);
		}

		public static void LogContentView(string contentName = null, string contentType = null, string contentId = null, Dictionary<string, object> customAttributes = null)
		{
			if (customAttributes == null)
			{
				customAttributes = new Dictionary<string, object>();
			}
			Implementation.LogContentView(contentName, contentType, contentId, customAttributes);
		}

		public static void LogSearch(string query = null, Dictionary<string, object> customAttributes = null)
		{
			if (customAttributes == null)
			{
				customAttributes = new Dictionary<string, object>();
			}
			Implementation.LogSearch(query, customAttributes);
		}

		public static void LogCustom(string eventName, Dictionary<string, object> customAttributes = null)
		{
			if (eventName == null)
			{
				Debug.Log("Answers' Custom Events require event names. Skipping this event because its name is null.");
				return;
			}
			if (customAttributes == null)
			{
				customAttributes = new Dictionary<string, object>();
			}
			Implementation.LogCustom(eventName, customAttributes);
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
