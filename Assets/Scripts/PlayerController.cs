using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {

    public static PlayerController instance;
    Animator anim;
    /*Vector3 target; //Por si se ocupa un identificador al dar los click en la escena
    public GameObject targetPosition;*/
    Vector3 newPosition;
    bool moving;

    public bool abilityQ;
    public bool abilityW;
    public bool abilityE;
    public bool abilityR;

    void Start()
    {
        instance = this;
        anim = GetComponent<Animator>();

        moving = false;
        abilityQ = false;
        abilityW = false;
        abilityE = false;
        abilityR = false;
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(1) || Input.GetMouseButton(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitFloor;
            /*
            RaycastHit hitObstacles; //Para identificar si hay algun obstáculo
            RaycastHit hitEnemy; //Para identificar si hay algún enemigo
            */

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
            anim.SetFloat("Forward", 10.0f);
            transform.Translate(new Vector3(0, 0, 0.5f));
            if (Vector3.Distance(transform.position, newPosition) < 0.5f)
            {
                anim.SetFloat("Forward", 0.0f);
                moving = false;
            }
        }

        //Activar Abilidades
        if (Input.GetKeyDown(KeyCode.Q))
        {
            abilityQ = true;
            abilityW = false;
            abilityE = false;
            abilityR = false;
            AbilityQ.instance.Active(abilityQ);
            AbilityW.instance.Active(abilityW);
            AbilityE.instance.Active(abilityE);
            AbilityR.instance.Active(abilityR);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            abilityW = true;
            abilityQ = false;
            abilityE = false;
            abilityR = false;
            AbilityQ.instance.Active(abilityQ);
            AbilityW.instance.Active(abilityW);
            AbilityE.instance.Active(abilityE);
            AbilityR.instance.Active(abilityR);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            abilityE = true;
            abilityQ = false;
            abilityW = false;
            abilityR = false;
            AbilityQ.instance.Active(abilityQ);
            AbilityW.instance.Active(abilityW);
            AbilityE.instance.Active(abilityE);
            AbilityR.instance.Active(abilityR);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            abilityR = true;
            abilityQ = false;
            abilityW = false;
            abilityE = false;
            AbilityQ.instance.Active(abilityQ);
            AbilityW.instance.Active(abilityW);
            AbilityE.instance.Active(abilityE);
            AbilityR.instance.Active(abilityR);
        }
    }

    public void AbilityOff()
    {
        abilityQ = false;
        abilityW = false;
        abilityE = false;
        abilityR = false;
        AbilityQ.instance.Active(abilityQ);
        AbilityW.instance.Active(abilityW);
        AbilityE.instance.Active(abilityE);
        AbilityR.instance.Active(abilityR);
    }

    void OnTriggerEnter(Collider objectCollider)
    {
        if (objectCollider.gameObject.tag == "Enemy")
            anim.SetBool("Crouch", true);
    }

    void OnTriggerExit(Collider objectCollider)
    {
        if (objectCollider.gameObject.tag == "Enemy")
            anim.SetBool("Crouch", false);
    }
}