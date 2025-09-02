using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	public abstract class AbstractTargetFollower : MonoBehaviour
	{
		public enum UpdateType
		{
			FixedUpdate = 0,
			LateUpdate = 1,
			ManualUpdate = 2
		}

		[SerializeField]
		protected Transform m_Target;

		[SerializeField]
		private bool m_AutoTargetPlayer = true;

		[SerializeField]
		private UpdateType m_UpdateType;

		protected Rigidbody targetRigidbody;

		public Transform Target
		{
			get
			{
				return m_Target;
			}
		}

		protected virtual void Start()
		{
			if (m_AutoTargetPlayer)
			{
				FindAndTargetPlayer();
			}
			if (!(m_Target == null))
			{
				targetRigidbody = m_Target.GetComponent<Rigidbody>();
			}
		}

		private void FixedUpdate()
		{
			if (m_AutoTargetPlayer && (m_Target == null || !m_Target.gameObject.activeSelf))
			{
				FindAndTargetPlayer();
			}
			if (m_UpdateType == UpdateType.FixedUpdate)
			{
				FollowTarget(Time.deltaTime);
			}
		}

		private void LateUpdate()
		{
			if (m_AutoTargetPlayer && (m_Target == null || !m_Target.gameObject.activeSelf))
			{
				FindAndTargetPlayer();
			}
			if (m_UpdateType == UpdateType.LateUpdate)
			{
				FollowTarget(Time.deltaTime);
			}
		}

		public void ManualUpdate()
		{
			if (m_AutoTargetPlayer && (m_Target == null || !m_Target.gameObject.activeSelf))
			{
				FindAndTargetPlayer();
			}
			if (m_UpdateType == UpdateType.ManualUpdate)
			{
				FollowTarget(Time.deltaTime);
			}
		}

		protected abstract void FollowTarget(float deltaTime);

		public void FindAndTargetPlayer()
		{
			GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
			if ((bool)gameObject)
			{
				SetTarget(gameObject.transform);
			}
		}

		public virtual void SetTarget(Transform newTransform)
		{
			m_Target = newTransform;
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
