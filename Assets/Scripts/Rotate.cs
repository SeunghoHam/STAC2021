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
    [SerializeField] private float baseAngle;
    [SerializeField] private bool AutoShoot;


    [Header("Reference")]
    [SerializeField] private Transform angle3; // Triangle Object position

    [SerializeField] private Transform ShootPoint; // ShootPoint = RotatingObject
    [SerializeField] Animator camAnim; // CameraAnimator
    [SerializeField] GameObject testImage;

    [SerializeField] private float maxShootDelay = 0.4f;
    [SerializeField] private float curShootDelay = 0.5f;

    [Header("Shoot Bullet Rotation")]
    [SerializeField] private float AnlgeX;
    [SerializeField] private float AngleY;

    [Header("Prefab")]
    [SerializeField] private GameObject prefabBullet; // Bullet GameObject
    [SerializeField] private GameObject A3;
    [SerializeField] private GameObject A4;




    public float bulletSpeed = 5.0f;

      private void Start()
    {
        //testImage.SetActive(false);
        isButtonDown = false;
        mouseDrag = false;
        isShootButtonDown = false;
        AutoShoot = true;

        kdCreateBullet kdPooling = FindObjectOfType<kdCreateBullet>();
    }
    private void Update()
    {
        //Debug.Log(transform.eulerAngles.z);
        SetRotateZ();
        Shake();
        Shoot();
        Reload();
    }

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

    public void AutoShootButton()
    {
        AutoShoot = !AutoShoot;
        Debug.Log(AutoShoot);
    }
    public void Shoot() // 총알 발사
    {

        if (AutoShoot)
        {
            if (curShootDelay < maxShootDelay)
                return;
            if (curShootDelay > maxShootDelay)
            {
               
                GameObject Bullet = Instantiate(prefabBullet, this.transform.position, this.transform.rotation); // Bullet Instance.
                //Rigidbody2D rigid = Bullet.GetComponent<Rigidbody2D>();
                //rigid.AddRelativeForce(new Vector2(-1, 0.8f) * bulletSpeed, ForceMode2D.Impulse);


                //var bullet = ObjectPool.GetObject();
                //bullet.transform.position = this.transform.position;
                //bullet.transform.rotation  = this.transform.rotation;


                //bullet.transform.position = transform.position.normalized; // 이거는 3d에서 사용될거 같은데
            }
            curShootDelay = 0;
        }

    }
    private void Reload()
    {
        curShootDelay += Time.deltaTime;
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
                this.transform.eulerAngles = new Vector3(0, 0, 0);
                //testImage.SetActive(true);

            }
            else if (this.transform.eulerAngles.z < 159f && this.transform.eulerAngles.z > 51f)
            {
                this.transform.eulerAngles = new Vector3(0, 0, 120);
            }
        }
    }

    private void Shake()
    {
        if (Input.GetMouseButtonUp(0) && mouseDrag && isButtonDown && !isShootButtonDown)
        {
            isButtonDown = false;
            mouseDrag = false;
            camAnim.SetTrigger("shake");
        }
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
