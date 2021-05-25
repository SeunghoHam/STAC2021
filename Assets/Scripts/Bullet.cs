using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 1f;
    void Start()
    {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.AddRelativeForce(new Vector2(-1, 0.8f) * bulletSpeed, ForceMode2D.Impulse);
        Invoke("DestroyBullet", 1f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            //this.gameObject.SetActive(false);
            DestroyBullet();
        }
    }

    private void DestroyBullet()
    {
        ObjectPool.ReturnObject(this);
    }
}