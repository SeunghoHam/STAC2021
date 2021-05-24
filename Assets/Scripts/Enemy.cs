using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            Debug.Log(" Enemy & Bullet");
        }
        if(other.tag == "Player")
        {
            Debug.Log(" Enemy & Player");
        }
    }
    void Update()
    {

    }
}
