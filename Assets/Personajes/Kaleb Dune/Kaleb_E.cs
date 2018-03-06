using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kaleb_E : Ability_abstract
{
    float costAbility = 25;
    public float cooldownE = 0;
    public float cooldownElimit;

    public bool jump;
    public float jumpingTime = 0;
    public bool move;

    public override void launch()
    {
        Jump();
    }

    void Start()
    {
        jump = false;
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

            if (Input.GetMouseButtonUp(0))
            {
                if (PlayerController.instance.barraStamina.fillAmount >= costAbility / PlayerController.instance.stats.stats.stamina)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    if (Input.mousePosition.x < Screen.width * 0.5)
                        GetComponent<SpriteRenderer>().flipX = false;
                    else
                        GetComponent<SpriteRenderer>().flipX = true;

                    if (Physics.Raycast(ray, out hit, 100, PlayerController.instance.movementMask))
                    {
                        PlayerController.instance.navMeshAgent.SetDestination(hit.point);
                        PlayerController.instance.newPosition = hit.point;
                        transform.LookAt(new Vector3(PlayerController.instance.newPosition.x, PlayerController.instance.newPosition.y, PlayerController.instance.newPosition.z));
                        move = true;

                        AirAttack();
                    }
                }
                else
                {
                    AreaSkillCursor.instance.activeCursor = false;
                    Debug.Log("Imposible utilizar la habilidad, poca stamina");
                }
            }
        }

        if (move == true)
        {
            //PlayerController.instance.transform.Translate(new Vector3(0, 0, 0.5f));
            if (Vector3.Distance(PlayerController.instance.transform.position, PlayerController.instance.newPosition) < 5.0f)
            {
                move = false;
            }
        }

        if (jumpingTime >= 10)
            EndSkill();

        if (cooldownE >= cooldownElimit)
        {
            CancelInvoke("CoolDown");
            cooldownE = 0;
        }

    }

    public void EndSkill()
    {
        CancelInvoke("JumpingTime");
        jump = false;
        jumpingTime = 0;

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

        EndSkill();
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
