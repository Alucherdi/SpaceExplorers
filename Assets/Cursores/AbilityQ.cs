using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityQ : MonoBehaviour {

    public static AbilityQ instance;
    Vector3 newPosition;
    public bool activeAbility;
    public Image abilityQImage;

    void Start () {
        instance = this;
	}
	
	public void Update () {
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
    }

    public void Active(bool active)
    {
        activeAbility = active;
    }
}
