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
	private float previousAngle = 0f;
	public LayerMask layerMask;


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
		float pitch = CrossPlatformInputManager.GetAxis("Vertical");

		// auto throttle up, or down if braking.
    	m_Throttle = m_AirBrakes ? -1 : 1;

		Ray ray = new Ray(m_Aeroplane.transform.position, Vector3.down);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask.value))
		{
			float angle = Vector3.Angle(hit.normal, Vector3.up);
			if (hit.normal.z < 0) {
				angle *= -1;
			}
			if (!Mathf.Approximately(angle, previousAngle))
			{
				pitch = angle;
				previousAngle = angle;
			}
			Debug.DrawLine(ray.origin, hit.point);
			m_Aeroplane.Altitude = hit.distance;
			// Debug.Log("Altitude = " + m_Aeroplane.Altitude);
			// Debug.Log("Pitch = " + pitch);
		}

		// Pass the input to the aeroplane
		m_Aeroplane.Move(0.0f, pitch, m_Yaw, m_Throttle, m_AirBrakes);

		// Debug.Log("ForwardSpeed = " + m_Aeroplane.ForwardSpeed);
	}

}
