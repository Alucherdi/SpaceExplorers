using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerController : MonoBehaviour {

    public static PlayerController instance;
    Animator anim;
    /*Vector3 target;
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
            /*RaycastHit hitObstacles;
            RaycastHit hitEnemy;*/

            if (Physics.Raycast(ray, out hitFloor))
            {
                if (hitFloor.collider.CompareTag("Floor"))
                {
                    newPosition = hitFloor.point;
                    transform.LookAt(new Vector3(newPosition.x, newPosition.y, newPosition.z));

                    moving = true;
                    AbilitiesController.instance.DesactiveAllAbilities();
                    AbilityOff();
                    AbilityQ.instance.Active(false);
                    AbilityW.instance.Active(false);
                    
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
            AbilitiesController.instance.ActiveAbilityQ();
            AbilityQ.instance.Active(abilityQ);
            abilityW = false;
            abilityE = false;
            abilityR = false;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            abilityW = true;
            AbilitiesController.instance.ActiveAbilityW();
            AbilityW.instance.Active(abilityW);
            abilityQ = false;
            abilityE = false;
            abilityR = false;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            AbilitiesController.instance.ActiveAbilityE();
            abilityE = true;
            abilityQ = false;
            abilityW = false;
            abilityR = false;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            AbilitiesController.instance.ActiveAbilityR();
            abilityR = true;
            abilityQ = false;
            abilityW = false;
            abilityE = false;
        }
    }

    public void AbilityOff()
    {
        abilityQ = false;
        abilityW = false;
        abilityE = false;
        abilityR = false;
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


/*
public class PlayerController : MonoBehaviour {

    NavMeshAgent agent;
    Animator anim;

    Vector3 target;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(1) || Input.GetMouseButton(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitFloor;
            RaycastHit hitEnemy;
            
            if(Physics.Raycast(ray, out hitFloor))
            {
                target = hitFloor.point;
                SetPosition();
            }

            if(Physics.Raycast(ray, out hitEnemy))
            {
                target = hitEnemy.point;
                SetPosition();
            }
        }

        anim.SetFloat("Forward", agent.velocity.magnitude/agent.speed);
        
    }

    void SetPosition()
    {
        agent.SetDestination(target);
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


*/


/*target = hitFloor.point;
                    SetPosition();*/
/*if (Physics.Raycast(ojosPosition.transform.position, newPosition - ojosPosition.transform.position, out hitObstacles, Vector3.Distance(transform.position, newPosition)))
{
    if (hitObstacles.collider.CompareTag("Obstaculo"))
    {
        obsPosition.transform.position = hitObstacles.point;
        Debug.Log("Imposible Acceder");
    }
    else
    {
        moving = true;
    }
}
else
{
    moving = true;
}*/
