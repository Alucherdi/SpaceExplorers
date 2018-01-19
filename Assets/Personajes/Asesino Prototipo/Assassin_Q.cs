using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Assassin_Q : Ability_abstract
{

    public override void launch()
    {
        SkillShotCursor.instance.Active(true);
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0) && SkillShotCursor.instance.activeCursor == true)
        {
            SkillShotCursor.instance.activeCursor = false;
            PoisonedKnifes();
            PlayerController.instance.LookDestination(SkillShotCursor.instance.newPosition);  
            PlayerController.instance.AbilityOff();
        }
    }

    public void PoisonedKnifes()
    {
        Debug.Log("Utilizaste los cuchillos envenedado >:v");
    }
}
