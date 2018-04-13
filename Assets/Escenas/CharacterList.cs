using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //elimnar despues
using UnityEngine.Networking;

public class CharacterList : MonoBehaviour {

    public NetworkManager networkManager;

    public GameObject[] characterList;

    void Awake () {
        networkManager = GetComponent<NetworkManager>();
    }

    void Update()
    {
        if (CharacterSelection.instance.champname == "Leo23")
            networkManager.playerPrefab = characterList[0];
        else if (CharacterSelection.instance.champname == "Ek")
            networkManager.playerPrefab = characterList[1];
        else if (CharacterSelection.instance.champname == "Kaleb_Dune")
            networkManager.playerPrefab = characterList[2];
    }

    //Eliminar para despues
    public void Back()
    {
        Time.timeScale = 1;
        Loader.instance.LoadScene(1);
        SceneManager.LoadScene(1);
        MenuController.instance.Home();
    }
}
