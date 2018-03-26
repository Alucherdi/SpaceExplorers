using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alpha_r : Ability_abstract {


	float costAbility = 25;
	// Use this for initialization
	public GameObject area;
	// CooldownWrapper.
	public CooldownWrapper cooldown;
	public bool active;

	void Start () {
		active = false;
		cooldown = GetComponent<CooldownWrapper> ();
	}

	// Update is called once per frame
	void Update () {
		//cooldownWlimit = PlayerController.instance.stats.stats.launchWcd - (PlayerController.instance.stats.stats.launchWcd * (PlayerController.instance.stats.stats.cooldownReduction/100));
		//if (cooldownW == 0)
		if (active) {
			if (PlayerController.instance.barraStamina.fillAmount >= costAbility / PlayerController.instance.stats.stats.stamina) {
				Debug.Log ("Has sacado el escudo prro ");
				//PoisonedKnifes();
				//PlayerController.instance.LookDestination(SkillShotCursor.instance.newPosition);
				Instantiate (area, transform.position, transform.rotation);
				PlayerController.instance.barraStamina.fillAmount -= costAbility / PlayerController.instance.stats.stats.stamina;
				PlayerController.instance.AbilityOff ();
				cooldown.Yr = false;
				active = false;
			} else {

				//SkillShotCursor.instance.activeCursor = false;
				Debug.Log ("Imposible utilizar la habilidad, poca stamina");
				PlayerController.instance.AbilityOff ();

			}

		} else {
			//SkillShotCursor.instance.activeCursor = false;
			//alphaWActive = false;
			Debug.Log ("No se hacompletado el enfriamiento");
		}

	}

	public override void launch(){
		active = true;
		Debug.Log ("R");
		// Buscar enemigos y ponerlos en la lista.

	}
}
