using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alpha_e : Ability_abstract {

	float costAbility = 25;
	public float cooldownE=0;
	public float cooldownElimit;

	public override void launch()
	{
		SkillShotCursor.instance.Active(true);
	}

	void Update()
	{
		cooldownElimit = PlayerController.instance.stats.stats.launchEcd - (PlayerController.instance.stats.stats.launchEcd * (PlayerController.instance.stats.stats.cooldownReduction/100));

		if (cooldownE == 0)
		{
			if (Input.GetMouseButtonUp(0) && SkillShotCursor.instance.activeCursor == true)
			{
				if (PlayerController.instance.barraStamina.fillAmount >= costAbility / PlayerController.instance.stats.stats.stamina)
				{
					SkillShotCursor.instance.activeCursor = false;
					PoisonedKnifes();
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

		if (cooldownE >= cooldownElimit)
		{
			CancelInvoke("CoolDown");
			cooldownE = 0;
		} 
	}

	public void PoisonedKnifes()
	{
		Debug.Log("Utilizaste los cuchillos envenedados >:v");
		//PlayerController.instance.anim.SetTrigger("SpellQ");
		KnifeShooter.instance.KnifeShot();
		InvokeRepeating("CoolDown", 0.1f, 1.0f);
	}

	void CoolDown()
	{
		cooldownE++;
	}
}
