using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    public static MenuController instance;

    public GameObject menuPanel;

    public GameObject shopPanel; //Tienda para venta de moneda del juego, skins para personajes/armas

    public GameObject rewardsPanel; //Premios que se pueden conseguir en la temporada

    public GameObject newsPanel; //Noticias del juego, actualización etc.

    public GameObject profilePanel; //Estadísticas del jugador, partidas/victoria/top5

    public GameObject optionsPanel; //Opciones de audio

    public GameObject lobbyPanel; //Selección de Personajes y modo de juego... compañeros...

    public GameObject gameoverPanel; //Letreró de partida terminada (victoria o no) estadísticas del jugador en la partida

	void Start () {

        instance = this;

        menuPanel.SetActive(true);
        shopPanel.SetActive(false);
        rewardsPanel.SetActive(false);
        newsPanel.SetActive(false);
        profilePanel.SetActive(false);
        optionsPanel.SetActive(false);
        lobbyPanel.SetActive(false);
        gameoverPanel.SetActive(false);
	}

    public void Shop()
    {
        menuPanel.SetActive(false);
        shopPanel.SetActive(true);
        rewardsPanel.SetActive(false);
        newsPanel.SetActive(false);
        profilePanel.SetActive(false);
        optionsPanel.SetActive(false);
        lobbyPanel.SetActive(false);
        gameoverPanel.SetActive(false);
    }

    public void Rewards()
    {
        menuPanel.SetActive(false);
        shopPanel.SetActive(false);
        rewardsPanel.SetActive(true);
        newsPanel.SetActive(false);
        profilePanel.SetActive(false);
        optionsPanel.SetActive(false);
        lobbyPanel.SetActive(false);
        gameoverPanel.SetActive(false);
    }

    public void News()
    {
        menuPanel.SetActive(false);
        shopPanel.SetActive(false);
        rewardsPanel.SetActive(false);
        newsPanel.SetActive(true);
        profilePanel.SetActive(false);
        optionsPanel.SetActive(false);
        lobbyPanel.SetActive(false);
        gameoverPanel.SetActive(false);
    }

    public void Profile()
    {
        menuPanel.SetActive(false);
        shopPanel.SetActive(false);
        rewardsPanel.SetActive(false);
        newsPanel.SetActive(false);
        profilePanel.SetActive(true);
        optionsPanel.SetActive(false);
        lobbyPanel.SetActive(false);
        gameoverPanel.SetActive(false);
    }

    public void Options()
    {
        menuPanel.SetActive(false);
        shopPanel.SetActive(false);
        rewardsPanel.SetActive(false);
        newsPanel.SetActive(false);
        profilePanel.SetActive(false);
        optionsPanel.SetActive(true);
        lobbyPanel.SetActive(false);
        gameoverPanel.SetActive(false);
    }

    public void Lobby()
    {
        menuPanel.SetActive(false);
        shopPanel.SetActive(false);
        rewardsPanel.SetActive(false);
        newsPanel.SetActive(false);
        profilePanel.SetActive(false);
        optionsPanel.SetActive(false);
        lobbyPanel.SetActive(true);
        gameoverPanel.SetActive(false);
    }

	public void GameOver()
    {
        menuPanel.SetActive(false);
        shopPanel.SetActive(false);
        rewardsPanel.SetActive(false);
        newsPanel.SetActive(false);
        profilePanel.SetActive(false);
        optionsPanel.SetActive(false);
        lobbyPanel.SetActive(false);
        gameoverPanel.SetActive(true);
    }

    public void ClosePanel()
    {
        menuPanel.SetActive(true);
        shopPanel.SetActive(false);
        rewardsPanel.SetActive(false);
        newsPanel.SetActive(false);
        profilePanel.SetActive(false);
        optionsPanel.SetActive(false);
        lobbyPanel.SetActive(false);
        gameoverPanel.SetActive(false);
    }
}
