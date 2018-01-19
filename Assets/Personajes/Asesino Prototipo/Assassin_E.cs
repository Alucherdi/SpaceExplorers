using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Assassin_E : Ability_abstract
{
    //Character assassin;

    public override void launch()
    {
        //ActiveCamouflage();
    }

    void Start()
    {

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            for(int i=0; i >=200; i++)
            {
                Wrapper.instace.character.stamina--;
            }
        }
    }

    public void ActiveCamouflage()
    {
        /*if (Wrapper.instace.character.stamina >= 101)
            {
                Wrapper.instace.character.stamina--;
                Debug.Log(Wrapper.instace.character.stamina);
            }*/
    }
}
