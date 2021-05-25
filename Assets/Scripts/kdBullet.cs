using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kdBullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 2f;
    Rigidbody2D rigid= null;

    private void OnEnable() 
    {
        if(rigid == null)
        {
            rigid = GetComponent<Rigidbody2D>();
        }    
        rigid.velocity = Vector2.zero; 
        //m_myRigid.AddForce(gameObject.transform.forward * 3f);
        rigid.AddRelativeForce(new Vector2(-1, 0.8f) * bulletSpeed, ForceMode2D.Impulse);
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(0.5f);
        //Destroy(gameObject);
        kdObjectPoolingManager.instance.InsertQueue(gameObject);
    }
    
}
