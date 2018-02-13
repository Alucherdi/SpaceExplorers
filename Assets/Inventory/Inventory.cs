using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {


	/// <summary>
	/// / Queda pendiente el ordenamiento
	/// y que la mochila estepor defecto incializada en 6 espacios
	/// </summary>

	// Delegado para actualizar GUI
	public delegate void OnItemChanged ();
	public OnItemChanged onItemChangedCallback;
	public materials_data materials;
	// Stats del personaje
	Stats stats;

	public int max = 6; // Cantidad maxima de items

	public List<Item> backpack = new List<Item> ();
	Empty_slot empty_slot;

	public void Start(){
		stats = GetComponent<Stats> ();
		empty_slot = gameObject.AddComponent<Empty_slot> ();
		empty_slot.itemName = "Empty";
		backpack.Add (empty_slot);
		backpack.Add (empty_slot);
		backpack.Add (empty_slot);
		backpack.Add (empty_slot);
		backpack.Add (empty_slot);
		backpack.Add (empty_slot);
		materials.wood = 999;
		materials.leaves = 999;
		materials.metal = 999;
		materials.organic = 999;
		materials.water = 999;

	}

	public bool addItem(Item item){
		for (int i = 0; i < backpack.Count; i++) {
			if (backpack[i].itemName == "Empty") {
				backpack [i] = item;

				// Actualizar stats
				stats.AddStats(i);

				// Notificador para acualizar GUI
				if (onItemChangedCallback != null) {
					onItemChangedCallback.Invoke ();
				}
				return true;
			}	
		}
		return false;
	}

	public void removeItem(int n){
		
		backpack [n] = empty_slot;

		stats.RemoveStats (n);
		// Notificador para actualizar GUI
		if (onItemChangedCallback != null) {
			onItemChangedCallback.Invoke ();
		}
	}



	///// Wrapper 
	/// 
	void Update(){
		
	}


}


[System.Serializable]
public struct materials_data {
	public float water;
	public float metal;
	public float leaves;
	public float organic;
	public float wood;
}
	
