using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsaberController : MonoBehaviour {

    Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Throw(18.0f, 1.0f, Camera.main.transform.forward, 2.0f));
        }
    }

    IEnumerator Throw(float dist, float width, Vector3 direction, float time)
    {
        Vector3 pos = transform.position;
        float height = transform.position.y;
        Quaternion q = Quaternion.FromToRotation(Vector3.forward, direction);
        float timer = 0.0f;
        rigidbody.AddTorque(0.0f, 0.0f, 400.0f);
        while (timer < time)
        {
            float t = Mathf.PI * 2.0f * timer / time - Mathf.PI / 2.0f;
            float x = width * Mathf.Cos(t);
            float z = dist * Mathf.Sin(t);
            Vector3 v = new Vector3(x, height, z + dist);
            rigidbody.MovePosition(pos + (q * v));
            timer += Time.deltaTime;
            yield return null;
        }

        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.velocity = Vector3.zero;
        rigidbody.rotation = Quaternion.identity;
        rigidbody.MovePosition(pos);
    }
}
/*
 'dist' - distance of the throw.
 'width' - width of the ellipse for the throw.
 'direction' - vector indicating the direction of the throw
 'time' - time the throw should take.
 */
