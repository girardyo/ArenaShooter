using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerFPSScript : MonoBehaviour
{

    [SerializeField]
    [Range(0, 1000)]
    private float Speed;

    [SerializeField]
    [Range(200, 700)]
    private float JumpForce;

    [SerializeField]
    private float RotationSpeed;

    [SerializeField]
    private float XangleMax;

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
    {
        float DeltaSpeed = Speed * Time.deltaTime;
        float DeltaRot = RotationSpeed * Time.deltaTime;



 
        transform.LookAt(target);
       

        int t = 0;

        if (Input.GetKey(KeyCode.Z))
        {
            //GetComponent<Rigidbody>().AddForce(transform.forward * DeltaSpeed);
            //m_Rigidbody.velocity = transform.forward * Speed;
            t = -1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            //GetComponent<Rigidbody>().AddForce(-transform.forward * DeltaSpeed);
            //m_Rigidbody.velocity = -transform.forward * Speed;
            t = 1;
        }

        Vector3 CurrentSpeed = GetComponent<Rigidbody>().velocity;
        Vector3 MaxSpeed = Speed * t * Vector3.forward;

        GetComponent<Rigidbody>().AddForce(MaxSpeed - CurrentSpeed);
        /*
        float Xaxis = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0, Xaxis * DeltaRot, 0));

        float Yaxis = Input.GetAxis("Mouse Y");
        Camera.main.transform.Rotate(new Vector3(-Yaxis * DeltaRot, 0, 0));

        Vector3 rot = Camera.main.transform.eulerAngles;
        float x = rot.x;
        x = Mathf.Clamp(x, -XangleMax, XangleMax);
        rot.x = x;

        Camera.main.transform.eulerAngles = rot;

    */

        int u = 0;



        if (Input.GetKey(KeyCode.D))
        {
            //transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * Speed, Space.World);
            //transform.Rotate(new Vector3(0, DeltaRot, 0));
            u = -1;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            //transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * Speed, Space.World);
            //transform.Rotate(new Vector3(0, -DeltaRot, 0));
            u = 1;
        }
        Vector3 CurrentSpeedu = GetComponent<Rigidbody>().velocity;
        Vector3 MaxSpeedu = Speed * u * Vector3.right;

        GetComponent<Rigidbody>().AddForce(MaxSpeedu - CurrentSpeedu);


        if (Input.GetKeyDown(KeyCode.Space) && NbColliderInTrigger > 0)
        {
            Debug.Log("Nombre de collider trigger" + NbColliderInTrigger);
            GetComponent<Rigidbody>().AddForce(new Vector3(0, JumpForce, 0));
        }
       






    }
}
