using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assassin_W : Ability_abstract
{

    public override void launch()
    {
        SmokeBomb();
    }
	
    public void SmokeBomb()
    {
        Debug.Log("Utilizaste la bomba de humo para escapar =_=");
    }
}
