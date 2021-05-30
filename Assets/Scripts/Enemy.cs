using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float enemyspeed = 0.5f;

    StatusManager theStatusMgr;
    ScoreManager theScoreMgr;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            //Debug.Log(" Enemy & Bullet");
            StartCoroutine(Destroy());
            theScoreMgr.IncreaseScore(1);
            
        }
        else if(other.tag == "Player")
        {
            Debug.Log(" 적, 캐릭터 충돌");
            StartCoroutine(Destroy());
            theStatusMgr.DecreaseHP(1);
        }
    }
    IEnumerator Destroy()
    {
        this.gameObject.SetActive(false);
        yield return null;
    }
    void Start()
    {
        theStatusMgr = FindObjectOfType<StatusManager>();
        theScoreMgr = FindObjectOfType<ScoreManager>();

        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.AddRelativeForce(new Vector2(0,1) * enemyspeed, ForceMode2D.Impulse);
    }
}
