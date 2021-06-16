using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float enemySpeed = 120f;

    [SerializeField] public ParticleSystem collisionParticle;
    StatusManager theStatusMgr;
    ScoreManager theScoreMgr;
    private float time =0;
    private float _fadeTime =1f;

    void Start()
    {
        theStatusMgr = FindObjectOfType<StatusManager>();
        theScoreMgr = FindObjectOfType<ScoreManager>();

        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.AddRelativeForce(new Vector2(0,1) * enemySpeed*Time.deltaTime, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            StartCoroutine(Destroy());
            theScoreMgr.IncreaseScore(1);
            
        }
        else if(other.tag == "Player")
        {
            StartCoroutine(Destroy());
            theStatusMgr.DecreaseHP(1);
        }
    }
    IEnumerator Destroy()
    {

        //GetComponent<SpriteRenderer>().color = new Color(1,1,1,1f - time/_fadeTime);
       Destroy(gameObject);

        yield return null;
    }

}
