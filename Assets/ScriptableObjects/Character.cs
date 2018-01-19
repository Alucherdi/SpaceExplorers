using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")] 
public class Character : ScriptableObject {
	
	public string characterName; 
	public float health; // HP
	public float stamina; // 
	public float healthRegen; // Per second
	public float staminaRegen; // Per second
    public float multiplier;
    /*STATS de ataque físico*/
	public float physicalAttack; // Phisiscal damage
    public float phiysicalkResist; // Armor
    public float attackSpeed;
    /*STATS de ataque energético*/
    public float energyAttack; // Energy damage;
	public float energyResist; // Energetic armor
    /*STATS de velocidad*/
	public float speed; // Movement speed
    public float dash;
    /*STATS de CoolDown*/
    public float cooldownReduction; // % 
	public float launchQ_CD;
	public float launchW_CD;
	public float launchE_CD;
	public float launchR_CD;
}
