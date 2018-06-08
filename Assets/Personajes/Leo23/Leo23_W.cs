using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leo23_W : Ability_abstract
{
    float costAbility = 50;
    public float cooldownW = 0;
    public float cooldownWLimit;

    bool activeTackle;

    public override void launch()
    {

    }
	
	void Update ()
    {
		cooldownWLimit = PlayerController.instance.stats.stats.launchWcd - (PlayerController.instance.stats.stats.launchWcd * (PlayerController.instance.stats.stats.cooldownReduction / 100));

        if (cooldownW == 0)
        {
            if (Input.GetMouseButtonUp(0) && PlayerController.instance.abilityW == true)
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

                            activeTackle = true;

                            PlayerController.instance.barraStamina.fillAmount -= costAbility / PlayerController.instance.stats.stats.stamina;
                            PlayerController.instance.AbilityOff();
                            MenuController.instance.skillW.fillAmount = 0;
                        }
                    }
                }
                else
                {
                    Debug.Log("Imposible utilizar la habilidad, poca stamina");
                }
            }
        }

        if (cooldownW >= cooldownWLimit)
        {
            CancelInvoke("CoolDown");
            cooldownW = 0;
            MenuController.instance.skillW.fillAmount = 1;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" && activeTackle == true)
        {
            PlayerController.instance.anim.SetFloat("Run", 0.0f);
            PlayerController.instance.moving = false;
            //PlayerController.instance.anim.SetTrigger("SpellW");
            activeTackle = false;
            InvokeRepeating("CoolDown", 0.1f, 1.0f);
        }
    }

    void CoolDown()
    {
        cooldownW++;
        MenuController.instance.skillW.fillAmount += 1 / cooldownWLimit;
    }
}
