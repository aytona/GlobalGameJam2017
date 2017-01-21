using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(NavMeshAgent))]
public class Wave : MonoBehaviour {

    public List<Transform> waypoints;
    public float rotateDistance;
    public float rotateSpeed;

    private NavMeshAgent agent;
    private int currentWaypoint = 0;

    private Vector3 rotateDirection;
    private Quaternion lookRotation;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = waypoints[currentWaypoint].position;
	}
	
	// Update is called once per frame
	void Update () {
        if(!agent.pathPending && agent.remainingDistance <= rotateDistance){
            agent.destination = waypoints[++currentWaypoint % waypoints.Count].position;
        }
    }
}
