using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ass_w : Ability_abstract {
	public bool trap;
	// Use this for initialization
	void Start () {
		trap = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void launch(){
		Debug.Log ("Ass w");
		trap = true;
	}
}
