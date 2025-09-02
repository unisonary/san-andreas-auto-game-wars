using UnityEngine;

public class PlayerAnimationListener : MonoBehaviour
{
	private TransformPathMaker pathMaker;

	private PlayerBehaviour playerBehaviour;

	private void Start()
	{
		pathMaker = base.transform.parent.GetComponent<TransformPathMaker>();
		playerBehaviour = pathMaker.gameObject.GetComponent<PlayerBehaviour>();
	}

	public void PlayPathMaker()
	{
		pathMaker.Play();
	}

	public void ResetPathMaker()
	{
		pathMaker.Reset();
	}

	public void NextClimbState()
	{
		pathMaker.NextState();
	}

	public void Jump()
	{
		playerBehaviour.Jump();
	}

	public void punchagain()
	{
		Debug.Log("Punch...b");
		playerBehaviour.punchagain();
	}

	public void punchstop()
	{
		Debug.Log("Punch...c");
		playerBehaviour.punchidle();
	}

	public void Splash()
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
