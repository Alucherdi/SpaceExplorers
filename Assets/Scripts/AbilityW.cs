using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityW : MonoBehaviour {

    public static AbilityW instance;

    public bool activeJoystick;
    bool activeAbility;

    Vector3 newPosition;

    Vector3 posicionIncial;
    public Image joystickAbilities1Image;
    public Image JoystickAbilities2Image;

    //
    public float velocidad = 1.5f;
    public float velocidadAngular = 90.0f;
    public float smooth = 1.5f;

    private Vector3 position;
    private Quaternion rotation;
    private float distancia;
     //

    void Start()
    {
        instance = this;
        posicionIncial = transform.position;

        joystickAbilities1Image.enabled = false;
        JoystickAbilities2Image.enabled = false;
    }

    void Update()
    {
        if (activeJoystick == true)
        {
            joystickAbilities1Image.enabled = true;
            JoystickAbilities2Image.enabled = true;
        }
        else
        {
            joystickAbilities1Image.enabled = false;
            JoystickAbilities2Image.enabled = false;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitFloor;

        if (Physics.Raycast(ray, out hitFloor))
        {
            if (hitFloor.collider.CompareTag("Floor"))
            {
                newPosition = hitFloor.point;
                JoystickAbilities2Image.transform.position = newPosition;
            }
        }

        if (Input.GetMouseButtonUp(0) && activeAbility == true)
        {
            AbilitiesController.instance.DesactiveAllAbilities();
            Debug.Log("Utilizaste la Habilidad 2/W");
            activeAbility = false;
            PlayerController.instance.AbilityOff();
        }
    }



    public void Active(bool active)
    {
        activeAbility = active;
    }

    public void EnableJoystick(bool active2)
    {
        activeJoystick = active2;
    }
}
