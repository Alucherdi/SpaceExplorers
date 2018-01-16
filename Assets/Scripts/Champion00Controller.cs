using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Champion00Controller : MonoBehaviour {

    public static Champion00Controller instance;
    Vector3 newPosition;
    public bool moving;

    public bool abilityQ;
    public bool abilityW;
    public bool abilityE;
    public bool abilityR;

    void Start()
    {
        instance = this;

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
            transform.Translate(new Vector3(0, 0, 0.5f));
            if (Vector3.Distance(transform.position, newPosition) < 0.5f)
            {
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
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            abilityW = true;
            abilityQ = false;
            abilityE = false;
            abilityR = false;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            abilityE = true;
            abilityQ = false;
            abilityW = false;
            abilityR = false;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
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

}
