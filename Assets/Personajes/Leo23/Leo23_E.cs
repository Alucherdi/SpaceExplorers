using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leo23_E : Ability_abstract
{
    float costAbility = 1;
    public float cooldownE = 0;
    public float cooldownELimit;

    public override void launch()
    {
        ActiveOtherWorld();
    }
	
	void Update () {

        cooldownELimit = PlayerController.instance.stats.stats.launchEcd - (PlayerController.instance.stats.stats.launchEcd * (PlayerController.instance.stats.stats.cooldownReduction / 100));

        if (PlayerController.instance.maincamera.GetComponent<OtherWorldEffect>().enabled == true)
            PlayerController.instance.barraStamina.fillAmount -= costAbility / PlayerController.instance.stats.stats.stamina;

        if ((Input.GetMouseButtonUp(0) || PlayerController.instance.barraStamina.fillAmount == 0) && PlayerController.instance.abilityE == true)
            DisableSpell();

        if (PlayerController.instance.moving == true)
            PlayerController.instance.abilityE = true;

        if (cooldownE >= cooldownELimit)
        {
            CancelInvoke("CoolDown");
            cooldownE = 0;
        }
    }

    public void DisableSpell()
    {
        PlayerController.instance.maincamera.GetComponent<OtherWorldEffect>().enabled = false;
        InvokeRepeating("CoolDown", 0.1f, 1.0f);
        PlayerController.instance.AbilityOff();
    }

    public void ActiveOtherWorld()
    {
        if (cooldownE == 0)
            PlayerController.instance.maincamera.GetComponent<OtherWorldEffect>().enabled = true;
        else
            Debug.Log("Habilidad E no disponible aún");
    }

    void CoolDown()
    {
        cooldownE++;
    }
}