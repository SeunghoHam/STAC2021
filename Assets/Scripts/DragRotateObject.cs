using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragRotateObject : MonoBehaviour
{
    // https://jaehyuk1209.tistory.com/category/Game%20Engine/Unity

    public Transform Center;

    [SerializeField] private Vector3 FirstTouch;
    [SerializeField] private Vector3 LastTouch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            FirstTouch.x = Input.mousePosition.x;
            FirstTouch.y = Input.mousePosition.y;
        }
        if(Input.GetMouseButton(0))
        {
            LastTouch.x = Input.mousePosition.x;
            LastTouch.y = Input.mousePosition.y;

            float angle = Mathf.Atan2(LastTouch.x - FirstTouch.x, LastTouch.y - FirstTouch.y) * Mathf.Rad2Deg;
            Debug.Log(angle + 180);

            if(angle + 180 == 180)
            {
                angle += 180;
            }

            transform.rotation = Quaternion.Euler(transform.rotation.x, angle + 180, transform.rotation.z);
        }

        Quaternion target = Quaternion.LookRotation(Center.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 3f);
    }
}
