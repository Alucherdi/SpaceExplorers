using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenuController : MonoBehaviour {

    public static CharacterMenuController instance;

    public Image characterImage;
    public Text champText;

    public Sprite[] champsImages;

	void Start () {
        instance = this;

        characterImage.GetComponent<Image>();
	}
	
    public void Leo23Selection()
    {
        characterImage.sprite = champsImages[0];
        champText.text = "Leo23";
        ToCharacterSelection(champText.text, true);
    }

    public void EkSelection()
    {
        characterImage.sprite = champsImages[1];
        champText.text = "Ek";
        ToCharacterSelection(champText.text, true);
    }

    public void KalebDuneSelection()
    {
        characterImage.sprite = champsImages[2];
        champText.text = "Kaleb_Dune";
        ToCharacterSelection(champText.text, true);
    }

    public void MatsumotoSelection()
    {
        characterImage.sprite = champsImages[3];
        champText.text = "Matsumoto";
        CharacterSelection.instance.confirmButton.interactable = false;
        //ToCharacterSelection(champText.text, true);
    }

    public void NoPlayerSelection()
    {
        characterImage.sprite = champsImages[4];
        champText.text = "No Character";
        CharacterSelection.instance.confirmButton.interactable = false;
        //ToCharacterSelection(champText.text, true);
    }

    public void ToCharacterSelection(string name, bool interactableB)
    {
        CharacterSelection.instance.champname = name;
        CharacterSelection.instance.confirmButton.interactable = interactableB;
    }
}
