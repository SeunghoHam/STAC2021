using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kdCreateBullet : MonoBehaviour
{

    IEnumerator CreateCoroutine()
    {
        while(true)
        {
                yield return null;
                GameObject t_object = kdObjectPoolingManager.instance.GetQueue();
                t_object.transform.position=  Vector2.zero;
        }
    }
    // Start is called before the first frame update    
    void Start()
    {
        StartCoroutine(CreateCoroutine());
    }
}
