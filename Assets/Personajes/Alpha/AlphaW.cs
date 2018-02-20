using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaW : Ability_abstract{

	// Hacer escudo temporal
	// Use this for initialization
	public GameObject shield1; // Shield
	public GameObject shield2; // shield2;
	public bool drawShield;
	Camera mainCamera;
	PlayerController pjController;

	// Cooldown de la habilidad
	float current;
	float interval = 5.0f;

	void Start () {
		drawShield = false;
		mainCamera = FindObjectOfType<Camera> ();
		pjController = GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (drawShield) {
			//shield1.GetComponent<MeshRenderer> ().enabled = true;
			//shield2.GetComponent<MeshRenderer> ().enabled = true;
			//Debug.Log ("Weapond unholded");
		

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
			shield1.GetComponent<MeshRenderer> ().enabled = false;
			shield2.GetComponent<MeshRenderer> ().enabled = false;
			//shield1.GetComponent<AlphaShield> ().DeactivateShield ();
			//shield2.GetComponent<AlphaShield> ().DeactivateShield();
		}
	}

	public override void launch(){
		Debug.Log ("AlphaW en cooldown");
		if(Time.time >= current){
			current = Time.time + interval;
			drawShield = !drawShield;
			//pjController.stay = false;
			if(drawShield){
				Debug.Log("Shield fuera");
				shield1.GetComponent<AlphaShield> ().ActivateShield ();
				shield2.GetComponent<AlphaShield> ().ActivateShield ();
			}else{
				Debug.Log("Shield dentro");

			}

			Debug.Log ("W");

			if (drawShield == true || GetComponent<AlphaE> ().drawGun == true) {
				pjController.stay = true;
			} else {
				pjController.stay = false;
			}
		}

	}

	public void stopShield(){
	  
		drawShield = false;
		if (drawShield == true || GetComponent<AlphaE> ().drawGun == true) {
			pjController.stay = true;
		} else {
			pjController.stay = false;
		}
	}
}
