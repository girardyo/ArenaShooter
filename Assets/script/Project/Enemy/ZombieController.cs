using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
 
    GameObject g;
    [SerializeField]
    private int Damage;
    public float t;
    public bool attacked=false;

    private bool CanDamage = false;
    // Start is called before the first frame update
    void Start()
    {
        g = GameObject.FindGameObjectWithTag("Player");
        //GetComponent<NavMeshAgent>().SetDestination(Target.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<NavMeshAgent>().isActiveAndEnabled)
        {
            float Speed = Vector3.Magnitude(GetComponent<NavMeshAgent>().velocity);
            GetComponentInChildren<Animator>().SetFloat("Speed", Speed);

            if (GetComponent<NavMeshAgent>().remainingDistance < 3 && GetComponent<NavMeshAgent>().remainingDistance > 0)
            {

                if (attacked == false)
                {
                    GetComponentInChildren<Animator>().SetTrigger("Attack");
                    CanDamage = true;
                    GetComponent<CapsuleCollider>().enabled = true;
                    attacked = true;
                }

            }
            else
            {
                GetComponent<CapsuleCollider>().enabled = false;
            }

            GotoTarget();
        }

        if (attacked == true)
        {
            t += Time.deltaTime;
            if (t > 1.5f)
            {
                attacked = false;
                t = 0;
            }
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && CanDamage)
        {
            Debug.Log("DEGATS " + Damage);
            other.gameObject.GetComponent<LifeScript>().UpdateLife(-Damage);
            CanDamage = false;
        }
    }

    private void GotoTarget()
    {
        if (g)
            GetComponent<NavMeshAgent>().SetDestination(g.transform.position);
    }


}
