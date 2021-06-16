using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("prefab")]
    [SerializeField] private GameObject prefabEnemy;
    [SerializeField] private GameObject prefabItem_BonusScore;



    [SerializeField] private GameObject[] SpawnPoint;


    [Header("SpawnTimeSetting")]
    [SerializeField] private float maxSpawnDelay = 1.5f;
    [SerializeField] private float curSpawnDelay = 0f;

    
    void Start()
    {

    }
    void Update()
    {
        Spawn();
        SpawnDelay();
    }
    private void Spawn()
    {
        if(curSpawnDelay < maxSpawnDelay)
            return;
        if (curSpawnDelay > maxSpawnDelay)
        {
                RandomSpawn();
        }
        curSpawnDelay = 0f;
    }

    private void RandomSpawn()
    {
        int m_spawnpoint_Random = Random.Range(0,3); // Random.Range : Left = Include , Right = Exclusive
        int m_object_Random = Random.Range(0,2);
        Debug.Log(m_spawnpoint_Random);

        if(m_spawnpoint_Random == 0) // SpawnpointArray_Buttom Spawn
        {
            
            if(m_object_Random == 0)
            {
                GameObject Enemy = Instantiate(prefabEnemy, SpawnPoint[0].transform.position, SpawnPoint[0].transform.rotation);
            }
            else if(m_object_Random == 1)
            {
                GameObject bonusScore = Instantiate(prefabItem_BonusScore,SpawnPoint[0].transform.position, SpawnPoint[0].transform.rotation);
            }  
        }
        else if(m_spawnpoint_Random == 1)
        {
            if(m_object_Random == 0)
            {
                GameObject Enemy = Instantiate(prefabEnemy, SpawnPoint[1].transform.position, SpawnPoint[1].transform.rotation);
            }
            else if(m_object_Random == 1)
            {
                GameObject bonusScore = Instantiate(prefabItem_BonusScore,SpawnPoint[1].transform.position, SpawnPoint[1].transform.rotation);
            }  
        }
        else if(m_spawnpoint_Random == 2)
        {
            if(m_object_Random == 0)
            {
                GameObject Enemy = Instantiate(prefabEnemy, SpawnPoint[2].transform.position, SpawnPoint[2].transform.rotation);
            }
            else if(m_object_Random == 1)
            {
                GameObject bonusScore = Instantiate(prefabItem_BonusScore,SpawnPoint[2].transform.position, SpawnPoint[2].transform.rotation);
            }  
        }

              
    }
    private void SpawnDelay()
    {
        curSpawnDelay += Time.deltaTime;
    }

}
