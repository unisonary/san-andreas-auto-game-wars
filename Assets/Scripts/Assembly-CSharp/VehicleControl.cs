using System;
using UnityEngine;

public class VehicleControl : MonoBehaviour
{
	[Serializable]
	public class CarWheels
	{
		public ConnectWheel wheels;

		public WheelSetting setting;
	}

	[Serializable]
	public class ConnectWheel
	{
		public bool frontWheelDrive = true;

		public Transform frontRight;

		public Transform frontLeft;

		public bool backWheelDrive = true;

		public Transform backRight;

		public Transform backLeft;
	}

	[Serializable]
	public class WheelSetting
	{
		public float Radius = 0.4f;

		public float Weight = 1000f;

		public float Distance = 0.2f;
	}

	[Serializable]
	public class CarLights
	{
		public Light[] brakeLights;

		public Light[] reverseLights;
	}

	[Serializable]
	public class CarSounds
	{
		public AudioSource IdleEngine;

		public AudioSource crash;

		public AudioSource horn;

		public AudioSource nitro;

		public AudioSource closeDoor;

		public AudioSource openDoor;
	}

	[Serializable]
	public class CarParticles
	{
		public GameObject brakeParticlePerfab;

		public ParticleSystem shiftParticle1;

		public ParticleSystem shiftParticle2;

		private GameObject[] wheelParticle = new GameObject[4];
	}

	[Serializable]
	public class CarSetting
	{
		public bool showNormalGizmos;

		public Transform carSteer;

		public HitGround[] hitGround;

		public float springs = 25000f;

		public float dampers = 1500f;

		public float carPower = 120f;

		public float shiftPower = 150f;

		public float brakePower = 8000f;

		public Vector3 shiftCentre = new Vector3(0f, -0.8f, 0f);

		public float maxSteerAngle = 25f;

		public float shiftDownRPM = 1500f;

		public float shiftUpRPM = 2500f;

		public float idleRPM = 500f;

		public float stiffness = 2f;

		public bool automaticGear = true;

		public float[] gears = new float[6] { -10f, 9f, 6f, 4.5f, 3f, 2.5f };

		public float LimitBackwardSpeed = 60f;

		public float LimitForwardSpeed = 220f;
	}

	[Serializable]
	public class HitGround
	{
		public string tag = "street";

		public bool grounded;

		public AudioClip brakeSound;

		public AudioClip groundSound;

		public Color brakeColor;
	}

	private class WheelComponent
	{
		public Transform wheel;

		public WheelCollider collider;

		public Vector3 startPos;

		public float rotation;

		public float rotation2;

		public float maxSteer;

		public bool drive;

		public float pos_y;
	}

	private AIVehicle AIVScript;

	public CarWheels carWheels;

	public CarLights carLights;

	public CarSounds carSounds;

	public CarParticles carParticles;

	public CarSetting carSetting;

	private float steer;

	private float accel;

	[HideInInspector]
	public bool brake;

	private bool shifmotor;

	public static bool fbrake;

	[HideInInspector]
	public float curTorque = 100f;

	[HideInInspector]
	public float powerShift = 100f;

	[HideInInspector]
	public bool shift;

	private float torque = 100f;

	[HideInInspector]
	public float speed;

	private float lastSpeed = -10f;

	private bool shifting;

	private bool carOff = true;

	private float[] efficiencyTable = new float[22]
	{
		0.6f, 0.65f, 0.7f, 0.75f, 0.8f, 0.85f, 0.9f, 1f, 1f, 0.95f,
		0.8f, 0.7f, 0.6f, 0.5f, 0.45f, 0.4f, 0.36f, 0.33f, 0.3f, 0.2f,
		0.1f, 0.05f
	};

	private float efficiencyTableStep = 250f;

	private float Pitch;

	private float PitchDelay;

	private float shiftTime;

	private float shiftDelay;

	[HideInInspector]
	public int currentGear;

	[HideInInspector]
	public bool NeutralGear = true;

	[HideInInspector]
	public float motorRPM;

	[HideInInspector]
	public bool Backward;

	private float wantedRPM;

	private float w_rotate;

	private float slip;

	private float slip2;

	private GameObject[] Particle = new GameObject[4];

	private Vector3 steerCurAngle;

	private Rigidbody myRigidbody;

	private WheelComponent[] wheels;

	private WheelComponent SetWheelComponent(Transform wheel, float maxSteer, bool drive, float pos_y)
	{
		WheelComponent wheelComponent = new WheelComponent();
		GameObject gameObject = new GameObject(wheel.name + "WheelCollider");
		gameObject.transform.parent = base.transform;
		gameObject.transform.position = wheel.position;
		gameObject.transform.eulerAngles = base.transform.eulerAngles;
		pos_y = gameObject.transform.localPosition.y;
		WheelCollider wheelCollider = (WheelCollider)gameObject.AddComponent(typeof(WheelCollider));
		wheelComponent.wheel = wheel;
		wheelComponent.collider = gameObject.GetComponent<WheelCollider>();
		wheelComponent.drive = drive;
		wheelComponent.pos_y = pos_y;
		wheelComponent.maxSteer = maxSteer;
		wheelComponent.startPos = gameObject.transform.localPosition;
		return wheelComponent;
	}

	private void Awake()
	{
		AIVScript = base.transform.GetComponent<AIVehicle>();
		myRigidbody = base.transform.GetComponent<Rigidbody>();
		if ((bool)carSounds.horn)
		{
			AIVScript.horn = carSounds.horn;
		}
		if (AIVScript.vehicleStatus == VehicleStatus.EmptyOff)
		{
			carOff = true;
			Light[] brakeLights = carLights.brakeLights;
			for (int i = 0; i < brakeLights.Length; i++)
			{
				brakeLights[i].enabled = false;
			}
			brakeLights = carLights.reverseLights;
			for (int i = 0; i < brakeLights.Length; i++)
			{
				brakeLights[i].enabled = false;
			}
		}
		else
		{
			carOff = false;
		}
		if (carSetting.automaticGear)
		{
			NeutralGear = false;
		}
		wheels = new WheelComponent[4];
		wheels[0] = SetWheelComponent(carWheels.wheels.frontRight, carSetting.maxSteerAngle, carWheels.wheels.frontWheelDrive, carWheels.wheels.frontRight.position.y);
		wheels[1] = SetWheelComponent(carWheels.wheels.frontLeft, carSetting.maxSteerAngle, carWheels.wheels.frontWheelDrive, carWheels.wheels.frontLeft.position.y);
		wheels[2] = SetWheelComponent(carWheels.wheels.backRight, 0f, carWheels.wheels.backWheelDrive, carWheels.wheels.backRight.position.y);
		wheels[3] = SetWheelComponent(carWheels.wheels.backLeft, 0f, carWheels.wheels.backWheelDrive, carWheels.wheels.backLeft.position.y);
		if ((bool)carSetting.carSteer)
		{
			steerCurAngle = carSetting.carSteer.localEulerAngles;
		}
		WheelComponent[] array = wheels;
		for (int i = 0; i < array.Length; i++)
		{
			WheelCollider collider = array[i].collider;
			collider.suspensionDistance = carWheels.setting.Distance;
			JointSpring suspensionSpring = collider.suspensionSpring;
			suspensionSpring.spring = carSetting.springs;
			suspensionSpring.damper = carSetting.dampers;
			collider.suspensionSpring = suspensionSpring;
			collider.radius = carWheels.setting.Radius;
			collider.mass = carWheels.setting.Weight;
			WheelFrictionCurve forwardFriction = collider.forwardFriction;
			forwardFriction.asymptoteValue = 5000f;
			forwardFriction.extremumSlip = 2f;
			forwardFriction.asymptoteSlip = 20f;
			forwardFriction.stiffness = carSetting.stiffness;
			collider.forwardFriction = forwardFriction;
			forwardFriction = collider.sidewaysFriction;
			forwardFriction.asymptoteValue = 7500f;
			forwardFriction.asymptoteSlip = 2f;
			forwardFriction.stiffness = carSetting.stiffness;
			collider.sidewaysFriction = forwardFriction;
		}
	}

	public void ShiftUp()
	{
		float timeSinceLevelLoad = Time.timeSinceLevelLoad;
		if (timeSinceLevelLoad < shiftDelay || currentGear >= carSetting.gears.Length - 1)
		{
			return;
		}
		if (!carSetting.automaticGear)
		{
			if (currentGear == 0)
			{
				if (NeutralGear)
				{
					currentGear++;
					NeutralGear = false;
				}
				else
				{
					NeutralGear = true;
				}
			}
			else
			{
				currentGear++;
			}
		}
		else
		{
			currentGear++;
		}
		shiftDelay = timeSinceLevelLoad + 1f;
		shiftTime = 1.5f;
	}

	public void ShiftDown()
	{
		float timeSinceLevelLoad = Time.timeSinceLevelLoad;
		if (timeSinceLevelLoad < shiftDelay || (currentGear <= 0 && !NeutralGear))
		{
			return;
		}
		if (!carSetting.automaticGear)
		{
			if (currentGear == 1)
			{
				if (!NeutralGear)
				{
					currentGear--;
					NeutralGear = true;
				}
			}
			else if (currentGear == 0)
			{
				NeutralGear = false;
			}
			else
			{
				currentGear--;
			}
		}
		else
		{
			currentGear--;
		}
		shiftDelay = timeSinceLevelLoad + 0.1f;
		shiftTime = 2f;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (!carSounds.crash.isPlaying)
		{
			carSounds.crash.volume = Mathf.Clamp(myRigidbody.velocity.magnitude / 10f, 0.1f, 1f);
			carSounds.crash.Play();
		}
		if (collision.collider.CompareTag("Water"))
		{
			Application.LoadLevel(Application.loadedLevel);
		}
		if ((bool)collision.transform.root.GetComponent<VehicleControl>())
		{
			collision.transform.root.GetComponent<VehicleControl>().slip2 = Mathf.Clamp(collision.relativeVelocity.magnitude, 0f, 10f);
			myRigidbody.angularVelocity = new Vector3((0f - myRigidbody.angularVelocity.x) * 0.5f, myRigidbody.angularVelocity.y * 0.5f, (0f - myRigidbody.angularVelocity.z) * 0.5f);
			myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, myRigidbody.velocity.y * 0.5f, myRigidbody.velocity.z);
		}
	}

	private void OnCollisionStay(Collision collision)
	{
		if ((bool)collision.transform.root.GetComponent<VehicleControl>())
		{
			collision.transform.root.GetComponent<VehicleControl>().slip2 = 2f;
		}
	}

	private void Update()
	{
		if (AIVScript.vehicleStatus == VehicleStatus.EmptyOff)
		{
			carSounds.IdleEngine.mute = true;
			carSounds.nitro.mute = true;
		}
		else if (carOff)
		{
			carSounds.IdleEngine.mute = false;
			carSounds.nitro.mute = false;
			carOff = false;
		}
		if (AIVScript.vehicleStatus == VehicleStatus.AI)
		{
			AIVScript.AIActive = true;
		}
		else if (AIVScript.vehicleStatus == VehicleStatus.Player)
		{
			AIVScript.AIActive = false;
			AIVScript.automaticGear = carSetting.automaticGear;
			AIVScript.neutralGear = NeutralGear;
			AIVScript.currentGear = currentGear;
			AIVScript.motorRPM = motorRPM;
			AIVScript.powerShift = powerShift;
			if (!carSetting.automaticGear)
			{
				if (Input.GetKeyDown("page up"))
				{
					ShiftUp();
				}
				if (Input.GetKeyDown("page down"))
				{
					ShiftDown();
				}
			}
		}
		else
		{
			AIVScript.AIActive = false;
		}
	}

	private void FixedUpdate()
	{
		speed = myRigidbody.velocity.magnitude * 2.7f;
		AIVScript.vehicleSpeed = speed;
		if (speed < lastSpeed - 10f && slip < 10f)
		{
			slip = lastSpeed / 15f;
		}
		lastSpeed = speed;
		if (slip2 != 0f)
		{
			slip2 = Mathf.MoveTowards(slip2, 0f, 0.1f);
		}
		myRigidbody.centerOfMass = carSetting.shiftCentre;
		switch (AIVScript.vehicleStatus)
		{
		case VehicleStatus.EmptyOn:
			accel = 0f;
			steer = 0f;
			brake = false;
			shift = false;
			break;
		case VehicleStatus.AI:
			accel = AIVScript.AIAccel;
			steer = AIVScript.AISteer;
			brake = AIVScript.AIBrake;
			break;
		case VehicleStatus.Player:
			if (!carWheels.wheels.frontWheelDrive && !carWheels.wheels.backWheelDrive)
			{
				break;
			}
			if (GameControl.manager.controlMode == ControlMode.simple)
			{
				accel = 0f;
				brake = false;
				shift = false;
				steer = Mathf.MoveTowards(steer, Input.GetAxis("Horizontal"), 0.1f);
				accel = Input.GetAxis("Vertical");
				brake = Input.GetButton("Jump");
				shift = Input.GetKey(KeyCode.LeftShift) | Input.GetKey(KeyCode.RightShift);
				if (steer == 0f && PlayerBehaviour.CanDrift)
				{
					PlayerBehaviour.driftamount = 0f;
				}
			}
			else if (GameControl.manager.controlMode == ControlMode.touch)
			{
				if (GameControl.accelFwd != 0f)
				{
					accel = GameControl.accelFwd;
				}
				else
				{
					accel = GameControl.accelBack;
				}
				steer = Mathf.MoveTowards(steer, GameControl.steerAmount, 0.07f);
				brake = GameControl.brake;
				shift = GameControl.shift;
				if (GameControl.steerAmount == 0f && PlayerBehaviour.CanDrift)
				{
					PlayerBehaviour.driftamount = 0f;
				}
			}
			break;
		}
		if (!carWheels.wheels.frontWheelDrive && !carWheels.wheels.backWheelDrive)
		{
			accel = 0f;
		}
		if ((bool)carSetting.carSteer)
		{
			carSetting.carSteer.localEulerAngles = new Vector3(steerCurAngle.x, steerCurAngle.y, steerCurAngle.z + steer * -120f);
		}
		if (carSetting.automaticGear && currentGear == 1 && accel < 0f)
		{
			if (speed < 5f)
			{
				ShiftDown();
			}
		}
		else if (carSetting.automaticGear && currentGear == 0 && accel > 0f)
		{
			if (speed < 5f)
			{
				ShiftUp();
			}
		}
		else if (carSetting.automaticGear && motorRPM > carSetting.shiftUpRPM && accel > 0f && speed > 10f && !brake)
		{
			ShiftUp();
		}
		else if (carSetting.automaticGear && motorRPM < carSetting.shiftDownRPM && currentGear > 1)
		{
			ShiftDown();
		}
		if (speed < 1f)
		{
			Backward = true;
		}
		if (currentGear == 0 && Backward)
		{
			if (speed < carSetting.gears[0] * -10f)
			{
				accel = 0f - accel;
			}
			else
			{
				Backward = false;
			}
		}
		if (AIVScript.vehicleStatus != 0)
		{
			if (fbrake)
			{
				brake = true;
				accel = 0f;
				speed = 0f;
			}
			Light[] brakeLights = carLights.brakeLights;
			foreach (Light light in brakeLights)
			{
				if (brake || accel < 0f || speed < 1f || fbrake)
				{
					light.intensity = Mathf.MoveTowards(light.intensity, 8f, 0.5f);
				}
				else
				{
					light.intensity = Mathf.MoveTowards(light.intensity, 0f, 0.5f);
				}
				light.enabled = light.intensity != 0f;
			}
			brakeLights = carLights.reverseLights;
			foreach (Light light2 in brakeLights)
			{
				if (speed > 2f && currentGear == 0)
				{
					light2.intensity = Mathf.MoveTowards(light2.intensity, 8f, 0.5f);
				}
				else
				{
					light2.intensity = Mathf.MoveTowards(light2.intensity, 0f, 0.5f);
				}
				light2.enabled = light2.intensity != 0f;
			}
		}
		wantedRPM = 5500f * accel * 0.1f + wantedRPM * 0.9f;
		float num = 0f;
		int num2 = 0;
		bool flag = false;
		int num3 = 0;
		WheelComponent[] array = wheels;
		foreach (WheelComponent wheelComponent in array)
		{
			WheelCollider collider = wheelComponent.collider;
			if (wheelComponent.drive)
			{
				num = ((!NeutralGear && brake && currentGear < 2) ? (num + accel * carSetting.idleRPM) : (NeutralGear ? (num + carSetting.idleRPM * accel) : (num + collider.rpm)));
				num2++;
			}
			if (brake || accel < 0f)
			{
				if (accel < 0f || (brake && (wheelComponent == wheels[2] || wheelComponent == wheels[3])))
				{
					if (brake && accel > 0f)
					{
						slip = Mathf.Lerp(slip, 5f, accel * 0.01f);
					}
					else if (speed > 1f)
					{
						slip = Mathf.Lerp(slip, 1f, 0.002f);
					}
					else
					{
						slip = Mathf.Lerp(slip, 1f, 0.02f);
					}
					wantedRPM = 0f;
					collider.brakeTorque = carSetting.brakePower;
					wheelComponent.rotation = w_rotate;
				}
			}
			else
			{
				float brakeTorque;
				if (accel != 0f && !NeutralGear)
				{
					float num5 = (collider.brakeTorque = 0f);
					brakeTorque = num5;
				}
				else
				{
					float num5 = (collider.brakeTorque = 1000f);
					brakeTorque = num5;
				}
				collider.brakeTorque = brakeTorque;
				slip = ((!(speed > 0f)) ? (slip = Mathf.Lerp(slip, 0.01f, 0.02f)) : ((speed > 100f) ? (slip = Mathf.Lerp(slip, 1f + Mathf.Abs(steer), 0.02f)) : (slip = Mathf.Lerp(slip, 1.5f, 0.02f))));
				w_rotate = wheelComponent.rotation;
			}
			WheelFrictionCurve forwardFriction = collider.forwardFriction;
			forwardFriction.asymptoteValue = 5000f;
			forwardFriction.extremumSlip = 2f;
			forwardFriction.asymptoteSlip = 20f;
			forwardFriction.stiffness = carSetting.stiffness / (slip + slip2);
			collider.forwardFriction = forwardFriction;
			forwardFriction = collider.sidewaysFriction;
			forwardFriction.stiffness = carSetting.stiffness / (slip + slip2);
			forwardFriction.extremumSlip = 0.3f + Mathf.Abs(steer);
			forwardFriction.extremumValue = Mathf.Clamp(forwardFriction.extremumValue * (speed / 50f), 1f, 3f);
			collider.sidewaysFriction = forwardFriction;
			if (shift && currentGear > 1 && speed > 50f && shifmotor && Mathf.Abs(steer) < 0.2f)
			{
				if (powerShift == 0f)
				{
					shifmotor = false;
				}
				powerShift = Mathf.MoveTowards(powerShift, 0f, Time.deltaTime * 10f);
				carSounds.nitro.volume = Mathf.Lerp(carSounds.nitro.volume, 1f, Time.deltaTime * 10f);
				if (!carSounds.nitro.isPlaying)
				{
					carSounds.nitro.GetComponent<AudioSource>().Play();
				}
				curTorque = ((powerShift > 0f) ? carSetting.shiftPower : carSetting.carPower);
				carParticles.shiftParticle1.emissionRate = Mathf.Lerp(carParticles.shiftParticle1.emissionRate, (powerShift > 0f) ? 50 : 0, Time.deltaTime * 10f);
				carParticles.shiftParticle2.emissionRate = Mathf.Lerp(carParticles.shiftParticle2.emissionRate, (powerShift > 0f) ? 50 : 0, Time.deltaTime * 10f);
			}
			else
			{
				if (powerShift > 20f)
				{
					shifmotor = true;
				}
				carSounds.nitro.volume = Mathf.MoveTowards(carSounds.nitro.volume, 0f, Time.deltaTime * 2f);
				if (carSounds.nitro.volume == 0f)
				{
					carSounds.nitro.Stop();
				}
				powerShift = Mathf.MoveTowards(powerShift, 100f, Time.deltaTime * 5f);
				curTorque = carSetting.carPower;
				carParticles.shiftParticle1.emissionRate = Mathf.Lerp(carParticles.shiftParticle1.emissionRate, 0f, Time.deltaTime * 10f);
				carParticles.shiftParticle2.emissionRate = Mathf.Lerp(carParticles.shiftParticle2.emissionRate, 0f, Time.deltaTime * 10f);
			}
			wheelComponent.rotation = Mathf.Repeat(wheelComponent.rotation + Time.deltaTime * collider.rpm * 360f / 60f, 360f);
			wheelComponent.rotation2 = Mathf.Lerp(wheelComponent.rotation2, collider.steerAngle, 0.1f);
			wheelComponent.wheel.localRotation = Quaternion.Euler(wheelComponent.rotation, wheelComponent.rotation2, 0f);
			Vector3 localPosition = wheelComponent.wheel.localPosition;
			WheelHit hit;
			if (collider.GetGroundHit(out hit))
			{
				if ((bool)carParticles.brakeParticlePerfab)
				{
					if (Particle[num3] == null)
					{
						Particle[num3] = UnityEngine.Object.Instantiate(carParticles.brakeParticlePerfab, wheelComponent.wheel.position, Quaternion.identity);
						Particle[num3].name = "WheelParticle";
						Particle[num3].transform.parent = base.transform;
						Particle[num3].AddComponent<AudioSource>();
						Particle[num3].GetComponent<AudioSource>().volume = 0.2f;
						Particle[num3].GetComponent<AudioSource>().maxDistance = 50f;
						Particle[num3].GetComponent<AudioSource>().spatialBlend = 1f;
						Particle[num3].GetComponent<AudioSource>().dopplerLevel = 5f;
						Particle[num3].GetComponent<AudioSource>().rolloffMode = AudioRolloffMode.Custom;
					}
					ParticleSystem component = Particle[num3].GetComponent<ParticleSystem>();
					bool flag2 = false;
					for (int j = 0; j < carSetting.hitGround.Length; j++)
					{
						if (hit.collider.CompareTag(carSetting.hitGround[j].tag))
						{
							flag2 = carSetting.hitGround[j].grounded;
							if ((brake || Mathf.Abs(hit.sidewaysSlip) > 0.5f) && speed > 1f)
							{
								Particle[num3].GetComponent<AudioSource>().clip = carSetting.hitGround[j].brakeSound;
							}
							else if (Particle[num3].GetComponent<AudioSource>().clip != carSetting.hitGround[j].groundSound && !Particle[num3].GetComponent<AudioSource>().isPlaying)
							{
								Particle[num3].GetComponent<AudioSource>().clip = carSetting.hitGround[j].groundSound;
							}
							Particle[num3].GetComponent<ParticleSystem>().startColor = carSetting.hitGround[j].brakeColor;
						}
					}
					if (flag2 && speed > 5f && !brake)
					{
						component.enableEmission = true;
						Particle[num3].GetComponent<AudioSource>().volume = 0.2f;
						if (!Particle[num3].GetComponent<AudioSource>().isPlaying)
						{
							Particle[num3].GetComponent<AudioSource>().Play();
						}
					}
					else if ((brake || Mathf.Abs(hit.sidewaysSlip) > 0.6f) && speed > 1f)
					{
						if (accel < 0f || ((brake || Mathf.Abs(hit.sidewaysSlip) > 0.6f) && (wheelComponent == wheels[2] || wheelComponent == wheels[3])))
						{
							if (!Particle[num3].GetComponent<AudioSource>().isPlaying)
							{
								Particle[num3].GetComponent<AudioSource>().Play();
							}
							component.enableEmission = true;
							Particle[num3].GetComponent<AudioSource>().volume = 0.3f;
						}
					}
					else
					{
						component.enableEmission = false;
						Particle[num3].GetComponent<AudioSource>().volume = Mathf.Lerp(Particle[num3].GetComponent<AudioSource>().volume, 0f, Time.deltaTime * 10f);
					}
				}
				localPosition.y -= Vector3.Dot(wheelComponent.wheel.position - hit.point, base.transform.TransformDirection(0f, 1f, 0f) / base.transform.lossyScale.x) - collider.radius;
				localPosition.y = Mathf.Clamp(localPosition.y, -10f, wheelComponent.pos_y);
				flag = flag || wheelComponent.drive;
			}
			else
			{
				if (Particle[num3] != null)
				{
					Particle[num3].GetComponent<ParticleSystem>().enableEmission = false;
				}
				localPosition.y = wheelComponent.startPos.y - carWheels.setting.Distance;
				myRigidbody.AddForce(Vector3.down * 5000f);
			}
			num3++;
			wheelComponent.wheel.localPosition = localPosition;
		}
		if (num2 > 1)
		{
			num /= (float)num2;
		}
		motorRPM = 0.95f * motorRPM + 0.05f * Mathf.Abs(num * carSetting.gears[currentGear]);
		if (motorRPM > 5500f)
		{
			motorRPM = 5200f;
		}
		int num7 = (int)(motorRPM / efficiencyTableStep);
		if (num7 >= efficiencyTable.Length)
		{
			num7 = efficiencyTable.Length - 1;
		}
		if (num7 < 0)
		{
			num7 = 0;
		}
		float num8 = curTorque * carSetting.gears[currentGear] * efficiencyTable[num7];
		array = wheels;
		foreach (WheelComponent wheelComponent2 in array)
		{
			WheelCollider collider2 = wheelComponent2.collider;
			if (wheelComponent2.drive)
			{
				if (Mathf.Abs(collider2.rpm) > Mathf.Abs(wantedRPM))
				{
					collider2.motorTorque = 0f;
				}
				else
				{
					float motorTorque = collider2.motorTorque;
					if (!brake && accel != 0f && !NeutralGear)
					{
						if ((speed < carSetting.LimitForwardSpeed && currentGear > 0) || (speed < carSetting.LimitBackwardSpeed && currentGear == 0))
						{
							collider2.motorTorque = motorTorque * 0.9f + num8 * 1f;
						}
						else
						{
							collider2.motorTorque = 0f;
							collider2.brakeTorque = 2000f;
						}
					}
					else
					{
						collider2.motorTorque = 0f;
					}
				}
			}
			if (brake || slip2 > 2f)
			{
				collider2.steerAngle = Mathf.Lerp(collider2.steerAngle, steer * wheelComponent2.maxSteer, 0.02f);
				continue;
			}
			float num9 = Mathf.Clamp(speed / carSetting.maxSteerAngle, 1f, carSetting.maxSteerAngle);
			collider2.steerAngle = steer * (wheelComponent2.maxSteer / num9);
		}
		if (AIVScript.vehicleStatus != 0 && carSounds.IdleEngine != null)
		{
			float num10 = Mathf.Clamp(0.5f + (motorRPM - carSetting.idleRPM) / (carSetting.shiftUpRPM - carSetting.idleRPM) * 0.5f, 0f, 10f);
			num10 = Mathf.Clamp(0.6f + (motorRPM - carSetting.idleRPM) / (carSetting.shiftUpRPM - carSetting.idleRPM) * 0.5f, 0f, 10f);
			carSounds.IdleEngine.pitch = num10;
			carSounds.IdleEngine.volume = Mathf.MoveTowards(carSounds.IdleEngine.volume, 0.1f + Mathf.Abs(accel / 2.5f), 0.01f);
		}
	}

	private void OnDrawGizmos()
	{
		if (carSetting.showNormalGizmos && !Application.isPlaying)
		{
			Gizmos.matrix = Matrix4x4.TRS(base.transform.position, base.transform.rotation, base.transform.lossyScale);
			Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
			Gizmos.DrawCube(Vector3.up / 1.5f, new Vector3(2.5f, 2f, 6f));
			Gizmos.DrawSphere(carSetting.shiftCentre / base.transform.lossyScale.x, 0.2f);
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
