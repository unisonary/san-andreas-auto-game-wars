using System.Collections.Generic;
using UnityEngine;

namespace STB.LowPolyCharacterPack
{
	public class CharactersShowHandler : MonoBehaviour
	{
		public List<Transform> containersList = new List<Transform>();

		private int actualCharacterIndex;

		private List<Transform> CharacterList = new List<Transform>();

		private bool toLeft;

		private bool toRight;

		private void Start()
		{
			for (int i = 0; i < containersList.Count; i++)
			{
				foreach (Transform item in containersList[i])
				{
					CharacterList.Add(item);
				}
			}
			HandleAll();
		}

		public void GoToLeft()
		{
			toLeft = true;
		}

		public void GoToRight()
		{
			toRight = true;
		}

		public static Transform GetTransformInChildsByName(Transform mainTransform, string name)
		{
			if (mainTransform.name == name)
			{
				return mainTransform;
			}
			foreach (Transform item in mainTransform)
			{
				Transform transformInChildsByName = GetTransformInChildsByName(item, name);
				if (transformInChildsByName != null)
				{
					return transformInChildsByName;
				}
			}
			return null;
		}

		private void HandleAll()
		{
			if (Input.GetKeyDown(KeyCode.A) || toLeft)
			{
				actualCharacterIndex--;
			}
			if (Input.GetKeyDown(KeyCode.D) || toRight)
			{
				actualCharacterIndex++;
			}
			toLeft = false;
			toRight = false;
			if (actualCharacterIndex < 0)
			{
				actualCharacterIndex = CharacterList.Count - 1;
			}
			if (actualCharacterIndex > CharacterList.Count - 1)
			{
				actualCharacterIndex = 0;
			}
			for (int i = 0; i < CharacterList.Count; i++)
			{
				CharacterList[i].gameObject.SetActive(i == actualCharacterIndex);
			}
		}

		private void Update()
		{
			HandleAll();
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
