using UnityEngine;
using UnityEngine.UI;

public class WatchToUnlockWeapon : MonoBehaviour
{
	public int TotalViews;

	public int GunNum;

	public Text WatchText;

	private float buildTexPageWidth = 1280f;

	private float buildTexPageHeight = 800f;

	private void GuiTextureSizer(Image guitextureName, float textureWidth, float textureHeight)
	{
        RectTransform rectTransform = guitextureName.rectTransform;
        rectTransform.sizeDelta = new Vector2((float)Screen.width * (textureWidth / buildTexPageWidth), (float)Screen.height * (textureHeight / buildTexPageHeight));
        //guitextureName.pixelInset = new Rect(0f, 0f, (float)Screen.width * (textureWidth / buildTexPageWidth), (float)Screen.height * (textureHeight / buildTexPageHeight));
	}

	private void Start()
	{
		WatchText.text = "Watch " + TotalViews + " videos\nto unlock";
		WatchText.fontSize = Screen.width / 60;
	}

	private void Update()
	{
	}

	private void CheckCount()
	{
		TotalViews--;
		WatchText.text = "Watch " + TotalViews + " videos\nto unlock";
		if (TotalViews <= 0)
		{
			PlayerPrefs.SetInt(StoreManager.weaponsUnlockSystem[GunNum], 1);
			WeaponSelection.Instance.setUpDetails();
		}
	}

	public void OnMouseDown()
	{
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
