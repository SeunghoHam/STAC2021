using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    StatusManager theStatusMgr;
    ScoreManager theScoreMgr;
    private void Start()
    {
        theStatusMgr = FindObjectOfType<StatusManager>();
        theScoreMgr = FindObjectOfType<ScoreManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

    }
}
