using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Assassin_E : Ability_abstract
{
    int costAbility = 1;
    public float cooldownE = 0;
    public float cooldownElimit;

    public override void launch()
    {
        ActiveCamouflage();
    }

    void Update()
    {
        cooldownElimit = PlayerController.instance.stats.stats.launchEcd - (PlayerController.instance.stats.stats.launchEcd * (PlayerController.instance.stats.stats.cooldownReduction / 100));

        if (PlayerController.instance.skinPlayer.enabled == false)
            PlayerController.instance.barraStamina.fillAmount -= costAbility / PlayerController.instance.stats.stats.stamina;

        if ((Input.GetMouseButtonUp(0) || PlayerController.instance.barraStamina.fillAmount == 0)&& PlayerController.instance.abilityE == true)
            DisableCamouflage();

        if (PlayerController.instance.moving == true)
            PlayerController.instance.abilityE = true;

        if (cooldownE == cooldownElimit)
        {
            CancelInvoke("CoolDown");
            cooldownE = 0;
        }
    }

    public void DisableCamouflage()
    {
        PlayerController.instance.skinPlayer.enabled = true;
        InvokeRepeating("CoolDown", 0.1f, 1.0f);
        PlayerController.instance.AbilityOff();
    }

    public void ActiveCamouflage()
    {
        if (cooldownE == 0)
            PlayerController.instance.anim.SetTrigger("SpellE");
        else
            Debug.Log("Habilidad E no disponible aún");
    }

    void CoolDown()
    {
        cooldownE++;
    }
}
