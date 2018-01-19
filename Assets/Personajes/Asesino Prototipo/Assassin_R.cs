using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Assassin_R : Ability_abstract
{

    public override void launch()
    {
        AreaSkillCursor.instance.Active(true);
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0) && AreaSkillCursor.instance.activeCursor == true)
        {
            AreaSkillCursor.instance.activeCursor = false;
            SpecialAttack();
            PlayerController.instance.LookDestination(SkillShotCursor.instance.newPosition);
            PlayerController.instance.AbilityOff();
        }
    }

    public void SpecialAttack()
    {
        Debug.Log("Utilizaste el ataque mas prron D:");
    }
}
