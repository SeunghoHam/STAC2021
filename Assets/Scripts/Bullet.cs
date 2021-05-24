using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    ScoreManager theScoreMgr;
    public void checkCollision()
    {
        Debug.Log("Collision");
    }
    void Start()
    {
        theScoreMgr = FindObjectOfType<ScoreManager>();    
    }
    void Update() 
    {
        checkCollision();
    }

}
