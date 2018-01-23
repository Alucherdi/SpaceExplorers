using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Assassin_E : Ability_abstract
{
    int costAbility = 1;

    public override void launch()
    {
        ActiveCamouflage();
    }

    void Update()
    {
        if(PlayerController.instance.skinPlayer.enabled == false)
            PlayerController.instance.barraStamina.fillAmount -= costAbility / Wrapper.instace.character.stamina;

        if (Input.GetMouseButtonUp(0) || PlayerController.instance.barraStamina.fillAmount == 0)
            DisableCamouflage();
    }

    public void DisableCamouflage()
    {
        PlayerController.instance.skinPlayer.enabled = true;
    }

    public void ActiveCamouflage()
    {
        PlayerController.instance.skinPlayer.enabled = false;
    }
}
