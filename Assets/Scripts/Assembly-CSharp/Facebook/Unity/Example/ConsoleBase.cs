using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Facebook.Unity.Example
{
	internal class ConsoleBase : MonoBehaviour
	{
		private const int DpiScalingFactor = 160;

		private static Stack<string> menuStack = new Stack<string>();

		private string status = "Ready";

		private string lastResponse = string.Empty;

		private Vector2 scrollPosition = Vector2.zero;

		private float? scaleFactor;

		private GUIStyle textStyle;

		private GUIStyle buttonStyle;

		private GUIStyle textInputStyle;

		private GUIStyle labelStyle;

		protected static int ButtonHeight
		{
			get
			{
				if (!Constants.IsMobile)
				{
					return 24;
				}
				return 60;
			}
		}

		protected static int MainWindowWidth
		{
			get
			{
				if (!Constants.IsMobile)
				{
					return 700;
				}
				return Screen.width - 30;
			}
		}

		protected static int MainWindowFullWidth
		{
			get
			{
				if (!Constants.IsMobile)
				{
					return 760;
				}
				return Screen.width;
			}
		}

		protected static int MarginFix
		{
			get
			{
				if (!Constants.IsMobile)
				{
					return 48;
				}
				return 0;
			}
		}

		protected static Stack<string> MenuStack
		{
			get
			{
				return menuStack;
			}
			set
			{
				menuStack = value;
			}
		}

		protected string Status
		{
			get
			{
				return status;
			}
			set
			{
				status = value;
			}
		}

		protected Texture2D LastResponseTexture { get; set; }

		protected string LastResponse
		{
			get
			{
				return lastResponse;
			}
			set
			{
				lastResponse = value;
			}
		}

		protected Vector2 ScrollPosition
		{
			get
			{
				return scrollPosition;
			}
			set
			{
				scrollPosition = value;
			}
		}

		protected float ScaleFactor
		{
			get
			{
				if (!scaleFactor.HasValue)
				{
					scaleFactor = Screen.dpi / 160f;
				}
				return scaleFactor.Value;
			}
		}

		protected int FontSize
		{
			get
			{
				return (int)Math.Round(ScaleFactor * 16f);
			}
		}

		protected GUIStyle TextStyle
		{
			get
			{
				if (textStyle == null)
				{
					textStyle = new GUIStyle(GUI.skin.textArea);
					textStyle.alignment = TextAnchor.UpperLeft;
					textStyle.wordWrap = true;
					textStyle.padding = new RectOffset(10, 10, 10, 10);
					textStyle.stretchHeight = true;
					textStyle.stretchWidth = false;
					textStyle.fontSize = FontSize;
				}
				return textStyle;
			}
		}

		protected GUIStyle ButtonStyle
		{
			get
			{
				if (buttonStyle == null)
				{
					buttonStyle = new GUIStyle(GUI.skin.button);
					buttonStyle.fontSize = FontSize;
				}
				return buttonStyle;
			}
		}

		protected GUIStyle TextInputStyle
		{
			get
			{
				if (textInputStyle == null)
				{
					textInputStyle = new GUIStyle(GUI.skin.textField);
					textInputStyle.fontSize = FontSize;
				}
				return textInputStyle;
			}
		}

		protected GUIStyle LabelStyle
		{
			get
			{
				if (labelStyle == null)
				{
					labelStyle = new GUIStyle(GUI.skin.label);
					labelStyle.fontSize = FontSize;
				}
				return labelStyle;
			}
		}

		protected virtual void Awake()
		{
			Application.targetFrameRate = 60;
		}

		protected bool Button(string label)
		{
			return GUILayout.Button(label, ButtonStyle, GUILayout.MinHeight((float)ButtonHeight * ScaleFactor), GUILayout.MaxWidth(MainWindowWidth));
		}

		protected void LabelAndTextField(string label, ref string text)
		{
			GUILayout.BeginHorizontal();
			GUILayout.Label(label, LabelStyle, GUILayout.MaxWidth(200f * ScaleFactor));
			text = GUILayout.TextField(text, TextInputStyle, GUILayout.MaxWidth(MainWindowWidth - 150));
			GUILayout.EndHorizontal();
		}

		protected bool IsHorizontalLayout()
		{
			return Screen.orientation == ScreenOrientation.LandscapeLeft;
		}

		protected void SwitchMenu(Type menuClass)
		{
			menuStack.Push(GetType().Name);
			SceneManager.LoadScene(menuClass.Name);
		}

		protected void GoBack()
		{
			if (Enumerable.Any(menuStack))
			{
				SceneManager.LoadScene(menuStack.Pop());
			}
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
