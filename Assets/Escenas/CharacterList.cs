using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //elimnar despues
using UnityEngine.Networking;

public class CharacterList : MonoBehaviour
{

    public NetworkManager networkManager;

    public GameObject[] characterList;

    void Awake()
    {
        networkManager = GetComponent<NetworkManager>();
    }

    void Update()
    {
        if (CharacterSelection.instance.champname == "Leo23")
            //NetworkManager.Instantiate(characterList[0], transform.position, transform.rotation);
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

//Prueba Original
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //elimnar despues

public class CharacterList : MonoBehaviour
{

    public GameObject[] characterList;

    public GameObject Leo23;

    void Start()
    {
        characterList = new GameObject[transform.childCount];

        characterList[0] = GameObject.Find("Leo23");
        characterList[1] = GameObject.Find("Ek");
        characterList[2] = GameObject.Find("Kaleb_Dune");

        characterList[0].SetActive(false);
        characterList[1].SetActive(false);
        characterList[2].SetActive(false);
    }

    void Update()
    {
        if (CharacterSelection.instance.champname == "Leo23")
            characterList[0].SetActive(true);
        else if (CharacterSelection.instance.champname == "Ek")
            characterList[1].SetActive(true);
        else if (CharacterSelection.instance.champname == "Kaleb_Dune")
            characterList[2].SetActive(true);
    }

    //Eliminar para despues
    public void Back()
    {
        Time.timeScale = 1;
        Loader.instance.LoadScene(1);
        SceneManager.LoadScene(1);
        MenuController.instance.Home();
    }
}*/


//Primer Prueba con Network Manager
/*using System.Collections;
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
}*/
