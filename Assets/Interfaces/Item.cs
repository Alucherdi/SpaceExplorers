using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Script que añade los elementos del item
// Al gameobject
//
public abstract class Item : MonoBehaviour {
	
	public string itemName;
	public Active_abstract active;
	public Pasive_abstract pasive;
	public bonus item_stats;
	public Sprite sprite;

	public void OnTriggerEnter(Collider col){
		Inventory invent = col.gameObject.GetComponent<Inventory> ();
		if(col.gameObject.CompareTag("Player")){
			if (invent.addItem(this)) {
				Debug.Log ("Item añadido");
				//Destroy (gameObject);
				gameObject.GetComponent<MeshRenderer> ().enabled = false;
				gameObject.GetComponent<BoxCollider> ().enabled = false;
			} else {
				Debug.Log ("Inventario lleno");
			}
		}
	}

	public void Update(){
		//Debug.Log ("Nope");
	}

}

[System.Serializable]
public struct bonus {
	public float health; // hp
	public float stamina; // Used for skills
	public float healthRegen; // Per second
	public float staminaRegen; // Per second
	public float physicalDamage; // Phisiscal damage
	public float energyDamage; // Energy damage;
	public float physicalResist; // Armor
	public float energyResist; // Energetic armor
	public float movementSpeed; // Movement speed
	public float attackSpeed; // How fast can the char do the weapons attack
	public float cooldownReduction; // % 
}
