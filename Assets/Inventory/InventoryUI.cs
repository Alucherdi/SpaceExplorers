using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {

    public static InventoryUI instance;

	public GameObject player;
	public Transform itemsParent;
	InventorySlot[] slots;
	public Inventory inventory;

	void Start () {
        instance = this;   
	}
	
	void Update () {
        player = GameObject.FindWithTag("Player");
        inventory = player.GetComponent<Inventory>();
        inventory.onItemChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
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
