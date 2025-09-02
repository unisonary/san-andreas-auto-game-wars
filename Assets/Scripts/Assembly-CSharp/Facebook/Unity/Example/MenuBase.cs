using System;
using System.Linq;
using UnityEngine;

namespace Facebook.Unity.Example
{
	internal abstract class MenuBase : ConsoleBase
	{
		private static ShareDialogMode shareDialogMode;

		protected abstract void GetGui();

		protected virtual bool ShowDialogModeSelector()
		{
			return false;
		}

		protected virtual bool ShowBackButton()
		{
			return true;
		}

		protected void HandleResult(IResult result)
		{
			if (result == null)
			{
				base.LastResponse = "Null Response\n";
				LogView.AddLog(base.LastResponse);
				return;
			}
			base.LastResponseTexture = null;
			if (!string.IsNullOrEmpty(result.Error))
			{
				base.Status = "Error - Check log for details";
				base.LastResponse = "Error Response:\n" + result.Error;
			}
			else if (result.Cancelled)
			{
				base.Status = "Cancelled - Check log for details";
				base.LastResponse = "Cancelled Response:\n" + result.RawResult;
			}
			else if (!string.IsNullOrEmpty(result.RawResult))
			{
				base.Status = "Success - Check log for details";
				base.LastResponse = "Success Response:\n" + result.RawResult;
			}
			else
			{
				base.LastResponse = "Empty Response\n";
			}
			LogView.AddLog(result.ToString());
		}

		protected void OnGUI()
		{
			if (IsHorizontalLayout())
			{
				GUILayout.BeginHorizontal();
				GUILayout.BeginVertical();
			}
			GUILayout.Label(GetType().Name, base.LabelStyle);
			AddStatus();
			if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
			{
				Vector2 vector = base.ScrollPosition;
				vector.y += Input.GetTouch(0).deltaPosition.y;
				base.ScrollPosition = vector;
			}
			base.ScrollPosition = GUILayout.BeginScrollView(base.ScrollPosition, GUILayout.MinWidth(ConsoleBase.MainWindowFullWidth));
			GUILayout.BeginHorizontal();
			if (ShowBackButton())
			{
				AddBackButton();
			}
			AddLogButton();
			if (ShowBackButton())
			{
				GUILayout.Label(GUIContent.none, GUILayout.MinWidth(ConsoleBase.MarginFix));
			}
			GUILayout.EndHorizontal();
			if (ShowDialogModeSelector())
			{
				AddDialogModeButtons();
			}
			GUILayout.BeginVertical();
			GetGui();
			GUILayout.Space(10f);
			GUILayout.EndVertical();
			GUILayout.EndScrollView();
		}

		private void AddStatus()
		{
			GUILayout.Space(5f);
			GUILayout.Box("Status: " + base.Status, base.TextStyle, GUILayout.MinWidth(ConsoleBase.MainWindowWidth));
		}

		private void AddBackButton()
		{
			GUI.enabled = Enumerable.Any(ConsoleBase.MenuStack);
			if (Button("Back"))
			{
				GoBack();
			}
			GUI.enabled = true;
		}

		private void AddLogButton()
		{
			if (Button("Log"))
			{
				SwitchMenu(typeof(LogView));
			}
		}

		private void AddDialogModeButtons()
		{
			GUILayout.BeginHorizontal();
			foreach (object value in Enum.GetValues(typeof(ShareDialogMode)))
			{
				AddDialogModeButton((ShareDialogMode)value);
			}
			GUILayout.EndHorizontal();
		}

		private void AddDialogModeButton(ShareDialogMode mode)
		{
			bool num = GUI.enabled;
			GUI.enabled = num && mode != shareDialogMode;
			if (Button(mode.ToString()))
			{
				shareDialogMode = mode;
				FB.Mobile.ShareDialogMode = mode;
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
