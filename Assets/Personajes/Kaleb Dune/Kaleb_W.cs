using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kaleb_W : Ability_abstract
{
    float costAbility = 1;
    public float cooldownW = 0;
    public float cooldownWlimit;

    public override void launch()
    {
        ActiveVision();
    }
	
	void Update () {

        cooldownWlimit = PlayerController.instance.stats.stats.launchWcd - (PlayerController.instance.stats.stats.launchWcd * (PlayerController.instance.stats.stats.cooldownReduction / 100));

        //Shader
        if (PlayerController.instance.maincamera.GetComponent<EnemyDetector>().enabled == true)
            PlayerController.instance.barraStamina.fillAmount -= costAbility / PlayerController.instance.stats.stats.stamina;

        if ((Input.GetMouseButtonUp(0) || PlayerController.instance.barraStamina.fillAmount == 0) && PlayerController.instance.abilityW == true)
            DisableSpell();

        if (cooldownW >= cooldownWlimit)
        {
            CancelInvoke("CoolDown");
            cooldownW = 0;
        }
    }

    public void DisableSpell()
    {
        //Shader
        PlayerController.instance.maincamera.GetComponent<EnemyDetector>().enabled = false;
        InvokeRepeating("CoolDown", 0.1f, 1.0f);
        PlayerController.instance.AbilityOff();
    }

    public void ActiveVision()
    {
        if (cooldownW == 0)
            //Shader
            PlayerController.instance.maincamera.GetComponent<EnemyDetector>().enabled = true;
        else
            Debug.Log("Habilidad W no disponible aún");
    }

    void CoolDown()
    {
        cooldownW++;
    }
}
