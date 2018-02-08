using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeaderStore : MonoBehaviour {

	public Text wood;
	public Text metal;
	public Text organic;
	public Text leaves;
	public Text water;
	public float itemm;
	public float craftTime;
	public float parts=0;
	public Slider slider;
	public Transform drawingZone;
	public List<GameObject> objects;
	// Pplayer
	public GameObject player;
	public Inventory inventory;
	//public ItemStore[] slots;
	//public Transform slotsContainer;
	//currency
	public List<GameObject> itemsStore;
	// Use this for initialization
	// Natural timer
	private int nextUpdate=1;
	void Start () {
		inventory = player.GetComponent<Inventory> ();
		//slots = slotsContainer.GetComponentsInChildren<ItemStore> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (parts != 0) {
			if (Time.time >= nextUpdate) {
				nextUpdate = Mathf.FloorToInt (Time.time) + 1;
				slider.value += parts;
				if (slider.value >= .98) {
					int itemmm = (int) itemm;
					GameObject item_instance = Instantiate (objects [itemmm], drawingZone.position, drawingZone.rotation);
					slider.value = 0;
					parts = 0;
				}
			}
		}
	}

	public void BuyItem(){
		/// Instanciar el item en una lista de todos los items;
		Debug.Log("Se va a crear el item");
		Debug.Log (itemm);
		ItemStore cost = itemsStore [(int) itemm].GetComponent<ItemStore> ();
		if(checkCurrency(inventory, cost))
		{
			parts = (float) (1.0 / craftTime);
		}

	}
	public bool checkCurrency(Inventory inventory, ItemStore itemStore){
		bool back = true;
		if(inventory.materials.leaves < itemStore.leaves
			|| inventory.materials.metal < itemStore.metal
			|| inventory.materials.wood < itemStore.wood
			|| inventory.materials.water < itemStore.wood
			|| inventory.materials.organic < itemStore.organic){
			back = false;
		}
		if (back) {
			inventory.materials.leaves -= itemStore.leaves;
			inventory.materials.metal -= itemStore.metal;
			inventory.materials.wood -= itemStore.wood;
			inventory.materials.water -= itemStore.wood;
			inventory.materials.organic -= itemStore.organic;
		}
		return back;
	}

}
