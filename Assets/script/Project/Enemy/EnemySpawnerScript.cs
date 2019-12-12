using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject EnemyPrefab;
    private float t = 0;
    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t>1)
        {
            GameObject g = Instantiate(EnemyPrefab);
            int RandomSpawn = Random.Range(0, 4);
            Debug.Log(RandomSpawn);
            g.transform.position = transform.GetChild(RandomSpawn).position;

            //g.transform.position = new Vector3(Random.Range(-20, 20), 1.05f, Random.Range(-20, 20));
            //gtransform.position = new Vector3(0, 10, 0);
            t = 0;
        }
    }
}
