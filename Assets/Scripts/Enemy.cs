using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float enemyspeed = 0.5f;

    [SerializeField] public ParticleSystem collisionParticle;
    StatusManager theStatusMgr;
    ScoreManager theScoreMgr;
    private float time =0;
    private float _fadeTime =1f;

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

        //GetComponent<SpriteRenderer>().color = new Color(1,1,1,1f - time/_fadeTime);
       Destroy(gameObject);

        yield return null;
    }
    void Start()
    {
        theStatusMgr = FindObjectOfType<StatusManager>();
        theScoreMgr = FindObjectOfType<ScoreManager>();

        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.AddRelativeForce(new Vector2(0,1) * enemyspeed, ForceMode2D.Impulse);
    }
    void Update() 
    {
       
        time += Time.deltaTime;
    }
    
}
