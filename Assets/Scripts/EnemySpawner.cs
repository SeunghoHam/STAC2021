using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("prefab")]
    [SerializeField] private GameObject prefabEnemy;
    [SerializeField] private GameObject[] enemySpawnPoint;

    [Header("SpawnTimeSetting")]
    [SerializeField] private float maxSpawnDelay = 1f;
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
            //Debug.Log("EnemySpawn");
            for(int i=0; i < enemySpawnPoint.Length; i++)
            {
                GameObject Enemy = Instantiate(prefabEnemy, enemySpawnPoint[i].transform.position, enemySpawnPoint[i].transform.rotation);
                
            }
           
        }

        curSpawnDelay = 0f;
    }
    void SpawnDelay()
    {
        curSpawnDelay += Time.deltaTime;
    }

}
