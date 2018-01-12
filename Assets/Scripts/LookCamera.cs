using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCamera : MonoBehaviour {
    public Transform target;

    void Update()
    {
        transform.LookAt(target);//Dirige la vista hacia el target
    }
}
