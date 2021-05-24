using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletSpeed = 5f;
    void Start() 
    {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();    
        rigid.AddRelativeForce(new Vector2(-1, 0.8f) * bulletSpeed, ForceMode2D.Impulse);
    }
}
