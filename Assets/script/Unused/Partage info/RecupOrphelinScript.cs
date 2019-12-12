using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecupOrphelinScript : MonoBehaviour
{
    [SerializeField]
    private GameObject gameobject;


    // Start is called before the first frame update
    void Start()
    {
        GameObject obj1 = GameObject.Find("Objet1");
        GameObject[] Enemys = GameObject.FindGameObjectsWithTag("Enemy");

        Debug.Log(gameobject.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
