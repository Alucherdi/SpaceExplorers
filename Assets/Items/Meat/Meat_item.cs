using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat_item : Item {

	// Use this for initialization
	void Start () {
		itemName = "Meat";
		item_stats.energyResist = 10;
		//this.active = new Meat_active ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void Active(int slot)
    {
		Debug.Log ("Activa meat");
	}
}
