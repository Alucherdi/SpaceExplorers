using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovimientoMouse : MonoBehaviour {

    NavMeshAgent agent;

    void Start(){
       agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update(){

        if (Input.GetMouseButtonDown(1) || Input.GetMouseButton(1))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
                agent.destination = hit.point;
        }

    }
}
