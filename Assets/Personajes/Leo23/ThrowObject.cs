using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ThrowObject : NetworkBehaviour{

    public static ThrowObject instance;
    public GameObject boomer;

    // Use this for initialization
    void Start () {
        instance = this;
		Debug.Log (this.gameObject.name);
	}
	
	// Update is called once per frame
	[Command]
	public void CmdObjectThrow()
    {
		Debug.Log ("Bulled created");
        GameObject clone;
        clone = Instantiate(boomer, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation) as GameObject;
		NetworkServer.Spawn (clone);
	}
}
