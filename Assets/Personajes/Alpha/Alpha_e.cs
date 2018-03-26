using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alpha_e : Ability_abstract {

	float costAbility = 25;
	//public float cooldownE=25;
	//public float cooldownElimit;
	//public bool active = false;

	// Cooldown wrapper 
	public CooldownWrapper cooldown;
	public bool active;

	void Start () {
		active = false;
		cooldown = GetComponent<CooldownWrapper> ();
		//swordHitbox.GetComponent<MeshRenderer> ().enabled = false;
		//mainCamera = FindObjectOfType<Camera> ();
		//pjController = GetComponent<PlayerController> ();

	}


	void Update()
	{
		//cooldownElimit = PlayerController.instance.stats.stats.launchEcd - (PlayerController.instance.stats.stats.launchEcd * (PlayerController.instance.stats.stats.cooldownReduction/100));

		if (active)
		{
			if (Input.GetMouseButtonUp(0) && Cursor_e.instance.activeCursor == true)
			{
				if (PlayerController.instance.barraStamina.fillAmount >= costAbility / PlayerController.instance.stats.stats.stamina)
				{
					Debug.Log ("lanzamiento alpha e");
					Cursor_e.instance.activeCursor = false;
					PoisonedKnifes();
					//PlayerController.instance.LookDestination(SkillShotCursor.instance.newPosition);
					PlayerController.instance.barraStamina.fillAmount -= costAbility / PlayerController.instance.stats.stats.stamina;
					PlayerController.instance.AbilityOff();
					cooldown.Ye= false;
					active = false;
				}
				else
				{
					Cursor_e.instance.activeCursor = false;
					Debug.Log("Imposible utilizar la habilidad, poca stamina");
					PlayerController.instance.AbilityOff();
					active = false;
				}
			}
		}
		else
		{
			//Debug.Log ("Se apaga el cursor");
			Cursor_e.instance.activeCursor = false;
			active = false;
			Debug.Log ("Desaparece porque aun no llega el cd e");
		}
		/*
		if (cooldownE >= cooldownElimit)
		{
			CancelInvoke("CoolDown");
			cooldownE = 0;
		} 
		*/
	}

	public void PoisonedKnifes()
	{
		Debug.Log("Utilizaste los cuchillos envenedados >:v");
		//PlayerController.instance.anim.SetTrigger("SpellQ");
		BulletShooter.instance.BulletShot();
	}


	public override void launch()
	{
		active = true;
		//cooldownE=0;
		Debug.Log ("Se esta presionando e");
		Cursor_e.instance.Active(true);
	}
}
