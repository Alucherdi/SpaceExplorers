using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kaleb_R : Ability_abstract
{
    float costAbility = 100;
    public float cooldownR = 0;
    public float cooldownRlimit;

    public GameObject bulletPanel;
    public Image firstshootImage;
    public Image secondshootImage;
    public Image thirdshootImage;

    public int bullets = 3;
    public float wait = 0;

    public override void launch()
    {

    }

    void Start () {
        bulletPanel.SetActive(false);
	}
	
	void Update () {
		
        if(cooldownR >= cooldownRlimit)
        {
            CancelInvoke("CoolDown");
            cooldownR = 0;
            bullets = 3;
        }

        if(wait >=2)
        {
            CancelInvoke("WaitShot");
            wait = 0;
        }

        if(bullets==0)
            InvokeRepeating("CoolDown", 0.1f, 1.0f);
    }

    public void SpecialShot()
    {
        Debug.Log("Disparaste una bala especial");
        //Animacion
        //BulletShooter.instance.BulletShot();
    }

    void CoolDown()
    {
        cooldownR++;
    }

    void WaitShot()
    {
        wait++;
    }
}
