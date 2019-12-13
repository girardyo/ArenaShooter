using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathfindingAgentScript : MonoBehaviour
{
    [SerializeField]
    private Transform[] Target;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<NavMeshAgent>().SetDestination(Target.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<NavMeshAgent>().remainingDistance < 3)
            GotoTarget();
    }

    private void GotoTarget()
    {
        GetComponent<NavMeshAgent>().SetDestination(Target[Random.Range(0, Target.Length)].position);
    }
}
