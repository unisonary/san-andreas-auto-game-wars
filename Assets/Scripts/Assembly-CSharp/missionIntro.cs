using UnityEngine;

public class missionIntro : MonoBehaviour
{
	public GameObject[] movefrom_obj;

	public GameObject[] movefrom_obj2;

	public GameObject[] scalefrom_obj;

	private void Start()
	{
		float num = 1f;
		GameObject[] array = movefrom_obj;
		foreach (GameObject gameObject in array)
		{
			if (gameObject != null)
			{
				iTween.MoveFrom(gameObject, iTween.Hash("y", gameObject.transform.position.y + 600f, "time", 0.2f, "delay", num, "easetype", iTween.EaseType.easeOutCubic));
			}
			num += 0.1f;
		}
		num = 0.2f;
		array = scalefrom_obj;
		for (int i = 0; i < array.Length; i++)
		{
			iTween.ScaleFrom(array[i], iTween.Hash("Scale", Vector3.zero, "time", 0.3f, "delay", num));
			num += 0.15f;
		}
		num = 0.1f;
		array = movefrom_obj2;
		foreach (GameObject gameObject2 in array)
		{
			if (gameObject2 != null)
			{
				iTween.MoveFrom(gameObject2, iTween.Hash("y", gameObject2.transform.position.y - 550f, "time", 0.2f, "delay", num, "easetype", iTween.EaseType.easeOutCubic));
			}
			num += 0.1f;
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
