using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrotherSword : MonoBehaviour {

	// Use this for initialization
	Animator anim;
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SwordAttack(){
		anim.SetTrigger ("AlphaQ");
	}
}
