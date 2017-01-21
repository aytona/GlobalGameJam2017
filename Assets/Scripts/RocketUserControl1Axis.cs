using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Vehicles.Aeroplane;

public class RocketUserControl1Axis : MonoBehaviour {

	// reference to the aeroplane that we're controlling
	private AeroplaneController m_Aeroplane;
	private float m_Throttle;
	private bool m_AirBrakes;
	private float m_Yaw;


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

		// Pass the input to the aeroplane
		m_Aeroplane.Move(0.0f, 0.0f, m_Yaw, m_Throttle, m_AirBrakes);
	}

}
