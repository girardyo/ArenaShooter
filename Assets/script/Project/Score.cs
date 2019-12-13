using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{

    private int Scoreint=0;
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<TextMeshProUGUI>().text = "Score : " + Scoreint;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreUpdate(int num)
    {
        Scoreint += num;
        Debug.Log(Scoreint);
        GetComponent<TextMeshProUGUI>().text = "Score : " + Scoreint;
    }

}
