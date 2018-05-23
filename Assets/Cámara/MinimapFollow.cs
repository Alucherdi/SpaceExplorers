using UnityEngine;

public class MinimapFollow : MonoBehaviour {

	public Transform playerTransform;

    /*void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }*/

    void Update()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        this.transform.position = playerTransform.position + new Vector3(0f, 10f, 0f);  
    }
}