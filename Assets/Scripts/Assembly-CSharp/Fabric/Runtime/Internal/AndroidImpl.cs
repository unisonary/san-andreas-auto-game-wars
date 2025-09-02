using System;
using UnityEngine;

namespace Fabric.Runtime.Internal
{
	internal class AndroidImpl : Impl
	{
		private static readonly AndroidJavaClass FabricInitializer = new AndroidJavaClass("io.fabric.unity.android.FabricInitializer");

		public override string Initialize()
		{
			return FabricInitializer.CallStatic<string>("JNI_InitializeFabric", Array.Empty<object>());
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
