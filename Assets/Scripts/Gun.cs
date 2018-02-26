using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Gun : NetworkBehaviour {

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
		
	[Command]
	public void CmdperformShot(){
		if (shotAllowed) {
			Debug.Log ("Perform shot");
			BulletController newBullet = Instantiate (bullet, shootpoint.position, shootpoint.rotation) as BulletController;
			newBullet.speed = bulletSpeed;

			// Spawn bullet clients
			NetworkServer.Spawn(newBullet.gameObject);
			shotAllowed = false;
		}
	}


}
