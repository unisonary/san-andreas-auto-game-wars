using UnityEngine;

public class WheelSkidmarks : MonoBehaviour
{
	public GameObject skidCaller;

	public float startSlipValue = 0.4f;

	private Skidmarks skidmarks;

	private int lastSkidmark = -1;

	private WheelCollider wheel_col;

	private float wheelSlipAmount;

	private WheelHit GroundHit;

	private void Start()
	{
		skidCaller = base.transform.root.gameObject;
		wheel_col = GetComponent<WheelCollider>();
		if ((bool)Object.FindObjectOfType(typeof(Skidmarks)))
		{
			skidmarks = Object.FindObjectOfType(typeof(Skidmarks)) as Skidmarks;
		}
		else
		{
			Debug.Log("No skidmarks object found. Skidmarks will not be drawn");
		}
	}

	private void FixedUpdate()
	{
		wheel_col.GetGroundHit(out GroundHit);
		wheelSlipAmount = Mathf.Abs(GroundHit.sidewaysSlip);
		if (wheelSlipAmount > startSlipValue)
		{
			Vector3 pos = GroundHit.point + 2f * skidCaller.GetComponent<Rigidbody>().velocity * Time.deltaTime;
			lastSkidmark = skidmarks.AddSkidMark(pos, GroundHit.normal, wheelSlipAmount / 2f, lastSkidmark);
			if (wheel_col.transform.parent.GetComponent<AIVehicle>().vehicleStatus == VehicleStatus.Player && PlayerBehaviour.CanDrift)
			{
				PlayerBehaviour.driftamount += 1f;
				Debug.Log(PlayerBehaviour.Totaldrifts + " driftamount " + PlayerBehaviour.driftamount);
				if (PlayerBehaviour.driftamount == 150f)
				{
					PlayerBehaviour.Totaldrifts--;
					PlayerBehaviour.driftamount = 0f;
				}
			}
		}
		else
		{
			lastSkidmark = -1;
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
