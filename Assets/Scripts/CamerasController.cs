using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasController : MonoBehaviour {

    public Camera playerCamera;
	
	// Update is called once per frame
	void Update () {

        //gameObject.GetComponent<Script>().enabled = true;

        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (playerCamera.GetComponent<ThirdPersonCamera>().enabled == true)
            {
                playerCamera.GetComponent<ThirdPersonCamera>().enabled = false;
                playerCamera.GetComponent<WorldCamera>().enabled = true;
            }
            else
            {
                playerCamera.GetComponent<ThirdPersonCamera>().enabled = true;
                playerCamera.GetComponent<WorldCamera>().enabled = false;
            }
                
        }
        
    }
}
