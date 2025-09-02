using UnityEngine;
using UnityEngine.UI;

public class LoadingProgressBar : MonoBehaviour
{
	private Rect _TextureCompleteRect;
    private RectTransform _rectTransform;

    private Rect _TextureCurrentRect;

	public float mf_Percentage;

	private float f_PercentageVisible = 1f;

	private bool Is_True;

	public Text LoadingPer;

	public Image LoadingBar;

	private void Start()
	{
		SetPercentage(0f);
	}

	private void SetBasicRect()
	{
        // Assuming your Image component is attached to the same GameObject
        _rectTransform = GetComponent<RectTransform>();

        // Set _TextureCompleteRect based on the initial RectTransform values
        _TextureCompleteRect = _rectTransform.rect;
       // _TextureCompleteRect = GetComponent<Image>().pixelInset;
        //_TextureCompleteRect = _rectTransform.rect;
        _TextureCurrentRect = _TextureCompleteRect;
		Is_True = true;
	}

	private void Update()
	{
		if (f_PercentageVisible != mf_Percentage && Is_True)
		{
			f_PercentageVisible = mf_Percentage;
			SetPercentage(f_PercentageVisible);
		}
		LoadingPer.text = "Loading... " + (int)mf_Percentage + "%";
		LoadingBar.gameObject.GetComponent<Image>().fillAmount = mf_Percentage / 100f;
	}

	private void SetPercentage(float percentageToShow)
	{
		float num = _TextureCompleteRect.width * (percentageToShow / 100f);
		if (num < 0f)
		{
			num = 0f;
		}
		else if (num > _TextureCompleteRect.width)
		{
			num = _TextureCompleteRect.width;
		}
		_TextureCurrentRect = new Rect(0f, 0f, num, _TextureCompleteRect.height);
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
