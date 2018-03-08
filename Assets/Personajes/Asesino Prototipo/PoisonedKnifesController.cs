using System.Collections;
using UnityEngine;

public class PoisonedKnifesController : MonoBehaviour {
	// Falta quitar eliminar proyectil despues de ciero timpo
    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
