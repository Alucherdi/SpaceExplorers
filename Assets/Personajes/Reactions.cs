using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reactions : MonoBehaviour {
	// Samurai Stack
	// Use this for initialization
	// Samurai Stack
	public float samuraiStack; // Up to 3
	float freezeEnd=0;
	float freezeInverval=3.0f;
	public bool freeze; // true mientras esta freeze
	void Start () {
		samuraiStack = 0;
	}

	// Update is called once per frame
	void Update () {
		//	Debug.Log (this.tag);
		// Freeze cooldown
		if(freeze){
			if (Time.time >= freezeEnd) {
				Debug.Log (Time.time);
				Debug.Log ("Freeze temrinado");
				freeze = false;
			}
		}
	}

	public void Freeze(){
		freezeEnd = Time.time + freezeInverval; // Cuando termina el stun
		freeze = true;
		Debug.Log (Time.time);
	}


	public void Stun(){

	}

}
