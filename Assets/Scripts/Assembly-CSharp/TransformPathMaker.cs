using UnityEngine;

public class TransformPathMaker : MonoBehaviour
{
	[HideInInspector]
	public bool play;

	[HideInInspector]
	public Transform reference;

	private Rigidbody rb;

	[HideInInspector]
	public int state;

	[HideInInspector]
	public Vector3[] points;

	[HideInInspector]
	public float[] pointsTime;

	private Vector3 correctPosition;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		if (play)
		{
			MoveTo();
		}
	}

	public void NextState()
	{
		if (state < points.Length)
		{
			state++;
			if (state < points.Length)
			{
				CorrectPosition();
			}
			else
			{
				Reset();
			}
		}
	}

	private void MoveTo()
	{
		if (state < points.Length)
		{
			base.transform.position = Vector3.Lerp(base.transform.position, correctPosition, pointsTime[state] * Time.deltaTime);
		}
	}

	public void Reset()
	{
		rb.isKinematic = false;
		play = false;
		state = 0;
	}

	public void Play()
	{
		if (!play)
		{
			CorrectPosition();
			rb.isKinematic = true;
			play = true;
		}
	}

	private void CorrectPosition()
	{
		Vector3 vector = reference.right * points[state].x;
		Vector3 vector2 = new Vector3(0f, points[state].y, 0f);
		Vector3 vector3 = reference.forward * points[state].z;
		Vector3 vector4 = reference.position + vector + vector2 + vector3;
		correctPosition = new Vector3(vector4.x, vector2.y, vector4.z);
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
