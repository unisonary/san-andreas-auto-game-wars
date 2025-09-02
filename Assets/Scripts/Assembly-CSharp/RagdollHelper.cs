using System.Collections.Generic;
using UnityEngine;

public class RagdollHelper : MonoBehaviour
{
	public enum RagdollState
	{
		animated = 0,
		ragdolled = 1,
		blendToAnim = 2
	}

	public class BodyPart
	{
		public Transform transform;

		public Vector3 storedPosition;

		public Quaternion storedRotation;
	}

	public PlayerBehaviour pB;

	private Component[] components;

	public RagdollState state;

	public float ragdollToMecanimBlendTime = 0.3f;

	private float mecanimToGetUpTransitionTime = 0.05f;

	private float ragdollingEndTime = -100f;

	private Vector3 ragdolledHipPosition;

	private Vector3 ragdolledHeadPosition;

	private Vector3 ragdolledFeetPosition;

	private List<BodyPart> bodyParts = new List<BodyPart>();

	private Animator anim;

	public bool ragdolled
	{
		get
		{
			return state != RagdollState.animated;
		}
		set
		{
			if (value)
			{
				if (state == RagdollState.animated)
				{
					setKinematic(false);
					anim.enabled = false;
					state = RagdollState.ragdolled;
				}
			}
			else
			{
				if (state != RagdollState.ragdolled)
				{
					return;
				}
				setKinematic(true);
				ragdollingEndTime = Time.time;
				anim.enabled = true;
				state = RagdollState.blendToAnim;
				foreach (BodyPart bodyPart in bodyParts)
				{
					bodyPart.storedRotation = bodyPart.transform.rotation;
					bodyPart.storedPosition = bodyPart.transform.position;
				}
				ragdolledFeetPosition = 0.5f * (anim.GetBoneTransform(HumanBodyBones.LeftToes).position + anim.GetBoneTransform(HumanBodyBones.RightToes).position);
				ragdolledHeadPosition = anim.GetBoneTransform(HumanBodyBones.Head).position;
				ragdolledHipPosition = anim.GetBoneTransform(HumanBodyBones.Hips).position;
				RaycastHit hitInfo;
				if (!Physics.SphereCast(pB.aimHelperSpine.position - pB.aimHelper.forward, 0.5f, pB.aimHelper.forward - Vector3.up * 0.2f, out hitInfo, 5f))
				{
					anim.Play("Get Up Back");
				}
				else
				{
					anim.Play("Get Up Front");
				}
			}
		}
	}

	private void DisableRagdoll(bool active)
	{
		Component[] componentsInChildren = base.transform.GetComponentsInChildren(typeof(Rigidbody));
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			((Rigidbody)componentsInChildren[i]).isKinematic = !active;
		}
		componentsInChildren = base.transform.GetComponentsInChildren(typeof(Collider));
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			((Collider)componentsInChildren[i]).enabled = active;
		}
	}

	private void setKinematic(bool newValue)
	{
		Component[] componentsInChildren = GetComponentsInChildren(typeof(Rigidbody));
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			(componentsInChildren[i] as Rigidbody).isKinematic = newValue;
		}
		componentsInChildren = base.transform.GetComponentsInChildren(typeof(Collider));
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			((Collider)componentsInChildren[i]).enabled = !newValue;
		}
	}

	private void Start()
	{
		setKinematic(true);
		components = GetComponentsInChildren(typeof(Transform));
		Component[] array = components;
		foreach (Component component in array)
		{
			if (component.GetComponent<Rigidbody>() != null)
			{
				BodyPart bodyPart = new BodyPart();
				bodyPart.transform = component as Transform;
				bodyParts.Add(bodyPart);
			}
		}
		anim = GetComponent<Animator>();
	}

	private void Update()
	{
	}

	private void LateUpdate()
	{
		if (state != RagdollState.blendToAnim)
		{
			return;
		}
		if (Time.time <= ragdollingEndTime + mecanimToGetUpTransitionTime)
		{
			Vector3 vector = ragdolledHipPosition - anim.GetBoneTransform(HumanBodyBones.Hips).position;
			Vector3 vector2 = base.transform.position + vector;
			RaycastHit[] array = Physics.RaycastAll(new Ray(vector2, Vector3.down));
			vector2.y = 0f;
			RaycastHit[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				RaycastHit raycastHit = array2[i];
				if (!raycastHit.transform.IsChildOf(base.transform))
				{
					vector2.y = Mathf.Max(vector2.y, raycastHit.point.y);
				}
			}
			base.transform.position = vector2;
			Vector3 vector3 = ragdolledHeadPosition - ragdolledFeetPosition;
			vector3.y = 0f;
			Vector3 vector4 = 0.5f * (anim.GetBoneTransform(HumanBodyBones.LeftFoot).position + anim.GetBoneTransform(HumanBodyBones.RightFoot).position);
			Vector3 vector5 = anim.GetBoneTransform(HumanBodyBones.Head).position - vector4;
			vector5.y = 0f;
			base.transform.rotation *= Quaternion.FromToRotation(vector5.normalized, vector3.normalized);
		}
		float value = 1f - (Time.time - ragdollingEndTime - mecanimToGetUpTransitionTime) / ragdollToMecanimBlendTime;
		value = Mathf.Clamp01(value);
		foreach (BodyPart bodyPart in bodyParts)
		{
			if (bodyPart.transform != base.transform)
			{
				if (bodyPart.transform == anim.GetBoneTransform(HumanBodyBones.Hips))
				{
					bodyPart.transform.position = Vector3.Lerp(bodyPart.transform.position, bodyPart.storedPosition, value);
				}
				bodyPart.transform.rotation = Quaternion.Lerp(bodyPart.transform.rotation, bodyPart.storedRotation, value);
			}
		}
		pB.rb.velocity = Vector3.zero;
		pB.rb.isKinematic = false;
		pB.rb.useGravity = true;
		if (value == 0f)
		{
			state = RagdollState.animated;
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
