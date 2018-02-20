using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kaleb_W : Ability_abstract
{
    float costAbility = 25;
    public float cooldownW = 0;
    public float cooldownWlimit;

    public float wait = 0;

    public override void launch()
    {
        ActiveVision();
    }
	
	void Update () {

        cooldownWlimit = PlayerController.instance.stats.stats.launchWcd - (PlayerController.instance.stats.stats.launchWcd * (PlayerController.instance.stats.stats.cooldownReduction / 100));

        if ((Input.GetMouseButtonUp(0) || PlayerController.instance.barraStamina.fillAmount == 0) && PlayerController.instance.abilityW == true)
            DisableSpell();

        if (wait >= 7)
            DisableSpell();

        if (cooldownW >= cooldownWlimit)
        {
            CancelInvoke("CoolDown");
            cooldownW = 0;
        }
    }

    public void DisableSpell()
    {
        CancelInvoke("Wait");
        wait = 0;

        InvokeRepeating("CoolDown", 0.1f, 1.0f);
        //Shader
        PlayerController.instance.maincamera.GetComponent<EnemyDetector>().enabled = false;
        PlayerController.instance.barraStamina.fillAmount -= costAbility / PlayerController.instance.stats.stats.stamina;
        PlayerController.instance.AbilityOff();
    }

    public void ActiveVision()
    {
        if (cooldownW == 0)
        {
            PlayerController.instance.maincamera.GetComponent<EnemyDetector>().enabled = true;
            InvokeRepeating("Wait", 0.1f, 1.0f);
        }
        else
            Debug.Log("Habilidad W no disponible aún");
    }

    void CoolDown()
    {
        cooldownW++;
    }

    void Wait()
    {
        wait++;
    }
}
