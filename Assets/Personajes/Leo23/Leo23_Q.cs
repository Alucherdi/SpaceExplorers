using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leo23_Q : Ability_abstract
{
    int costAbility = 20;
    public float cooldownQ = 0;
    public float cooldownQlimit;
    public GameObject boomer;

    public override void launch()
    {
        
    }
	
	void Update () {

        cooldownQlimit = PlayerController.instance.stats.stats.launchQcd - (PlayerController.instance.stats.stats.launchQcd * (PlayerController.instance.stats.stats.cooldownReduction / 100));
        
        if(cooldownQ == 0)
        {
            if (Input.GetMouseButtonUp(0) && PlayerController.instance.abilityQ == true)
            {
                if (PlayerController.instance.barraStamina.fillAmount >= costAbility / PlayerController.instance.stats.stats.stamina)
                {
                    SkillShotCursor.instance.activeCursor = false;
                    GameObject clone;
                    clone = Instantiate(boomer, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.rotation) as GameObject;
                    PlayerController.instance.LookDestination(SkillShotCursor.instance.newPosition);
                    PlayerController.instance.barraStamina.fillAmount -= costAbility / PlayerController.instance.stats.stats.stamina;
                    PlayerController.instance.AbilityOff();
                }
                else
                {
                    Debug.Log("Imposible utilizar la habilidad, poca stamina");
                    PlayerController.instance.AbilityOff();
                }
            }
        }
        else
        {
            Debug.Log("Habilidad Q no disponible aún");
        }

        if (cooldownQ == cooldownQlimit)
        {
            CancelInvoke("CoolDown");
            cooldownQ = 0;
        }
    }

    void CoolDown()
    {
        cooldownQ++;
    }
}
