using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour {

    public static CharacterSelection instance;

    public GameObject assassinCharacter;
    public GameObject leo23Character;
    //public GameObject kalebCharacter;

    public bool assassin;
    public bool leo23;
    //public bool kaleb;

	void Start () {
        instance = this;

        assassinCharacter = GameObject.Find("IvanChamp");
        leo23Character = GameObject.Find("Player");
        //kalebCharacter = GameObject.Find("Kaleb_Dune");

        assassinCharacter.SetActive(false);
        leo23Character.SetActive(false);
        //kalebCharacter.SetActive(false);

        assassin = false;
        leo23 = false;
        //kaleb = false;
    }
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            assassinCharacter.SetActive(true);
            assassin = true;
            leo23Character.SetActive(false);
            leo23 = false;
            /*kalebCharacter.SetActive(false);
            kaleb = false;*/
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            assassinCharacter.SetActive(false);
            assassin = false;
            leo23Character.SetActive(true);
            leo23 = true;
            /*kalebCharacter.SetActive(false);
            kaleb = false;*/
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            assassinCharacter.SetActive(false);
            assassin = false;
            leo23Character.SetActive(false);
            leo23 = false;
            /*kalebCharacter.SetActive(true);
            kaleb = true;*/
        }
    }
}
