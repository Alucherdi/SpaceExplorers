using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EnemyState {NORMAL, PSN, STUNNED}

public class EnemyController : MonoBehaviour {

    public Image enemyLifeImage;
    public EnemyState characterState;

    //Esperar X tiempo
    public int number = 0;
    public bool stunned;

	void Start () {
        stunned = false;

        characterState = EnemyState.NORMAL;
	}
	
	void Update () {

        if(characterState == EnemyState.NORMAL)
        {
            if (enemyLifeImage.fillAmount <= 0.25)
                InvokeRepeating("AumentarVida", 5.0f, 0.1f);
            else if (enemyLifeImage.fillAmount == 1)
                CancelInvoke("AumentarVida");
        }

        //Envenenamiento
        if(characterState == EnemyState.PSN && number == 0)
        {
            enemyLifeImage.fillAmount -= 0.001f;
            InvokeRepeating("Cuenta", 11.0f, 11.0f);
            //Daño de envenenamiento daño/vidadelpersonaje
            //tomar en cuenta resistencia igual
        }

        //Aturdido
        /*if (Assassin_Dash.instance.dash == true)
            stunned = true;

        if(characterState == EnemyState.STUNNED)
        {
            InvokeRepeating("Cuenta", 11.0f, 11.0f);
        }*/

        if (number >= 11)
        {
            Debug.Log("No estoy envenenado o aturdido");
            CancelInvoke("Cuenta");
            number = 0;
            stunned = false;
            characterState = EnemyState.NORMAL;
        }


    }

    void AumentarVida()
    {
        enemyLifeImage.fillAmount += 0.00001f;
    }

    void Cuenta()
    {
        number++;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Knife")
        {
            enemyLifeImage.fillAmount -= 0.1f;
            Debug.Log("Estoy envenenado");
            characterState = EnemyState.PSN;
        }

        if (collision.gameObject.tag == "Player" && stunned==true)
        {
            Debug.Log("Estoy aturdio");
            characterState = EnemyState.STUNNED;
        }
    }
}
