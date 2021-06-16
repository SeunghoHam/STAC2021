using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_BonusScore : MonoBehaviour
{
    private float itemSpeed = 120f;

    StatusManager theStatusMgr;
    ScoreManager theScoreMgr;
    void Start()
    {
        theStatusMgr = FindObjectOfType<StatusManager>();
        theScoreMgr = FindObjectOfType<ScoreManager>();

        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.AddRelativeForce(new Vector2(0,1) * itemSpeed* Time.deltaTime, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            StartCoroutine(Destroy());
            //theStatusMgr.DecreaseHP(1);
            
            
        }
        else if(other.tag == "Player")
        {
            StartCoroutine(Destroy());
            theScoreMgr.IncreaseScore(10);
        }
    }

    IEnumerator Destroy()
    {
        Destroy(gameObject);
        yield return null;
    }
}
