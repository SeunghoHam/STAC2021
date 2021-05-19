using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 direction;
    public void Shoot(Vector2 direction)
    {
        this.direction= direction;
        //Invoke("DestroyBullet", 1f);
        StartCoroutine(DestroyBullet());
    }
    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(1f);
        BulletPoolingManager.ReturnObject(this);
    }

    void Update() 
    {
        transform.Translate(direction);    
    }
    /*
    Rigidbody2D m_myRigid = null;
    [SerializeField] private float bulletSpeed = 3f;
    private void OnEnable() 
    {
        if(m_myRigid == null)
        {
            m_myRigid =GetComponent<Rigidbody2D>();
        }    
        m_myRigid.velocity= Vector3.zero;
        //Bullets.GetComponent<Rigidbody2D>().AddForce(Bullets.transform.forward * bulletSpeed);
        m_myRigid.AddForce(gameObject.transform.forward * bulletSpeed); 
        
    }
    void Start()
    {
        StartCoroutine(destroyBullet());
    }
    void Update() {
        
    }
    // Update is called once per frame
    IEnumerator destroyBullet()
    {
        yield return new WaitForSeconds(1f);
        //BulletPoolingManager.instance.InsertQueue(gameObject);
    }
}*/
}
