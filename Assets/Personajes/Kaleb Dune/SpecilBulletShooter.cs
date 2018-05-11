using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecilBulletShooter : MonoBehaviour {

    public static SpecilBulletShooter instance;

    public GameObject sbulletPrefab;
    public float sbulletForce;
    private GameObject tmpsBullet;

	void Start () {
        instance = this;
	}

    public void SBulletShot()
    {
        tmpsBullet = (GameObject)Instantiate(sbulletPrefab, transform.position, transform.rotation);
        tmpsBullet.GetComponent<Rigidbody>().AddForce(transform.forward * sbulletForce, ForceMode.VelocityChange);
    }
}
