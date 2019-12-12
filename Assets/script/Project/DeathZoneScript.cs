using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneScript : MonoBehaviour
{
    public Transform RespawnPos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = RespawnPos.position;
        }
    }
}
