using System.Collections.Generic;
using UnityEngine;

public class VehicleCamera : MonoBehaviour
{
	public Transform target;

	public float smooth = 0.3f;

	public float distance = 5f;

	public float height = 1f;

	public float Angle = 20f;

	public LayerMask lineOfSightMask = 0;

	public List<Transform> cameraSwitchView;

	[HideInInspector]
	public int Switch;

	private float yVelocity;

	private float xVelocity;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.C))
		{
			Switch++;
			if (Switch > cameraSwitchView.Count)
			{
				Switch = 0;
			}
		}
		if (Switch == 0)
		{
			float x = Mathf.SmoothDampAngle(base.transform.eulerAngles.x, target.eulerAngles.x + Angle, ref xVelocity, smooth);
			float y = Mathf.SmoothDampAngle(base.transform.eulerAngles.y, target.eulerAngles.y, ref yVelocity, smooth);
			base.transform.eulerAngles = new Vector3(x, y, 0f);
			Vector3 vector = base.transform.rotation * -Vector3.forward;
			float num = AdjustLineOfSight(target.position + new Vector3(0f, height, 0f), vector);
			base.transform.position = target.position + new Vector3(0f, height, 0f) + vector * num;
		}
		else
		{
			base.transform.position = cameraSwitchView[Switch - 1].position;
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, cameraSwitchView[Switch - 1].rotation, Time.deltaTime * 5f);
		}
	}

	private float AdjustLineOfSight(Vector3 target, Vector3 direction)
	{
		RaycastHit hitInfo;
		if (Physics.Raycast(target, direction, out hitInfo, distance, lineOfSightMask.value))
		{
			return hitInfo.distance;
		}
		return distance;
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
