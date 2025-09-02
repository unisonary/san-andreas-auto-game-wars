using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Facebook.Unity.Example
{
	internal class LogView : ConsoleBase
	{
		private static string datePatt = "M/d/yyyy hh:mm:ss tt";

		private static IList<string> events = new List<string>();

		public static void AddLog(string log)
		{
			events.Insert(0, string.Format("{0}\n{1}\n", DateTime.Now.ToString(datePatt), log));
		}

		protected void OnGUI()
		{
			GUILayout.BeginVertical();
			if (Button("Back"))
			{
				GoBack();
			}
			if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
			{
				Vector2 vector = base.ScrollPosition;
				vector.y += Input.GetTouch(0).deltaPosition.y;
				base.ScrollPosition = vector;
			}
			base.ScrollPosition = GUILayout.BeginScrollView(base.ScrollPosition, GUILayout.MinWidth(ConsoleBase.MainWindowFullWidth));
			GUILayout.TextArea(string.Join("\n", Enumerable.ToArray(events)), base.TextStyle, GUILayout.ExpandHeight(true), GUILayout.MaxWidth(ConsoleBase.MainWindowWidth));
			GUILayout.EndScrollView();
			GUILayout.EndVertical();
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
