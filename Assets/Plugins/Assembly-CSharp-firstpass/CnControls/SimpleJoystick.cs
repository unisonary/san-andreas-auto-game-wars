using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CnControls
{
	public class SimpleJoystick : MonoBehaviour, IDragHandler, IEventSystemHandler, IPointerUpHandler, IPointerDownHandler
	{
		public float MovementRange = 50f;

		public string HorizontalAxisName = "Horizontal";

		public string VerticalAxisName = "Vertical";

		[Space(15f)]
		[Tooltip("Should the joystick be hidden on release?")]
		public bool HideOnRelease;

		[Tooltip("Should the Base image move along with the finger without any constraints?")]
		public bool MoveBase = true;

		[Tooltip("Should the joystick snap to finger? If it's FALSE, the MoveBase checkbox logic will be ommited")]
		public bool SnapsToFinger = true;

		[Tooltip("Constraints on the joystick movement axis")]
		public ControlMovementDirection JoystickMoveAxis = ControlMovementDirection.Both;

		[Tooltip("Image of the joystick base")]
		public Image JoystickBase;

		[Tooltip("Image of the stick itself")]
		public Image Stick;

		[Tooltip("Touch Zone transform")]
		public RectTransform TouchZone;

		private Vector2 _initialStickPosition;

		private Vector2 _intermediateStickPosition;

		private Vector2 _initialBasePosition;

		private RectTransform _baseTransform;

		private RectTransform _stickTransform;

		private float _oneOverMovementRange;

		protected VirtualAxis HorizintalAxis;

		protected VirtualAxis VerticalAxis;

		public bool isCameraControl;

		public static bool Isdraging = false;

		public static int fingerIdJoystick = -1;

		public static int fingetIdCam;

		public Camera CurrentEventCamera { get; set; }

		private void Awake()
		{
			_stickTransform = Stick.GetComponent<RectTransform>();
			_baseTransform = JoystickBase.GetComponent<RectTransform>();
			_initialStickPosition = _stickTransform.anchoredPosition;
			_intermediateStickPosition = _initialStickPosition;
			_initialBasePosition = _baseTransform.anchoredPosition;
			_stickTransform.anchoredPosition = _initialStickPosition;
			_baseTransform.anchoredPosition = _initialBasePosition;
			_oneOverMovementRange = 1f / MovementRange;
			if (HideOnRelease)
			{
				Hide(true);
			}
		}

		private void OnEnable()
		{
			HorizintalAxis = HorizintalAxis ?? new VirtualAxis(HorizontalAxisName);
			VerticalAxis = VerticalAxis ?? new VirtualAxis(VerticalAxisName);
			CnInputManager.RegisterVirtualAxis(HorizintalAxis);
			CnInputManager.RegisterVirtualAxis(VerticalAxis);
		}

		private void OnDisable()
		{
			CnInputManager.UnregisterVirtualAxis(HorizintalAxis);
			CnInputManager.UnregisterVirtualAxis(VerticalAxis);
		}

		public virtual void OnDrag(PointerEventData eventData)
		{
			CurrentEventCamera = eventData.pressEventCamera ?? CurrentEventCamera;
			Vector3 worldPoint;
			RectTransformUtility.ScreenPointToWorldPointInRectangle(_stickTransform, eventData.position, CurrentEventCamera, out worldPoint);
			_stickTransform.position = worldPoint;
			Vector2 anchoredPosition = _stickTransform.anchoredPosition;
			if ((JoystickMoveAxis & ControlMovementDirection.Horizontal) == 0)
			{
				anchoredPosition.x = _intermediateStickPosition.x;
			}
			if ((JoystickMoveAxis & ControlMovementDirection.Vertical) == 0)
			{
				anchoredPosition.y = _intermediateStickPosition.y;
			}
			_stickTransform.anchoredPosition = anchoredPosition;
			Vector2 vector = new Vector2(anchoredPosition.x, anchoredPosition.y) - _intermediateStickPosition;
			float magnitude = vector.magnitude;
			Vector2 vector2 = vector / magnitude;
			if (magnitude > MovementRange)
			{
				if (MoveBase && SnapsToFinger)
				{
					float num = vector.magnitude - MovementRange;
					Vector2 vector3 = vector2 * num;
					_baseTransform.anchoredPosition += vector3;
					_intermediateStickPosition += vector3;
				}
				else
				{
					_stickTransform.anchoredPosition = _intermediateStickPosition + vector2 * MovementRange;
				}
			}
			float num2 = Mathf.Clamp(vector.x * _oneOverMovementRange, -1f, 2f);
			float num3 = Mathf.Clamp(vector.y * _oneOverMovementRange, -1f, 2f);
			if (num2 >= 0.3f && num2 <= 0.6f)
			{
				num2 = 0.8f;
			}
			if (num2 <= -0.3f && num2 >= -0.6f)
			{
				num2 = -0.8f;
			}
			if (num3 >= 0.3f && num3 <= 0.6f)
			{
				num3 = 0.8f;
			}
			if (num3 <= -0.3f && num3 >= -0.6f)
			{
				num3 = -0.8f;
			}
			if (num2 >= 0.8f || num2 <= -0.8f)
			{
				HorizintalAxis.Value = num2;
			}
			if (num3 >= 0.8f || num3 <= -0.8f)
			{
				VerticalAxis.Value = num3;
			}
			if (isCameraControl)
			{
				Isdraging = true;
			}
			for (int i = 0; i < Input.touchCount; i++)
			{
				fingerIdJoystick = Input.GetTouch(i).fingerId;
			}
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			_baseTransform.anchoredPosition = _initialBasePosition;
			_stickTransform.anchoredPosition = _initialStickPosition;
			_intermediateStickPosition = _initialStickPosition;
			VirtualAxis horizintalAxis = HorizintalAxis;
			float value = (VerticalAxis.Value = 0f);
			horizintalAxis.Value = value;
			if (HideOnRelease)
			{
				Hide(true);
			}
			if (isCameraControl)
			{
				Isdraging = false;
			}
			for (int i = 0; i < Input.touchCount; i++)
			{
				fingerIdJoystick = Input.GetTouch(i).fingerId;
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			MonoBehaviour.print("hiiiiiiiiiiiiiiiiiiii " + SnapsToFinger);
			for (int i = 0; i < Input.touchCount; i++)
			{
				fingerIdJoystick = Input.GetTouch(i).fingerId;
			}
			if (SnapsToFinger)
			{
				CurrentEventCamera = eventData.pressEventCamera ?? CurrentEventCamera;
				Vector3 worldPoint;
				RectTransformUtility.ScreenPointToWorldPointInRectangle(_stickTransform, eventData.position, CurrentEventCamera, out worldPoint);
				Vector3 worldPoint2;
				RectTransformUtility.ScreenPointToWorldPointInRectangle(_baseTransform, eventData.position, CurrentEventCamera, out worldPoint2);
				_baseTransform.position = worldPoint2;
				_stickTransform.position = worldPoint;
				_intermediateStickPosition = _stickTransform.anchoredPosition;
			}
			if (HideOnRelease)
			{
				Hide(false);
			}
			if (isCameraControl)
			{
				Isdraging = true;
			}
		}

		private void Hide(bool isHidden)
		{
			JoystickBase.gameObject.SetActive(!isHidden);
			Stick.gameObject.SetActive(!isHidden);
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
