using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brother : MonoBehaviour {

	// Use this for initialization
	public Transform begin;
	public float extRadius = 10.0f;
	public float followRadius = 10.0f;

	public List<GameObject> enemies;
	public List<bool> enemiesCheck;
	public float interval; // Para determinar el tiempo que tiene para actuar el ulti
	public float current; //

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool CheckClose(){
		for(int i=0; i < enemies.Count; i ++){
			if(Vector3.Distance(transform.position, enemies[i])){
				Debug.Log ("Siguiendo");
				Debug.Log (enemies);
				return true;// Si se encontro siguiente objetivo
			}
		}
		return false;
	}

	public void Follow(){
	
	}

	public void Freeze(){
	
	}
}
