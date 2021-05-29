using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("prefab")]
    [SerializeField] private GameObject prefabEnemy;
    [SerializeField] private GameObject[] enemySpawnPoint;

    [Header("SpawnTimeSetting")]
    [SerializeField] private float maxSpawnDelay = 3f;
    [SerializeField] private float curSpawnDelay = 0.1f;

    
    void Start()
    {

    }
    void Update()
    {
        EnemySpawn();
        SpawnDelay();
    }
    private void EnemySpawn()
    {
        if(curSpawnDelay < maxSpawnDelay)
            return;
        if (curSpawnDelay > maxSpawnDelay)
        {
                RandomSpawn();
            for(int i=0; i < enemySpawnPoint.Length; i++)
            {
                //GameObject Enemy = Instantiate(prefabEnemy, enemySpawnPoint[i].transform.position, enemySpawnPoint[i].transform.rotation);       
            }
           
        }

        curSpawnDelay = 0f;
    }

    private void RandomSpawn()
    {
        int m_random = Random.Range(0,2); 

        if(m_random == 0)
        {
            Debug.Log("냥냥0");
            GameObject Enemy = Instantiate(prefabEnemy, enemySpawnPoint[0].transform.position, enemySpawnPoint[0].transform.rotation);
        }
        else if(m_random == 1)
        {
            Debug.Log("냥냥1");
            GameObject Enemy = Instantiate(prefabEnemy, enemySpawnPoint[1].transform.position, enemySpawnPoint[1].transform.rotation);
        }
        //else if(m_random == 2)
        //{
        //   Debug.Log("냥냥2");
        //    GameObject Enemy = Instantiate(prefabEnemy, enemySpawnPoint[2].transform.position, enemySpawnPoint[2].transform.rotation);
        //}

              
    }
    void SpawnDelay()
    {
        curSpawnDelay += Time.deltaTime;
    }

}
