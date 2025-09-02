using System;
using Google.Developers;

namespace Com.Google.Android.Gms.Common.Api
{
	public class PendingResult<R> : JavaObjWrapper where R : Result
	{
		private const string CLASS_NAME = "com/google/android/gms/common/api/PendingResult";

		public PendingResult(IntPtr ptr)
			: base(ptr)
		{
		}

		public PendingResult()
			: base("com.google.android.gms.common.api.PendingResult")
		{
		}

		public R await(long arg_long_1, object arg_object_2)
		{
			return InvokeCall<R>("await", "(JLjava/util/concurrent/TimeUnit;)Lcom/google/android/gms/common/api/Result;", new object[2] { arg_long_1, arg_object_2 });
		}

		public R await()
		{
			return InvokeCall<R>("await", "()Lcom/google/android/gms/common/api/Result;", Array.Empty<object>());
		}

		public bool isCanceled()
		{
			return InvokeCall<bool>("isCanceled", "()Z", Array.Empty<object>());
		}

		public void cancel()
		{
			InvokeCallVoid("cancel", "()V");
		}

		public void setResultCallback(ResultCallback<R> arg_ResultCallback_1)
		{
			InvokeCallVoid("setResultCallback", "(Lcom/google/android/gms/common/api/ResultCallback;)V", arg_ResultCallback_1);
		}

		public void setResultCallback(ResultCallback<R> arg_ResultCallback_1, long arg_long_2, object arg_object_3)
		{
			InvokeCallVoid("setResultCallback", "(Lcom/google/android/gms/common/api/ResultCallback;JLjava/util/concurrent/TimeUnit;)V", arg_ResultCallback_1, arg_long_2, arg_object_3);
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
