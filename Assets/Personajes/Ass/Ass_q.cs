using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ass_q : Ability_abstract {

	public List<GameObject> nodesB;
	public GameObject nodePrefab;
	public Transform position;
	float costAbility = 0;
	public float cooldownQ = 0;
	public float cooldownQlimit;

	bool activeMurder;

	public override void launch(){
		Debug.Log ("Ass q");
		AreaSkillCursor.instance.Active(true);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		cooldownQlimit = PlayerController.instance.stats.stats.launchQcd - (PlayerController.instance.stats.stats.launchQcd * (PlayerController.instance.stats.stats.cooldownReduction / 100));
		if(cooldownQ==0)
		{
			if (Input.GetMouseButtonUp(0) && AreaSkillCursor.instance.activeCursor == true)
			{
				if (PlayerController.instance.barraStamina.fillAmount >= costAbility / PlayerController.instance.stats.stats.stamina)
				{
					Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
					RaycastHit hitEnemy;

					/*
					if (Input.mousePosition.x < Screen.width * 0.5)
						GetComponent<SpriteRenderer>().flipX = false;
					else
						GetComponent<SpriteRenderer>().flipX = true;
					*/
					if(nodesB.Count==5){

						Destroy (nodesB [0]);
						nodesB.RemoveAt (0);
						/*
						GameObject instanceDel = nodesB [0];
						Destroy (instanceDel);
						nodesB.RemoveAt (0);
						nodesB [0] = nodesB [1];
						nodesB [1] = nodesB [2];
						nodesB [2] = nodesB [3];
						nodesB [3] = nodesB [4];
						nodesB.RemoveAt(4);
						*/
					}
					position = AreaSkillCursor.instance.cursorSkillIamge.transform;
					GameObject nodeInstance = Instantiate (nodePrefab, position.position, position.rotation); 
					nodesB.Add (nodeInstance);

					PlayerController.instance.barraStamina.fillAmount -= costAbility / PlayerController.instance.stats.stats.stamina;
					PlayerController.instance.AbilityOff();
					AreaSkillCursor.instance.activeCursor = false;

				}
				else
				{
					AreaSkillCursor.instance.activeCursor = false;
					Debug.Log("Imposible utilizar la habilidad, poca stamina");
				}
			}
		}
		else
		{
			AreaSkillCursor.instance.activeCursor = false;
		}

		if (cooldownQ >= cooldownQlimit)
		{
			CancelInvoke("CoolDown");
			cooldownQ = 0;
		}
	
	}




}
