using UnityEngine;
using System.Collections;

public class TestMove : MonoBehaviour {

    public float speed;

    private CharacterController controller;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        controller.Move(new Vector3(speed*Input.GetAxis("Horizontal"),0f,speed*Input.GetAxis("Vertical")));
	}
}
