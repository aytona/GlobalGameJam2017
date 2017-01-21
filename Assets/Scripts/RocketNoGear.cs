using System;
using UnityEngine;

public class RocketNoGear : MonoBehaviour
{

	private enum GearState
	{
		Raised = -1,
		Lowered = 1
	}

	// The landing gear can be raised and lowered at differing altitudes.
	// The gear is only lowered when descending, and only raised when climbing.

	// this script detects the raise/lower condition and sets a parameter on
	// the animator to actually play the animation to raise or lower the gear.

	public bool raised = true;

	private GearState m_State = GearState.Raised;
	private Animator m_Animator;

	// Use this for initialization
	private void Start()
	{
		m_Animator = GetComponent<Animator>();
	}


	// Update is called once per frame
	private void Update()
	{
		if (raised)
		{
			m_State = GearState.Raised;
		}
		else
		{
			m_State = GearState.Lowered;
		}

		// set the parameter on the animator controller to trigger the appropriate animation
		m_Animator.SetInteger("GearState", (int) m_State);
	}
}
