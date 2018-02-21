using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MonoBehaviour {

	void Update () {

        //"Zoom" utilizando la vista Ortográfica
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && GetComponent<Camera>().orthographicSize > 4)
            GetComponent<Camera>().orthographicSize--;
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && GetComponent<Camera>().orthographicSize < 20)
            GetComponent<Camera>().orthographicSize++;

        //Zoom utilizando vista en Perspectiva
        //Distancia minima 25
        //Distancia maxima 100
        if (CamerasController.instance.playerCamera.GetComponent<ThirdPersonCamera>().enabled == true)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0 && ThirdPersonCamera.instance.distance > 25)
                ThirdPersonCamera.instance.distance--;
            if (Input.GetAxis("Mouse ScrollWheel") < 0 && ThirdPersonCamera.instance.distance < 50)
                ThirdPersonCamera.instance.distance++;
        }
    }
}
