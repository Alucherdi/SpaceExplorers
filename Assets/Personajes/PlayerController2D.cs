using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController2D : MonoBehaviour {

    Rigidbody rb;
    NavMeshAgent navMeshAgent;
    public LayerMask movementMask;

    //Variables
    public Animator anim;
    public AnimatorStateInfo currentState;
    public Vector3 newPosition;
    public bool moving;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        moving = false;
    }

    void Update()
    {
        currentState = anim.GetCurrentAnimatorStateInfo(0);

        if (Input.GetMouseButtonDown(1) || Input.GetMouseButton(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                navMeshAgent.SetDestination(hit.point);
                newPosition = hit.point;

                moving = true;
            }
        }

        if (moving == true)
        {
            anim.SetFloat("Run", 10.0f);
            if (Vector3.Distance(transform.position, newPosition) < 0.5f)
            {
                anim.SetFloat("Run", 0.0f);
                moving = false;
            }
        }
        else
        {
            anim.SetFloat("Run", 0.0f);
            moving = false;
        }
    }
}
