using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCameraSword : MonoBehaviour {

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
