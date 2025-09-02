using System;
using UnityEngine;

namespace Fabric.Answers.Internal
{
	internal class AnswersSharedInstanceJavaObject
	{
		private AndroidJavaObject javaObject;

		public AnswersSharedInstanceJavaObject()
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.crashlytics.android.answers.Answers");
			javaObject = androidJavaClass.CallStatic<AndroidJavaObject>("getInstance", Array.Empty<object>());
		}

		public void Log(string methodName, AnswersEventInstanceJavaObject eventInstance)
		{
			javaObject.Call(methodName, eventInstance.javaObject);
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
