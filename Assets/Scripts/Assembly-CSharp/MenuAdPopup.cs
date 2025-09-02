using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuAdPopup : MonoBehaviour
{
	public Image MEnuAdImage;

	public static MenuAdPopup Instance;

	private string templinktoMenuad = "";

	private void Awake()
	{
		Instance = this;
		base.gameObject.SetActive(false);
	}

	public void ShowMenuAd(Texture2D tex)
	{
		base.gameObject.SetActive(true);
		MEnuAdImage.sprite = Sprite.Create(tex, new Rect(0f, 0f, tex.width, tex.height), new Vector2(0f, 0f));
	}

	public void clickOnAd()
	{
		Application.OpenURL(templinktoMenuad);
		base.gameObject.SetActive(false);
		if (SceneManager.GetActiveScene().buildIndex == 0)
		{
			SceneManager.LoadScene("Menu");
		}
	}

	public void Close()
	{
		if (SceneManager.GetActiveScene().buildIndex == 0)
		{
			SceneManager.LoadScene("Menu");
			Debug.Log("-- load menu Level ");
		}
		base.gameObject.SetActive(false);
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
