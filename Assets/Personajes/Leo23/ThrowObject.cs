using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour {

    public static ThrowObject instance;
    public GameObject boomer;

    // Use this for initialization
    void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	public void ObjectThrow()
    {
        GameObject clone;
        clone = Instantiate(boomer, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation) as GameObject;
    }
}
