using System;
using System.Collections.Generic;
using UnityEngine;

namespace Fabric.Answers.Internal
{
	internal class AnswersEventInstanceJavaObject
	{
		public AndroidJavaObject javaObject;

		public AnswersEventInstanceJavaObject(string eventType, Dictionary<string, object> customAttributes, params string[] args)
		{
			javaObject = new AndroidJavaObject(string.Format("com.crashlytics.android.answers.{0}", eventType), args);
			foreach (KeyValuePair<string, object> customAttribute in customAttributes)
			{
				string key = customAttribute.Key;
				object value = customAttribute.Value;
				if (value == null)
				{
					Debug.Log(string.Format("[Answers] Expected custom attribute value to be non-null. Received: {0}", value));
				}
				else if (IsNumericType(value))
				{
					javaObject.Call<AndroidJavaObject>("putCustomAttribute", new object[2]
					{
						key,
						AsDouble(value)
					});
				}
				else if (value is string)
				{
					javaObject.Call<AndroidJavaObject>("putCustomAttribute", new object[2] { key, value });
				}
				else
				{
					Debug.Log(string.Format("[Answers] Expected custom attribute value to be a string or numeric. Received: {0}", value));
				}
			}
		}

		public void PutMethod(string method)
		{
			InvokeSafelyAsString("putMethod", method);
		}

		public void PutSuccess(bool? success)
		{
			InvokeSafelyAsBoolean("putSuccess", success);
		}

		public void PutContentName(string contentName)
		{
			InvokeSafelyAsString("putContentName", contentName);
		}

		public void PutContentType(string contentType)
		{
			InvokeSafelyAsString("putContentType", contentType);
		}

		public void PutContentId(string contentId)
		{
			InvokeSafelyAsString("putContentId", contentId);
		}

		public void PutCurrency(string currency)
		{
			InvokeSafelyAsCurrency("putCurrency", currency);
		}

		public void InvokeSafelyAsCurrency(string methodName, string currency)
		{
			if (currency != null)
			{
				AndroidJavaObject androidJavaObject = new AndroidJavaClass("java.util.Currency").CallStatic<AndroidJavaObject>("getInstance", new object[1] { currency });
				javaObject.Call<AndroidJavaObject>("putCurrency", new object[1] { androidJavaObject });
			}
		}

		public void InvokeSafelyAsBoolean(string methodName, bool? arg)
		{
			if (arg.HasValue)
			{
				javaObject.Call<AndroidJavaObject>(methodName, new object[1] { arg });
			}
		}

		public void InvokeSafelyAsInt(string methodName, int? arg)
		{
			if (arg.HasValue)
			{
				javaObject.Call<AndroidJavaObject>(methodName, new object[1] { arg });
			}
		}

		public void InvokeSafelyAsString(string methodName, string arg)
		{
			if (arg != null)
			{
				javaObject.Call<AndroidJavaObject>(methodName, new object[1] { arg });
			}
		}

		public void InvokeSafelyAsDecimal(string methodName, object arg)
		{
			if (arg != null)
			{
				javaObject.Call<AndroidJavaObject>(methodName, new object[1]
				{
					new AndroidJavaObject("java.math.BigDecimal", arg.ToString())
				});
			}
		}

		public void InvokeSafelyAsDouble(string methodName, object arg)
		{
			if (arg != null)
			{
				javaObject.Call<AndroidJavaObject>(methodName, new object[1] { AsDouble(arg) });
			}
		}

		private static bool IsNumericType(object o)
		{
			TypeCode typeCode = Type.GetTypeCode(o.GetType());
			if ((uint)(typeCode - 5) <= 10u)
			{
				return true;
			}
			return false;
		}

		private static AndroidJavaObject AsDouble(object param)
		{
			return new AndroidJavaObject("java.lang.Double", param.ToString());
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
