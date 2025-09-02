using UnityEngine;

namespace Facebook.Unity.Example
{
	internal class Pay : MenuBase
	{
		private string payProduct = string.Empty;

		protected override void GetGui()
		{
			LabelAndTextField("Product: ", ref payProduct);
			if (Button("Call Pay"))
			{
				CallFBPay();
			}
			GUILayout.Space(10f);
		}

		private void CallFBPay()
		{
			FB.Canvas.Pay(payProduct, "purchaseitem", 1, null, null, null, null, null, base.HandleResult);
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
