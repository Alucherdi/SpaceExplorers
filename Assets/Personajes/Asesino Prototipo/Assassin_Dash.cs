using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assassin_Dash : Ability_abstract {

    public static Assassin_Dash instance;

    int costAbility = 1;

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
        if(PlayerController.instance.dash == true)
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
}
