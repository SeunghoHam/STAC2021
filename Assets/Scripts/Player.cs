using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    StatusManager theStatusMgr;
    private void Start()
    {
        theStatusMgr = FindObjectOfType<StatusManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            //theStatusMgr.DecreaseHP(1);
            Debug.Log("test");

        }
    }
}
