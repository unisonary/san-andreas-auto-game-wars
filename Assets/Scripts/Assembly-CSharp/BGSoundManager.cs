using UnityEngine;

public class BGSoundManager : MonoBehaviour
{
	private static BGSoundManager _instance;

	public static BGSoundManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = Object.FindObjectOfType<BGSoundManager>();
			}
			if (_instance == null)
			{
				_instance = new GameObject("BGSoundManager").AddComponent<BGSoundManager>();
			}
			return _instance;
		}
	}

	public bool IsMute
	{
		get
		{
			return GetComponent<AudioSource>().mute;
		}
		set
		{
			GetComponent<AudioSource>().mute = value;
		}
	}

	private void Awake()
	{
		if (!GetComponent<AudioSource>())
		{
			base.gameObject.AddComponent<AudioSource>();
		}
		SetVolume(75f);
		Object.DontDestroyOnLoad(this);
	}

	public void PlayAudioClip(AudioClip audioClip)
	{
		if (GetComponent<AudioSource>().isPlaying)
		{
			GetComponent<AudioSource>().Stop();
		}
		GetComponent<AudioSource>().clip = audioClip;
		GetComponent<AudioSource>().loop = true;
		GetComponent<AudioSource>().Play();
	}

	public void StopPlaying()
	{
		if (GetComponent<AudioSource>().isPlaying)
		{
			GetComponent<AudioSource>().Stop();
		}
	}

	public void SetVolume(float percent)
	{
		GetComponent<AudioSource>().volume = percent * 0.01f;
	}

	public void ResumeSound()
	{
		GetComponent<AudioSource>().Play();
	}

	public void PauseSound()
	{
		GetComponent<AudioSource>().Pause();
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
