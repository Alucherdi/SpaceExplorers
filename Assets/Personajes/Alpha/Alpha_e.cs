using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alpha_e : Ability_abstract {

	float costAbility = 25;
	public float cooldownE=25;
	public float cooldownElimit;
	public bool active = false;

	public override void launch()
	{
		active = true;
		cooldownE=0;
		SkillShotCursor.instance.Active(true);
	}

	void Update()
	{
		cooldownElimit = PlayerController.instance.stats.stats.launchEcd - (PlayerController.instance.stats.stats.launchEcd * (PlayerController.instance.stats.stats.cooldownReduction/100));

		if (cooldownE == 0 && active )
		{
			if (Input.GetMouseButtonUp(0) && SkillShotCursor.instance.activeCursor == true)
			{
				if (PlayerController.instance.barraStamina.fillAmount >= costAbility / PlayerController.instance.stats.stats.stamina)
				{
					Debug.Log ("lanzamiento alpha e");
					SkillShotCursor.instance.activeCursor = false;
					PoisonedKnifes();
					//PlayerController.instance.LookDestination(SkillShotCursor.instance.newPosition);
					PlayerController.instance.barraStamina.fillAmount -= costAbility / PlayerController.instance.stats.stats.stamina;
					PlayerController.instance.AbilityOff();
					active = false;
				}
				else
				{
					SkillShotCursor.instance.activeCursor = false;
					Debug.Log("Imposible utilizar la habilidad, poca stamina");
					PlayerController.instance.AbilityOff();
					active = false;
				}
			}
		}
		else
		{
			//Debug.Log ("Se apaga el cursor");
			SkillShotCursor.instance.activeCursor = false;
			active = false;

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
