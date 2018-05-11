using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PruebaNetwork : NetworkManager {

    public override void OnServerConnect(NetworkConnection conn)
    {
        Debug.Log("Prueba de Conexión");
    }
}
