using CnControls;
using UnityEngine;

namespace UnityStandardAssets.Copy._2D
{
	[RequireComponent(typeof(PlatformerCharacter2D))]
	public class Platformer2DUserControl : MonoBehaviour
	{
		private PlatformerCharacter2D m_Character;

		private bool m_Jump;

		private void Awake()
		{
			m_Character = GetComponent<PlatformerCharacter2D>();
		}

		private void Update()
		{
			if (!m_Jump)
			{
				m_Jump = CnInputManager.GetButtonDown("Jump");
			}
		}

		private void FixedUpdate()
		{
			float axis = CnInputManager.GetAxis("Horizontal");
			m_Character.Move(axis, m_Jump);
			m_Jump = false;
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
