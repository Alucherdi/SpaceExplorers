using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_shooter : MonoBehaviour {

	public static Bullet_shooter instance;

	public GameObject bulletPrefab;
	public float bulletForce;
	private GameObject tmpBullet;

	void Start () {
		instance = this;
	}

	public void BulletShot()
	{
		tmpBullet = (GameObject)Instantiate(bulletPrefab, transform.position, transform.rotation);
		tmpBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletForce, ForceMode.VelocityChange);		
	}
}
