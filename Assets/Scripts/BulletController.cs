using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletController : MonoBehaviour {

	public float speed;
	WhenBeHit otherr;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Translate (Vector3.forward * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		Debug.Log ("I hit something");
		Debug.Log (other.gameObject.tag);
		if (other.gameObject.CompareTag ("Enemy")) {
			Debug.Log ("I hit an enemy");
			other.gameObject.GetComponent<WhenBeHit> ().samuraiStack += 1;
			if (other.gameObject.GetComponent<WhenBeHit> ().samuraiStack  >= 3) {
				other.gameObject.GetComponent<WhenBeHit> ().Freeze ();
				other.gameObject.GetComponent<WhenBeHit> ().samuraiStack = 0;
			}
		}
		if (other.gameObject.CompareTag ("Player")) {
		  
		} else {
			Debug.Log ("I hit with ");
			Debug.Log (other.gameObject.tag);
			Destroy (gameObject);
		}
	}
}
