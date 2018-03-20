using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeShooter : MonoBehaviour {

    public static KnifeShooter instance;

    public GameObject knifePrefab;
    public float knifeForce;
    private GameObject tmpKnife;

	void Start () {
        instance = this;
	}
	
	public void KnifeShot()
    {
        tmpKnife = (GameObject)Instantiate(knifePrefab, transform.position, transform.rotation);
        tmpKnife.GetComponent<Rigidbody>().AddForce(transform.forward * knifeForce, ForceMode.VelocityChange);		
	}
}
