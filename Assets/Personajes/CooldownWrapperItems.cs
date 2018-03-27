using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownWrapperItems : MonoBehaviour {
	// cds
	public float cooldown1=0;
	public float cooldown1limit;

	public float cooldown2=0;
	public float cooldown2limit;

	public float cooldown3=0;
	public float cooldown3limit;

	public float cooldown4=0;
	public float cooldown4limit;

	public float cooldown0=0;
	public float cooldown0limit;

	// Bools
	public bool Y0;
	public bool Y1;
	public bool Y2;
	public bool Y3;
	public bool Y4;



	// Use this for initialization
	void Start () {
		Y0 = true;
		Y1 = true;
		Y2 = true;
		Y3 = true;
		Y4 = true;
	}
	
	// Update is called once per frame
	void Update () {
		// Check in false 

		if(!Y0)
		{
			if (cooldown0 == 0) {
				InbokeRepp0 ();
			}
		}
		if(!Y1)
		{
			if (cooldown1 == 0) {
				InbokeRepp1 ();
			}
		}	
		if(!Y2)
		{
			if (cooldown2 == 0) {
				InbokeRepp2 ();
			}
		}	
		if(!Y3)
		{
			if (cooldown3 == 0) {
				InbokeRepp3 ();
			}
		}
		if(!Y4)
		{
			if (cooldown4 == 0) {
				InbokeRepp4 ();
			}
		}	

		// Limit and reset and set abbility capability
		if (cooldown0 >= cooldown0limit) {
			CancelInvoke ("CoolDown0");
			cooldown0 = 0;
			Y0 = true;
		}

		if (cooldown1 >= cooldown1limit)
		{
			CancelInvoke("CoolDown1");
			cooldown1 = 0;
			Y1 = true;
		}
		if (cooldown2 >= cooldown2limit)
		{
			CancelInvoke("CoolDown2");
			cooldown2 = 0;
			Y2 = true;
		}
		if (cooldown3 >= cooldown3limit)
		{
			CancelInvoke("CoolDown3");
			cooldown3 = 0;
			Y3 = true;
		} 	
		if (cooldown4 >= cooldown4limit)
		{
			CancelInvoke("CoolDown4");
			cooldown4 = 0;
			Y4 = true;
		} 	
	}

	// Metodos inboke
	// Metodos a invoke
	void CoolDown0()
	{
		cooldown0++;
	}
	void CoolDown1()
	{
		cooldown1++;
	}
	void CoolDown2()
	{
		cooldown2++;
	}
	void CoolDown3()
	{
		cooldown3++;
	}
	void CoolDown4()
	{
		cooldown4++;
	}

	/// Ibokes
	public void InbokeRepp0(){
		InvokeRepeating("CoolDown0", 0.1f, 1.0f);

	}
	public void InbokeRepp1(){
		InvokeRepeating("CoolDown1", 0.1f, 1.0f);

	}
	public void InbokeRepp2(){
		InvokeRepeating("CoolDown2", 0.1f, 1.0f);

	}
	public void InbokeRepp3(){
		InvokeRepeating("CoolDown3", 0.1f, 1.0f);

	}
	public void InbokeRepp4(){
		InvokeRepeating("CoolDown4", 0.1f, 1.0f);

	}

}
