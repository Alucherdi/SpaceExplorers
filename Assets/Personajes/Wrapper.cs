using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrapper : MonoBehaviour
{
    private Interfaz[] abilities;

    void Start()
    {
        abilities = GetComponents<Interfaz>();
        abilities[1].Something();
    }

    void Update()
    {

    }
}
