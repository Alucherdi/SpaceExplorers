using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCamera : MonoBehaviour
{
    public Transform target;

    public float distance = 50.0f; //distancia de la camara al personaje
    public float height = 20.0f;

    public float speed = 100.0f;

    Vector3 position;


    void Update()
    {
        /*Vector3 position = target.position; //obtiene posición del objeto que se queire seguir
        position += Quaternion.Euler(0.0f, 0.0f, 0.0f) * new Vector3(0.0f, height, -distance);*/


        if (Input.GetAxis("Mouse X") > 0)
            transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed, 0.0f, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed);
        else if (Input.GetAxis("Mouse X") < 0)
            transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed, 0.0f, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed);


        if(Input.GetKeyDown(KeyCode.A))
        {
            Vector3 position = target.position; //obtiene posición del objeto que se queire seguir
            position += Quaternion.Euler(0.0f, 0.0f, 0.0f) * new Vector3(0.0f, height, -distance);

            transform.position = position;
            transform.LookAt(target); //Apunta hacia el personaje
        }
            
    }
}