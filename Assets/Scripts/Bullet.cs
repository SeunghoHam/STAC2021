using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Awake() 
    {
        //http://devkorea.co.kr/bbs/board.php?bo_table=m03_qna&wr_id=76571
    }
    void OnEnable() 
    {
        Rotate rotate = GetComponent<Rotate>();
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        //rigid.AddRelativeForce(0,);
    }
    void Start() 
    {
        
    }
}
