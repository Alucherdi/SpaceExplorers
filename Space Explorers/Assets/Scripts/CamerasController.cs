using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasController : MonoBehaviour {

    public Camera playerCamera;
    public Camera worldCamera;
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.Y))
        {
            if (playerCamera.enabled == true)
            {
                playerCamera.enabled = false;
                worldCamera.enabled = true;
            }
            else
            {
                playerCamera.enabled = true;
                worldCamera.enabled = false;
            }
                
        }
        
    }
}
