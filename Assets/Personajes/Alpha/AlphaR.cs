using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaR : Ability_abstract {

	// Use this for initialization
	public GameObject area;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void launch(){
		Instantiate (area, transform.position, transform.rotation);
		Debug.Log ("R");
		// Buscar enemigos y ponerlos en la lista.

	}
}
