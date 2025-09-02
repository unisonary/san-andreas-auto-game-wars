using CnControls;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
	[HideInInspector]
	public PlayerBehaviour pB;

	[HideInInspector]
	public Controller controller;

	[Header("Camera Settings")]
	public bool recoilInfluence = true;

	public float recoilInfluenceFactor = 20f;

	public Vector2 cameraOffset = new Vector2(0.5f, 1.5f);

	public float maxDistance = 2f;

	public float aimDifference = 0.3f;

	public float mouseSensitivity = 3f;

	private float currentCamDistance;

	private float currentAimDifference;

	private float camAngleX;

	private float camAngleZ;

	private float downClamp;

	[HideInInspector]
	public bool aimIsRightSide;

	[HideInInspector]
	public float originalSide;

	private bool sideCollision;

	private bool currentSideCollision;

	private bool oppositeSideCollision;

	private float Initialmousesensitivity;

	private Vector3 pos1;

	private Vector3 pos2;

	private float Diffx;

	private float Diffy;

	private bool Isclicked;

	private float distance = 3f;

	public float xSpeed = 120f;

	public float ySpeed = 120f;

	private float yMinLimit = -60f;

	public float yMaxLimit = 80f;

	public float XMinlimit = -120f;

	public float Xmaxlimit = 120f;

	public float distanceMin = 0.5f;

	public float distanceMax = 15f;

	private Rigidbody rigidbodyobj;

	[HideInInspector]
	public float x;

	[HideInInspector]
	public float y;

	private int _Layermaskval;

	private float _Multiplier = 1f;

	public float Camxval = 2f;

	public int fingeridvalue;

	private void Start()
	{
		Input.multiTouchEnabled = true;
		controller = GetComponent<Controller>();
		currentCamDistance = maxDistance;
		originalSide = cameraOffset.x;
		if (cameraOffset.x >= 0f)
		{
			aimIsRightSide = true;
		}
		Initialmousesensitivity = mouseSensitivity;
		_Layermaskval = 1023;
		_Layermaskval = ~_Layermaskval;
	}

	private void Update()
	{
		if (!LevelManager.mee.Inpopup)
		{
			float camxAxis = controller.camxAxis;
			float camyAxis = controller.camyAxis;
			if (pB.aim)
			{
				mouseSensitivity = 1.5f;
			}
			else
			{
				mouseSensitivity = Initialmousesensitivity;
			}
			if (!pB.aim)
			{
				Touchvalues(1f);
			}
			else
			{
				Touchvalues(0.75f);
			}
			Vector3 position = pB.camPivot[0].position;
			RaycastHit hitInfo;
			currentSideCollision = Physics.SphereCast(position, 0.2f, -pB.cam.forward + pB.cam.right * (cameraOffset.x * 1f), out hitInfo, maxDistance / 2f);
			oppositeSideCollision = Physics.SphereCast(position, 0.2f, -pB.cam.forward + pB.cam.right * (cameraOffset.x * -1f), out hitInfo, maxDistance / 2f);
			if (Input.GetKeyDown(controller.SwitchAimSideKey) && controller.canSwitchAimSide && !oppositeSideCollision)
			{
				aimIsRightSide = !aimIsRightSide;
				cameraOffset.x *= -1f;
				originalSide = cameraOffset.x;
			}
			if (pB.aim)
			{
				sideCollision = currentSideCollision;
			}
			else
			{
				sideCollision = false;
			}
			RaycastHit hitInfo2;
			if (Physics.SphereCast(position, 0.1f, -pB.cam.forward, out hitInfo2, maxDistance / 2f) || Physics.SphereCast(position, 0.2f, -pB.cam.forward + pB.cam.right * (cameraOffset.x / 2f), out hitInfo2, maxDistance))
			{
				float value = Vector3.Distance(pB.camPivot[0].position, hitInfo2.point) - currentAimDifference;
				value = Mathf.Clamp(value, 0.1f, maxDistance);
				currentCamDistance = value;
				GoSmooth(0f, 0f - currentCamDistance + 0.3f, 100f);
			}
			else
			{
				currentCamDistance = maxDistance - currentAimDifference;
				GoSmooth(cameraOffset.x, 0f - currentCamDistance, 10f);
			}
			pB.cameraParent.position = pB.boneRb[0].transform.position + base.transform.up * cameraOffset.y;
			bool recoilInfluence2 = recoilInfluence;
		}
	}

	private void GoSmooth(float x, float z, float t)
	{
		if (sideCollision && !oppositeSideCollision)
		{
			originalSide = cameraOffset.x;
			aimIsRightSide = !aimIsRightSide;
			cameraOffset.x *= -1f;
		}
		else if (!pB.aim)
		{
			cameraOffset.x = originalSide;
			if (cameraOffset.x >= 0f)
			{
				aimIsRightSide = true;
			}
			else
			{
				aimIsRightSide = false;
			}
		}
		float num = 0f;
		num = ((!aimIsRightSide) ? (-0.6f) : 0.6f);
		if (pB.aim)
		{
			if (currentSideCollision && oppositeSideCollision)
			{
				num = 0f;
			}
			pB.cam.localPosition = Vector3.Lerp(pB.cam.localPosition, new Vector3(num, 0f, z), t * Time.deltaTime);
		}
		else
		{
			pB.cam.localPosition = Vector3.Lerp(pB.cam.localPosition, new Vector3(x, 0f, z), t * Time.deltaTime);
		}
	}

	private void Touchvalues(float _val)
	{
		for (int i = 0; i < Input.touchCount; i++)
		{
			if (Input.GetTouch(i).phase == TouchPhase.Began)
			{
				pos1 = (pos2 = Input.GetTouch(i).deltaPosition);
				Diffx = (Diffy = 0f);
				SimpleJoystick.fingetIdCam = Input.GetTouch(i).fingerId;
			}
			if (Input.GetTouch(i).phase == TouchPhase.Ended)
			{
				Diffx = (Diffy = 0f);
				SimpleJoystick.fingerIdJoystick = 0;
			}
			if (Input.GetTouch(i).phase == TouchPhase.Moved)
			{
				pos2 = Input.GetTouch(i).deltaPosition;
				Diffx = pos2.x - pos1.x;
				Diffy = pos2.y - pos1.x;
				Rotatearound(_val);
			}
		}
	}

	private void Rotatearound(float _Multiperval)
	{
		if (!(base.transform != null))
		{
			return;
		}
		for (int i = 0; i < Input.touchCount; i++)
		{
			if (Input.touchCount == 1)
			{
				fingeridvalue = 0;
				if (SimpleJoystick.Isdraging)
				{
					return;
				}
			}
			else if (Input.GetTouch(i).fingerId != SimpleJoystick.fingerIdJoystick)
			{
				fingeridvalue = i;
			}
			if (_Multiperval < 1f)
			{
				x += Input.GetTouch(fingeridvalue).deltaPosition.x * (xSpeed / 2f) * distance * 0.02f * _Multiperval;
				y -= Input.GetTouch(fingeridvalue).deltaPosition.y * (ySpeed / 2f) * 0.02f * _Multiperval;
			}
			else
			{
				x += Input.GetTouch(fingeridvalue).deltaPosition.x * (xSpeed / 2f) * distance * 0.02f * _Multiperval;
				y -= Input.GetTouch(fingeridvalue).deltaPosition.y * (ySpeed / 2f) * 0.02f * _Multiperval;
			}
		}
		y = ClampAngle(y, yMinLimit, yMaxLimit);
		Quaternion quaternion = Quaternion.Euler(y, x, 0f);
		distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5f, distanceMin, distanceMax);
		RaycastHit hitInfo;
		if (Physics.Linecast(base.transform.localPosition, base.transform.localPosition, out hitInfo, _Layermaskval))
		{
			distance -= hitInfo.distance;
		}
		Vector3 vector = new Vector3(0f, 0.3f, 0f - distance);
		Vector3 vector2 = quaternion * vector + base.transform.position;
		if (_Multiperval < 1f)
		{
			pB.camPivot[0].rotation = Quaternion.Lerp(pB.camPivot[0].transform.rotation, quaternion, 3.5f * Time.deltaTime);
		}
		else
		{
			pB.camPivot[0].rotation = Quaternion.Lerp(pB.camPivot[0].transform.rotation, quaternion, 8f * Time.deltaTime);
		}
	}

	public static float ClampAngle(float angle, float min, float max)
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
