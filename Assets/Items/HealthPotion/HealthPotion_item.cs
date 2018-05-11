using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion_item : Item {

	// Use this for initialization
	void Start () {
		//active = new HealthPotion_active ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void Active(int slot)
    {
		Debug.Log ("Activa health potion");
	}
}
