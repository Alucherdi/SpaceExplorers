using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
                    
public enum States {START,LOG_IN,LOBBY,IN_GAME,BACK_MENU,VICTORY,GAME_OVER,EXIT}
//Characterselection, Saladeespera, Opciones?
//LOG_OUT, SEARCH_MATCH

public class GameState : MonoBehaviour
{
    public static GameState gamestate;

    public States currentState;

    public delegate void LoginEvent();
    public LoginEvent login;
    public delegate void LobbyEvent();
    public LobbyEvent lobby;
    public delegate void GameEvent();
    public GameEvent game;
    public delegate void BackMenuEvent();
    public BackMenuEvent backmenu;
    public delegate void VictoryEvent();
    public VictoryEvent victory;
    public delegate void GameOverEvent();
    public GameOverEvent gameover;
    public delegate void ExitEvent();
    public ExitEvent exit;

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

        login += Login;
        lobby += Lobby;
        game += Game;
        backmenu += BackMenu;
        victory += Victory;
        gameover += GameOver;
        exit += ExitGame;
	}
	
    public void ChangeState(States newState)
    {
        currentState = newState;

        switch(currentState)
        {
            case States.LOG_IN:
                login();
                break;

            case States.LOBBY:
                lobby();
                break;

            case States.IN_GAME:
                game();
                break;

            case States.BACK_MENU:
                backmenu();
                break;

            case States.VICTORY:
                victory();
                break;

            case States.GAME_OVER:
                gameover();
                break;

            case States.EXIT:
                exit();
                break;
        }
    }

    public void Login()
    {

    }

    public void Lobby()
    {

    }

    public void Game()
    {

    }

    public void BackMenu()
    {

    }

    public void Victory()
    {

    }

    public void GameOver()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
