using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmunationUI : MonoBehaviour
{

    private int AmmoInt;
    // Start is called before the first frame update
    void Start()
    {
       // GetComponent<TextMeshProUGUI>().text = "Score : " + AmmoInt;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetAmmunation()
    {
        AmmoInt = 0;
    }

    public void AmmunationUpdate(int num)
    {
       // Debug.Log(AmmoInt);
        GetComponent<TextMeshProUGUI>().text = ""+num;

    }


}
