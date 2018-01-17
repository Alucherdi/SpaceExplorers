using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")] 
public class Character : ScriptableObject {
	
	public string characterName;
	public int healt; // hp
	public int stamina; // Used for skills
	public int healthRegen; // Per second
	public int staminaRegen; // Per second
	public int attack; // Phisiscal damage
	public int energy; // Energy damage;
	public int attackResist; // Armor
	public int energyResist; // Energetic armor
	public int movementSpeed; // Movement speed
	public int attackSpeed; // How fast can the char do the weapons attack
	public int cooldownReduction; // % 
	public float launchQcdr;
	public float launchWcdr;
	public float launchEcdr;
	public float launchRcdr;
}
