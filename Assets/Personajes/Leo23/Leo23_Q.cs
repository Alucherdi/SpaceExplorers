using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leo23_Q : Ability_abstract
{
    float costAbility = 20;
    public float cooldownQ = 0;
    public float cooldownQlimit;
    public GameObject throwObject;

    public override void launch()
    {
        throwObject.SetActive(true);
    }

    void Start()
    {
        throwObject.SetActive(false);
    }

    void Update () {

        cooldownQlimit = PlayerController.instance.stats.stats.launchQcd - (PlayerController.instance.stats.stats.launchQcd * (PlayerController.instance.stats.stats.cooldownReduction / 100));

        if (cooldownQ == 0)
        {
            if (Input.GetMouseButtonUp(0) && PlayerController.instance.abilityQ == true)
            {
                if (PlayerController.instance.barraStamina.fillAmount >= costAbility / PlayerController.instance.stats.stats.stamina)
                {
                    SkillShotCursor.instance.activeCursor = false;
                    ThrowObject.instance.CmdObjectThrow();
                    InvokeRepeating("CoolDown", 0.1f, 1.0f);
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
        else if (cooldownQ < 2)
        {
            if(LightsaberController.instance.throwobject==true)
            {
                throwObject.SetActive(false);
                LightsaberController.instance.throwobject = false;
            }
        }

        if (cooldownQ >= cooldownQlimit)
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
