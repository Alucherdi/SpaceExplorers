using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DropZone : MonoBehaviour, IDropHandler {
	//public Image icon;
	public int slot;
	public int slot2;
	public GameObject player;
	public GameObject canvas;
	public InventoryUI inventoryUI;
	public Inventory inventory;
	Item item;
	void Start(){
		inventory = player.GetComponent<Inventory> ();
		inventoryUI = canvas.GetComponent<InventoryUI> ();
	}

	public void OnDrop(PointerEventData eventData){
		Debug.Log ("Dropped");
		slot = GetComponent<InventorySlot> ().slotNumber;
		slot2 = eventData.pointerDrag.GetComponent<Draggable> ().slot;
		Debug.Log (slot);
		Debug.Log (slot2);
		item = inventory.backpack [slot];
		inventory.backpack [slot] = inventory.backpack [slot2];
		inventory.backpack [slot2] = item;
		inventoryUI.UpdateUI ();

	}
}
