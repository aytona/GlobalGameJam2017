﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Vehicles.Aeroplane;

public class RocketUserControl1Axis : MonoBehaviour {

	[SerializeField] private float m_PitchSensitivity = .5f;        // How sensitively the AI applies the pitch controls
    [SerializeField] private float m_MaxClimbAngle = 45;            // The maximum angle that the AI will attempt to make plane can climb at
	[SerializeField] private float m_SpeedEffect = 0.01f;           // This increases the effect of the controls based on the plane's speed.
	[SerializeField] private float m_maxDistance = 150f;

	// reference to the aeroplane that we're controlling
	private AeroplaneController m_Aeroplane;
	private float m_Throttle;
	private bool m_AirBrakes;
	private float m_Yaw;
	public LayerMask layerMask;
	public float lerp = 0.5f;
	public float initVal = 0f;

	private float pitch = 0f;
	private float changePitch = 0f;
	private float targetAnglePitch = 0f;
	private float previousAngle = 0f;
	private float threshold = 0f;


	private void Awake()
	{
		// Set up the reference to the aeroplane controller.
		m_Aeroplane = GetComponent<AeroplaneController>();
	}


	private void FixedUpdate()
	{
		// Read input for the pitch, yaw, roll and throttle of the aeroplane.
		m_AirBrakes = CrossPlatformInputManager.GetButton("Fire1");
		m_Yaw = CrossPlatformInputManager.GetAxis("Horizontal");

		// auto throttle up, or down if braking.
    	m_Throttle = m_AirBrakes ? -1 : 1;

		// var direction = transform.TransformDirection(Vector3.forward);
		var direction = Vector3.down;
		var ray = new Ray(m_Aeroplane.transform.position, direction);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, m_maxDistance, layerMask.value))
		{
			Debug.DrawLine(ray.origin, hit.point);
			m_Aeroplane.Altitude = hit.distance;

			float targetAnglePitch = -Vector3.Angle(hit.normal, -direction);
			if (!Mathf.Approximately(previousAngle, targetAnglePitch))
			{
				previousAngle = targetAnglePitch;

				// Set the target for the planes pitch, we check later that this has not passed the maximum threshold
				targetAnglePitch = Mathf.Clamp(targetAnglePitch, -m_MaxClimbAngle*Mathf.Deg2Rad, m_MaxClimbAngle*Mathf.Deg2Rad);

				// calculate the difference between current pitch and desired pitch
				changePitch = targetAnglePitch - m_Aeroplane.PitchAngle;

				// AI applies elevator control (pitch, rotation around x) to reach the target angle
				pitch = changePitch*m_PitchSensitivity;
				// adjust how fast the AI is changing the controls based on the speed. Faster speed = faster on the controls.
				float currentSpeedEffect = 1 + (m_Aeroplane.ForwardSpeed * m_SpeedEffect);
				pitch *= currentSpeedEffect;
			}
		}

		// Pass the input to the aeroplane
		m_Aeroplane.Move(0.0f, pitch, m_Yaw, m_Throttle, m_AirBrakes);

		// Debug.Log("ForwardSpeed = " + m_Aeroplane.ForwardSpeed);
	}

}