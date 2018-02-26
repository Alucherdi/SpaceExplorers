using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaE : Ability_abstract {

	// Use this for initialization
	Inventory inventory;
	public Gun gun;
	Camera mainCamera;
	public bool drawGun;
	public GameObject laser;
	PlayerController pjController;
	void Start () {
		drawGun = false;
		pjController = GetComponent<PlayerController> ();
		inventory = GetComponent<Inventory> ();
		gun = inventory.gun;
		mainCamera = FindObjectOfType<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (drawGun) {
			laser.GetComponent<MeshRenderer> ().enabled = true;
			//Debug.Log ("Weapond unholded");
			if (Input.GetMouseButtonDown (0)) {
				gun.CmdperformShot ();

			} 

			if (Input.GetMouseButtonUp (0)) {
				gun.CmdperformShot ();

			} 

			Vector3 target = new Vector3 (Input.mousePosition.x, transform.position.y, Input.mousePosition.z);
			//transform.LookAt (target);

			// look at mouse to aim the shoot
			Ray cameraRay = mainCamera.ScreenPointToRay (Input.mousePosition);
			Plane groundPlane = new Plane (Vector3.up, Vector3.zero);
			float rayLength;
			if (groundPlane.Raycast (cameraRay, out rayLength)) {
				Vector3 pointToLook = cameraRay.GetPoint (rayLength);
				Debug.DrawLine (cameraRay.origin, pointToLook, Color.blue);
				transform.LookAt (new Vector3 (pointToLook.x, transform.position.y, pointToLook.z));
			}

		} else {
			laser.GetComponent<MeshRenderer> ().enabled = false;
		}
	}

	public override void launch(){
		// Hond unhold gun
		drawGun = !drawGun;
	//	pjController.stay = false;
		if (gun != null) {
			Debug.Log ("gun is not null");
		} else {
			Debug.Log ("gun is null");
		}
		Debug.Log ("E");

		if (GetComponent<AlphaW> ().drawShield == true || drawGun == true) {
			pjController.stay = true;
		} else {
			pjController.stay = false;
		}
	}
}
