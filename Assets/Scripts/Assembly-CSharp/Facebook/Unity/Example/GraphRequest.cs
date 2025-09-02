using System.Collections;
using UnityEngine;

namespace Facebook.Unity.Example
{
	internal class GraphRequest : MenuBase
	{
		private string apiQuery = string.Empty;

		private Texture2D profilePic;

		protected override void GetGui()
		{
			bool num = GUI.enabled;
			GUI.enabled = num && FB.IsLoggedIn;
			if (Button("Basic Request - Me"))
			{
				FB.API("/me", HttpMethod.GET, base.HandleResult);
			}
			if (Button("Retrieve Profile Photo"))
			{
				FB.API("/me/picture", HttpMethod.GET, ProfilePhotoCallback);
			}
			if (Button("Take and Upload screenshot"))
			{
				StartCoroutine(TakeScreenshot());
			}
			LabelAndTextField("Request", ref apiQuery);
			if (Button("Custom Request"))
			{
				FB.API(apiQuery, HttpMethod.GET, base.HandleResult);
			}
			if (profilePic != null)
			{
				GUILayout.Box(profilePic);
			}
			GUI.enabled = num;
		}

		private void ProfilePhotoCallback(IGraphResult result)
		{
			if (string.IsNullOrEmpty(result.Error) && result.Texture != null)
			{
				profilePic = result.Texture;
			}
			HandleResult(result);
		}

		private IEnumerator TakeScreenshot()
		{
			yield return new WaitForEndOfFrame();
			int width = Screen.width;
			int height = Screen.height;
			Texture2D texture2D = new Texture2D(width, height, TextureFormat.RGB24, false);
			texture2D.ReadPixels(new Rect(0f, 0f, width, height), 0, 0);
			texture2D.Apply();
			byte[] contents = texture2D.EncodeToPNG();
			WWWForm wWWForm = new WWWForm();
			wWWForm.AddBinaryData("image", contents, "InteractiveConsole.png");
			wWWForm.AddField("message", "herp derp.  I did a thing!  Did I do this right?");
			FB.API("me/photos", HttpMethod.POST, base.HandleResult, wWWForm);
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
