using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemStore : MonoBehaviour {

	// Use this for initialization

	public Image icon;
	//public Item item;

	// Recibpe
	public float wood;
	public float water;
	public float metal;
	public float organic;
	public float leaves;
	public float craftTime;

	//Update header
	public GameObject header;
	HeaderStore headerData;
	//public float itemToBuy;
	//Item item_instance;
	public float itemSelected;
	void Start () {
		headerData = header.GetComponent<HeaderStore> ();
		//item_instance = GetComponent<Item> ();
		//item_instance.sprite = GetComponent<Image> ().sprite;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetData(){
		headerData.leaves.text = leaves.ToString();
		headerData.wood.text = wood.ToString();
		headerData.metal.text = metal.ToString();
		headerData.water.text = water.ToString();
		headerData.organic.text = organic.ToString ();
		headerData.itemm = itemSelected;
		headerData.craftTime = craftTime;
		//headerData.itemToBuy = itemToBuy;
	}
}


