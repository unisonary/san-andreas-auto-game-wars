using UnityEngine;

public class IKControl : MonoBehaviour
{
	[HideInInspector]
	public PlayerBehaviour pB;

	[HideInInspector]
	public Animator animator;

	[HideInInspector]
	public Vector3 rightHandPos;

	[HideInInspector]
	public Vector3 leftHandPos;

	public float rightHandWeight;

	public float lookAtWeight;

	public float leftHandWeight;

	public bool useleftHand;

	[HideInInspector]
	public Transform head;

	private void Start()
	{
		leftHandWeight = 0f;
		rightHandWeight = 0f;
		lookAtWeight = 0f;
	}

	private void OnAnimatorIK()
	{
		if (!animator)
		{
			return;
		}
		if (pB.inMoveState)
		{
			LerpLookAtWeight(0.5f, 5f);
		}
		else
		{
			LerpLookAtWeight(0f, 5f);
		}
		if (pB.aim)
		{
			animator.SetLookAtPosition(head.position + pB.aimHelper.forward);
		}
		else
		{
			animator.SetLookAtPosition(head.position + pB.cam.forward);
		}
		animator.SetLookAtWeight(lookAtWeight);
		if (pB.equippedWeapon)
		{
			animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
			animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);
			animator.SetIKPosition(AvatarIKGoal.RightHand, pB.rightHandInWeapon.position);
			animator.SetIKRotation(AvatarIKGoal.RightHand, pB.rightHandInWeapon.rotation);
			animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, leftHandWeight);
			animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, leftHandWeight);
			animator.SetIKPosition(AvatarIKGoal.LeftHand, pB.leftHandInWeapon.position);
			animator.SetIKRotation(AvatarIKGoal.LeftHand, pB.leftHandInWeapon.rotation);
			if (pB.currentWeapon.usingLeftHand)
			{
				leftHandWeight = 1f;
			}
			else
			{
				leftHandWeight = 0f;
			}
			LerpRightHandWeight(1f, 5f);
		}
		else
		{
			leftHandWeight = 0f;
			rightHandWeight = 0f;
			animator.SetIKPositionWeight(AvatarIKGoal.RightHand, rightHandWeight);
			animator.SetIKRotationWeight(AvatarIKGoal.RightHand, rightHandWeight);
			animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandPos);
			animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, leftHandWeight);
			animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, leftHandWeight);
			animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandPos);
		}
	}

	public void LerpHandWeight(float to, float t)
	{
		leftHandWeight = Mathf.Lerp(leftHandWeight, to, t * Time.deltaTime);
	}

	public void LerpRightHandWeight(float to, float t)
	{
		rightHandWeight = Mathf.Lerp(rightHandWeight, to, t * Time.deltaTime);
	}

	public void LerpLookAtWeight(float to, float t)
	{
		lookAtWeight = Mathf.Lerp(lookAtWeight, to, t * Time.deltaTime);
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
