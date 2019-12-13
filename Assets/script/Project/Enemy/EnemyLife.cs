using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyLife : LifeScript
{
    bool Scoreadded = false;
    [SerializeField]
    GameObject WeaponSpawn1;
    [SerializeField]
    GameObject WeaponSpawn2;
    [SerializeField]
    GameObject WeaponSpawn3;
    public Image LifeBar;
    private bool lifebarbool=false;

    public List<GameObject> EnemyList = new List<GameObject>();
    GameObject g;
    // Start is called before the first frame update
    void Start()
    {
        g = GameObject.FindGameObjectWithTag("Respawn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Death()
    {


        Destroy(LifeBar.gameObject.transform.parent.gameObject);
        gameObject.tag = "Untagged";

        EnemyList = g.GetComponent<EnemySpawnerScript>().GetListEnemy();
        Debug.Log("Enemy Index "+EnemyList.IndexOf(gameObject));
        EnemyList.Remove(gameObject);
        Debug.Log("Count enemy" +EnemyList.Count);

        g.GetComponent<EnemySpawnerScript>().SetListEnemy(EnemyList);
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;

        Destroy(GetComponent<Rigidbody>());

        GetComponentInChildren<Animator>().SetTrigger("isDead");
        GetComponent<NavMeshAgent>().speed = 0;
        //Destroy(gameObject, 2);
        if (Scoreadded == false)
        {
            GameObject g = GameObject.FindGameObjectWithTag("Score");
            g.GetComponent<Score>().ScoreUpdate(25);
            Scoreadded = true;

            int RandomSpawn = Random.Range(0, 10);
            Debug.Log(RandomSpawn);
            if (RandomSpawn == 4)
            {
                int RandomWeapon = Random.Range(0, 3);
                Debug.Log(RandomWeapon);
                if (RandomWeapon == 0)
                {
                    GameObject weaponSpawn1 = Instantiate(WeaponSpawn1);
                    weaponSpawn1.transform.position = transform.position + new Vector3(0, 2.09f, 0);
                }

                if (RandomWeapon == 1)
                {
                    GameObject weaponSpawn2 = Instantiate(WeaponSpawn2);
                    weaponSpawn2.transform.position = transform.position + new Vector3(0, 2.09f, 0);
                }

                if (RandomWeapon == 2)
                {
                    GameObject weaponSpawn3 = Instantiate(WeaponSpawn3);
                    weaponSpawn3.transform.position = transform.position + new Vector3(0, 2.09f, 0);
                }
            }
        }
    }

    public override void End()
    {

    }

    public override void UpdateLife(int nb)
    {
        base.UpdateLife(nb);
        if (lifebarbool == false)
        {
            gameObject.transform.GetChild(0).GetComponent<Canvas>().enabled = true;
            lifebarbool = true;
        }
        //        LifeBar.transform.localScale = new Vector3((float)CurrentLife / (float)MaxLife, 1, 1);
        LifeBar.fillAmount = (float)CurrentLife / (float)MaxLife;

        if (CurrentLife == 0)
        {
            //Debug.Log("allo : " + LifeBar.fillAmount);
            Destroy(LifeBar.gameObject.transform.parent.gameObject);
        }
    }

    
}
