using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

    //Vista de la cámara al personaje
    public Transform target;
    public GameObject targetCharacter;

    public float distance = 50.0f; //distancia de la camara al personaje
    public float height = 20.0f;

    void Update()
    {
        Vector3 position = target.position; //obtiene posición del objeto que se queire seguir
        position += Quaternion.Euler(0.0f, 0.0f, 0.0f) * new Vector3(0.0f, height, -distance);

        transform.position = position;

        if (CharacterSelection.instance.assassin == true)
            targetCharacter = GameObject.Find("IvanChamp");
        else if (CharacterSelection.instance.leo23 == true)
            targetCharacter = GameObject.Find("Player");
        else
            targetCharacter = GameObject.Find("EmptyCharacter");

        target = targetCharacter.transform;

        transform.LookAt(target); //Apunta hacia el personaje
    }
}
