using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo_item : Item {

	// Use this for initialization
	void Start () {
		item_stats.attackSpeed = 22f;
		itemName = "Escudo";
		//this.active = new Escudo_activa ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void Active(int slot)
    {
		Debug.Log ("Activa escudo");
	}

}
