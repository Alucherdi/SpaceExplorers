using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")] 
public class Character : ScriptableObject {
	
	public string characterName;
	public stats_char stats;
	public modifiers_char modifiers;
	//public Sprite sprite;
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
