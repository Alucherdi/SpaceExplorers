using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assassin_W : Ability_abstract
{
    float costAbility = 50;
    public float cooldownW = 0;
    public float cooldownWlimit;

    public override void launch()
    {
        
    }

    void Update()
    {
        cooldownWlimit = PlayerController.instance.stats.stats.launchWcd - (PlayerController.instance.stats.stats.launchWcd * (PlayerController.instance.stats.stats.cooldownReduction / 100));

        if(cooldownW==0)
        {
            if (Input.GetMouseButtonUp(0) && PlayerController.instance.abilityW == true)
            {
                if (PlayerController.instance.barraStamina.fillAmount >= costAbility / PlayerController.instance.stats.stats.stamina)
                {
                    SmokeBomb();
                    //PlayerController.instance.LookDestination(SkillShotCursor.instance.newPosition);
                    PlayerController.instance.barraStamina.fillAmount -= costAbility / PlayerController.instance.stats.stats.stamina;
                    PlayerController.instance.AbilityOff();
                    HudController.instace.skillW.fillAmount = 0;
                }
                else
                {
                    Debug.Log("Imposible utilizar la habilidad, poca stamina");
                    PlayerController.instance.AbilityOff();
                }
            }
        }

        if (cooldownW >= cooldownWlimit)
        {
            CancelInvoke("CoolDown");
            cooldownW = 0;
            HudController.instace.skillW.fillAmount = 1;
        }
    }

    public void SmokeBomb()
    {
        Debug.Log("Utilizaste la bomba de humo para escapar =_=");
        //PlayerController.instance.anim.SetTrigger("SpellW");
        SmokeBombShooter.instance.BombShot();
        InvokeRepeating("CoolDown", 0.1f, 1.0f);
    }

    void CoolDown()
    {
        cooldownW++;
        HudController.instace.skillW.fillAmount += 1 / cooldownWlimit;
    }
}
