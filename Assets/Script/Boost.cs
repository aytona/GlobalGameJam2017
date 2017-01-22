using UnityEngine;
using System.Collections;

public class Boost : MonoBehaviour {

    public float force;


    void OnTriggerEnter(Collider other){
        Debug.Log(other.tag);
        if(other.tag == "Car"){
            Debug.Log("Force added");
            other.GetComponent<Rigidbody>().AddForce(other.transform.forward * force);
        }
    }
}
