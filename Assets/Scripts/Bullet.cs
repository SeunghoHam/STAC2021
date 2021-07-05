using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 1f;
    void Start()
    {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.AddRelativeForce(new Vector2(-1f,0.5f) * bulletSpeed, ForceMode2D.Impulse);
        transform.Rotate(0,0,60f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy" || other.tag == "ItemScore")
        {
            StartCoroutine(DestoryBullet());
        }


    }


    IEnumerator DestoryBullet()
    {
        Destroy(gameObject);
        yield return null;
    }
}