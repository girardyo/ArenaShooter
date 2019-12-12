using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;
    public Transform boss;
    public Vector3 offset;
    public float Speed = 0.125f;


    private void Update()
    {
        Vector3 DesiredPosition = player.position + offset;
        Vector3 SmoothedPosition = Vector3.Lerp(transform.position, DesiredPosition, Speed * Time.deltaTime);
        transform.position = SmoothedPosition;


        float dist = Vector3.Distance(boss.position, player.position);
       // print("Distance to other: " + dist);


        if (dist >= 12f && dist <= 42)
        {
            gameObject.GetComponent<Camera>().orthographicSize = Mathf.Lerp(gameObject.GetComponent<Camera>().orthographicSize, dist * 0.7875f, Time.deltaTime);

            //cameraSize.orthographic = false;
        }

        if (dist > 42)
            gameObject.GetComponent<Camera>().orthographicSize = Mathf.Lerp(gameObject.GetComponent<Camera>().orthographicSize, 34.5f, Time.deltaTime);

        }
    //cameraSize.GetComponent<Camera>().orthographicSize



}
