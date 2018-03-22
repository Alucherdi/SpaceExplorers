using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownWrapper : MonoBehaviour {


	// Habilities scripts
	public Ability_abstract abb_q;
	public Ability_abstract abb_w;
	public Ability_abstract abb_e;
	public Ability_abstract abb_r;

	// Cooldown variables
	// Q
	public float cooldownQ=0;
	public float cooldownQlimit;

	// W
	public float cooldownW=0;
	public float cooldownWlimit;

	// E
	public float cooldownE=0;
	public float cooldownElimit;

	// R
	public float cooldownR=0;
	public float cooldownRlimit;

	// Public Bool Alowers
	public bool Yq;
	public bool Yw;
	public bool Ye;
	public bool Yr;
	public bool Yd;

	// Use this for initialization
	void Start () {
		// Limit sets
		Yq = true;
		Yw = true;
		Ye = true;
		Yr = true;
		Yd = true;
		//cooldownQlimit = PlayerController.instance.stats.stats.launchQcd;//- (PlayerController.instance.stats.stats.launchQcd * (PlayerController.instance.stats.stats.cooldownReduction/100));
		//cooldownElimit = PlayerController.instance.stats.stats.launchEcd;//- (PlayerController.instance.stats.stats.launchEcd * (PlayerController.instance.stats.stats.cooldownReduction/100));
		//cooldownWlimit = PlayerController.instance.stats.stats.launchWcd;//- (PlayerController.instance.stats.stats.launchWcd * (PlayerController.instance.stats.stats.cooldownReduction/100));
		//cooldownRlimit = PlayerController.instance.stats.stats.launchRcd;//- (PlayerController.instance.stats.stats.launchRcd * (PlayerController.instance.stats.stats.cooldownReduction/100));

	}
	
	// Update is called once per frame
	void Update () {
		
		// Check in false 

		if(!Yq)
		{
			if (cooldownQ == 0) {
				InbokeReppQ ();
			}
		}
		if(!Yw)
		{
			if (cooldownW == 0) {
				InbokeReppW ();
			}
		}	
		if(!Ye)
		{
			if (cooldownE == 0) {
				InbokeReppE ();
			}
		}	
		if(!Yr)
		{
			if (cooldownR == 0) {
				InbokeReppR ();
			}
		}	
			
		// Limit and reset and set abbility capability
		if (cooldownQ >= cooldownQlimit) {
			CancelInvoke ("CoolDownQ");
			cooldownQ = 0;
			Yq = true;
		}

		if (cooldownW >= cooldownWlimit)
		{
			CancelInvoke("CoolDownW");
			cooldownW = 0;
			Yq = true;
		}
		if (cooldownE >= cooldownElimit)
		{
			CancelInvoke("CoolDownE");
			cooldownE = 0;
			Ye = true;
		}
		if (cooldownR >= cooldownRlimit)
		{
			CancelInvoke("CoolDownR");
			cooldownR = 0;
			Yr = true;
		} 	

	}

	// Metodos a invoke
	void CoolDownQ()
	{
		cooldownQ++;
	}
	void CoolDownW()
	{
		cooldownW++;
	}
	void CoolDownE()
	{
		cooldownE++;
	}
	void CoolDownR()
	{
		cooldownR++;
	}

	/// Ibokes
	public void InbokeReppQ(){
		InvokeRepeating("CoolDownQ", 0.1f, 1.0f);

	}
	public void InbokeReppW(){
		InvokeRepeating("CoolDownW", 0.1f, 1.0f);

	}
	public void InbokeReppE(){
		InvokeRepeating("CoolDownE", 0.1f, 1.0f);

	}
	public void InbokeReppR(){
		InvokeRepeating("CoolDownR", 0.1f, 1.0f);

	}
		
}
