using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

	// Use this for initialization
	public Transform position;
	public bool trap;
	public bool laser;
	public GameObject owner;
	public Ass_w ownerW;

	void Start () {
		trap = false;
		laser = true;
		owner = GameObject.FindGameObjectWithTag ("Player");
		ownerW = owner.GetComponent<Ass_w> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(trap){
			transform.Rotate (Vector3.up, 100f* Time.deltaTime);
		}
	}

	public void Shoot(){
	
	}

	public void OnMouseDown(){
		if(ownerW.trap){
			Debug.Log ("Me he convertido en una trampa");
			trap = true;
			ownerW.trap = false;
		}
		Debug.Log ("Has dado clic al objeto");
	}

	public void OnTriggerEnter(Collider other){
		if(trap && other.gameObject.CompareTag("Enemy")){
			Debug.Log ("Se ha activado el stun");
		}
	}


}
