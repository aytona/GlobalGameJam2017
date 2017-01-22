using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Vehicles.Aeroplane;

public class Gate : MonoBehaviour {

	private bool passed = false;
	
	public string playerCollider = "BodyCentreCapsule";
	
	public bool Passed { get; private set; }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// <summary>
	/// OnTriggerEnter is called when the Collider other enters the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.name.Equals(playerCollider))
		{
			Passed = true;
		}
	}
}
