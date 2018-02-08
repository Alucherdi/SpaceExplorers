using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Material_gui : MonoBehaviour {


	// Use this for initialization
	//public GameObject player;
	//public Inventory inventory;
	public Text metal;
	public Text wood;
	public Text water;
	public Text leaves;
	public Text organic;
	void Start () {
		//inventory = player.GetComponent<Inventory> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetNumbers(float xmetal, float xwood, float xwater, float xleaves, float xorganic){
		metal.text = xmetal.ToString();
		wood.text = xwood.ToString();
		water.text = xwater.ToString();
		leaves.text = xleaves.ToString();
		organic.text = xorganic.ToString();
	}
}
