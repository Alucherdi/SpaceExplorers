using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour {

	// Use this for initialization
	public List<GameObject> enemies;
	public float current;
	public float interval= 0.2f;
	public GameObject brother;
	public bool created;
	void Start () {
		current = Time.time+interval;
		created = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (created) {
			if (Time.time >= current) {
				Instantiate (brother, transform.position, transform.rotation);
				brother.GetComponent<Brother> ().enemies = enemies;
				brother.GetComponent<Brother> ().ArtificialStart ();
				created = false;
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("Enemy")){
			Debug.Log ("******"+other.gameObject.name);
			enemies.Add (other.gameObject);
		}
	}


}
