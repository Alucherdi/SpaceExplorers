using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaQ : Ability_abstract {

	// Use this for initialization
	public GameObject sword;
	public PlayerController pcontroller;
	BrotherSword brothersword;
	void Start () {
		//PlayerController pcontroller = GetComponent<PlayerController> ();
		brothersword = sword.GetComponent<BrotherSword> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void launch(){
		Debug.Log ("Q");
		pcontroller.anim.SetFloat ("Forward", 0.0f);
		pcontroller.moving = false;
		brothersword.SwordAttack ();
	}
}
