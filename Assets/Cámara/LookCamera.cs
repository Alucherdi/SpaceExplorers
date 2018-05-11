using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCamera : MonoBehaviour {
    public Transform target;

	public void Start()
	{
		target = GameObject.Find ("LookTarget").transform;
	}

    void Update()
    {
        transform.LookAt(target);//Dirige la vista hacia el target
    }
}
