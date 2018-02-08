using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Escudo_activa : Active_abstract {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void launchActive(){
		GameObject.Find ("Shield").GetComponent<Image> ().fillAmount += .25f;
	}
}
