using CnControls;
using UnityEngine;

[RequireComponent(typeof(ThirdPersonCharacter))]
public class ThirdPersonUserControl : MonoBehaviour
{
	private ThirdPersonCharacter m_Character;

	private Transform m_Cam;

	private Vector3 m_CamForward;

	private Vector3 m_Move;

	private bool m_Jump;

	private float h;

	private float v;

	public void Start()
	{
		if (Camera.main != null)
		{
			m_Cam = Camera.main.transform;
		}
		else
		{
			Debug.LogWarning("Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.");
		}
		m_Character = GetComponent<ThirdPersonCharacter>();
	}

	public void Update()
	{
		if (!m_Jump)
		{
			if (GameControl.manager.controlMode == ControlMode.simple)
			{
				m_Jump = Input.GetButtonDown("Jump");
			}
			else if (GameControl.manager.controlMode == ControlMode.touch && GameControl.jump)
			{
				m_Jump = true;
				GameControl.jump = false;
			}
		}
	}

	public void FixedUpdate()
	{
		if (GameControl.manager.controlMode == ControlMode.simple)
		{
			h = Input.GetAxis("Horizontal");
			v = Input.GetAxis("Vertical");
		}
		else if (GameControl.manager.controlMode == ControlMode.touch)
		{
			h = CnInputManager.GetAxis("HorizontalJoystick");
			v = CnInputManager.GetAxis("VerticalJoystick");
		}
		bool key = Input.GetKey(KeyCode.C);
		if (m_Cam != null)
		{
			m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1f, 0f, 1f)).normalized;
			m_Move = v * m_CamForward + h * m_Cam.right;
		}
		else
		{
			m_Move = v * Vector3.forward + h * Vector3.right;
		}
		if (Input.GetKey(KeyCode.LeftShift))
		{
			m_Move *= 0.5f;
		}
		m_Character.Move(m_Move, key, m_Jump);
		m_Jump = false;
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
