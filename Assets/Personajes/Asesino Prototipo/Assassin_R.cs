using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Assassin_R : Ability_abstract
{
    int costAbility = 150;

    bool activemurder;

    public override void launch()
    {
        AreaSkillCursor.instance.Active(true);
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0) && AreaSkillCursor.instance.activeCursor == true)
        {
            if (PlayerController.instance.barraStamina.fillAmount >= costAbility / Wrapper.instace.character.stamina)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitEnemy;

                if (Physics.Raycast(ray, out hitEnemy))
                {
                    if (hitEnemy.collider.CompareTag("Enemy"))
                    {
                        PlayerController.instance.newPosition = hitEnemy.point;
                        transform.LookAt(new Vector3(PlayerController.instance.newPosition.x, 0.0f, PlayerController.instance.newPosition.z));
                        PlayerController.instance.moving = true;

                        activemurder = true;
                        
                        AreaSkillCursor.instance.activeCursor = false;
                        PlayerController.instance.barraStamina.fillAmount -= costAbility / Wrapper.instace.character.stamina;
                        PlayerController.instance.AbilityOff();
                    }
                }
            }
            else
            {
                AreaSkillCursor.instance.activeCursor = false;
                Debug.Log("Imposible utilizar la habilidad, poca stamina");
                PlayerController.instance.AbilityOff();
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" && activemurder==true)
        {
            PlayerController.instance.anim.SetFloat("Run", 0.0f);
            PlayerController.instance.moving = false;
            PlayerController.instance.anim.SetTrigger("SpellR");
            activemurder = false;
        }
    }
}
