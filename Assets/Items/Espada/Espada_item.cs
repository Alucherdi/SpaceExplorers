using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada_item : Item {

	// Use this for initialization
	void Start () {
		item_stats.physicalDamage = 10f;
		itemName = "Espada";
		//this.active = new Espada_activa ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public override void Active(){
		Debug.Log ("Activa earing");
	}
}
