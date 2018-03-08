using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alpha_w : Ability_abstract {

	// Use this for initialization
	public GameObject shieldHitbox;
	Camera mainCamera;
	PlayerController pjController;
	public GameObject spawnSword;

	// Cooldown de abilidad
	float costAbility = 25;
	public float cooldownW=0;
	public float cooldownWlimit;
	bool alphaWActive;

	void Start () {
		shieldHitbox.GetComponent<MeshRenderer> ().enabled = false;
		mainCamera = FindObjectOfType<Camera> ();
		pjController = GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		cooldownWlimit = PlayerController.instance.stats.stats.launchWcd - (PlayerController.instance.stats.stats.launchWcd * (PlayerController.instance.stats.stats.cooldownReduction/100));
		if (cooldownW == 0)
		{
			
			if (alphaWActive)
			{

				if (PlayerController.instance.barraStamina.fillAmount >= costAbility / PlayerController.instance.stats.stats.stamina)
				{
					shieldHitbox.GetComponent<Shield_htbxcd> ().Active ();
					//SkillShotCursor.instance.activeCursor = false;
					alphaWActive = false;
					Debug.Log ("Has sacado el escudo prro ");
					//PoisonedKnifes();
					//PlayerController.instance.LookDestination(SkillShotCursor.instance.newPosition);
					PlayerController.instance.barraStamina.fillAmount -= costAbility / PlayerController.instance.stats.stats.stamina;
					PlayerController.instance.AbilityOff();
				}
				else
				{

					//SkillShotCursor.instance.activeCursor = false;
					Debug.Log("Imposible utilizar la habilidad, poca stamina");
					PlayerController.instance.AbilityOff();

				}

			}

		}
		else
		{
			//SkillShotCursor.instance.activeCursor = false;
			alphaWActive = false;
		}

		if (cooldownW >= cooldownWlimit)
		{
			CancelInvoke("CoolDown");
			cooldownW = 0;
		} 	


	}


	public override void launch (){
		Debug.Log ("Alpha w");
		//SkillShotCursor.instance.Active(true);
		alphaWActive = true;

	}
}
