using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Stats : MonoBehaviour {

	Inventory inventory;
	public stats_char stats;
	public modifiers_char modifiers;

	// Use this for initialization
	void Start () {
		// Statts
		inventory = GetComponent<Inventory> ();
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
        stats.launchDcd = GetComponent<Wrapper>().character.stats.launchDcd;

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
        MenuController.instance.health.text = stats.health.ToString();
        MenuController.instance.stamina.text = stats.stamina.ToString();
        MenuController.instance.physicalDamege.text = stats.physicalDamage.ToString();
        MenuController.instance.energyDamage.text = stats.energyDamage.ToString();
        MenuController.instance.physicalResist.text = stats.physicalResist.ToString();
        MenuController.instance.energyResist.text = stats.energyResist.ToString();
        MenuController.instance.moveSpeed.text = stats.movementSpeed.ToString();
        MenuController.instance.attackSpeed.text = stats.attackSpeed.ToString();
    }



	public void AddStats(int n){
		stats.health += modifiers.health * inventory.backpack [n].item_stats.health;
		stats.stamina += modifiers.stamina * inventory.backpack [n].item_stats.stamina;
		stats.healthRegen += modifiers.healthRegen * inventory.backpack [n].item_stats.healthRegen;
		stats.staminaRegen += modifiers.staminaRegen * inventory.backpack [n].item_stats.staminaRegen;
		stats.physicalDamage += modifiers.physicalDamage * inventory.backpack [n].item_stats.physicalDamage;
		stats.energyDamage += modifiers.energyDamage * inventory.backpack [n].item_stats.energyDamage;
		stats.physicalResist += modifiers.physicalResist * inventory.backpack [n].item_stats.physicalResist;
		stats.energyResist += modifiers.energyResist* inventory.backpack [n].item_stats.energyResist;
		stats.movementSpeed += modifiers.movementSpeed* inventory.backpack [n].item_stats.movementSpeed;
		stats.attackSpeed += modifiers.attackSpeed * inventory.backpack [n].item_stats.attackSpeed;
		stats.cooldownReduction += modifiers.cooldownReduction * inventory.backpack [n].item_stats.cooldownReduction;
		Debug.Log ("Actualizando stats (Add)");
	}

	public void RemoveStats(int n){
		stats.health -= modifiers.health * inventory.backpack [n].item_stats.health;
		stats.stamina -= modifiers.stamina * inventory.backpack [n].item_stats.stamina;
		stats.healthRegen -= modifiers.healthRegen * inventory.backpack [n].item_stats.healthRegen;
		stats.staminaRegen -= modifiers.staminaRegen * inventory.backpack [n].item_stats.staminaRegen;
		stats.physicalDamage -= modifiers.physicalDamage * inventory.backpack [n].item_stats.physicalDamage;
		stats.energyDamage -= modifiers.energyDamage * inventory.backpack [n].item_stats.energyDamage;
		stats.physicalResist -= modifiers.physicalResist * inventory.backpack [n].item_stats.physicalResist;
		stats.energyResist -= modifiers.energyResist* inventory.backpack [n].item_stats.energyResist;
		stats.movementSpeed -= modifiers.movementSpeed* inventory.backpack [n].item_stats.movementSpeed;
		stats.attackSpeed -= modifiers.attackSpeed * inventory.backpack [n].item_stats.attackSpeed;
		stats.cooldownReduction += modifiers.cooldownReduction * inventory.backpack [n].item_stats.cooldownReduction;
		Debug.Log ("Actualizando stats (Remove)");
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
        public float launchDcd;

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
