using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RebootLevel : MonoBehaviour
{
    GameObject g;
    private bool isWave5=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            g = GameObject.FindGameObjectWithTag("Player");

            if (g.GetComponent<PlayerLifeScript>().getIsPlayerDead())
            {
                string currentSceneName = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(currentSceneName);
            }
            if (isWave5)
            {
                string currentSceneName = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(currentSceneName);
            }


        }
    }

    public void setIsWave(bool Bool)
    {
        isWave5 = Bool;
    }
}
