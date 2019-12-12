using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScriptMG : MonoBehaviour
{

    public float timer = 0;

    public GameObject Balle;
    [SerializeField]
    private float Power;

    [SerializeField]
    private Transform Spawn;
    private int Ammo;
    GameObject g;
    // Start is called before the first frame update
    void Start()
    {
        g = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        Ammo = g.GetComponent<WeaponController>().GetAmmoMG42();

        if (Input.GetMouseButton(0) && Ammo > 0)
        {
            timer += Time.deltaTime;

            if (timer > 0.1f)
            {
                g.GetComponent<WeaponController>().SetAmmoMG42(-1);
                GameObject balle = Instantiate(Balle);
                balle.transform.position = Spawn.transform.position;
                balle.transform.rotation = Spawn.transform.rotation;
                balle.GetComponent<Rigidbody>().AddForce(Spawn.forward * Power);
                Debug.Log("Shoot");
                timer = 0;
            }

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
    public void ActivateWeapon(bool Bool)
    {
        transform.gameObject.SetActive(Bool);
        Debug.Log("ACTIVATION");
    }


}
