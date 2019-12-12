using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeParent : MonoBehaviour
{
    [SerializeField]
    private GameObject[] ListObjects;


    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject g in ListObjects)
        {
            g.transform.SetParent(transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
