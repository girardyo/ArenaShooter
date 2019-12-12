using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class CanvasScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Text;

    public void AfficherCoucou()
    {
        Text.text = "Coucou";
    }


}
