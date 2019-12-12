using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SamouraiControllerScript : MonoBehaviour
{
    //[SerializeField]
    // private Transform Target;
    GameObject g;





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

            if (GetComponent<NavMeshAgent>().remainingDistance < 2)
            {
                GetComponentInChildren<Animator>().SetTrigger("Attack");
            }

            GotoTarget();
        }
    }

    private void GotoTarget()
    {
        if(g)
            GetComponent<NavMeshAgent>().SetDestination(g.transform.position);
    }
}
