using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Stats : MonoBehaviour {

	//Inventory inventory;
	public stats_char stats;
	public modifiers_char modifiers;

	// Use this for initialization
	void Start () {
		// Statts
		//inventory = GetComponent<Inventory> ();
		stats.health = GetComponent<Wrapper> ().character.stats.health;
		stats.stamina = GetComponent<Wrapper> ().character.stats.stamina;
		stats.healthRegen = GetComponent<Wrapper> ().character.stats.healthRegen;
		stats.staminaRegen = GetComponent<Wrapper> ().character.stats.staminaRegen;
		stats.physicalDamage = GetComponent<Wrapper> ().character.stats.physicalDamage;
		stats.energyDamage = GetComponent<Wrapper> ().character.stats.energyDamage;
		stats.physicalResist = GetComponent<Wrapper> ().character.stats.physicalResist;
		stats.energyResist = GetComponent<Wrapper> ().character.stats.energyResist;
		stats.movementSpeed= GetComponent<Wrapper> ().character.stats.movementSpeed;
		stats.attackSpeed = GetComponent<Wrapper> ().character.stats.attackSpeed;
		stats.cooldownReduction = GetComponent<Wrapper> ().character.stats.cooldownReduction;
		stats.launchEcd = GetComponent<Wrapper> ().character.stats.launchEcd;
		stats.launchQcd = GetComponent<Wrapper> ().character.stats.launchQcd;
		stats.launchWcd = GetComponent<Wrapper> ().character.stats.launchWcd;
		stats.launchRcd = GetComponent<Wrapper> ().character.stats.launchRcd;

		// MOdifiers
		modifiers.health = GetComponent<Wrapper> ().character.modifiers.health;
		modifiers.stamina = GetComponent<Wrapper> ().character.modifiers.stamina;
		modifiers.healthRegen= GetComponent<Wrapper> ().character.modifiers.healthRegen;
		modifiers.staminaRegen = GetComponent<Wrapper> ().character.modifiers.staminaRegen;
		modifiers.physicalDamage = GetComponent<Wrapper> ().character.modifiers.physicalDamage;
		modifiers.energyDamage = GetComponent<Wrapper> ().character.modifiers.energyDamage;
		modifiers.physicalResist = GetComponent<Wrapper> ().character.modifiers.physicalResist;
		modifiers.energyResist = GetComponent<Wrapper> ().character.modifiers.energyResist;
		modifiers.movementSpeed = GetComponent<Wrapper> ().character.modifiers.movementSpeed;
		modifiers.attackSpeed = GetComponent<Wrapper> ().character.modifiers.attackSpeed;
		modifiers.cooldownReduction = GetComponent<Wrapper> ().character.modifiers.cooldownReduction;
	}

	// Update is called once per frame
	void Update () {

	}





	[System.Serializable]
	public struct stats_char {
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
		public float launchQcd;
		public float launchWcd;
		public float launchEcd;
		public float launchRcd;

	}

	[System.Serializable]
	public struct modifiers_char {
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
}
