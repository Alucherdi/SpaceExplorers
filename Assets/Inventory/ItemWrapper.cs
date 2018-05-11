using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWrapper : MonoBehaviour {

	Inventory inventory;

	// Use this for initialization
	void Start () {
		inventory = GetComponent<Inventory> ();
	}

	// Active Item Slot 0
	public void launchSlot0(){
		if (inventory.backpack [0].itemName == "Empty") {
			Debug.Log ("No hay item en el slot");
		} else {
			inventory.backpack [0].GetComponent<Item> ().Active(0);
		}
	}

	// Active Item Slot 1
	public void launchSlot1(){
		if (inventory.backpack [1].itemName == "Empty") {
			Debug.Log ("No hay item en el slot");
		} else {
			inventory.backpack [1].GetComponent<Item> ().Active(1);
		}
	}

	// Active Item Slot 2
	public void launchSlot2(){
		if (inventory.backpack [2].itemName == "Empty") {
			Debug.Log ("No hay item en el slot");
		} else {
			inventory.backpack [2].GetComponent<Item> ().Active(2);
		}
	}

	// Active Item Slot 3
	public void launchSlot3(){
		if (inventory.backpack [3].itemName == "Empty") {
			Debug.Log ("No hay item en el slot");
		} else {
			inventory.backpack [3].GetComponent<Item> ().Active(3);
		}
	}

	// Active Item Slot 4
	public void launchSlot4(){
		if (inventory.backpack [4].itemName == "Empty") {
			Debug.Log ("No hay item en el slot");
		} else {
			inventory.backpack [4].GetComponent<Item> ().Active(4);
		}
	}

	// Active Item Slot 5
	public void launchSlot5(){
		if (inventory.backpack [5].itemName == "Empty") {
			Debug.Log ("No hay item en el slot");
		} else {
			inventory.backpack [5].GetComponent<Item> ().Active(5);
		}
	}

}

