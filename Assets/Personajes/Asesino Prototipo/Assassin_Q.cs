using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Assassin_Q : Ability_abstract
{
    int costAbility = 25;
    public float cooldownQ=0;
    public float cooldownQlimit;

    public override void launch()
    {
        SkillShotCursor.instance.Active(true);
    }

    void Update()
    {
        cooldownQlimit = PlayerController.instance.stats.stats.launchQcd - (PlayerController.instance.stats.stats.launchQcd * (PlayerController.instance.stats.stats.cooldownReduction/100));

        if (cooldownQ == 0)
        {
            if (Input.GetMouseButtonUp(0) && SkillShotCursor.instance.activeCursor == true)
            {
                if (PlayerController.instance.barraStamina.fillAmount >= costAbility / PlayerController.instance.stats.stats.stamina)
                {
                    SkillShotCursor.instance.activeCursor = false;
                    PoisonedKnifes();
                    PlayerController.instance.LookDestination(SkillShotCursor.instance.newPosition);
                    PlayerController.instance.barraStamina.fillAmount -= costAbility / PlayerController.instance.stats.stats.stamina;
                    PlayerController.instance.AbilityOff();
                }
                else
                {
                    SkillShotCursor.instance.activeCursor = false;
                    Debug.Log("Imposible utilizar la habilidad, poca stamina");
                    PlayerController.instance.AbilityOff();
                }
            }
        }
        else
        {
            SkillShotCursor.instance.activeCursor = false;
            Debug.Log("Habilidad Q no disponible aún");
        }

        if (cooldownQ == cooldownQlimit)
        {
            CancelInvoke("CoolDown");
            cooldownQ = 0;
        } 
    }

    public void PoisonedKnifes()
    {
        Debug.Log("Utilizaste los cuchillos envenedados >:v");
        PlayerController.instance.anim.SetTrigger("SpellQ");
        InvokeRepeating("CoolDown", 0.1f, 1.0f);
    }

    void CoolDown()
    {
        cooldownQ++;
    }
}
