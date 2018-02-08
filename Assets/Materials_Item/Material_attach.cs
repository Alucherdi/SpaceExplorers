using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material_attach : MonoBehaviour {

	public Material_item item;
	public float ratioInteraction;
	public float distance;
	public GameObject player;

	// Item stats
	public string materialName;
	public float water;
	public float metal;
	public float leaves;
	public float organic;
	public float wood;
	public float resist;
	//
	void Start()
	{
		// Find local player
		materialName = item.materialName;
		water = item.water;
		metal = item.metal;
		leaves = item.leaves;
		organic = item.organic;
		wood = item.wood;
		resist = item.resist;
	}

	void Update()
	{
		
	}

	void OnMouseDown(){
		if (Vector3.Distance (transform.position, player.transform.position) < 10.0f) {
			if ( resist >0 ) {
				if (player.GetComponent<HitMaterial> ().hit (gameObject)) {
				
				}else {
					Debug.Log ("Se encuentra en cd ");
				}


				Debug.Log (resist);
				Debug.Log ("Se ha tocado el objeto " + distance);
			} else  {
				gameObject.GetComponent<MeshRenderer> ().enabled = false;
				gameObject.GetComponent<BoxCollider> ().enabled = false;
                foreach (Transform children in this.transform)
                {
                    children.GetComponent<MeshRenderer>().enabled = false;
                }
                Debug.Log ("Se ha terminado el objeto");
			}
		}
	}
}
