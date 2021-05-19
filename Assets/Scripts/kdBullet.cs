using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kdBullet : MonoBehaviour
{
    Rigidbody2D m_myRigid= null;

    private void OnEnable() 
    {
        if(m_myRigid == null)
        {
            m_myRigid = GetComponent<Rigidbody2D>();
        }    
        m_myRigid.velocity = Vector2.zero; 
        m_myRigid.AddForce(gameObject.transform.forward * 3f);
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(1f);
        //Destroy(gameObject);
        kdObjectPoolingManager.instance.InsertQueue(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
