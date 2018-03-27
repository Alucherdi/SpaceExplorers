using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //elimnar despues

public class CharacterList : MonoBehaviour {

    public GameObject[] characterList;

	void Awake () {
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
}
