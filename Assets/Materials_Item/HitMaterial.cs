using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMaterial : MonoBehaviour {


	public float hitRate=1.0f;
	public float nextHit;
	public bool onHit=false;
	Inventory inventory;
	Material_attach hitted; // Material golpeado;
	public GameObject materialGui;
	Material_gui materialGuiScript;
	// Use this for initialization
	void Start () {
		inventory = GetComponent<Inventory> ();
		materialGuiScript = materialGui.GetComponent<Material_gui> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool hit(GameObject obj)
	{
		if (Time.time > nextHit)
		{
			hitted = obj.GetComponent<Material_attach> ();
			inventory.materials.water += hitted.water;
			inventory.materials.wood += hitted.wood;
			inventory.materials.leaves += hitted.leaves;
			inventory.materials.organic += hitted.organic;
			inventory.materials.metal += hitted.metal;
			hitted.resist -= 1;
			nextHit = Time.time + hitRate;
			materialGuiScript.SetNumbers (inventory.materials.metal, inventory.materials.wood
				, inventory.materials.water, inventory.materials.leaves, inventory.materials.organic);
			return true;
		}
		return false;
	}
}
