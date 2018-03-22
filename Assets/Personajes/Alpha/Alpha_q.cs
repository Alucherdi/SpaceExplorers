﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alpha_q : Ability_abstract {

	// Use this for initialization
	public GameObject swordHitbox;
	Camera mainCamera;
	PlayerController pjController;
	public GameObject spawnSword;
	public bool active;
	// Cooldown de abilidad
	float costAbility = 25;
	// CooldownWrapper.
	public CooldownWrapper cooldown;

	void Start () {
		active = false;
		swordHitbox.GetComponent<MeshRenderer> ().enabled = false;
		mainCamera = FindObjectOfType<Camera> ();
		pjController = GetComponent<PlayerController> ();

	}

	// Update is called once per frame
	void Update () {
		//cooldownQlimit = PlayerController.instance.stats.stats.launchQcd - (PlayerController.instance.stats.stats.launchQcd * (PlayerController.instance.stats.stats.cooldownReduction/100));
		//if (cooldownQ == 0)
		if(active)
		{
			if (Input.GetMouseButtonUp(0) && Cursor_q.instance.activeCursor == true)
			{
				if (PlayerController.instance.barraStamina.fillAmount >= costAbility / PlayerController.instance.stats.stats.stamina)
				{
					swordHitbox.GetComponent<Sword_htbxcd> ().Active ();
					Cursor_q.instance.activeCursor = false;
					Debug.Log ("lanzamiento alpha Q (espada)");
					//PoisonedKnifes();
					//PlayerController.instance.LookDestination(SkillShotCursor.instance.newPosition);
					PlayerController.instance.barraStamina.fillAmount -= costAbility / PlayerController.instance.stats.stats.stamina;
					PlayerController.instance.AbilityOff();
					// Inboke cancel
					cooldown.Yq = false;
					active = false;

				}
				else
				{

					Cursor_q.instance.activeCursor = false;
					Debug.Log("Imposible utilizar la habilidad, poca stamina");
					PlayerController.instance.AbilityOff();
				}
			}
		}
		else
		{
			Cursor_q.instance.activeCursor = false;
			Debug.Log ("Desaparece porque aun no llega el cd q");
		}
	}
	public override void launch (){
		Debug.Log ("Alpha q");
		//cooldownQ=0;
		Cursor_q.instance.Active(true);
		active = true;
	}
}
