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
        
    }

    public void EkSelection()
    {
        characterImage.sprite = champsImages[1];
        champText.text = "Ek";
    }

    public void KalebDuneSelection()
    {
        characterImage.sprite = champsImages[2];
        champText.text = "Kaleb Dune";
    }

    public void MatsumotoSelection()
    {
        characterImage.sprite = champsImages[3];
        champText.text = "Matsumoto";
    }

    public void NoPlayerSelection()
    {
        characterImage.sprite = champsImages[4];
        champText.text = "No Character";
    }
}
