using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class BackButton : MonoBehaviour
{
	public delegate void CloseCurrentPopup();

	public static GameObject CurrentPopup;

	public static List<GameObject> CurrentlyOpenedPopups = new List<GameObject>();

	[CompilerGenerated]
	private static CloseCurrentPopup m_CloseCurrentPopupEvent;

	private static BackButton _instance;

	private bool canClickEscape;

	public static BackButton Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = UnityEngine.Object.FindObjectOfType<BackButton>();
			}
			return _instance;
		}
	}

	public bool SetBackClick
	{
		get
		{
			return canClickEscape;
		}
		set
		{
			canClickEscape = value;
		}
	}

	public static event CloseCurrentPopup CloseCurrentPopupEvent
	{
		[CompilerGenerated]
		add
		{
			CloseCurrentPopup closeCurrentPopup = BackButton.m_CloseCurrentPopupEvent;
			CloseCurrentPopup closeCurrentPopup2;
			do
			{
				closeCurrentPopup2 = closeCurrentPopup;
				CloseCurrentPopup value2 = (CloseCurrentPopup)Delegate.Combine(closeCurrentPopup2, value);
				closeCurrentPopup = Interlocked.CompareExchange(ref BackButton.m_CloseCurrentPopupEvent, value2, closeCurrentPopup2);
			}
			while (closeCurrentPopup != closeCurrentPopup2);
		}
		[CompilerGenerated]
		remove
		{
			CloseCurrentPopup closeCurrentPopup = BackButton.m_CloseCurrentPopupEvent;
			CloseCurrentPopup closeCurrentPopup2;
			do
			{
				closeCurrentPopup2 = closeCurrentPopup;
				CloseCurrentPopup value2 = (CloseCurrentPopup)Delegate.Remove(closeCurrentPopup2, value);
				closeCurrentPopup = Interlocked.CompareExchange(ref BackButton.m_CloseCurrentPopupEvent, value2, closeCurrentPopup2);
			}
			while (closeCurrentPopup != closeCurrentPopup2);
		}
	}

	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	private void Update()
	{
		if (canClickEscape)
		{
			Input.GetKeyDown(KeyCode.Escape);
		}
	}

	private void OnLevelWasLoaded(int SceneName)
	{
		canClickEscape = true;
		//BackButton.CloseCurrentPopupEvent = null;
		CurrentPopup = null;
		CurrentlyOpenedPopups = new List<GameObject>();
	}

	public void Add(GameObject currentObj)
	{
		canClickEscape = false;
		CancelInvoke("makeWorkBack");
		Invoke("makeWorkBack", 0.5f);
		CurrentPopup = currentObj;
		CurrentlyOpenedPopups.Add(CurrentPopup);
	}

	private void makeWorkBack()
	{
		canClickEscape = true;
	}

	public void Remove()
	{
		CurrentlyOpenedPopups.Remove(CurrentPopup);
		CurrentPopup = null;
		if (CurrentlyOpenedPopups.Count > 0)
		{
			CurrentPopup = CurrentlyOpenedPopups[CurrentlyOpenedPopups.Count - 1];
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
