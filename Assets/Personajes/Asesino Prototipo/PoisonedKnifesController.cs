using System.Collections;
using UnityEngine;

public class PoisonedKnifesController : MonoBehaviour {

    private GameObject tmpDecal;

    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);

        //tmpDecal.transform.parent = objectCollider.gameObject.transform;
    }
}
