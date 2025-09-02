using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
	public static LoadingManager myScript;

	public static string SceneName = "";

	private AsyncOperation AsyncOp;

	private bool Is_ReadyToLoad;

	private float timerVal;

	private float targeTimer = 1f;

	public Text Text_Loading;

	public Text randomTxt;

	public float LoadingPer;

	[SerializeField]
	public LoadingProgressBar ProgressBar;

	public GameObject BG;

	public bool Is_ChangeSprite;

	public Sprite[] LaodingSprites;

	public string DefaultScene;

	public Slider _slider;

	private string[] HintTxts = new string[7] { "Tournament matches can get you the highest XP", "Double your score with a Fire Ball", "Score 3 consecutive baskets to make a Fire Ball", "Score 3 Stars and gain +100 XP instantly!", "Do not miss out on Bonus Shots", "Perfect Power makes perfect Shots!", "Perfect Power makes perfect Shots!" };

	private void Awake()
	{
		myScript = this;
	}

	private void Start()
	{
		checkSprite();
		Is_ReadyToLoad = false;
		timerVal = 0f;
		Text_Loading.text = "Loading... ";
		Invoke("LoadNextScene", 2f);
		LoadingPer = 0f;
		ProgressBar.mf_Percentage = 0f;
	}

	private void LoadNextScene()
	{
		StartCoroutine(loadLEvelTest());
	}

	private void checkSprite()
	{
	}

	private IEnumerator loadLEvelTest()
	{
		if (SceneName == "")
		{
			AsyncOp = Application.LoadLevelAsync(DefaultScene);
			AsyncOp.allowSceneActivation = false;
			yield return AsyncOp;
		}
		else
		{
			AsyncOp = Application.LoadLevelAsync(SceneName);
			AsyncOp.allowSceneActivation = false;
			yield return AsyncOp;
		}
	}

	private void Update()
	{
		if (!Is_ReadyToLoad && AsyncOp != null)
		{
			if (AsyncOp.progress >= 0.85f)
			{
				AsyncOp.allowSceneActivation = true;
				Is_ReadyToLoad = true;
			}
			LoadingPer = (int)(AsyncOp.progress * 100f);
			ProgressBar.mf_Percentage = (int)(AsyncOp.progress * 100f);
			_slider.value = (int)(AsyncOp.progress * 100f);
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
