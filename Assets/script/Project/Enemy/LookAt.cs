using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    private Camera mcamera;

    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        mcamera = Camera.main;
        gameObject.transform.LookAt(mcamera.transform.position);

    }

    // Update is called once per frame
    void Update()
    {
       gameObject.transform.LookAt(mcamera.transform.position);

    }
}
