using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {

    public static PlayerController instance;

    Wrapper wrapper;
    Animator anim;
    /*Vector3 target; //Por si se ocupa un identificador al dar los click en la escena
    public GameObject targetPosition;*/
    Vector3 newPosition;
    public bool moving;

    public bool abilityQ;
    public bool abilityW;
    public bool abilityE;
    public bool abilityR;

    public Image barraVida;
    public Image barraStamina;

    public SkinnedMeshRenderer skinPlayer;

    void Start()
    {
        instance = this;
        wrapper = GetComponent<Wrapper>();
        anim = GetComponent<Animator>();

        moving = false;
        abilityQ = false;
        abilityW = false;
        abilityE = false;
        abilityR = false;
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(1) || Input.GetMouseButton(1))
        {

            /*
            RaycastHit hitObstacles; //Para identificar si hay algun obstáculo
            RaycastHit hitEnemy; //Para identificar si hay algún enemigo
            */

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitFloor;

            if (Physics.Raycast(ray, out hitFloor))
            {
                if (hitFloor.collider.CompareTag("Floor"))
                {
                    newPosition = hitFloor.point;
                    transform.LookAt(new Vector3(newPosition.x, newPosition.y, newPosition.z));

                    moving = true;
                    AbilityOff();
                }
            }
            //LookDestination(newPosition);
        }

        if (moving == true)
        {
            anim.SetFloat("Forward", 10.0f);
            transform.Translate(new Vector3(0, 0, 0.5f));
            if (Vector3.Distance(transform.position, newPosition) < 0.5f)
            {
                anim.SetFloat("Forward", 0.0f);
                moving = false;
            }
        }
        //barraStamina.fillAmount -= precioHabilidad/StaminaPersonaje
        
        //Activar Abilidades
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SkillShotCursor.instance.Active(false);
            AreaSkillCursor.instance.Active(false);
            wrapper.launchQ();
            abilityQ = true;
            abilityW = false;
            abilityE = false;
            abilityR = false;

        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            SkillShotCursor.instance.Active(false);
            AreaSkillCursor.instance.Active(false);
            wrapper.launchW();
            abilityW = true;
            abilityQ = false;
            abilityE = false;
            abilityR = false;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            SkillShotCursor.instance.Active(false);
            AreaSkillCursor.instance.Active(false);
            wrapper.launchE();
            abilityE = true;
            abilityQ = false;
            abilityW = false;
            abilityR = false;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SkillShotCursor.instance.Active(false);
            AreaSkillCursor.instance.Active(false);
            wrapper.launchR();
            abilityR = true;
            abilityQ = false;
            abilityW = false;
            abilityE = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
            wrapper.launchDash();

        /*Sistema para uamentar STAMINA*/
        if (barraStamina.fillAmount == 1)
        {
            CancelInvoke("AumentarStamina");
        }

        if (barraStamina.fillAmount < 1)
        {
            InvokeRepeating("AumentarStamina", 5.0f, 0.1f);
        }
    }

    public void AbilityOff()
    {
        abilityQ = false;
        abilityW = false;
        abilityE = false;
        abilityR = false;
    }


    void AumentarStamina()
    {
        barraStamina.fillAmount += 0.002f;
    }

    public void LookDestination(Vector3 newPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitFloor;

        if (Physics.Raycast(ray, out hitFloor))
        {
            if (hitFloor.collider.CompareTag("Floor"))
            {
                newPosition = hitFloor.point;
                transform.LookAt(new Vector3(newPosition.x, newPosition.y, newPosition.z));
            }
        }
    }

    public void MovingTo(Vector3 destination, bool moving)
    {
        if (moving == true)
        {
            anim.SetFloat("Forward", 10.0f);
            transform.Translate(new Vector3(0, 0, 0.5f));
            if (Vector3.Distance(transform.position, destination) < 10.0f)
            {
                anim.SetFloat("Forward", 0.0f);
                moving = false;
            }
        }
    }

    void OnTriggerEnter(Collider objectCollider)
    {
        if (objectCollider.gameObject.tag == "Enemy")
        {
            //Debug.Log("Entre en colisión");
            barraVida.fillAmount -= 0.1f;
            /*
             *barraVida.fillAmount -= AtaqueEnemigo/VidadelPersonaje.
            */ 
             
        }
    }
}