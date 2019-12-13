using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastControllerScript : MonoBehaviour
{

    [SerializeField]
    private GameObject Target;

    //private GameObject PrefabExplo;


    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            float x = hit.point.x;
            float z = hit.point.z;
            Target.GetComponent<Transform>().position = new Vector3(x, (float)1.05, z);
            //GameObject Explo = Instantiate(PrefabExplo);
            //Explo.transform.position = hit.point;
            //Destroy(Explo, 2)
        }/*
        if (Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Target.GetComponent<Transform>().position = hit.point;
                //GameObject Explo = Instantiate(PrefabExplo);
                //Explo.transform.position = hit.point;
                //Destroy(Explo, 2)
            }
        }*/
    }
}
