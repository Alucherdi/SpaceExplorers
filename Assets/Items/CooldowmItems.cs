using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldowmItems : MonoBehaviour {

    public static CooldowmItems instance;

    public int cooldown = 0;
    public int limitCooldown;

    public void InvocarCoolDown(int limite)
    {
        limitCooldown = limite;
        InvokeRepeating("CoolDown", 0.1f, 1.0f);
    }

    public void CancelarCoolDown()
    {
        CancelInvoke("CoolDown");
        cooldown = 0;
        limitCooldown = 0;
    }

    void CoolDown()
    {
        cooldown++;
    }
}
