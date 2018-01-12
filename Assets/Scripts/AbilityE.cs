using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityE : MonoBehaviour {

    public static AbilityE instance;
    public bool activeAbility;
    public Image abilityEImage;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if (activeAbility == true)
            abilityEImage.enabled = true;
        else
            abilityEImage.enabled = false;

        if (Input.GetMouseButtonUp(0) && activeAbility == true)
        {
            Debug.Log("Utilizaste la Habilidad 3/E");
            activeAbility = false;
            PlayerController.instance.AbilityOff();
        }
    }

    public void Active(bool active)
    {
        activeAbility = active;
    }
}
