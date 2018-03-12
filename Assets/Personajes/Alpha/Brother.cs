using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brother : MonoBehaviour {

	// Use this for initialization
	public Transform begin;
	public float extRadius = 10.0f;
	public float followRadius = 5.0f;
	public float speed;
	public List<GameObject> enemies;
	public List<bool> enemiesCheck;
	public float interval = 1.0f; // Para determinar el tiempo que tiene para actuar el ulti
	public float current; //
	public GameObject playerToFollow;
	public bool move;
	public bool follow;
	public bool cach;
	public bool search;
	public bool started;

	void Start () {
		/*
		for(int i=0; i < enemies.Count; i ++){
			enemiesCheck [i] = false;
		}
		current = Time.time + interval;
		cach = false;
		follow = false;
		search = true;
		move = CheckClose ();
		*/
		started = false;
		current = Time.time;
		//ArtificialStart ();
	}

	public void ArtificialStart(){
		for(int i=0; i < enemies.Count; i ++){
			enemiesCheck.Add(false);
		}
		current = Time.time + interval;
		cach = false;
		follow = false;
		search = true;
		//move = CheckClose ();
		started = true; // Esto se hace despues del primer frame
		// Y se borran los enemigos y los checks
	}

	// Update is called once per frame
	void Update () {
		if (current <= Time.time) {

			CheckClose ();
			Follow ();

		}

	}

	public bool CheckClose(){
		if (search) {
			for (int i = 0; i < enemies.Count; i++) {
				if (Vector3.Distance (transform.position, enemies [i].transform.position) <= followRadius && !enemiesCheck [i]) {
					Debug.Log ("Siguiendo");
					Debug.Log (i);
					enemiesCheck [i] = true;
					playerToFollow = enemies [i];
					follow = true;
					cach = false;
					search = false;
					return true;// Si se encontro siguiente objetivo

				}
			}

		}
		return false;
	}

	public void Follow(){
		if (follow) {
			// Seguir
			// Lerp
			transform.position = Vector3.Lerp(transform.position, playerToFollow.transform.position, Time.deltaTime * 2);
		}
	}

	public void Freeze(){

	}

	void OnTriggerEnter(Collider other){

		if (  other.gameObject.CompareTag("Enemy") && other.gameObject.name == playerToFollow.name ) {
			cach = true;
			follow = false;
			search = true;
			Debug.Log ("Hermano, lo he tocado!!");
			Debug.Log (other.gameObject.name);
			other.gameObject.GetComponent<Reactions> ().Freeze ();
		}
	}

	public void VanishBrother(){
		Destroy (this.gameObject);
	}
}
