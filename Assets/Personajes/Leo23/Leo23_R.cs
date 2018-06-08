using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leo23_R : Ability_abstract
{
    float costAbility = 150;
    public float cooldownR = 0;
    public float cooldownRLimit;

    bool activeMurder;

    public override void launch()
    {

    }
	
	void Update () {
        cooldownRLimit = PlayerController.instance.stats.stats.launchRcd - (PlayerController.instance.stats.stats.launchRcd * (PlayerController.instance.stats.stats.cooldownReduction / 100));

        if (cooldownR == 0)
        {
            if (Input.GetMouseButtonUp(0) && PlayerController.instance.abilityR == true)
            {
                if (PlayerController.instance.barraStamina.fillAmount >= costAbility / PlayerController.instance.stats.stats.stamina)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hitEnemy;

                    if (Physics.Raycast(ray, out hitEnemy))
                    {
                        if (hitEnemy.collider.CompareTag("Enemy"))
                        {
                            PlayerController.instance.navMeshAgent.SetDestination(hitEnemy.point);
                            transform.LookAt(new Vector3(PlayerController.instance.newPosition.x, 0.0f, PlayerController.instance.newPosition.z));
                            PlayerController.instance.moving = true;

                            activeMurder = true;

                            PlayerController.instance.barraStamina.fillAmount -= costAbility / PlayerController.instance.stats.stats.stamina;
                            PlayerController.instance.AbilityOff();
                            MenuController.instance.skillR.fillAmount = 0;
                        }
                    }
                }
                else
                {
                    Debug.Log("Imposible utilizar la habilidad, poca stamina");
                }
            }
        }

        if (cooldownR >= cooldownRLimit)
        {
            CancelInvoke("CoolDown");
            cooldownR = 0;
            MenuController.instance.skillR.fillAmount = 1;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" && activeMurder == true)
        {
            PlayerController.instance.anim.SetFloat("Run", 0.0f);
            PlayerController.instance.moving = false;
            //PlayerController.instance.anim.SetTrigger("SpellR");
            PlayerController.instance.maincamera.GetComponent<OtherWorldEffect>().enabled = true;
            activeMurder = false;
            InvokeRepeating("CoolDown", 0.1f, 1.0f);
        }
    }

    void CoolDown()
    {
        cooldownR++;
        MenuController.instance.skillR.fillAmount += 1 / cooldownRLimit;
    }
}
