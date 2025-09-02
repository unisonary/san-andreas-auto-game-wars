using UnityEngine;

public class GizmoObject : MonoBehaviour
{
	public GizmoShape gizmoShape;

	public Color gizmoColor = Color.white;

	public float gizmoSize = 1f;

	public bool wireMode;

	public bool drawRay;

	public float rayLength = 2f;

	private void OnDrawGizmos()
	{
		Gizmos.color = gizmoColor;
		if (drawRay)
		{
			Vector3 vector = base.transform.TransformDirection(Vector3.fwd);
			Gizmos.DrawRay(base.transform.position, vector * rayLength);
		}
		Gizmos.matrix = Matrix4x4.TRS(base.transform.position, base.transform.rotation, base.transform.localScale);
		switch (gizmoShape)
		{
		case GizmoShape.Cube:
			if (wireMode)
			{
				Gizmos.DrawWireCube(Vector3.zero, Vector3.one * gizmoSize);
			}
			else
			{
				Gizmos.DrawCube(Vector3.zero, Vector3.one * gizmoSize);
			}
			break;
		case GizmoShape.Sphere:
			if (wireMode)
			{
				Gizmos.DrawWireSphere(Vector3.zero, gizmoSize);
			}
			else
			{
				Gizmos.DrawSphere(Vector3.zero, gizmoSize);
			}
			break;
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
