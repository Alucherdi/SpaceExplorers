using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Necklace_item : Item {

	// Use this for initialization
	void Start () {
		//active = new  Necklace_active ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void Active(){
		Debug.Log ("Activa necklace");
	}
}
