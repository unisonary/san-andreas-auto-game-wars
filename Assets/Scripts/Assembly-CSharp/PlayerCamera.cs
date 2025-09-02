using CnControls;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
	public Transform target;

	public LayerMask lineOfSightMask = 0;

	public float smoothTime = 0.15f;

	public float smoothRotate = 0.1f;

	public float xSpeed = 150f;

	public float ySpeed = 150f;

	public float yMinLimit = -40f;

	public float yMaxLimit = 60f;

	public float cameraDistance = 2.5f;

	public Vector3 targetOffset = Vector3.zero;

	public bool visibleMouseCursor = true;

	[HideInInspector]
	public float x;

	[HideInInspector]
	public float y;

	[HideInInspector]
	public float z;

	[HideInInspector]
	public float xSmooth;

	[HideInInspector]
	public float ySmooth;

	[HideInInspector]
	public float zSmooth;

	private float xSmooth2;

	private float ySmooth2;

	private float distance = 10f;

	private float xVelocity;

	private float yVelocity;

	private float zVelocity;

	private float xSmooth2Velocity;

	private float ySmooth2Velocity;

	private Vector3 posVelocity = Vector3.zero;

	private float distanceVelocity;

	private Vector3 targetPos;

	private Quaternion rotation;

	private void Start()
	{
		if (visibleMouseCursor)
		{
			Cursor.visible = true;
		}
		else
		{
			Cursor.visible = false;
		}
		Vector3 eulerAngles = base.transform.eulerAngles;
		x = eulerAngles.y;
		y = eulerAngles.x;
	}

	private void LateUpdate()
	{
		if ((bool)target)
		{
			Rigidbody component = target.GetComponent<Rigidbody>();
			if (GameControl.manager.controlMode == ControlMode.simple)
			{
				x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
				y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
				xSmooth2 = Mathf.SmoothDamp(xSmooth2, Input.GetAxis("Mouse X") / 5f, ref xSmooth2Velocity, 0.1f);
				ySmooth2 = Mathf.SmoothDamp(ySmooth2, Input.GetAxis("Mouse Y") / 5f, ref ySmooth2Velocity, 0.1f);
			}
			else if (GameControl.manager.controlMode == ControlMode.touch)
			{
				x += CnInputManager.GetAxis("Camera X") * xSpeed * 0.02f;
				y -= CnInputManager.GetAxis("Camera Y") * ySpeed * 0.02f;
				xSmooth2 = Mathf.SmoothDamp(xSmooth2, CnInputManager.GetAxis("Camera X") / 5f, ref xSmooth2Velocity, 0.1f);
				ySmooth2 = Mathf.SmoothDamp(ySmooth2, CnInputManager.GetAxis("Camera Y") / 5f, ref ySmooth2Velocity, 0.1f);
			}
			y = ClampAngle(y, yMinLimit, yMaxLimit);
			distance = Mathf.SmoothDamp(distance, Mathf.Clamp(y / 30f, -100f, 0f) + cameraDistance, ref distanceVelocity, 0.2f);
			xSmooth = Mathf.SmoothDamp(xSmooth, x + CameraMotion(2f, 1f) * component.velocity.magnitude, ref xVelocity, smoothTime);
			ySmooth = Mathf.SmoothDamp(ySmooth, y + CameraMotion(2f, 0.5f) * component.velocity.magnitude, ref yVelocity, smoothTime);
			zSmooth = Mathf.SmoothDamp(zSmooth, CameraMotion(1f, 0.5f) * component.velocity.magnitude, ref zVelocity, smoothTime);
			rotation = Quaternion.Euler(ySmooth, xSmooth, zSmooth);
			targetPos = Vector3.SmoothDamp(targetPos, base.transform.TransformDirection(Mathf.Clamp(xSmooth2, -0.4f, 0.4f), 0f, 0f) + new Vector3(0f, targetOffset.y - Mathf.Clamp(ySmooth2, -0.2f, 0.2f)), ref posVelocity, smoothRotate);
			Vector3 vector = rotation * -Vector3.forward;
			float num = AdjustLineOfSight(targetPos + target.position, vector);
			base.transform.rotation = rotation;
			base.transform.position = targetPos + target.position + base.transform.TransformDirection(targetOffset.x, 0f, 0.1f) + vector * num;
		}
	}

	private float CameraMotion(float speed, float angle)
	{
		return Mathf.PingPong(Time.time * speed, angle) - angle / 2f;
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

	private static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360f)
		{
			angle += 360f;
		}
		if (angle > 360f)
		{
			angle -= 360f;
		}
		return Mathf.Clamp(angle, min, max);
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
