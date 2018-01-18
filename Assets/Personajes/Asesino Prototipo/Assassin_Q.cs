using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Assassin_Q : Ability_abstract
{
    public static Assassin_Q instance;
    Vector3 newPosition;
    public bool activeAbility;
    public Image abilityQImage;

    public override void launch()
    {
        //Debug.Log("Assassin Habilidad Q");
    }

    void Start () {
        instance = this;
	}

	void Update () {
		        if (activeAbility == true)
            abilityQImage.enabled = true;
        else
            abilityQImage.enabled = false;


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
            PlayerController.instance.LookDestination(newPosition);
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
