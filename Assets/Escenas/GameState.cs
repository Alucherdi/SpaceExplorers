using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
                    
public enum States {START,LOBBY,SEARCH_MATCH,IN_GAME,BACK_MENU,GAME_OVER,EXIT,LOG_OUT}

//public enum States { START, LOG_IN, LOBBY, SEARCH_MATCH, IN_GAME, BACK_MENU, VICTORY, GAME_OVER, EXIT, LOG_OUT }

public class GameState : MonoBehaviour
{
    public static GameState gamestate;

    public States currentState;

    public delegate void LobbyEvent();
    public LobbyEvent lobby;
    public delegate void SearchMatchEvent();
    public SearchMatchEvent searchmatch;
    public delegate void InGameEvent();
    public InGameEvent ingame;
    public delegate void BackMenuEvent();
    public BackMenuEvent backmenu;
    public delegate void GameOverEvent();
    public GameOverEvent gameover;
    public delegate void ExitEvent();
    public ExitEvent exit;
    public delegate void LogoutEvent();
    public LogoutEvent logout;

    void Awake()
    {
        if(gamestate == null)
        {
            gamestate = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start ()
    {
        currentState = States.START;

        lobby += Lobby;
        searchmatch += SearchMatch;
        ingame += InGame;
        backmenu += BackMenu;
        gameover += GameOver;
        exit += ExitGame;
        logout += Logout;
	}

    public void ChangeState(States newState)
    {
        currentState = newState;

        switch(currentState)
        {
            case States.LOBBY:
                lobby();
                break;

            case States.SEARCH_MATCH:
                searchmatch();
                break;

            case States.IN_GAME:
                ingame();
                break;

            case States.BACK_MENU:
                backmenu();
                break;

            case States.GAME_OVER:
                gameover();
                break;

            case States.EXIT:
                exit();
                break;

            case States.LOG_OUT:
                logout();
                break;
        }
    }

    public void Lobby()
    {
        Time.timeScale = 1;
        //MenuController.instance.Lobby();
    }

    public void SearchMatch()
    {
        //Matchmaking
    }

    public void InGame()
    {
        Time.timeScale = 1;
        Loader.instance.LoadScene(2);
        SceneManager.LoadScene(2);
        MenuController.instance.InGame();
    }

    public void BackMenu()
    {
        Time.timeScale = 1;
        //SceneManager.LoadScene(); //Escena donde esta el Menu
        MenuController.instance.Home();
    }

    public void GameOver()
    {
        Time.timeScale = 1;
        //SceneManager.LoadScene();//escena donde esta el GameOver
        MenuController.instance.GameOver();
    }

    public void Logout()
    {
        //
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
