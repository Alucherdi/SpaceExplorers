using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

	public GameObject player;
	public Inventory inventory;
	Item item;
	public Image icon;
	public Button removeButton;
	public int slotNumber;
	// Numero en vez de game object

	void Start () {
		inventory = player.GetComponent<Inventory> ();
		//inventory.onItemChangedCallback += UpdateUI;
	}


	public void AddItem(Item newItem){
		item = newItem;
		icon.sprite = item.sprite;
		icon.enabled = true;
		removeButton.interactable = true;

	}

	public void ClearSlot(){
		item = gameObject.AddComponent<Empty_slot> ();
		icon.sprite = null;
		icon.enabled = false;
		removeButton.interactable = false;
	}

	public void OnRemoveButton(){
		inventory.removeItem (slotNumber);
	}

	public void UseItem(){
		inventory.backpack [slotNumber].Active(slotNumber);
	}
}
