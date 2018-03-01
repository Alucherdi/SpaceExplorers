using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsaberController : MonoBehaviour {

    bool go;//Will Be Used To Change Direction Of Weapon

    GameObject player;//Reference To The Main Character
    public GameObject sword;//Reference To The Main Character's Weapon

    Transform itemToRotate;//The Weapon That Is A Child Of The Empty Game Object

    Vector3 locationInFrontOfPlayer;//Location In Front Of Player To Travel To

    void Start()
    {
        go = false; //Set To Not Return Yet

        player = GameObject.Find("Leo23");// The GameObject To Return To
        sword = GameObject.Find("Lightsaber");//The Weapon The Character Is Holding In The Scene

        sword.GetComponent<SpriteRenderer>().enabled = false; //Turn Off The Mesh Render To Make The Weapon Invisible

        itemToRotate = gameObject.transform.GetChild(0); //Find The Weapon That Is The Child Of The Empty Object      

        //Adjust The Location Of The Player Accordingly, Here I Add To The Y position So That The Object Doesn't Go Too Low ...Also Pick A Location In Front Of The Player
        locationInFrontOfPlayer = new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z) + player.transform.forward * 10f;

        StartCoroutine(Boom());//Now Start The Coroutine
    }

    IEnumerator Boom()
    {
        go = true;
        yield return new WaitForSeconds(1.0f);
        go = false;
    }

    void Update()
    {
        itemToRotate.transform.Rotate(0, 0, Time.deltaTime * 500); //Rotar el "lightsaber"

        if (go)
        {
            transform.position = Vector3.MoveTowards(transform.position, locationInFrontOfPlayer, Time.deltaTime * 40); //Change The Position To The Location In Front Of The Player           
            sword.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (!go)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z), Time.deltaTime * 40); //Return To Player
        }

        if (!go && Vector3.Distance(player.transform.position, transform.position) < 1.5)
        {
            //Once It Is Close To The Player, Make The Player's Normal Weapon Visible, and Destroy The Clone
            sword.GetComponent<SpriteRenderer>().enabled = true;
            Destroy(this.gameObject);
        }
    }
}