using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaPotion_item : Item {

	// Use this for initialization
	void Start () {
		//active = new StaminaPotion_active ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void Active(int slot)
    {
		Debug.Log ("Activa stamina pot");
	}
}
