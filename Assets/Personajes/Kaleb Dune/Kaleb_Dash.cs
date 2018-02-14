using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kaleb_Dash : Ability_abstract
{

    public static Kaleb_Dash instance;

    float costAbility = 1;
    public float cooldownDash = 0;
    public float cooldownDashLimit;

    public bool dash;

    public override void launch()
    {

    }

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        cooldownDashLimit = PlayerController.instance.stats.stats.launchDcd - (PlayerController.instance.stats.stats.launchDcd * (PlayerController.instance.stats.stats.cooldownReduction / 100));

        if (cooldownDash == 0)
        {
            if (PlayerController.instance.dash == true)
            {
                if (PlayerController.instance.barraStamina.fillAmount >= costAbility / PlayerController.instance.stats.stats.stamina)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hitFloor;

                    if (Physics.Raycast(ray, out hitFloor))
                    {
                        if (hitFloor.collider.CompareTag("Floor"))
                        {
                            PlayerController.instance.newPosition = hitFloor.point;
                            transform.LookAt(new Vector3(PlayerController.instance.newPosition.x, PlayerController.instance.newPosition.y, PlayerController.instance.newPosition.z));

                            dash = true;
                            InvokeRepeating("CoolDown", 0.1f, 1.0f);
                            PlayerController.instance.AbilityOff();
                        }
                    }
                }
                else
                {
                    Debug.Log("Imposible utilizar la habilidad, poca stamina");
                    PlayerController.instance.AbilityOff();
                }
            }
        }

        if (cooldownDash >= cooldownDashLimit)
        {
            CancelInvoke("CoolDown");
            cooldownDash = 0;
        }

        if (dash == true)
        {
            transform.Translate(new Vector3(0, 0, 3.0f));
            PlayerController.instance.barraStamina.fillAmount -= costAbility / PlayerController.instance.stats.stats.stamina;
            if (Vector3.Distance(transform.position, PlayerController.instance.newPosition) < 3.0f)
            {
                dash = false;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" && dash == true)
            dash = false;
    }

    void CoolDown()
    {
        cooldownDash++;
    }
}
