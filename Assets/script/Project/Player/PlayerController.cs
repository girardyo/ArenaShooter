using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    [Range(0,1000)]
    private float Speed;

    [SerializeField]
    [Range(200, 700)]
    private float JumpForce;

    [SerializeField]
    private float RotationSpeed;
    private int NbColliderInTrigger;
    //Rigidbody m_Rigidbody;

    public Transform target;

    private bool lockEnemy;

    private void OnTriggerEnter(Collider other)
    {
        NbColliderInTrigger++;
    }

    private void OnTriggerExit(Collider other)
    {
        NbColliderInTrigger--;
    }

    // Start is called before the first frame update
    void Start()
    {
        //m_Rigidbody = GetComponent<Rigidbody>();

    }

    

    // Update is called once per frame
    void Update()
    {/*
        float x = Input.GetAxis("X-Axis");
        float y = Input.GetAxis("Y-Axis");
        float htAxis = Input.GetAxis("3rd Axis");
        float vtAxis = Input.GetAxis("4th Axis");
        Debug.Log(x +" "+ y);
        Debug.Log(htAxis + " " + vtAxis);*/

        /*
        if (x != 0.0f || y != 0.0f)
        {
            float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
            Debug.Log(angle);
            // Do something with the angle here.
        }
        */
        float DeltaSpeed = Speed * Time.deltaTime;
        float DeltaRot = RotationSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (lockEnemy == false)
            {
                lockEnemy = true;
            }
            else
            {
                lockEnemy = false;
            }
            Debug.Log(lockEnemy);
        }

        if (lockEnemy == true)
        {
            Debug.Log("locked");
            Debug.Log("allo " + Input.GetAxis("Horizontalps4"));

            transform.LookAt(target);
        }

        int t = 0;

        if (Input.GetKey(KeyCode.Z))
        {
            //GetComponent<Rigidbody>().AddForce(transform.forward * DeltaSpeed);
            //m_Rigidbody.velocity = transform.forward * Speed;
            t = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            //GetComponent<Rigidbody>().AddForce(-transform.forward * DeltaSpeed);
            //m_Rigidbody.velocity = -transform.forward * Speed;
            t = -1;
        }

        Vector3 CurrentSpeed = GetComponent<Rigidbody>().velocity;
        Vector3 MaxSpeed = Speed*t*transform.forward;

        GetComponent<Rigidbody>().AddForce(MaxSpeed - CurrentSpeed);

        float Xaxis = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0, Xaxis * DeltaRot, 0));







        if (Input.GetKey(KeyCode.D))
        {
            //transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * Speed, Space.World);
            transform.Rotate(new Vector3(0, DeltaRot, 0));
        }

        if (Input.GetKey(KeyCode.Q))
        {
            //transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * Speed, Space.World);
            transform.Rotate(new Vector3(0, -DeltaRot, 0));
        }

        if (Input.GetKeyDown(KeyCode.Space)&& NbColliderInTrigger >0)
        {
            Debug.Log("Nombre de collider trigger" + NbColliderInTrigger);
            GetComponent<Rigidbody>().AddForce(new Vector3(0, JumpForce, 0));
        }
        if (Input.GetKeyDown(KeyCode.E))
        {

        }
    }
}
