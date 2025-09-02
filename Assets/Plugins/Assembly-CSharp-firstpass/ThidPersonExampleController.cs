using CnControls;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ThidPersonExampleController : MonoBehaviour
{
	public float MovementSpeed = 10f;

	private Transform _mainCameraTransform;

	private Transform _transform;

	private CharacterController _characterController;

	private void OnEnable()
	{
		_mainCameraTransform = Camera.main.GetComponent<Transform>();
		_characterController = GetComponent<CharacterController>();
		_transform = GetComponent<Transform>();
	}

	public void Update()
	{
		Vector3 direction = new Vector3(CnInputManager.GetAxis("Horizontal"), CnInputManager.GetAxis("Vertical"));
		Vector3 vector = Vector3.zero;
		if (direction.sqrMagnitude > 0.001f)
		{
			vector = _mainCameraTransform.TransformDirection(direction);
			vector.y = 0f;
			vector.Normalize();
			_transform.forward = vector;
		}
		vector += Physics.gravity;
		_characterController.Move(vector * Time.deltaTime);
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
