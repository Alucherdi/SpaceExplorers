using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kaleb_Q : Ability_abstract
{
    float costAbility = 25;
    public float cooldownQ = 0;
    public float cooldownQlimit;

    public override void launch()
    {
        SkillShotCursor.instance.Active(true);
    }

	void Update () {
        cooldownQlimit = PlayerController.instance.stats.stats.launchQcd - (PlayerController.instance.stats.stats.launchQcd * (PlayerController.instance.stats.stats.cooldownReduction / 100));

        if (cooldownQ == 0)
        {
            if (Input.GetMouseButtonUp(0) && SkillShotCursor.instance.activeCursor == true)
            {
                if (PlayerController.instance.barraStamina.fillAmount >= costAbility / PlayerController.instance.stats.stats.stamina)
                {
                    SkillShotCursor.instance.activeCursor = false;
                    PlayerController.instance.LookDestination(SkillShotCursor.instance.newPosition);
                    Bullet();
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
        }

        if (cooldownQ >= cooldownQlimit)
        {
            CancelInvoke("CoolDown");
            cooldownQ = 0;
        }
    }

    public void Bullet()
    {
        Debug.Log("Disparaste una bala");
        //Animacion
        BulletShooter.instance.BulletShot();
        InvokeRepeating("CoolDown", 0.1f, 1.0f);
    }

    void CoolDown()
    {
        cooldownQ++;
    }
}
