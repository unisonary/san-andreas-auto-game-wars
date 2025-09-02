using UnityEngine;
using UnityEngine.UI;

public class MoveUIBase : MonoBehaviour
{
	public bool xDir;

	public bool yDir;

	public bool left;

	public bool up;

	public bool scale;

	public bool popup;

	public bool directPlay;

	public float distance;

	public float time;

	public float delay;

	public float revdelay;

	public float alphaVal;

	public float _val;

	public iTween.EaseType effectType;

	public iTween.LoopType loopType;

	public int addValue;

	public Vector3 _pos;

	public bool alphaFade;

	public bool withReverse;

	public bool moveToPos;

	[Space(15f)]
	public bool IsText;

	public Color _textColor = Color.white;

	private void Awake()
	{
		if (_val == 0f)
		{
			_val = base.transform.localScale.x - 0.5f;
		}
		if (addValue == 0)
		{
			addValue = 1;
		}
		if (alphaVal == 0f)
		{
			alphaVal = 1f;
		}
		if (time == 0f)
		{
			time = 1f;
		}
		if (xDir)
		{
			Vector3 position = base.transform.position;
			_val = position.x;
			if (left)
			{
				position.x -= addValue;
			}
			else
			{
				position.x += addValue;
			}
			base.transform.position = position;
		}
		if (yDir)
		{
			Vector3 position2 = base.transform.position;
			_val = position2.y;
			if (up)
			{
				position2.y += addValue;
			}
			else
			{
				position2.y -= addValue;
			}
			base.transform.position = position2;
		}
		if (directPlay)
		{
			CallStart();
		}
		if (IsText && alphaFade)
		{
			base.gameObject.GetComponent<Text>().color = new Color(_textColor.r, _textColor.g, _textColor.b, 0f);
		}
		else
		{
			_textColor = base.gameObject.GetComponent<Image>().color;
		}
	}

	public void CallStart()
	{
		if (popup)
		{
			iTween.ScaleFrom(base.gameObject, iTween.Hash("x", _val, "y", _val, "time", time, "delay", delay, "looptype", loopType, "easetype", effectType));
		}
		if (scale)
		{
			iTween.ScaleAdd(base.gameObject, iTween.Hash("x", -0.5f, "y", -0.5f, "time", time, "delay", delay, "looptype", loopType, "easetype", effectType));
		}
		if (alphaFade)
		{
			if (IsText)
			{
				_textColor = _textColor;
				iTween.ValueTo(base.gameObject, iTween.Hash("from", base.gameObject.GetComponent<Text>().color.a, "to", alphaVal, "time", time - 0.1f, "delay", delay, "easetype", effectType, "onupdate", "TextFade", "oncomplete", "OnTextFadeComplete", "oncompletetarget", base.gameObject));
			}
			else
			{
				iTween.ValueTo(base.gameObject, iTween.Hash("from", base.gameObject.GetComponent<Image>().color.a, "to", alphaVal, "time", time - 0.1f, "delay", delay, "easetype", effectType, "onupdate", "SpriteFade", "oncomplete", "OnSpriteFadeComplete", "oncompletetarget", base.gameObject));
			}
		}
		if (moveToPos)
		{
			iTween.MoveTo(base.gameObject, iTween.Hash("position", _pos, "looptype", loopType, "time", time, "easeType", effectType, "delay", delay));
		}
		if (!alphaFade)
		{
			Call();
		}
	}

	public void TextFade(float value)
	{
		base.gameObject.GetComponent<Text>().color = new Color(base.gameObject.GetComponent<Text>().color.r, base.gameObject.GetComponent<Text>().color.g, base.gameObject.GetComponent<Text>().color.b, value);
	}

	public void OnTextFadeComplete()
	{
		base.gameObject.GetComponent<Text>().color = new Color(base.gameObject.GetComponent<Text>().color.r, base.gameObject.GetComponent<Text>().color.g, base.gameObject.GetComponent<Text>().color.b, alphaVal);
	}

	public void SpriteFade(float value)
	{
		base.gameObject.GetComponent<Image>().color = new Color(base.gameObject.GetComponent<Image>().color.r, base.gameObject.GetComponent<Image>().color.g, base.gameObject.GetComponent<Image>().color.b, value);
	}

	public void OnSpriteFadeComplete()
	{
		base.gameObject.GetComponent<Image>().color = new Color(base.gameObject.GetComponent<Image>().color.r, base.gameObject.GetComponent<Image>().color.g, base.gameObject.GetComponent<Image>().color.b, alphaVal);
	}

	public void OnSpriteFadeReverseComplete()
	{
		base.gameObject.GetComponent<Image>().color = new Color(base.gameObject.GetComponent<Image>().color.r, base.gameObject.GetComponent<Image>().color.g, base.gameObject.GetComponent<Image>().color.b, 0f);
	}

	public void OnTextFadeReverseComplete()
	{
		base.gameObject.GetComponent<Text>().color = new Color(base.gameObject.GetComponent<Text>().color.r, base.gameObject.GetComponent<Text>().color.g, base.gameObject.GetComponent<Text>().color.b, 0f);
	}

	private void Call()
	{
		if (xDir)
		{
			iTween.MoveTo(base.gameObject, iTween.Hash("x", _val, "looptype", loopType, "time", time, "easeType", effectType, "delay", delay));
		}
		if (yDir)
		{
			iTween.MoveTo(base.gameObject, iTween.Hash("y", _val, "looptype", loopType, "time", time, "easeType", effectType, "delay", delay));
		}
	}

	public void Reverse()
	{
		if (xDir)
		{
			if (left)
			{
				iTween.MoveTo(base.gameObject, iTween.Hash("x", _val - 1f, "looptype", loopType, "time", time, "delay", revdelay, "easeType", effectType));
			}
			else
			{
				iTween.MoveTo(base.gameObject, iTween.Hash("x", _val + 1f, "looptype", loopType, "time", time, "delay", revdelay, "easeType", effectType));
			}
		}
		if (yDir)
		{
			if (up)
			{
				iTween.MoveTo(base.gameObject, iTween.Hash("y", _val + 1f, "looptype", loopType, "time", time, "delay", revdelay, "easeType", effectType));
			}
			else
			{
				iTween.MoveTo(base.gameObject, iTween.Hash("y", _val - 1f, "looptype", loopType, "time", time, "delay", revdelay, "easeType", effectType));
			}
		}
		if (alphaFade)
		{
			if (IsText)
			{
				iTween.ValueTo(base.gameObject, iTween.Hash("from", base.gameObject.GetComponent<Text>().color.a, "to", 0, "time", time, "delay", revdelay, "easetype", effectType, "onupdate", "TextFade", "oncomplete", "OnTextFadeReverseComplete", "oncompletetarget", base.gameObject));
			}
			else
			{
				iTween.ValueTo(base.gameObject, iTween.Hash("from", base.gameObject.GetComponent<Image>().color.a, "to", _textColor.a, "time", time, "delay", revdelay, "easetype", effectType, "onupdate", "SpriteFade", "oncomplete", "OnSpriteFadeReverseComplete", "oncompletetarget", base.gameObject));
			}
		}
	}

	public void CallWithReverse()
	{
		if (xDir)
		{
			iTween.MoveTo(base.gameObject, iTween.Hash("x", _val, "delay", delay, "looptype", loopType, "time", time, "easeType", effectType));
		}
		if (yDir)
		{
			iTween.MoveTo(base.gameObject, iTween.Hash("y", _val, "delay", delay, "looptype", loopType, "time", time, "easeType", effectType));
		}
		Invoke("Reverse", time + 1f);
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
