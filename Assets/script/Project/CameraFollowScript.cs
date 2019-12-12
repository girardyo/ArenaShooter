using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    [SerializeField]
    private Transform Target1;

    [SerializeField]
    private Transform Target2;

    [SerializeField]
    private float Speed = 3f;

    [SerializeField]
    private float Offset = 10;

    [SerializeField]
    private float MinDistance, MaxDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 middle = Vector3.Lerp(Target1.position, Target2.position, 0.5f);

        float distance = Vector3.Distance(Target1.position, Target2.position);

        if (distance > MaxDistance)
        {

            distance = MaxDistance;

        }

        if (distance < MinDistance)
        {

            distance = MinDistance;

        }

        Vector3 t = middle + new Vector3(0, distance + Offset, 0);

        transform.position = Vector3.Lerp(transform.position, t , Time.deltaTime * Speed);



    }
}
