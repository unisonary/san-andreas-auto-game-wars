using UnityEngine;
using UnityEngine.EventSystems;

namespace CnControls
{
	public class Touchpad : MonoBehaviour, IDragHandler, IEventSystemHandler, IPointerUpHandler, IPointerDownHandler
	{
		public string HorizontalAxisName = "Horizontal";

		public string VerticalAxisName = "Vertical";

		public bool PreserveInertia = true;

		public float Friction = 3f;

		private VirtualAxis _horizintalAxis;

		private VirtualAxis _verticalAxis;

		private int _lastDragFrameNumber;

		private bool _isCurrentlyTweaking;

		[Tooltip("Constraints on the joystick movement axis")]
		public ControlMovementDirection ControlMoveAxis = ControlMovementDirection.Both;

		public Camera CurrentEventCamera { get; set; }

		private void OnEnable()
		{
			_horizintalAxis = _horizintalAxis ?? new VirtualAxis(HorizontalAxisName);
			_verticalAxis = _verticalAxis ?? new VirtualAxis(VerticalAxisName);
			CnInputManager.RegisterVirtualAxis(_horizintalAxis);
			CnInputManager.RegisterVirtualAxis(_verticalAxis);
		}

		private void OnDisable()
		{
			CnInputManager.UnregisterVirtualAxis(_horizintalAxis);
			CnInputManager.UnregisterVirtualAxis(_verticalAxis);
		}

		public virtual void OnDrag(PointerEventData eventData)
		{
			if ((ControlMoveAxis & ControlMovementDirection.Horizontal) != 0)
			{
				_horizintalAxis.Value = eventData.delta.x;
			}
			if ((ControlMoveAxis & ControlMovementDirection.Vertical) != 0)
			{
				_verticalAxis.Value = eventData.delta.y;
			}
			_lastDragFrameNumber = Time.renderedFrameCount;
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			_isCurrentlyTweaking = false;
			if (!PreserveInertia)
			{
				_horizintalAxis.Value = 0f;
				_verticalAxis.Value = 0f;
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			_isCurrentlyTweaking = true;
			OnDrag(eventData);
		}

		private void Update()
		{
			if (_isCurrentlyTweaking && _lastDragFrameNumber < Time.renderedFrameCount - 2)
			{
				_horizintalAxis.Value = 0f;
				_verticalAxis.Value = 0f;
			}
			if (PreserveInertia && !_isCurrentlyTweaking)
			{
				_horizintalAxis.Value = Mathf.Lerp(_horizintalAxis.Value, 0f, Friction * Time.deltaTime);
				_verticalAxis.Value = Mathf.Lerp(_verticalAxis.Value, 0f, Friction * Time.deltaTime);
			}
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
