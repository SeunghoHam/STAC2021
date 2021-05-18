using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [Header("do not touch")]
    public float baseAngle = 0.0f;

    [Header("Check")]
    [SerializeField] private bool bulletShooting = false;
    [SerializeField] private bool mouseClick = false;

    [SerializeField] public Transform angle3; // Triangle Object position
    [SerializeField] public GameObject Bullet; // Bullet GameObject
    [SerializeField] private Transform ShootPoint; // ShootPoint = RotatingObject
    
    [SerializeField] Animator camAnim;


    [SerializeField] GameObject testImage;
    public float bulletSpeed = 3.0f;
    private void OnMouseDown()
    {
        mouseClick = true;
        bulletShooting = true;
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        pos = Input.mousePosition - pos;
        baseAngle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
        baseAngle -= Mathf.Atan2(transform.right.y, transform.right.x) * Mathf.Rad2Deg;
    }

    private void OnMouseDrag()
    {
        mouseClick = false;
        bulletShooting = false;
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        pos = Input.mousePosition - pos;
        float angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg - baseAngle;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void Shoot()
    {
        
        GameObject Bullets = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
        //Bullets.GetComponent<Rigidbody2D>().AddForce(Bullets.transform.forward * bulletSpeed);

    }
    void SetRotateZ()
    {
        if (gameObject.transform.rotation.z >= -0.3)
        {
            transform.Rotate(0, 0, -40);
            testImage.SetActive(false);
        }
    }

    private void Start()
    {
        testImage.SetActive(false);
    }
    private void Update()
    {
        //Debug.Log(angle3.transform.rotation.z);
        //Debug.Log(baseAngle);
        if (gameObject.transform.rotation.z >= -90 && gameObject.transform.rotation.z <= 0)
        {
            //gameObject.transform.localEulerAngles = new Vector3(0, 0, -45);
        }

        if (Input.GetMouseButtonDown(0))
        {

        }

        if(Input.GetMouseButtonUp(0))
        {
            camAnim.SetTrigger("shake");
        }
        if (mouseClick && Input.GetMouseButtonUp(0))
        {
            Shoot();
        }


    }
}
