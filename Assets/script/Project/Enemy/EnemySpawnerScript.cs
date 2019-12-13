using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public GameObject EnemyPrefab2;
    public GameObject EnemyPrefab3;
    public Canvas canvas;

    public List<GameObject> EnemyList = new List<GameObject>();
    public TextMeshProUGUI vague;
    private float t = 0;
    // Update is called once per frame
    private int round;
    private int compteur=0;
    private int maxEnemy;
    private bool BossSpawn;
    private float speedSpawn;
    private void Start()
    {
        round = 1;
        vague.text = "Vague : " + round;
    }

    void Update()
    {
        switch (round)
        {
            case 1:
                speedSpawn = 1;
                maxEnemy = 10;
                SpawnEnemy();
                break;
            case 2:
                speedSpawn = 0.5f;
                maxEnemy = 20;
                SpawnEnemy();
                break;

            case 3:
                speedSpawn = 0.5f;
                maxEnemy = 40;
                SpawnEnemy();
                break;

            case 4:
                speedSpawn = 0.40f;
                maxEnemy = 80;
                SpawnEnemy();
                break;

            case 5:
                speedSpawn = 0.25f;
                maxEnemy = 160;
                SpawnEnemy();
                break;


            default:
                break;
        }  

    }

    public List<GameObject> GetListEnemy()
    {
        return EnemyList;
    }

    public void SetListEnemy(List<GameObject> newEnemyList)
    {
        EnemyList = newEnemyList;
    }

    public void SpawnEnemy()
    {
        Debug.Log(compteur);
        t += Time.deltaTime;
        if (t > speedSpawn && compteur<maxEnemy)
        {
            compteur++;

            GameObject g;

            int randomEnemy = Random.Range(0, 2);
            if (randomEnemy == 0)
            {
                g = Instantiate(EnemyPrefab);
                g.gameObject.name = "Enemy" + compteur;
                EnemyList.Add(g);

            }
            else
            {
                g = Instantiate(EnemyPrefab2);
                g.gameObject.name = "Enemy" + compteur;
                EnemyList.Add(g);


            }
            int RandomSpawn = Random.Range(0, 4);
            Debug.Log(RandomSpawn);
            g.transform.position = transform.GetChild(RandomSpawn).position;

            //g.transform.position = new Vector3(Random.Range(-20, 20), 1.05f, Random.Range(-20, 20));
            //gtransform.position = new Vector3(0, 10, 0);
            t = 0;
        }
        if (compteur < 1 && round == 5 && BossSpawn==false)
        {
            GameObject g;

            g = Instantiate(EnemyPrefab3);
            g.gameObject.name = "Boss" + compteur;
            EnemyList.Add(g);
            g.transform.position = transform.GetChild(8).position;
            BossSpawn = true;
        }
        if (compteur ==maxEnemy&& EnemyList.Count == 0)
        {
            if (round == 5)
            {
                canvas.GetComponent<Canvas>().enabled = true;
                canvas.GetComponent<RebootLevel>().setIsWave(true);
            }
            compteur = 0;
            round ++;
            vague.text = "Vague : " + round;

        }
    }




}
