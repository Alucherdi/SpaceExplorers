using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaShield: MonoBehaviour {

	// Use this for initialization
	public AlphaW alphaw;
	public float interval;
	public float current;
	public bool activate;
	void Start () {
		interval = 0.7f;
		activate = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (activate) {
			
			if (Time.time >= current) {
				DeactivateShield ();
			}
		}

	}

	public void ActivateShield(){
		activate = true;
		GetComponent<MeshRenderer> ().enabled = true;
		current = Time.time + interval;

	}

	public void DeactivateShield(){
		activate = false;
		GetComponent<MeshRenderer> ().enabled = false;
		alphaw.stopShield ();
	}
}
