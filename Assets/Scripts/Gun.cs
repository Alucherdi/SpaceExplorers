using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	// Use this for initialization
	public Transform shootpoint;
	public bool shotAllowed;
	public BulletController bullet;
	public float bulletSpeed;
	public float cdshots;
	private float currentshot;

	void Start () {
		shotAllowed = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!shotAllowed) {
			if (currentshot <= 0) {
				currentshot = cdshots;
				// Can shot
				shotAllowed = true;
			} else {
				currentshot -= Time.deltaTime;
			}
		}
	}
		

	public void performShot(){
		if (shotAllowed) {
			Debug.Log ("Perform shot");
			BulletController newBullet = Instantiate (bullet, shootpoint.position, shootpoint.rotation) as BulletController;
			newBullet.speed = bulletSpeed;
			shotAllowed = false;
		}
	}


}
