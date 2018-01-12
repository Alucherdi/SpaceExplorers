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

    }
}
