using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillShotCursor : MonoBehaviour {

    public static SkillShotCursor instance;
    public Vector3 newPosition;
    public bool activeCursor;
    public Image skillShotCursorImage;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if (activeCursor == true)
            skillShotCursorImage.enabled = true;
        else
            skillShotCursorImage.enabled = false;


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

    public void Active(bool active)
    {
        activeCursor = active;
    }
}
