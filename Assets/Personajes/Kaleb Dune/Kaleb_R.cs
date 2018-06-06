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
    public Image thirdshootImage;
    public Image secondshootImage;
    public Image firstshootImage;

    public int bullets = 3;
    public float wait = 0;

    public override void launch()
    {
        
    }

    void Start () {
        bulletPanel.SetActive(false);
    }
	
	void Update () {

        cooldownRlimit = PlayerController.instance.stats.stats.launchRcd - (PlayerController.instance.stats.stats.launchRcd * (PlayerController.instance.stats.stats.cooldownReduction / 100));

        if (cooldownR == 0)
        {
            if (Input.GetMouseButtonUp(0) && PlayerController.instance.abilityR==true)
            {
                if (PlayerController.instance.barraStamina.fillAmount >= costAbility / PlayerController.instance.stats.stats.stamina)
                {
                    //PlayerController.instance.LookDestination(SkillShotCursor.instance.newPosition);      
                    SpecialShot();
                    bullets--;
                    InvokeRepeating("WaitShot",0.1f, 1.0f);
                }
                else
                {
                    Debug.Log("Imposible utilizar la habilidad, poca stamina");
                    PlayerController.instance.AbilityOff();
                }
            }

            //Activar/Desactivar Panel
            if (PlayerController.instance.abilityR == true)
                bulletPanel.SetActive(true);
            else
                bulletPanel.SetActive(false);
        }

        if (wait >= 8)
            EndSkill();

        //Cuenta de las balas
        if (bullets == 3)
            EnableBulletImages();
        else if (bullets == 2)
            firstshootImage.enabled = false;
        else if (bullets == 1)
            secondshootImage.enabled = false;
        else if (bullets == 0)
            thirdshootImage.enabled = false;


        if (cooldownR >= cooldownRlimit)
        {
            CancelInvoke("CoolDown");
            cooldownR = 0;
            bullets = 3;
            MenuController.instance.skillR.fillAmount = 1;
        }    
    }

    void EndSkill()
    {
        bulletPanel.SetActive(false);

        CancelInvoke("WaitShot");
        wait = 0;

        InvokeRepeating("CoolDown", 0.1f, 1.0f);

        PlayerController.instance.barraStamina.fillAmount -= costAbility / PlayerController.instance.stats.stats.stamina;
        PlayerController.instance.AbilityOff();
        MenuController.instance.skillR.fillAmount = 0;

    }

    void EnableBulletImages()
    {
        firstshootImage.enabled = true;
        secondshootImage.enabled = true;
        thirdshootImage.enabled = true;
    }

    public void SpecialShot()
    {
        Debug.Log("Disparaste una bala especial");
        //Animacion
        SpecilBulletShooter.instance.SBulletShot();
    }

    void CoolDown()
    {
        cooldownR++;
        MenuController.instance.skillR.fillAmount += 1 / cooldownRlimit;
    }

    void WaitShot()
    {
        wait++;
    }
}
