using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alpha_q : Ability_abstract {

	// Use this for initialization
	public GameObject swordHitbox;
	Camera mainCamera;
	PlayerController pjController;
	public GameObject spawnSword;

	// Cooldown de abilidad
	float costAbility = 25;
	public float cooldownQ=0;
	public float cooldownQlimit;

	void Start () {
		swordHitbox.GetComponent<MeshRenderer> ().enabled = false;
		mainCamera = FindObjectOfType<Camera> ();
		pjController = GetComponent<PlayerController> ();

	}

	// Update is called once per frame
	void Update () {
		cooldownQlimit = PlayerController.instance.stats.stats.launchQcd - (PlayerController.instance.stats.stats.launchQcd * (PlayerController.instance.stats.stats.cooldownReduction/100));
		if (cooldownQ == 0)
		{
			if (Input.GetMouseButtonUp(0) && SkillShotCursor.instance.activeCursor == true)
			{
				if (PlayerController.instance.barraStamina.fillAmount >= costAbility / PlayerController.instance.stats.stats.stamina)
				{
					swordHitbox.GetComponent<Sword_htbxcd> ().Active ();
					SkillShotCursor.instance.activeCursor = false;
					Debug.Log ("Has sacado la spada prro ");
					//PoisonedKnifes();
					//PlayerController.instance.LookDestination(SkillShotCursor.instance.newPosition);
					PlayerController.instance.barraStamina.fillAmount -= costAbility / PlayerController.instance.stats.stats.stamina;
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
		else
		{
			SkillShotCursor.instance.activeCursor = false;
		}

		if (cooldownQ >= cooldownQlimit)
		{
			CancelInvoke("CoolDown");
			cooldownQ = 0;
		} 	

	}


	public override void launch (){
		Debug.Log ("Alpha q");
		SkillShotCursor.instance.Active(true);
	}
}
