using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasController : MonoBehaviour {

    public static CamerasController instance;
    public Camera playerCamera;

    void Start()
    {
        instance = this;
    }

    void Update () {

        //Habilita el script de la cámara a utilizar
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
