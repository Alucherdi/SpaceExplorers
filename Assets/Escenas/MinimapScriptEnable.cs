using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapScriptEnable : MonoBehaviour {

    public Camera minimapCam;

	/*void Awake () {
        minimapCam.GetComponent<MinimapFollow>().enabled = true;
	}*/
	
	void Update () {
        minimapCam.GetComponent<MinimapFollow>().enabled = true;
    }
}
