using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float enemyspeed = 1f;

    StatusManager theStatusMgr; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            Debug.Log(" Enemy & Bullet");
            StartCoroutine(Destroy());
            
        }
        if(other.tag == "Player")
        {
            Debug.Log(" Enemy & Player");
        }
    }
    IEnumerator Destroy()
    {
        this.gameObject.SetActive(false);
        yield return null;
    }
    void Start()
    {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.AddRelativeForce(new Vector2(1f, -0.8f) * enemyspeed, ForceMode2D.Impulse);
    }
}
