using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Material Item", menuName = "Material Item")] 
public class Material_item : ScriptableObject{

	public string materialName;
	public float water;
	public float metal;
	public float leaves;
	public float organic;
	public float wood;
	public float resist;

}
