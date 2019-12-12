using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyLifeScript : LifeScript
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Death()
    {
        GetComponentInChildren<Animator>().SetTrigger("isDead");
        GetComponent<NavMeshAgent>().speed = 0;
    }

    public override void End()
    {
        Destroy(gameObject);
    }

}
