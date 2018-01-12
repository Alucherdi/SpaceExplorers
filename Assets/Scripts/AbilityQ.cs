using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityQ : MonoBehaviour {

    public static AbilityQ instance;
    Vector3 newPosition;

    bool activeAbility;

    void Start () {
        instance = this;
	}
	
	void Update () {
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

        if (Input.GetMouseButtonUp(0) && activeAbility==true)
        {
            AbilitiesController.instance.DesactiveAllAbilities();
            Debug.Log("Utilizaste la Habilidad 1/Q");
            activeAbility = false;
            PlayerController.instance.AbilityOff();
        }
    }

    public void Active(bool active)
    {
        activeAbility = active;
    }
}
