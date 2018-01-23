using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityW : MonoBehaviour {

    public static AbilityW instance;
    public bool activeAbility;
    Vector3 newPosition;
    public Image abilityWImage;
    public Image cursorW;


    //public GameObject actualPosition;
    Vector3 targetPosition;

    public float area;
    public float perímetro;
    public float radio;



    void Start(){
        instance = this;

        area = Mathf.PI *(radio*radio);
        perímetro = Mathf.PI * (2 * radio);
    }

    void Update(){

        if (activeAbility == true) {
            abilityWImage.enabled = true;
            cursorW.enabled = true;
        }
        else {
            abilityWImage.enabled = false;
            cursorW.enabled = false;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitFloor;

        if (Physics.Raycast(ray, out hitFloor))
        {
            if (hitFloor.collider.CompareTag("Floor"))
            {
                newPosition = hitFloor.point;
                cursorW.transform.position = new Vector3(newPosition.x, newPosition.y + 0.1f, newPosition.z);
            }
        }


        if (Input.GetMouseButtonUp(0) && activeAbility == true)
        {
            AreaDetector();
        }
    }

    public void Active(bool active)
    {
        activeAbility = active;
    }

    public void AreaDetector()
    {
        targetPosition = Input.mousePosition;

        if ((targetPosition != PlayerController.instance.transform.position) )
        {
            PlayerController.instance.LookDestination(targetPosition);
            //PlayerController.instance.MovingTo(targetPosition, PlayerController.instance.moving);
            //actualPosition.transform.position=new Vector3(cursorW.transform.position.x, cursorW.transform.position.y, cursorW.transform.position.z);
            //Debug.Log("Utilizaste la Habilidad 2/W");
        }
        else
        {
            PlayerController.instance.LookDestination(targetPosition);
            Debug.Log("Utilizaste la Habilidad 2/W");
            activeAbility = false;
            PlayerController.instance.AbilityOff();
        }
    }
}
