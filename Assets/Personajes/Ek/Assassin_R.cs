﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Assassin_R : Ability_abstract
{
    float costAbility = 150;
    public float cooldownR = 0;
    public float cooldownRlimit;

    bool activeMurder;

    public override void launch()
    {
        AreaSkillCursor.instance.Active(true);
    }

    void Update()
    {
        cooldownRlimit = PlayerController.instance.stats.stats.launchRcd - (PlayerController.instance.stats.stats.launchRcd * (PlayerController.instance.stats.stats.cooldownReduction / 100));

        if(cooldownR==0)
        {
            if (Input.GetMouseButtonUp(0) && AreaSkillCursor.instance.activeCursor == true)
            {
                if (PlayerController.instance.barraStamina.fillAmount >= costAbility / PlayerController.instance.stats.stats.stamina)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hitEnemy;

                    if (Input.mousePosition.x < Screen.width * 0.5)
                        GetComponent<SpriteRenderer>().flipX = false;
                    else
                        GetComponent<SpriteRenderer>().flipX = true;

                    if (Physics.Raycast(ray, out hitEnemy))
                    {
                        if (hitEnemy.collider.CompareTag("Enemy"))
                        {
                            PlayerController.instance.navMeshAgent.SetDestination(hitEnemy.point);
                            transform.LookAt(new Vector3(PlayerController.instance.newPosition.x, 0.0f, PlayerController.instance.newPosition.z));
                            PlayerController.instance.moving = true;

                            activeMurder = true;

                            AreaSkillCursor.instance.activeCursor = false;
                            PlayerController.instance.barraStamina.fillAmount -= costAbility / PlayerController.instance.stats.stats.stamina;
                            PlayerController.instance.AbilityOff();
                            HudController.instace.skillR.fillAmount = 0;
                        }
                    }
                }
                else
                {
                    AreaSkillCursor.instance.activeCursor = false;
                    Debug.Log("Imposible utilizar la habilidad, poca stamina");
                }
            }
        }
        else
        {
            AreaSkillCursor.instance.activeCursor = false;
        }

        if (cooldownR >= cooldownRlimit)
        {
            CancelInvoke("CoolDown");
            cooldownR = 0;
            HudController.instace.skillR.fillAmount = 1;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" && activeMurder==true)
        {
            PlayerController.instance.anim.SetFloat("Run", 0.0f);
            PlayerController.instance.moving = false;
            //PlayerController.instance.anim.SetTrigger("SpellR");
            Debug.Log("Has asesinado al enemigo >:3");
            activeMurder = false;
            InvokeRepeating("CoolDown", 0.1f, 1.0f);
        }
    }

    void CoolDown()
    {
        cooldownR++;
        HudController.instace.skillR.fillAmount += 1 / cooldownRlimit;
    }
}
