using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour {

    public static HudController instace;

    public GameObject player;

    public Text health;
    public Text stamina;
    public Text physicalDamege;
    public Text energyDamage;
    public Text physicalResist;
    public Text energyResist;
    public Text moveSpeed;
    public Text attackSpeed;

    public Image skillQ;
    public Image skillW;
    public Image skillE;
    public Image skillR;

    void Start () {
        instace = this;
	}
	
	void Update () {

        if (GameState.gamestate.currentState == States.IN_GAME)
        {
            player = GameObject.FindWithTag("Player");

                /*health.text = player.GetComponent<Stats>().stats.health.ToString();
                stamina.text = player.GetComponent<Stats>().stats.stamina.ToString();
                physicalDamege.text = player.GetComponent<Stats>().stats.physicalDamage.ToString();
                energyDamage.text = player.GetComponent<Stats>().stats.energyDamage.ToString();
                physicalResist.text = player.GetComponent<Stats>().stats.physicalResist.ToString();
                energyResist.text = player.GetComponent<Stats>().stats.energyResist.ToString();
                moveSpeed.text = player.GetComponent<Stats>().stats.movementSpeed.ToString();
                attackSpeed.text = player.GetComponent<Stats>().stats.attackSpeed.ToString();*/
        }
            
    }
}
