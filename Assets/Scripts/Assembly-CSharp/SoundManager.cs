using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public delegate void SetVolumeDelegate(float percent);

	public delegate void MuteDelegate(bool isMute);

	[HideInInspector]
	public int AudioSourcesLength = 1;

	public GameObject CustomAudioSourcePrefab;

	public List<AudioClip> Clips;

	private List<PlaySound> AudioSources;

	private bool isMute;

	private static SoundManager _instance;

	[CompilerGenerated]
	private static SetVolumeDelegate m_SetVolumeEvent;

	[CompilerGenerated]
	private static MuteDelegate m_MuteEvent;

	public static SoundManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = UnityEngine.Object.FindObjectOfType<SoundManager>();
			}
			if (_instance == null)
			{
				_instance = new GameObject("SoundManager").AddComponent<SoundManager>();
			}
			return _instance;
		}
	}

	public bool IsMute
	{
		get
		{
			return isMute;
		}
		set
		{
			isMute = value;
			//if (SoundManager.MuteEvent != null)
			//{
				//SoundManager.MuteEvent(value);
			//}
		}
	}

	public static event SetVolumeDelegate SetVolumeEvent
	{
		[CompilerGenerated]
		add
		{
			SetVolumeDelegate setVolumeDelegate = SoundManager.m_SetVolumeEvent;
			SetVolumeDelegate setVolumeDelegate2;
			do
			{
				setVolumeDelegate2 = setVolumeDelegate;
				SetVolumeDelegate value2 = (SetVolumeDelegate)Delegate.Combine(setVolumeDelegate2, value);
				setVolumeDelegate = Interlocked.CompareExchange(ref SoundManager.m_SetVolumeEvent, value2, setVolumeDelegate2);
			}
			while (setVolumeDelegate != setVolumeDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			SetVolumeDelegate setVolumeDelegate = SoundManager.m_SetVolumeEvent;
			SetVolumeDelegate setVolumeDelegate2;
			do
			{
				setVolumeDelegate2 = setVolumeDelegate;
				SetVolumeDelegate value2 = (SetVolumeDelegate)Delegate.Remove(setVolumeDelegate2, value);
				setVolumeDelegate = Interlocked.CompareExchange(ref SoundManager.m_SetVolumeEvent, value2, setVolumeDelegate2);
			}
			while (setVolumeDelegate != setVolumeDelegate2);
		}
	}

	public static event MuteDelegate MuteEvent
	{
		[CompilerGenerated]
		add
		{
			MuteDelegate muteDelegate = SoundManager.m_MuteEvent;
			MuteDelegate muteDelegate2;
			do
			{
				muteDelegate2 = muteDelegate;
				MuteDelegate value2 = (MuteDelegate)Delegate.Combine(muteDelegate2, value);
				muteDelegate = Interlocked.CompareExchange(ref SoundManager.m_MuteEvent, value2, muteDelegate2);
			}
			while (muteDelegate != muteDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			MuteDelegate muteDelegate = SoundManager.m_MuteEvent;
			MuteDelegate muteDelegate2;
			do
			{
				muteDelegate2 = muteDelegate;
				MuteDelegate value2 = (MuteDelegate)Delegate.Remove(muteDelegate2, value);
				muteDelegate = Interlocked.CompareExchange(ref SoundManager.m_MuteEvent, value2, muteDelegate2);
			}
			while (muteDelegate != muteDelegate2);
		}
	}

	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(this);
		if (AudioSources == null)
		{
			AudioSources = new List<PlaySound>();
		}
	}

	private PlaySound CreateAudioSource()
	{
		AudioSource audioSource = ((!CustomAudioSourcePrefab) ? new GameObject().AddComponent<AudioSource>() : UnityEngine.Object.Instantiate(CustomAudioSourcePrefab).GetComponent<AudioSource>());
		audioSource.transform.parent = base.transform;
		PlaySound playSound = audioSource.gameObject.AddComponent<PlaySound>();
		audioSource.mute = IsMute;
		audioSource.volume = 1f;
		AudioSources.Add(playSound);
		audioSource.name = "AudioSource" + AudioSources.Count;
		return playSound;
	}

	public void PlayAudioClip(AudioClip clip, float volume = 1f)
	{
		if (!clip)
		{
			return;
		}
		bool flag = false;
		for (int i = 0; i < AudioSources.Count; i++)
		{
			if (!AudioSources[i].isPlayingClip)
			{
				flag = true;
				StartCoroutine(AudioSources[i].PlayClip(clip, volume));
				break;
			}
		}
		if (!flag)
		{
			Debug.Log("Creating new AudioSource");
			StartCoroutine(CreateAudioSource().PlayClip(clip, volume));
		}
	}

	public void PlayAudioClip(int clipNo)
	{
		PlayAudioClip(Clips[clipNo]);
	}

	public void PlayAudioClip(GameObject customAudioSourcePrefab, AudioClip clip)
	{
		CustomAudioSourcePrefab = customAudioSourcePrefab;
		PlayAudioClip(clip);
	}

	public void PlayAudioClip(GameObject customAudioSourcePrefab, int clipNo)
	{
		CustomAudioSourcePrefab = customAudioSourcePrefab;
		PlayAudioClip(clipNo);
	}

	public void SetVolume(float percent)
	{
		//if (SoundManager.SetVolumeEvent != null)
		//{
			//SoundManager.SetVolumeEvent(percent * 0.01f);
		//}
	}

	private void OnLevelWasLoaded()
	{
		for (int i = 0; i < AudioSources.Count; i++)
		{
			AudioSources[i].StopPlaying();
		}
	}
}
public class soundmanager : MonoBehaviour
{
	public static soundmanager mee;

	private void Start()
	{
		mee = this;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		EnableBg_sound();
	}

	public void EnableBg_sound()
	{
		if (Application.loadedLevelName == "Menu" || Application.loadedLevelName == "LevelSelection")
		{
			base.gameObject.GetComponent<AudioSource>().Play();
			base.gameObject.GetComponent<AudioSource>().enabled = true;
		}
	}

	public void DisableBg_sound()
	{
		base.gameObject.GetComponent<AudioSource>().enabled = false;
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
