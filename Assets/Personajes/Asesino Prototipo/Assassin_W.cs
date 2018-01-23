using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assassin_W : Ability_abstract
{
    int costAbility = 50;

    public override void launch()
    {
        //SkillShotCursor.instance.Active(true);
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0) && PlayerController.instance.abilityW == true)
        {
            if (PlayerController.instance.barraStamina.fillAmount >= costAbility / Wrapper.instace.character.stamina)
            {
                SmokeBomb();
                PlayerController.instance.barraStamina.fillAmount -= costAbility / Wrapper.instace.character.stamina;
                PlayerController.instance.AbilityOff();
            }
            else
            {
                Debug.Log("Imposible utilizar la habilidad, poca stamina");
                PlayerController.instance.AbilityOff();
            }
        }
    }

    public void SmokeBomb()
    {
        Debug.Log("Utilizaste la bomba de humo para escapar =_=");
        SmokeBombShooter.instance.BombShot();
    }
}
