using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerController : MonoBehaviour {

    Animator anim;
    Vector3 target;
    public GameObject targetPosition;
    Vector3 newPosition;
    bool moving;

    void Start()
    {
        anim = GetComponent<Animator>();

        moving = false;
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
                    //targetPosition.transform.position = newPosition;
                    transform.LookAt(new Vector3(newPosition.x, newPosition.y, newPosition.z));

                    moving = true;
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
