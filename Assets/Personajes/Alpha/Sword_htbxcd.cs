using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_htbxcd : MonoBehaviour {
	// Scrip encargado de desrenderizar
	// El hitbox de la espada después de cierto tiempo

	// Use this for initialization
	public float current;
	public float interval = 0.1f;
	MeshRenderer thisRender;
	void Start () {
		thisRender = GetComponent<MeshRenderer> ();
		DeActive ();
	}

	// Update is called once per frame
	void Update () {
		if(!thisRender.enabled){
			return;
		}
		if(Time.time >= current){
			DeActive();
		}

	}

	public void Active(){
		// tiempo limite
		current = Time.time + interval;
		thisRender.enabled = true;
	}

	public void DeActive(){
		thisRender.enabled = false;
	}
}
