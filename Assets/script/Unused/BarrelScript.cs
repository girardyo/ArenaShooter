using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelScript : MonoBehaviour
{
    public GameObject PrefabExplosion;
    private float t;
    private bool timerBool = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            timerBool = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerBool == true)
        {
            t += Time.deltaTime;
        }

        if (t > 1)
        {
            gameObject.GetComponent<SphereCollider>().radius = 4.5f;
            Destroy(gameObject, 0.1f);
            GameObject explo = Instantiate(PrefabExplosion);
            explo.transform.position = gameObject.transform.position;
            Destroy(explo, 2);
        }

    }
}
