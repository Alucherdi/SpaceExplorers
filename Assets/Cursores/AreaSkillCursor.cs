using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaSkillCursor : MonoBehaviour {

    public static AreaSkillCursor instance;
    public bool activeCursor;
    public Vector3 newPosition;
    public Image areaSkillImage;
    public Image cursorSkillIamge;

    Vector3 targtePosition;

	void Start () {
        instance = this;
	}
	
	void Update () {

        if (activeCursor == true)
        {
            //areaSkillImage.enabled = true;
            cursorSkillIamge.enabled = true;
        }
        else
        {
            areaSkillImage.enabled = false;
            cursorSkillIamge.enabled = false;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitFloor;

        if (Physics.Raycast(ray, out hitFloor))
        {
            if (hitFloor.collider.CompareTag("Floor"))
            {
                newPosition = hitFloor.point;
                cursorSkillIamge.transform.position = new Vector3(newPosition.x, newPosition.y + 0.1f, newPosition.z);
            }
        }
    }

    public void Active(bool active)
    {
        activeCursor = active;
    }
}
