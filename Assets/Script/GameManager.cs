using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public HoverCarControl racer;
    public GameObject cameraCurve;
    public GameObject carCamera;
    public Transform cameraSpot;

	// Use this for initialization
	void Start () {
        racer.enabled = false;
        StartCoroutine(Init());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator Init(){
        Debug.Log("Is this running?");
        yield return new WaitForSeconds(2.0f);
        cameraCurve.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        cameraCurve.SetActive(false);
        carCamera.transform.position = cameraSpot.position;
        racer.enabled = true;
    }
}
