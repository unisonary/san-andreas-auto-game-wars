using System.Collections;
using UnityEngine;

[DisallowMultipleComponent]
public class PlaySound : MonoBehaviour
{
	[HideInInspector]
	public bool isPlayingClip;

	private void OnEnable()
	{
		SoundManager.SetVolumeEvent += HandleSetVolumeEvent;
		SoundManager.MuteEvent += HandleMuteEvent;
	}

	private void OnDisable()
	{
		SoundManager.SetVolumeEvent -= HandleSetVolumeEvent;
		SoundManager.MuteEvent -= HandleMuteEvent;
	}

	private void OnDestroy()
	{
		SoundManager.SetVolumeEvent -= HandleSetVolumeEvent;
		SoundManager.MuteEvent -= HandleMuteEvent;
	}

	private void HandleMuteEvent(bool isMute)
	{
		GetComponent<AudioSource>().mute = isMute;
	}

	private void HandleSetVolumeEvent(float percent)
	{
		GetComponent<AudioSource>().volume = percent;
	}

	public IEnumerator PlayClip(AudioClip audioClip, float volume, bool _loop = false)
	{
		isPlayingClip = true;
		GetComponent<AudioSource>().volume = volume;
		if (_loop)
		{
			GetComponent<AudioSource>().PlayOneShot(audioClip);
			GetComponent<AudioSource>().loop = true;
		}
		yield return new WaitForSeconds(audioClip.length);
		isPlayingClip = false;
	}

	public void StopPlaying()
	{
		GetComponent<AudioSource>().Stop();
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
