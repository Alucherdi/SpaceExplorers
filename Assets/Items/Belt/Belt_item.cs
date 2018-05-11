using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belt_item : Item {

	// Use this for initialization
	void Start () {
		//active = new Belt_active ();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

	public override void Active(int slot){
		Debug.Log ("Activa belt");
	}
}
