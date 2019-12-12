using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelTriggerScript : MonoBehaviour
{
    public int Puissance = 1500;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Enemy")
        {
            //Vector3 dir = collision.gameObject.transform.position = gameObject.transform.position;
            //other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, JumpPower, 0));
            Vector3 dir = other.gameObject.transform.position - gameObject.transform.position;
            other.gameObject.GetComponent<Rigidbody>().AddForce(dir * Puissance);
            //Destroy(other.gameObject);
        }

    }
}
