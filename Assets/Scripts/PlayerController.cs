using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerController : MonoBehaviour {

    public Animator anim;
    Vector3 target;
    public GameObject targetPosition;
    Vector3 newPosition;
    public bool moving;
	Wrapper wrapper;
	//public Gun gun;

    void Start()
    {
        anim = GetComponent<Animator>();
		wrapper = GetComponent<Wrapper> ();
        moving = false;
    }

    void Update()
    {

		/// Stop moving provicional
		/// Quitar if alpha E
		/// 
		if (GetComponent<AlphaE> ().drawGun == false) {
			if (Input.GetMouseButtonDown (1) || Input.GetMouseButton (1)) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hitFloor;
				/*RaycastHit hitObstacles;
	            RaycastHit hitEnemy;*/

				if (Physics.Raycast (ray, out hitFloor)) {
					if (hitFloor.collider.CompareTag ("Floor")) {
						newPosition = hitFloor.point;
						//targetPosition.transform.position = newPosition;
						transform.LookAt (new Vector3 (newPosition.x, newPosition.y, newPosition.z));

						moving = true;
					}
				}
			}

			if (moving == true) {
				anim.SetFloat ("Forward", 10.0f);
				transform.Translate (new Vector3 (0, 0, 0.5f));
				if (Vector3.Distance (transform.position, newPosition) < 0.5f) {
					anim.SetFloat ("Forward", 0.0f);
					moving = false;
				}
			}
		} else {
			anim.SetFloat ("Forward", 0.0f);
			moving = false;
		}


		if(Input.GetKeyDown(KeyCode.Q)){
			Debug.Log ("QQQ");
			wrapper.launchQ ();
		}

		if(Input.GetKeyDown(KeyCode.W)){
			wrapper.launchW ();
		}


		if(Input.GetKeyDown(KeyCode.E)){
			wrapper.launchE ();
		}

		if(Input.GetKeyDown(KeyCode.R)){
			wrapper.launchR ();
		}
    }

    void OnTriggerEnter(Collider objectCollider)
    {
        if (objectCollider.gameObject.tag == "Enemy")
            anim.SetBool("Crouch", true);
    }

    void OnTriggerExit(Collider objectCollider)
    {
        if (objectCollider.gameObject.tag == "Enemy")
            anim.SetBool("Crouch", false);
    }

}

