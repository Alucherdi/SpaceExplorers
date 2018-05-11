using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour {

    public static CharacterSelection instance;

    public GameObject characterPanel;
    public Button confirmButton;

    public string champname;

    void Start()
    {
        instance = this;

        confirmButton.interactable = false;
    }

    public void NewGame()
    {
        characterPanel.SetActive(false);
        GameState.gamestate.ChangeState(States.IN_GAME);
    }
}
