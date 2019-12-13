using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScriptGrenade : MonoBehaviour
{

    public GameObject Balle;
    [SerializeField]
    private float Power;

    [SerializeField]
    private Transform Spawn;
    GameObject g;
    private int Ammo;
    // Start is called before the first frame update
    void Start()
    {
        g = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ammo = g.GetComponent<WeaponController>().GetAmmoGrenade();
        if (Input.GetMouseButtonDown(0) && Ammo > 0)
        {
            g.GetComponent<WeaponController>().SetAmmoGrenade(-1);
            GameObject balle = Instantiate(Balle);
            balle.transform.position = Spawn.transform.position;
            balle.transform.rotation = Spawn.transform.rotation;

            balle.GetComponent<Rigidbody>().AddForce(Spawn.forward * Power);
            Debug.Log("Shoot");
        }
    }


    public void ActivateWeapon(bool Bool)
    {
        transform.gameObject.SetActive(Bool);
        Debug.Log("ACTIVATION");
    }


}
