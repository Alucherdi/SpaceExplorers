using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Assassin_Q : Ability_abstract
{
    int costAbility = 25;

    public override void launch()
    {
        SkillShotCursor.instance.Active(true);
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0) && SkillShotCursor.instance.activeCursor == true)
        {
            if (PlayerController.instance.barraStamina.fillAmount >= costAbility / Wrapper.instace.character.stamina)
            {
                SkillShotCursor.instance.activeCursor = false;
                PoisonedKnifes();
                PlayerController.instance.LookDestination(SkillShotCursor.instance.newPosition);
                PlayerController.instance.barraStamina.fillAmount -= costAbility / Wrapper.instace.character.stamina;
                PlayerController.instance.AbilityOff();
            }
            else
            {
                SkillShotCursor.instance.activeCursor = false;
                Debug.Log("Imposible utilizar la habilidad, poca stamina");
                PlayerController.instance.AbilityOff();
            }
        }
        
        
    }

    public void PoisonedKnifes()
    {
        Debug.Log("Utilizaste los cuchillos envenedado >:v");
        KnifeShooter.instance.KnifeShot();
    }
}
