using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float baseAngle = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //OnMouseDown();
        //OnMouseDrag();
        if(Input.GetMouseButtonDown(0))
        {
            OnMouseDown();
        }
        if(Input.GetMouseButton(0))
        {
            OnMouseDrag();
        }
    }
    void OnMouseDown()
    {
        Vector3 Position = Camera.main.WorldToScreenPoint(transform.position);
        Position = Input.mousePosition - Position;
        baseAngle = Mathf.Atan2(Position.y, Position.x) * Mathf.Rad2Deg;
        baseAngle = Mathf.Atan2(transform.right.y, transform.right.x) * Mathf.Rad2Deg;
    }
    void OnMouseDrag()
    {
        Vector3 Position = Camera.main.WorldToScreenPoint(transform.position);
        Position = Input.mousePosition - Position;

        float angle = Mathf.Atan2(Position.y, Position.x) * Mathf.Rad2Deg - baseAngle;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
