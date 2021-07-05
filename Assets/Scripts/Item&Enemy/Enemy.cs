using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float enemySpeed = 1f;

    //[SerializeField] public ParticleSystem collisionParticle;
    StatusManager theStatusMgr;
    ScoreManager theScoreMgr;
    private float time =0;
    private float _fadeTime =1f;

    void Start()
    {
        theStatusMgr = FindObjectOfType<StatusManager>();
        theScoreMgr = FindObjectOfType<ScoreManager>();

        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.AddRelativeForce(new Vector2(0,1) * enemySpeed, ForceMode2D.Impulse);
    }
    public void OntriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Bullet")
        {
            theScoreMgr.IncreaseScore(1);
            StartCoroutine(Destroy());
        }    
        
        if(other.tag == "Player")
        { 
            theStatusMgr.DecreaseHP(1);
            StartCoroutine(Destroy());
        }

    }
    IEnumerator Destroy()
    {

        //GetComponent<SpriteRenderer>().color = new Color(1,1,1,1f - time/_fadeTime);
       Destroy(gameObject);

        yield return null;
    }

}
