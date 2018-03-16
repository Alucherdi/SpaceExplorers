using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour {

    public static CharacterSelection instance;

    public GameObject characterPanel;

    public GameObject champSelected;
    public string champname;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if(CharacterMenuController.instance.characterImage.sprite == CharacterMenuController.instance.champsImages[0])
            champname = "Leo23";
    }

    public void NewGame()
    {
        characterPanel.SetActive(false);
        GameState.gamestate.ChangeState(States.IN_GAME);
        champSelected = GameObject.FindWithTag(champname);
        champSelected.SetActive(true);
    }
}
