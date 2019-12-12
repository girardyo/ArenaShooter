using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMoveScript : MonoBehaviour
{
    public Transform StartPos, EndPos;
    [SerializeField]
    [Range(0,1)]
    private float t;

    [SerializeField]
    private AnimationCurve Curve;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float p = Mathf.PingPong(Time.time,1);
        float c = Curve.Evaluate(Time.time);
        //float s = (Mathf.Sin(Time.time) + 1) / 2;
        transform.position = Vector3.Lerp(StartPos.position, EndPos.position, c);
        GetComponent<MeshRenderer>().material.color = Color.Lerp(Color.blue, Color.magenta, c);
    }
}
