using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityR : MonoBehaviour {

    public static AbilityR instance;
    public bool activeAbility;
    public Image abilityRImage;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if (activeAbility == true)
            abilityRImage.enabled = true;
        else
            abilityRImage.enabled = false;


        if (Input.GetMouseButtonUp(0) && activeAbility == true)
        {
            Debug.Log("Utilizaste la Habilidad 4/R");
            activeAbility = false;
            PlayerController.instance.AbilityOff();
        }
    }

    public void Active(bool active)
    {
        activeAbility = active;
    }
}
