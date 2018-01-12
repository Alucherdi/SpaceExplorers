using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitiesController : MonoBehaviour {

    public static AbilitiesController instance;

    public Image abilityQImage;
    public Image abilityWImage;
    public Image cursorW;
    public Image abilityEImage;
    public Image abilityRImage;

	void Start () {
        instance = this;

        DesactiveAllAbilities();
	}
	
    public void ActiveAbilityQ()
    {
        abilityQImage.enabled = true;
        AbilityW.instance.EnableJoystick(false);
        /*abilityWImage.enabled = false;
        cursorW.enabled = false;*/
        abilityEImage.enabled = false;
        abilityRImage.enabled = false;
    }

    public void ActiveAbilityW()
    {
        abilityQImage.enabled = false;
        AbilityW.instance.EnableJoystick(true);
        /*abilityWImage.enabled = true;
        cursorW.enabled = true;*/
        abilityEImage.enabled = false;
        abilityRImage.enabled = false;
    }

    public void ActiveAbilityE()
    {
        abilityQImage.enabled = false;
        AbilityW.instance.EnableJoystick(false);
        /*abilityWImage.enabled = false;
        cursorW.enabled = false;*/
        abilityEImage.enabled = true;
        abilityRImage.enabled = false;

        //Aquí va la abilididad E
    }

    public void ActiveAbilityR()
    {
        abilityQImage.enabled = false;
        AbilityW.instance.EnableJoystick(false);
        /*abilityWImage.enabled = false;
        cursorW.enabled = false;*/
        abilityEImage.enabled = false;
        abilityRImage.enabled = true;

        //Aquí va la abilididad R
    }

    public void DesactiveAllAbilities()
    {
        abilityQImage.enabled = false;
        abilityWImage.enabled = false;
        cursorW.enabled = false;
        abilityEImage.enabled = false;
        abilityRImage.enabled = false;
    }
}
