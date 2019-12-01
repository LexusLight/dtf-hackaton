using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public static float pointX = 0;
    public static float pointY = 0;

    // Update is called once per frame
    void Update()
    {
            Camera camera1 = GetComponent<Camera>();
            Vector3 point = camera1.WorldToViewportPoint(new Vector3(pointX, pointY, -10));
            Vector3 delta = new Vector3(Mathf.Ceil(pointX), Mathf.Ceil(pointY), 0) - camera1.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 10)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;


            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
    }
}