using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    public static MenuController instance;

    public GameObject menuPanel;

    public GameObject homePanel;

    public GameObject accountPanel;

    public GameObject configPanel;

    public GameObject newsPanel;

    public GameObject rewardsPanel;

    public GameObject charactersPanel;

    public GameObject shopPanel;

    public GameObject gameoverPanel;

    public GameObject logoutPanel;

    public GameObject hudPanel;
    public Text health;
    public Text stamina;
    public Text physicalDamege;
    public Text energyDamage;
    public Text physicalResist;
    public Text energyResist;
    public Text moveSpeed;
    public Text attackSpeed;

    public Image skillQ;
    public Image skillW;
    public Image skillE;
    public Image skillR;

    void Start () {
        instance = this;

        Home();
	}

    public void Home()
    {
        menuPanel.SetActive(true);
        homePanel.SetActive(true);
        accountPanel.SetActive(false);
        configPanel.SetActive(false);
        newsPanel.SetActive(false);
        rewardsPanel.SetActive(false);
        charactersPanel.SetActive(false);
        shopPanel.SetActive(false);
        gameoverPanel.SetActive(false);
        logoutPanel.SetActive(false);
        hudPanel.SetActive(false);
    }

    public void MyAccount()
    {
        menuPanel.SetActive(true);
        homePanel.SetActive(false);
        accountPanel.SetActive(true);
        configPanel.SetActive(false);
        newsPanel.SetActive(false);
        rewardsPanel.SetActive(false);
        charactersPanel.SetActive(false);
        shopPanel.SetActive(false);
        gameoverPanel.SetActive(false);
        logoutPanel.SetActive(false);
        hudPanel.SetActive(false);
    }

    public void Options()
    {
        menuPanel.SetActive(true);
        homePanel.SetActive(false);
        accountPanel.SetActive(false);
        configPanel.SetActive(true);
        newsPanel.SetActive(false);
        rewardsPanel.SetActive(false);
        charactersPanel.SetActive(false);
        shopPanel.SetActive(false);
        gameoverPanel.SetActive(false);
        logoutPanel.SetActive(false);
        hudPanel.SetActive(false);
    }

    public void News()
    {
        menuPanel.SetActive(true);
        homePanel.SetActive(false);
        accountPanel.SetActive(false);
        configPanel.SetActive(false);
        newsPanel.SetActive(true);
        rewardsPanel.SetActive(false);
        charactersPanel.SetActive(false);
        shopPanel.SetActive(false);
        gameoverPanel.SetActive(false);
        logoutPanel.SetActive(false);
        hudPanel.SetActive(false);
    }

    public void Rewards()
    {
        menuPanel.SetActive(true);
        homePanel.SetActive(false);
        accountPanel.SetActive(false);
        configPanel.SetActive(false);
        newsPanel.SetActive(false);
        rewardsPanel.SetActive(true);
        charactersPanel.SetActive(false);
        shopPanel.SetActive(false);
        gameoverPanel.SetActive(false);
        logoutPanel.SetActive(false);
        hudPanel.SetActive(false);
    }

    public void CharSelection()
    {
        CharacterSelection.instance.confirmButton.interactable = false;
        CharacterMenuController.instance.NoPlayerSelection();

        menuPanel.SetActive(false);
        homePanel.SetActive(false);
        accountPanel.SetActive(false);
        configPanel.SetActive(false);
        newsPanel.SetActive(false);
        rewardsPanel.SetActive(false);
        charactersPanel.SetActive(true);
        shopPanel.SetActive(false);
        gameoverPanel.SetActive(false);
        logoutPanel.SetActive(false);
        hudPanel.SetActive(false);
    }

    public void Shop()
    {
        menuPanel.SetActive(true);
        homePanel.SetActive(false);
        accountPanel.SetActive(false);
        configPanel.SetActive(false);
        newsPanel.SetActive(false);
        rewardsPanel.SetActive(false);
        charactersPanel.SetActive(false);
        shopPanel.SetActive(true);
        gameoverPanel.SetActive(false);
        logoutPanel.SetActive(false);
        hudPanel.SetActive(false);
    }

    public void InGame()
    {
        menuPanel.SetActive(false);
        homePanel.SetActive(false);
        accountPanel.SetActive(false);
        configPanel.SetActive(false);
        newsPanel.SetActive(false);
        rewardsPanel.SetActive(false);
        charactersPanel.SetActive(false);
        shopPanel.SetActive(false);
        gameoverPanel.SetActive(false);
        logoutPanel.SetActive(false);
        hudPanel.SetActive(true);
    }

    public void GameOver()
    {
        menuPanel.SetActive(false);
        homePanel.SetActive(false);
        accountPanel.SetActive(false);
        configPanel.SetActive(false);
        newsPanel.SetActive(false);
        rewardsPanel.SetActive(false);
        charactersPanel.SetActive(false);
        shopPanel.SetActive(false);
        gameoverPanel.SetActive(true);
        logoutPanel.SetActive(false);
        hudPanel.SetActive(false);
    }

    public void LogOut()
    {
        logoutPanel.SetActive(true);
    }

    public void CloseLogOut()
    {
        logoutPanel.SetActive(false);
    }
}
