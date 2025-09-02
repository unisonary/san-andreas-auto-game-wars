using System;
using System.Collections.Generic;
using UnityEngine;

public class BezierPath : MonoBehaviour
{
	[Serializable]
	public class PathPoint
	{
		public Vector3 p1;

		public Vector3 h1;

		[HideInInspector]
		public Bezier bezier = new Bezier(Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero);

		[HideInInspector]
		public float distance;

		[HideInInspector]
		public float[] internalDistance = new float[10];
	}

	public Color color = Color.yellow;

	public Color lineColor = Color.red;

	public List<PathPoint> points = new List<PathPoint>();

	private void Start()
	{
		for (int i = 0; i < points.Count - 1; i++)
		{
			points[i].bezier.p1 = points[i].p1;
			points[i].bezier.h1 = points[i].h1;
			points[i].bezier.p2 = points[i + 1].p1;
			points[i].bezier.h2 = -points[i + 1].h1;
			if (points[i].internalDistance == null)
			{
				points[i].internalDistance = new float[10];
			}
			for (int j = 0; j < 10; j++)
			{
				points[i].internalDistance[j] = (points[i].bezier.GetPointAtTime((float)j / 10f + 0.1f) - points[i].bezier.GetPointAtTime((float)j / 10f)).magnitude;
				points[i].distance += points[i].internalDistance[j];
			}
		}
	}

	public Vector3 GetPositionByT(float t)
	{
		if (t >= (float)(points.Count - 1))
		{
			return points[points.Count - 2].bezier.GetPointAtTime(1f);
		}
		if (t <= 0f)
		{
			return points[0].bezier.GetPointAtTime(0f);
		}
		int num = (int)t;
		return points[num].bezier.GetPointAtTime(t - (float)num);
	}

	public Vector3 GetPositionByDistance(float dist)
	{
		if (dist <= 0f)
		{
			return points[0].bezier.GetPointAtTime(0f);
		}
		int num = 0;
		while (dist > 0f && num < points.Count - 1)
		{
			dist -= points[num].distance;
			num++;
		}
		if (dist > 0f)
		{
			return points[points.Count - 2].bezier.GetPointAtTime(1f);
		}
		num--;
		dist += points[num].distance;
		int num2 = 0;
		while (dist > 0f)
		{
			dist -= points[num].internalDistance[num2];
			num2++;
		}
		num2--;
		dist += points[num].internalDistance[num2];
		float num3 = dist / points[num].internalDistance[num2] / 10f;
		num3 += (float)num2 / 10f;
		return points[num].bezier.GetPointAtTime(num3);
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
