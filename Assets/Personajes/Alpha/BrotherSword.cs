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

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Enemy")) {
			// Do damage
			Debug.Log ("Hit espada");

			// Do extra damage
				if(other.gameObject.GetComponent<WhenBeHit>().freeze){
					Debug.Log ("Hit espada aumentado");
				}
		}
	}
}
