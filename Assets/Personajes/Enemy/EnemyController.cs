using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

    public Image enemyLifeImage;

	void Start () {
		
	}
	
	void Update () {

        if (enemyLifeImage.fillAmount <= 0.4)
            InvokeRepeating("AumentarVida", 2.0f, 0.3f);
        else if (enemyLifeImage.fillAmount == 1)
            CancelInvoke("AumentarVida");

    }

    void AumentarVida()
    {
        enemyLifeImage.fillAmount += 0.05f;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Knife")
        {
            Debug.Log("Entre en colision");
            enemyLifeImage.fillAmount -= 0.2f;
        }
    }
}
