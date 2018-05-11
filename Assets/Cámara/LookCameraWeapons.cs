using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCameraWeapons : MonoBehaviour {

    public GameObject pointView;
    public Transform target;

	void Start () {
        pointView  = GameObject.Find("LookTarget");
        target = pointView.transform;
    }
	
	void Update () {
        transform.LookAt(target);
    }
}
