using CnControls;
using UnityEngine;

public class Controller : MonoBehaviour
{
	public enum AimMode
	{
		Hold = 0,
		Toggle = 1
	}

	public bool automaticPickUp = true;

	public bool automaticClimb;

	public bool canCrouch = true;

	public bool canSwitchAimSide = true;

	public AimMode aimMode;

	public KeyCode JumpKey = KeyCode.Space;

	public KeyCode RunKey = KeyCode.LeftShift;

	public KeyCode CrouchKey = KeyCode.C;

	public KeyCode ShootKey = KeyCode.Mouse0;

	public KeyCode AimKey = KeyCode.Mouse1;

	public KeyCode SwitchAimSideKey = KeyCode.T;

	public KeyCode ReloadKey = KeyCode.R;

	public KeyCode PickUpWeaponKey = KeyCode.E;

	public KeyCode EquipWeaponKey = KeyCode.Tab;

	public KeyCode PunchKey = KeyCode.G;

	[HideInInspector]
	public KeyCode[] keyCodes = new KeyCode[9]
	{
		KeyCode.Alpha1,
		KeyCode.Alpha2,
		KeyCode.Alpha3,
		KeyCode.Alpha4,
		KeyCode.Alpha5,
		KeyCode.Alpha6,
		KeyCode.Alpha7,
		KeyCode.Alpha8,
		KeyCode.Alpha9
	};

	[HideInInspector]
	public float xAxis;

	[HideInInspector]
	public float yAxis;

	[HideInInspector]
	public float camxAxis;

	[HideInInspector]
	public float camyAxis;

	private void Update()
	{
		if (GameControl.manager.controlMode == ControlMode.simple)
		{
			xAxis = Input.GetAxisRaw("Horizontal");
			yAxis = Input.GetAxisRaw("Vertical");
			camxAxis = Input.GetAxisRaw("Mouse X");
			camyAxis = Input.GetAxisRaw("Mouse Y");
		}
		else if (GameControl.manager.controlMode == ControlMode.touch)
		{
			xAxis = CnInputManager.GetAxis("Horizontal2");
			yAxis = CnInputManager.GetAxis("Vertical2");
			camxAxis = CnInputManager.GetAxis("Camera X");
			camyAxis = CnInputManager.GetAxis("Camera Y");
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
