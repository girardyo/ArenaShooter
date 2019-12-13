using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
   [SerializeField]
    private int Damage;
    [SerializeField]
    private GameObject g;
    private bool disableCollider=true;
    private void Start()
    {
    }

    private void Update()
    {
        if (g.GetComponent<EnemyLife>().CurrentLife <= 0)
        {
            if (disableCollider)
            {
                Debug.Log("VASE MORT");
                Destroy(gameObject);
                //GetComponent<BoxCollider>().enabled = false;
                //gameObject.GetComponent<BoxCollider>().size = new Vector3(0, 0, 0);
                disableCollider = false;
            }

        }


    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("DEGATS " + Damage);
            other.gameObject.GetComponent<LifeScript>().UpdateLife(-Damage);
        }
    }
}
