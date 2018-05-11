using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

    public static ThirdPersonCamera instance;
    //Vista de la cámara al personaje
    public Transform target;
    public GameObject targetCharacter;

    public float distance = 50.0f; //distancia de la camara al personaje
    public float height = 20.0f;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        Vector3 position = target.position; //obtiene posición del objeto que se queire seguir
        position += Quaternion.Euler(0.0f, 0.0f, 0.0f) * new Vector3(0.0f, height, -distance);

        transform.position = position;

        targetCharacter = GameObject.FindWithTag("Player");

        target = targetCharacter.transform;

        transform.LookAt(target); //Apunta hacia el personaje
    }
}
