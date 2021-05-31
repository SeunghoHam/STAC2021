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
    [SerializeField] private bool AutoShoot; // 자동 쏘기 버튼
    [SerializeField] private bool ShootCharge; // 이게 참이어야 슛 게이지가 오름
    [SerializeField] private GameObject testImage;

    [Header("Reference")]
    [SerializeField] private Transform angle3; // Triangle Object position

    [SerializeField] private Transform ShootPoint; // ShootPoint = RotatingObject
    [SerializeField] Animator camAnim; // CameraAnimator

    [SerializeField] private float maxShootDelay = 1f;
    [SerializeField] private float curShootDelay = 0.5f;

    [Header("Shoot Bullet Rotation")]
    [SerializeField] private float AnlgeX;
    [SerializeField] private float AngleY;

    [Header("Prefab")]
    [SerializeField] private GameObject prefabBullet; // Bullet GameObject
    [SerializeField] private GameObject A3;
    [SerializeField] private GameObject A4;

      private void Start()
    {
        testImage.SetActive(false);
        isButtonDown = false;
        mouseDrag = false;
        isShootButtonDown = false;
        AutoShoot = true;
        ShootCharge = true;

    }
    private void Update()
    {
        SetRotateZ();
        Shake();
        Shoot();
        Reload();
        AttackTimer();
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
        if(ShootCharge)
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

            }
            else if (this.transform.eulerAngles.z < 159f && this.transform.eulerAngles.z > 51f)
            {
                this.transform.eulerAngles = new Vector3(0, 0, 120);
            }
        }
    }

    private void AttackTimer()
    {
        if(isButtonDown && mouseDrag)
        {
            testImage.SetActive(true);
            ShootCharge = false;

        }
        if(!isButtonDown && !mouseDrag) // if not Clicking 이 불타입을 함수로 만드는 방버 생각해봐야 될듯 
        {
            testImage.SetActive(false);
            ShootCharge = true;
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

        }
    }
}
