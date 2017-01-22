using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	private List<Gate> gatesList = new List<Gate>();
	private bool hasWon = false;
	private bool hasLost = false;

	private GameObject player;
	public GameObject gates;
	public GameObject win;
	public GameObject loose;

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
		player = GameObject.FindGameObjectWithTag("Player");
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (player == null)
		{
			hasLost = true;
			loose.SetActive(true);
		}

		if (!hasWon && !hasLost)
		{
			var gatesChecked = gatesList.FindAll((gate) => {
				return gate.Passed == true;
			});

			if (gatesChecked.Count == gatesList.Count)
			{
				win.SetActive(true);
				Destroy(player);
				hasWon = true;
			}
		}
	}
}
