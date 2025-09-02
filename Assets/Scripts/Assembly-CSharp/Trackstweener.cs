using UnityEngine;
using UnityEngine.UI;

public class Trackstweener : MonoBehaviour
{
	public GameObject[] movefrom_obj;

	public GameObject[] fromLeft_obj;

	public GameObject[] scalefrom_obj;

	public GameObject[] fromRight_obj;

	public GameObject[] fromDown_obj;

	public Image[] Test;

	private int val = 500;

	private void OnEnable()
	{
		for (int i = 0; i < Test.Length; i++)
		{
			Test[i].raycastTarget = false;
		}
		Invoke("EnableRayCasts", 0.6f);
		float num = 0f;
		GameObject[] array = movefrom_obj;
		foreach (GameObject gameObject in array)
		{
			if (gameObject != null)
			{
				iTween.MoveFrom(gameObject, iTween.Hash("y", gameObject.transform.position.y + (float)val, "time", 1f, "delay", num, "easetype", iTween.EaseType.spring));
			}
			num += 0.1f;
		}
		num = 0.1f;
		array = fromLeft_obj;
		foreach (GameObject gameObject2 in array)
		{
			if (gameObject2 != null)
			{
				iTween.MoveFrom(gameObject2, iTween.Hash("x", gameObject2.transform.position.x - (float)val - 600f, "time", 1f, "delay", num, "easetype", iTween.EaseType.spring));
			}
			num += 0.1f;
		}
		num = 0.1f;
		array = scalefrom_obj;
		for (int j = 0; j < array.Length; j++)
		{
			iTween.ScaleFrom(array[j], iTween.Hash("Scale", Vector3.zero, "time", 0.5f, "delay", num, "easetype", iTween.EaseType.easeOutBack));
			num += 0.2f;
		}
		num = 0.1f;
		array = fromDown_obj;
		foreach (GameObject gameObject3 in array)
		{
			MonoBehaviour.print(gameObject3.name + " :a: " + gameObject3.transform.localPosition);
			if (gameObject3 != null)
			{
				iTween.MoveFrom(gameObject3, iTween.Hash("y", gameObject3.transform.position.y - (float)val, "time", 1f, "delay", num, "easetype", iTween.EaseType.spring));
			}
			num += 0.1f;
		}
		num = 0.1f;
		array = fromRight_obj;
		foreach (GameObject gameObject4 in array)
		{
			if (gameObject4 != null)
			{
				iTween.MoveFrom(gameObject4, iTween.Hash("x", gameObject4.transform.position.x + 2500f, "time", 1f, "delay", num, "easetype", iTween.EaseType.spring));
			}
			num += 0.2f;
		}
	}

	public void EnableRayCasts()
	{
		for (int i = 0; i < Test.Length; i++)
		{
			Test[i].raycastTarget = true;
		}
	}

	private void Update()
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
