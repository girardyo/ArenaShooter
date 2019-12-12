using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeRewind : MonoBehaviour
{
    public List<Vector3> ObjInTriggerPos = new List<Vector3>();
    public List<Quaternion> ObjInTriggerRotation = new List<Quaternion>();

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = GetComponent<Transform>().position;
        Quaternion rotation = GetComponent<Transform>().rotation;



        if (Input.GetKey(KeyCode.R)&& ObjInTriggerPos.Count>0)
        {
            transform.position = ObjInTriggerPos[ObjInTriggerPos.Count - 1];
            transform.rotation = ObjInTriggerRotation[ObjInTriggerRotation.Count - 1];

            ObjInTriggerPos.RemoveAt(ObjInTriggerPos.Count - 1);
            ObjInTriggerRotation.RemoveAt(ObjInTriggerRotation.Count - 1);

        }
        else
        {
            ObjInTriggerPos.Add(pos);
            ObjInTriggerRotation.Add(rotation);
        }

    }
}
