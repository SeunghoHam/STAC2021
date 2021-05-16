using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [Header("회전각 - 건들지마셈")]
    public float baseAngle = 0.0f;

    [SerializeField] public GameObject Bullet;
    [SerializeField] public Transform angle3;

    public float bulletSpeed = 3.0f;
    [SerializeField] private Transform ShootPoint;

    [SerializeField] private bool canShoot = false;

    [SerializeField] private bool Rotating = false;
    [SerializeField] Animator camAnim;
    private void OnMouseDown()
    {
        
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        pos = Input.mousePosition - pos;
        baseAngle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
        baseAngle -= Mathf.Atan2(transform.right.y, transform.right.x) * Mathf.Rad2Deg;
        canShoot = true;
    }

    private void OnMouseDrag()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        pos = Input.mousePosition - pos;
        float angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg - baseAngle;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);   
    }

    void SetRotateZ()
    { 
        if(gameObject.transform.rotation.z >= 0.02)
        {
            
        }
    }
    void Shoot()
    {
        Debug.Log("촣알발싸");
        GameObject Bullets = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
        Bullets.GetComponent<Rigidbody2D>().AddForce(Bullets.transform.forward * bulletSpeed);
    }
    private void Update()
    {
        Debug.Log(angle3.transform.rotation.z);
        //Debug.Log(baseAngle);
        if(gameObject.transform.rotation.z >= -90  && gameObject.transform.rotation.z <= 0)
        {
            //gameObject.transform.localEulerAngles = new Vector3(0, 0, -45);
        }
        // 드래그 해제 할 때 카메라 쉐이킹
        if(Input.GetMouseButtonUp(0))
        {
            camAnim.SetTrigger("shake");
            canShoot = false;
        }

        if( canShoot &&Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
}
