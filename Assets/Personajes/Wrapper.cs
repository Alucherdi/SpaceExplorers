﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrapper : MonoBehaviour {

	private Ability_abstract[] abilities;
	private Hashtable abilitiesh;
	public CooldownWrapper cooldown;

	void Start()
	{
		abilities = GetComponents<Ability_abstract> ();
		Debug.Log (abilities.Length);
		/*
		abilitiesh = new Hashtable ();
		abilitiesh.Add ("Q", abilities [0]);
		abilitiesh.Add ("W", abilities [1]);
		abilitiesh.Add ("E", abilities [2]);
		abilitiesh.Add ("R", abilities [3]);
		abilitiesh.Add ("Space", abilities [4]);
        */
	}

	public Character character;

	public void launchQ()
	{  if(cooldown.Yq){
			abilities[0].launch();
		}
	}

	public void launchW()
	{
		if (cooldown.Yw) {
			abilities [1].launch ();
		}
	}

	public void launchE()
	{
		if(cooldown.Ye){
			abilities[2].launch();
		}
	}

	public void launchR()
	{
		if(cooldown.Yr){
			abilities[3].launch();
		}
	}

	public void launchDash(){
		if(cooldown.Yd){
			abilities[4].launch();
		}
	}
}
