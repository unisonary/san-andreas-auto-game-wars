using UnityEngine;

public class LoopSoundManager : MonoBehaviour
{
	private static LoopSoundManager _instance;

	private bool isPauseCalled;

	public static LoopSoundManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = Object.FindObjectOfType<LoopSoundManager>();
			}
			if (_instance == null)
			{
				_instance = new GameObject("LoopSoundManager").AddComponent<LoopSoundManager>();
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
		GetComponent<AudioSource>().loop = true;
	}

	public void Pause()
	{
		if (GetComponent<AudioSource>().isPlaying)
		{
			isPauseCalled = true;
			GetComponent<AudioSource>().Pause();
		}
	}

	public void Resume()
	{
		isPauseCalled = false;
		if (!GetComponent<AudioSource>().isPlaying)
		{
			GetComponent<AudioSource>().Play();
		}
	}

	public void Playclip(AudioClip clip)
	{
		if (isPauseCalled && (bool)GetComponent<AudioSource>().clip)
		{
			isPauseCalled = false;
			GetComponent<AudioSource>().Play();
			return;
		}
		if (GetComponent<AudioSource>().isPlaying)
		{
			GetComponent<AudioSource>().Stop();
		}
		if ((bool)clip)
		{
			GetComponent<AudioSource>().clip = clip;
			GetComponent<AudioSource>().Play();
		}
	}

	public void Stop()
	{
		isPauseCalled = false;
		if (GetComponent<AudioSource>().isPlaying)
		{
			GetComponent<AudioSource>().Stop();
		}
	}

	public void SetVolume(float percent)
	{
		GetComponent<AudioSource>().volume = percent / 100f;
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
