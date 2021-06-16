using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hit_Image : MonoBehaviour
{
    [SerializeField] GameObject hitImage1;
    [SerializeField] GameObject hitImage2;
    void Start()
    {
        hitImage1.SetActive(false);
        hitImage2.SetActive(false);
    }
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            hitImage1.SetActive(true);
        }

    }


    public void Hit1()
    {
        hitImage1.SetActive(true);
        hitImage2.SetActive(false);
    }
    public void Hit2()
    {
        hitImage2.SetActive(false);
        hitImage2.SetActive(true);
    }
}
