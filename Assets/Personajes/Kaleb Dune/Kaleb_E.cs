using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kaleb_E : Ability_abstract
{
    float costAbility = 25;
    public float cooldownE = 0;
    public float cooldownElimit;

    public GameObject playerKaleb;
    public bool jump;
    public float jumpingTime = 0;

    public override void launch()
    {
        Jump();
    }

    void Start()
    {
        jump = false;

        playerKaleb = GameObject.Find("Kaleb_Dune");
    }

    void Update()
    {

        cooldownElimit = PlayerController.instance.stats.stats.launchEcd - (PlayerController.instance.stats.stats.launchEcd * (PlayerController.instance.stats.stats.cooldownReduction / 100));

        if(jump == true)
        {
            /*
            //Subir perosnaje
            If(Input.GetMouseButtonUp(0) && PlayerController.instance.abilityE==true);
                //Bajar personaje
                Click al piso, ese es el punto ddonde baja
                Realizar AirAttack();
                
            */
        }

        if (jumpingTime >= 10)
        {
            CancelInvoke("JumpingTime");
            jump = false;
            jumpingTime = 0;
            EndSkill();
        }

        if (cooldownE >= cooldownElimit)
        {
            CancelInvoke("CoolDown");
            cooldownE = 0;
        }

    }

    public void EndSkill()
    {
        InvokeRepeating("CoolDown", 0.1f, 1.0f);
        PlayerController.instance.barraStamina.fillAmount -= costAbility / PlayerController.instance.stats.stats.stamina;
        PlayerController.instance.AbilityOff();
    }

    public void Jump()
    {
        if (cooldownE == 0)
        {
            InvokeRepeating("JumpingTime", 0.1f, 1.0f);
            jump = true;
            //Animacion de salto, terminando jum=true;
        }    
        else
            Debug.Log("Habilidad E no disponible aún");
    }

    public void AirAttack()
    {
        //Animacion de caida, terminando EndSkill();
    }

    void CoolDown()
    {
        cooldownE++;
    }

    void JumpingTime()
    {
        jumpingTime++;
    }
}
