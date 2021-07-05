using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_BonusScore : MonoBehaviour
{
    private float itemSpeed = 1f;

    StatusManager theStatusMgr;
    ScoreManager theScoreMgr;
    void Start()
    {
        theStatusMgr = FindObjectOfType<StatusManager>();
        theScoreMgr = FindObjectOfType<ScoreManager>();

        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.AddRelativeForce(new Vector2(0,1) * itemSpeed, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {   
        if(other.tag == "Player") 
        {
            theScoreMgr.IncreaseScore(10);
            StartCoroutine(Destroy());
        }

        if(other.tag == "Bullet")
        {
            StartCoroutine(Destroy());
        }
       
    }

    IEnumerator Destroy()
    {
        Destroy(gameObject);
        yield return null;
    }
}
