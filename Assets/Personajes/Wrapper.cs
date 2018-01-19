using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrapper : MonoBehaviour {

    public static Wrapper instace;
	private Ability_abstract[] abilities;
	private Hashtable abilitiesh;

	void Start()
	{
        instace = this;
		abilities = GetComponents<Ability_abstract> ();

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
	{
		abilities[0].launch();
	}

	public void launchW()
	{
		abilities[1].launch();
	}

	public void launchE()
	{
		abilities[2].launch();
	}

	public void launchR()
	{
		abilities[3].launch();
	}

	public void launchDash(){
		abilities[4].launch();
	}
}
