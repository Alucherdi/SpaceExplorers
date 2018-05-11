using System.Collections;
using UnityEngine;

public class PoisonedKnifesController : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
