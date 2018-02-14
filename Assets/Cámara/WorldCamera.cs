using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCamera : MonoBehaviour
{
    public Transform target;
    //public GameObject targetCharacter;

    public float distance = 50.0f; //distancia de la camara al personaje
    public float height = 20.0f;

    public float speed = 100.0f;
	public float speed2 = 30.0f;

	public float delta = 20;

    void Update()
    {
		// Verificar si la cámara se encuentra en un filo
		// Derecha
		if(Input.mousePosition.x >= Screen.width - delta){
			transform.Translate (Vector3.right * Time.deltaTime * speed2, Space.World);
		}
		// Izquierda
		if(Input.mousePosition.x <= 0 + delta){
			transform.Translate (Vector3.left * Time.deltaTime * speed2, Space.World);
		}
		// Up
		if(Input.mousePosition.y >= 0 + delta){
			transform.Translate (Vector3.forward * Time.deltaTime * speed2, Space.World);
		}
		//Down
		if(Input.mousePosition.y <= Screen.height - delta){
			transform.Translate (Vector3.back * Time.deltaTime * speed2, Space.World);
		}

        if(Input.GetKeyDown(KeyCode.A))
        {
            Vector3 position = target.position; //obtiene posición del objeto que se queire seguir
            position += Quaternion.Euler(0.0f, 0.0f, 0.0f) * new Vector3(0.0f, height, -distance);

            transform.position = position;

            /*if (CharacterSelection.instance.assassin == true)
                targetCharacter = GameObject.Find("IvanChamp");
            else if (CharacterSelection.instance.leo23 == true)
                targetCharacter = GameObject.Find("Player");
            //else if (CharacterSelection.instance.kaleb == true)
                //targetCharacter = GameObject.Find("Kaleb_Dune");
            else
                targetCharacter = GameObject.Find("EmptyCharacter");*/

            //target = targetCharacter.transform;
            transform.LookAt(target); //Apunta hacia el personaje
        }      
    }
}
