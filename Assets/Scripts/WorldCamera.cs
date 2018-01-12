using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCamera : MonoBehaviour
{
public Transform target;

    public float distance = 50.0f; //distancia de la camara al personaje
    public float height = 20.0f;

    public float speed = 100.0f;
	public float speed2 = 30.0f;

	public float delta = 20;

    void Update()
    {
        //
        //Vector3 dir = new Vector3 (Input.GetAxisRaw ("Mouse X") * Time.deltaTime * speed, 0.0f, Input.GetAxisRaw ("Mouse Y") * Time.deltaTime * speed);

		// Verificar movimiento de la camara en world camera
		/*if (Input.GetAxis("Mouse X") > 0 || Input.GetAxis("Mouse Y") > 0)
            transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed, 0.0f);
		else if (Input.GetAxis("Mouse X") < 0 || Input.GetAxis("Mouse Y") > 0)
            transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed, 0.0f);*/

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
			transform.Translate (Vector3.up * Time.deltaTime * speed2, Space.World);
		}
		//Down
		if(Input.mousePosition.y <= Screen.height - delta){
			transform.Translate (Vector3.down * Time.deltaTime * speed2, Space.World);
		}

        if(Input.GetKeyDown(KeyCode.A))
        {
            Vector3 position = target.position; //obtiene posición del objeto que se queire seguir
            position += Quaternion.Euler(0.0f, 0.0f, 0.0f) * new Vector3(0.0f, height, -distance);

            transform.position = position;
            transform.LookAt(target); //Apunta hacia el personaje
        }
            
    }
}





/*public Transform target;

public float distance = 50.0f; //distancia de la camara al personaje
public float height = 20.0f;

public float speed = 100.0f;


void Update()
{
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

}*/
