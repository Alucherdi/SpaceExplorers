using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeBombController : MonoBehaviour {
    ParticleSystem smoke;

    void Start()
    {
        smoke = GetComponent<ParticleSystem>();

        smoke.Stop();
    }

    void OnCollisionEnter(Collision collision)
    {
        smoke.Play();
        Destroy(this.gameObject, 5.0f);
    }
}
