using UnityEngine;

public class MoveMap : MonoBehaviour
{
	public Camera bigMapView;

	private Vector3 offset;

	private Vector3 currentStartPosition;

	private Vector3 curScreenPoint;

	private void Start()
	{
		currentStartPosition = bigMapView.transform.position;
	}

	private void OnEnable()
	{
		bigMapView.transform.position = new Vector3(GameUI.instPlayerIcon.transform.position.x, currentStartPosition.y, GameUI.instPlayerIcon.transform.position.z);
	}

	private void OnMouseDown()
	{
		offset = bigMapView.transform.position;
		curScreenPoint = Vector3.zero;
	}

	private void OnMouseDrag()
	{
		curScreenPoint += new Vector3(0f - Input.GetAxis("Mouse X"), 0f, 0f - Input.GetAxis("Mouse Y")) * 25f;
		Vector3 position = offset + curScreenPoint;
		bigMapView.transform.position = position;
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
