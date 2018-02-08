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

		if(Input.GetKeyDown(KeyCode.A)){
			if (backpack [0].itemName == "Empty") {
				Debug.Log ("No hay item en el slot");
			} else {
				backpack [0].GetComponent<Item> ().active.launchActive ();	
				backpack [0] = empty_slot;
				if (onItemChangedCallback != null) {
					onItemChangedCallback.Invoke ();
				}
			}

		}

		if(Input.GetKeyDown(KeyCode.S)){
			if (backpack [1].itemName == "Empty") {
				Debug.Log ("No hay item en el slot");
			} else {
				backpack [1].GetComponent<Item> ().active.launchActive ();	
				backpack [1] = empty_slot;
				if (onItemChangedCallback != null) {
					onItemChangedCallback.Invoke ();
				}
			}
		}

		if(Input.GetKeyDown(KeyCode.D)){
			if (backpack [2].itemName == "Empty") {
				Debug.Log ("No hay item en el slot");
			} else {
				backpack [2].GetComponent<Item> ().active.launchActive ();	
				backpack [2] = empty_slot;
				if (onItemChangedCallback != null) {
					onItemChangedCallback.Invoke ();
				}
			}
		}

		if(Input.GetKeyDown(KeyCode.F)){
			if (backpack [3].itemName == "Empty") {
				Debug.Log ("No hay item en el slot");
			} else {
				backpack [3].GetComponent<Item> ().active.launchActive ();
				backpack [3] = empty_slot;
				if (onItemChangedCallback != null) {
					onItemChangedCallback.Invoke ();
				}
			}
		}

		if(Input.GetKeyDown(KeyCode.G)){
			if (backpack [4].itemName == "Empty") {
				Debug.Log ("No hay item en el slot");
			} else {
				backpack [4].GetComponent<Item> ().active.launchActive ();	
				backpack [4] = empty_slot;
				if (onItemChangedCallback != null) {
					onItemChangedCallback.Invoke ();
				}
			}
		}

		if(Input.GetKeyDown(KeyCode.H)){
			if (backpack [5].itemName == "Empty") {
				Debug.Log ("No hay item en el slot");
			} else {
				backpack [5].GetComponent<Item> ().active.launchActive ();	
				backpack [5] = empty_slot;
				if (onItemChangedCallback != null) {
					onItemChangedCallback.Invoke ();
				}
			}
		}

		//
		/*
		if(Input.GetKeyDown(KeyCode.G)){
			removeItem (0);
		}
		*/

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
	
