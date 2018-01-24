﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CharacterState {NORMAL, PSN, STUNNED, BATTLE}
public class PlayerController : MonoBehaviour {

    public static PlayerController instance;

    Wrapper wrapper;
    public Animator anim;
    /*Vector3 target; //Por si se ocupa un identificador al dar los click en la escena
    public GameObject targetPosition;*/
    public Vector3 newPosition;
    public bool moving;

    public bool abilityQ;
    public bool abilityW;
    public bool abilityE;
    public bool abilityR;
    public bool dash;

    public Image barraVida;
    public Image barraStamina;

    public SkinnedMeshRenderer skinPlayer;

    private CharacterState characterState;

    void Start()
    {
        instance = this;
        wrapper = GetComponent<Wrapper>();
        anim = GetComponent<Animator>();

        moving = false;
        abilityQ = false;
        abilityW = false;
        abilityE = false;
        abilityR = false;
        dash = false;

        characterState = CharacterState.NORMAL;
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(1) || Input.GetMouseButton(1))
        {

            /*
            RaycastHit hitObstacles; //Para identificar si hay algun obstáculo
            RaycastHit hitEnemy; //Para identificar si hay algún enemigo
            */

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitFloor;

            if (Physics.Raycast(ray, out hitFloor))
            {
                if (hitFloor.collider.CompareTag("Floor"))
                {
                    newPosition = hitFloor.point;
                    transform.LookAt(new Vector3(newPosition.x, newPosition.y, newPosition.z));

                    moving = true;
                    AbilityOff();
                }
            }
        }

        if (moving == true)
        {
            //anim.SetFloat("Forward", 10.0f);
            anim.SetFloat("Run", 10.0f);
            transform.Translate(new Vector3(0, 0, 0.5f));
            if (Vector3.Distance(transform.position, newPosition) < 0.5f)
            {
                //anim.SetFloat("Forward", 0.0f);
                anim.SetFloat("Run", 0.0f);
                moving = false;
            }
        }
        
        //Activar Abilidades
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SkillShotCursor.instance.Active(false);
            AreaSkillCursor.instance.Active(false);
            wrapper.launchQ();
            abilityQ = true;
            abilityW = false;
            abilityE = false;
            abilityR = false;
            dash = false;

        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            SkillShotCursor.instance.Active(false);
            AreaSkillCursor.instance.Active(false);
            wrapper.launchW();
            abilityW = true;
            abilityQ = false;
            abilityE = false;
            abilityR = false;
            dash = false;

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            SkillShotCursor.instance.Active(false);
            AreaSkillCursor.instance.Active(false);
            wrapper.launchE();
            abilityE = true;
            abilityQ = false;
            abilityW = false;
            abilityR = false;
            dash = false;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SkillShotCursor.instance.Active(false);
            AreaSkillCursor.instance.Active(false);
            wrapper.launchR();
            abilityR = true;
            abilityQ = false;
            abilityW = false;
            abilityE = false;
            dash = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SkillShotCursor.instance.Active(false);
            AreaSkillCursor.instance.Active(false);
            wrapper.launchDash();
            abilityR = false;
            abilityQ = false;
            abilityW = false;
            abilityE = false;
            dash = true;
        }

        if(characterState==CharacterState.NORMAL)
        {
            /*Sistema para aumentar Vida*/
            if (barraVida.fillAmount >= 0.75)
                CancelInvoke("AumentarVida");

            if (barraVida.fillAmount <= 0.25)
                InvokeRepeating("AumentarVida", 5.0f, 0.1f);
        }


        /*Sistema para aumentar STAMINA*/
        if (barraStamina.fillAmount == 1.0)
            CancelInvoke("AumentarStamina");

        if (barraStamina.fillAmount <= 0.9)
            InvokeRepeating("AumentarStamina", 5.0f, 0.1f);
    }

    void AumentarVida()
    {
        barraVida.fillAmount += 0.00001f;
    }

    void AumentarStamina()
    {
        barraStamina.fillAmount += 0.00001f;
    }

    public void AbilityOff()
    {
        SkillShotCursor.instance.Active(false);
        AreaSkillCursor.instance.Active(false);
        abilityQ = false;
        abilityW = false;
        abilityE = false;
        abilityR = false;
        dash = false;
    }

    public void LookDestination(Vector3 newPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitFloor;

        if (Physics.Raycast(ray, out hitFloor))
        {
            if (hitFloor.collider.CompareTag("Floor"))
            {
                newPosition = hitFloor.point;
                transform.LookAt(new Vector3(newPosition.x, newPosition.y, newPosition.z));
            }
        }
    }
}