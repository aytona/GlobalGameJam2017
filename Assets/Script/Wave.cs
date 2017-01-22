using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BansheeGz.BGSpline.Curve;

public class Wave : MonoBehaviour {

    public BGCurve curve;

    public void StartCurve(){
        curve.gameObject.SetActive(true);
    }
}
