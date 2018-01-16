using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
                    
public enum States {START,GAME,RESTART,BACK_MENU,GAME_OVER,EXIT,TUTORIAL}

// START, GAME, RETURN_MENU, OPTIONS, EXIT

public class GameState : MonoBehaviour
{
    public static GameState gamestate;

    public static GameState instance;
    public States currentState;

    public delegate void GameEvent();
    public GameEvent game;
    public delegate void RestartEvent();
    public RestartEvent restart;
    public delegate void BackMenuEvent();
    public BackMenuEvent backmenu;
    public delegate void GameOverEvent();
    public GameOverEvent gameOver;
    public delegate void ExitEvent();
    public ExitEvent exitGame;
    public delegate void TutoEvent();
    public ExitEvent tuto;

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
        instance = this;
        currentState = States.START;

        game += Game;
        restart += GameRestart;
        backmenu += BackMenu;
        gameOver += GameOver;
        exitGame += ExitGame;
        tuto += VerTuto;
	}
	
    public void ChangeState(States newState)
    {
        currentState = newState;

        switch(currentState)
        {
            case States.GAME:
                game();
                break;

            case States.RESTART:
                restart();
                break;

            case States.BACK_MENU:
                backmenu();
                break;

            case States.GAME_OVER:
                gameOver();
                break;

            case States.EXIT:
                exitGame();
                break;
			case States.TUTORIAL:
				VerTuto();
				break;
        }
    }
    
	public void Game()
    {

    }

	public void VerTuto()
	{

	}

    public void GameRestart()
    {

    }

    public void BackMenu()
    {

    }

    public void GameOver()
    {

    }

    public void MenuMusic()
    {

    }

    public void Credits()
    {

    }

    public void GameMusic()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
