using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {
	public GameObject player;
	public Transform itemsParent;
	InventorySlot[] slots;
	public Inventory inventory;
	// Use this for initialization
	void Start () {
		inventory = player.GetComponent<Inventory> ();
		inventory.onItemChangedCallback += UpdateUI;
		slots = itemsParent.GetComponentsInChildren<InventorySlot> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateUI(){
		for(int i=0; i<slots.Length; i++){
			if (inventory.backpack [i].itemName == "Empty") {
				slots [i].ClearSlot ();
			} else {
				slots [i].AddItem (inventory.backpack [i]);
			}
		}
		Debug.Log ("Actualizando UI");
	}
}
