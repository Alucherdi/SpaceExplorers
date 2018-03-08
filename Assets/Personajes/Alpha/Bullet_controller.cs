using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_controller : MonoBehaviour {
	// Falta quitar eliminar proyectil despues de ciero timpo
	void OnCollisionEnter(Collision collision)
	{
		Destroy(this.gameObject);
	}
}
