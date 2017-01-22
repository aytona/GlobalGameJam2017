using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public List<Gate> gatesList = new List<Gate>();

	public GameObject gates;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		var gatesGameObject = gates.GetComponentsInChildren<Gate>();
		foreach (var gateGameObject in gatesGameObject)
		{
			gatesList.Add(gateGameObject);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var gatesChecked = gatesList.FindAll((gate) => {
			return gate.Passed == true;
		});

		if (gatesChecked.Count == gatesList.Count)
		{
			Debug.Log("Win");
		}
	}
}
