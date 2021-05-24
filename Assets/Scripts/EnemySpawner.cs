using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("prefab")]
    [SerializeField] private GameObject prefabEnemy;
    [SerializeField] private GameObject[] enemySpawnPoint;

    [Header("Reference")]
    [SerializeField] private float enemySpeed;

    void EnemySpawn()
    {
         Debug.Log("EnemySpawn");
        GameObject Enemy = Instantiate(prefabEnemy, this.transform.position, this.transform.rotation);
        Rigidbody2D rigid = Enemy.GetComponent<Rigidbody2D>();
        
        rigid.AddRelativeForce(new Vector2(0, 1) * enemySpeed , ForceMode2D.Impulse);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
