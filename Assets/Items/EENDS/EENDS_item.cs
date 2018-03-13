using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EENDS_item : Item{

    public int activeCD = 35;
    public int cooldown = 0;

    public int slotNumber;

    public bool active = false;
    public int itemLife = 3;

    public GameObject player;
    public GameObject destination;
    public Vector3 teleportPosition;

    public override void Active(int slot)
    {
        slotNumber = slot;
        active = true;
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        destination = GameObject.Find("Teleport");
    }

    void Update()
    {
        teleportPosition = destination.transform.position;

        if (cooldown == 0 && active == true)
            ActiveEENDS();

        if(cooldown >= activeCD)
        {
            CancelInvoke("CoolDown");
            active = false;
            cooldown = 0;
        }

        if(itemLife == 0)
            Inventory.instance.removeItem(slotNumber);
    }

    void ActiveEENDS()
    {
        itemLife--;
        player.transform.position = teleportPosition;
        PlayerController.instance.navMeshAgent.SetDestination(teleportPosition);
        InvokeRepeating("CoolDown", 0.1f, 1.0f);
        active = false;
    }

    void CoolDown()
    {
        cooldown++;
    }
}
