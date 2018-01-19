using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Assassin_E : Ability_abstract
{
    int costAbility = 25;

    public override void launch()
    {
        ActiveCamouflage();
    }

    void Start()
    {

    }

    void Update()
    {
        if(PlayerController.instance.skinPlayer.enabled == false)
        {
            if (PlayerController.instance.barraStamina.fillAmount >= 1)
            {
                InvokeRepeating("Invisibilidad", 5.0f, 0.1f);
            }
        }


        if (PlayerController.instance.barraStamina.fillAmount == 0)
        {
            CancelInvoke("Invisibilidad");
            PlayerController.instance.skinPlayer.enabled = true;
        }

    }

    void Invisibilidad()
    {
        PlayerController.instance.barraStamina.fillAmount -= 0.02f;
    }

    public void ActiveCamouflage()
    {
        PlayerController.instance.skinPlayer.enabled = false;
    }
}
