using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JumpTriggerScript : MonoBehaviour
{
    public float JumpPower = 1000;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, JumpPower, 0));
        }
    }

}

