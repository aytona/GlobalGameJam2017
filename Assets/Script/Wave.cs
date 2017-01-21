using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class Wave : MonoBehaviour {

    private NavMeshAgent agent;
    private Transform currentTarget;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        agent.Move(new Vector3(0.1f, 0.1f, 0.1f));
	}
}
