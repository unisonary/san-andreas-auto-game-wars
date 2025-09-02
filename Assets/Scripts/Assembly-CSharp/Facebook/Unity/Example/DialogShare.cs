using System;
using UnityEngine;

namespace Facebook.Unity.Example
{
	internal class DialogShare : MenuBase
	{
		private string shareLink = "https://developers.facebook.com/";

		private string shareTitle = "Link Title";

		private string shareDescription = "Link Description";

		private string shareImage = "http://i.imgur.com/j4M7vCO.jpg";

		private string feedTo = string.Empty;

		private string feedLink = "https://developers.facebook.com/";

		private string feedTitle = "Test Title";

		private string feedCaption = "Test Caption";

		private string feedDescription = "Test Description";

		private string feedImage = "http://i.imgur.com/zkYlB.jpg";

		private string feedMediaSource = string.Empty;

		protected override bool ShowDialogModeSelector()
		{
			return true;
		}

		protected override void GetGui()
		{
			bool num = GUI.enabled;
			if (Button("Share - Link"))
			{
				FB.ShareLink(new Uri("https://developers.facebook.com/"), "", "", null, base.HandleResult);
			}
			if (Button("Share - Link Photo"))
			{
				FB.ShareLink(new Uri("https://developers.facebook.com/"), "Link Share", "Look I'm sharing a link", new Uri("http://i.imgur.com/j4M7vCO.jpg"), base.HandleResult);
			}
			LabelAndTextField("Link", ref shareLink);
			LabelAndTextField("Title", ref shareTitle);
			LabelAndTextField("Description", ref shareDescription);
			LabelAndTextField("Image", ref shareImage);
			if (Button("Share - Custom"))
			{
				FB.ShareLink(new Uri(shareLink), shareTitle, shareDescription, new Uri(shareImage), base.HandleResult);
			}
			GUI.enabled = num && (!Constants.IsEditor || (Constants.IsEditor && FB.IsLoggedIn));
			if (Button("Feed Share - No To"))
			{
				FB.FeedShare(string.Empty, new Uri("https://developers.facebook.com/"), "Test Title", "Test caption", "Test Description", new Uri("http://i.imgur.com/zkYlB.jpg"), string.Empty, base.HandleResult);
			}
			LabelAndTextField("To", ref feedTo);
			LabelAndTextField("Link", ref feedLink);
			LabelAndTextField("Title", ref feedTitle);
			LabelAndTextField("Caption", ref feedCaption);
			LabelAndTextField("Description", ref feedDescription);
			LabelAndTextField("Image", ref feedImage);
			LabelAndTextField("Media Source", ref feedMediaSource);
			if (Button("Feed Share - Custom"))
			{
				FB.FeedShare(feedTo, string.IsNullOrEmpty(feedLink) ? null : new Uri(feedLink), feedTitle, feedCaption, feedDescription, string.IsNullOrEmpty(feedImage) ? null : new Uri(feedImage), feedMediaSource, base.HandleResult);
			}
			GUI.enabled = num;
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
