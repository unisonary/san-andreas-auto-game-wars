using UnityEngine;
using UnityEngine.UI;

public class ButtonAnims : MonoBehaviour
{
	public MoveUIBase[] _buttons;

	private bool firstTime;

	public bool blackScreen;

	public bool mb_IsOnStart;

	public GameObject _blackTexture;

	private void OnEnable()
	{
		if (!firstTime)
		{
			firstTime = true;
		}
	}

	private void Start()
	{
		_buttons = base.gameObject.GetComponentsInChildren<MoveUIBase>();
		if (mb_IsOnStart)
		{
			CallAllAnims();
		}
	}

	public void CallAllAnims()
	{
		Debug.Log("showanims");
		if (blackScreen)
		{
			_blackTexture.GetComponent<Image>().enabled = true;
		}
		for (int i = 0; i < _buttons.Length; i++)
		{
			if (_buttons[i] != null)
			{
				_buttons[i].CallStart();
			}
		}
	}

	public void ReverseAll()
	{
		if (blackScreen)
		{
			_blackTexture.GetComponent<Image>().enabled = false;
		}
		for (int i = 0; i < _buttons.Length; i++)
		{
			if (_buttons[i] != null)
			{
				_buttons[i].Reverse();
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
