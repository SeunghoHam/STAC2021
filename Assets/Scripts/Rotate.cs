using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotate : MonoBehaviour
{
    [Header("Check")]
    [SerializeField] private bool mouseDrag; // if Mouse Drag
    [SerializeField] private bool isButtonDown; // if Mouse Click
    [SerializeField] private bool isShootButtonDown;
    [SerializeField] private float baseAngle = 0.0f;
    [SerializeField] public int Direction = 0;

    [Header("Reference")]
    [SerializeField] private Transform angle3; // Triangle Object position

    [SerializeField] private Transform ShootPoint; // ShootPoint = RotatingObject
    [SerializeField] Animator camAnim; // CameraAnimator
    [SerializeField] GameObject testImage;

    [SerializeField] private float maxShootDelay = 3.0f;
    [SerializeField] private float curShootDelay = 0.2f;

    [Header("Prefab")]
    [SerializeField] private GameObject prefabBullet; // Bullet GameObject
    [SerializeField] private GameObject A3;



    
    public float bulletSpeed = 5.0f;
    private void OnMouseDown()
    {
        isButtonDown = true;        

        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        pos = Input.mousePosition - pos;
        baseAngle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
        baseAngle -= Mathf.Atan2(transform.right.y, transform.right.x) * Mathf.Rad2Deg;
    }

    private void OnMouseDrag()
    {
        mouseDrag = true;

        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        pos = Input.mousePosition - pos;
        float angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg - baseAngle;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void Shoot() // 총알 발사
    {
        //StartCoroutine(CreateBullet());
        //BulletPoolingManager.GetObject();
        //GameObject Bullets = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
        //Bullets.GetComponent<Rigidbody2D>().AddForce(Bullets.transform.forward * bulletSpeed);
        

        Debug.Log("Shoot");
        GameObject Bullet = Instantiate(prefabBullet, this.transform.position, this.transform.rotation); // Bullet Instance 
        // Create position and Rotation is Local 
        Rigidbody2D rigid = Bullet.GetComponent<Rigidbody2D>();
        Vector2 leftup = Vector2.up + Vector2.left;
        
        //rigid.AddForce(new Vector2(-1,1) * bulletSpeed, ForceMode2D.Impulse);
        rigid.AddRelativeForce(new Vector2(-1,1) * bulletSpeed , ForceMode2D.Impulse);
        

        //curShootDelay = 0;
    }
    private void Reload()
    {
            curShootDelay += Time.deltaTime;
    }
    
    public void TestShoot()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //if(curShootDelay >  maxShootDelay)
                Shoot();
        }
        
    }
    void SetRotateZ() // 이런식으로 하면 될듯
    {
        if (isButtonDown && mouseDrag) // if Clicking
        {
           //Debug.Log("돌리는 중 입니다");
        }

        if (!isButtonDown && !mouseDrag) // if not Clicking
        {
            
            if (this.transform.eulerAngles.z < 50f && this.transform.eulerAngles.z < 291f)
                {
                    // left top Angle Setting
                    this.transform.eulerAngles = new Vector3(0,0,0);
                    testImage.SetActive(true);
                    
                }
            else if(this.transform.eulerAngles.z < 159f && this.transform.eulerAngles.z > 51f)
            {
                this.transform.eulerAngles = new Vector3(0,0,120);
            }
        }
    }

    private void Shake()
    {
 if (Input.GetMouseButtonUp(0) && mouseDrag && isButtonDown&& !isShootButtonDown)
        {
            isButtonDown = false;
            mouseDrag = false;
            camAnim.SetTrigger("shake");
        }
    }
    private void Start()
    {
        testImage.SetActive(false);
        isButtonDown = false;
        mouseDrag = false;
        isShootButtonDown = false;
    }
    private void Update()
    {
        //Debug.Log(transform.eulerAngles.z);
        SetRotateZ();
        TestShoot();
        Shake();
    }

    IEnumerator CreateBullet()
    {
        while (true)
        {
            yield return null;
            //Instantiate(Bullet, Vector2.zero, Quaternion.identity);
            //GameObject t_object = BulletPoolingManager.instance.GetQueue();
            //t_object.transform.position = Vector2.zero;
        }
    }
}
