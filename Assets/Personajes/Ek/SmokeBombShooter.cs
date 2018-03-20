using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeBombShooter : MonoBehaviour {

    public static SmokeBombShooter instance;

    public GameObject bombPrefab;
    public float bombForce;
    private GameObject tmpBomb;

	void Start () {
        instance = this;
    }
	
	public void BombShot() {
        tmpBomb = (GameObject)Instantiate(bombPrefab, transform.position, transform.rotation);
        tmpBomb.GetComponent<Rigidbody>().AddForce(transform.forward * bombForce, ForceMode.VelocityChange);
    }
}
