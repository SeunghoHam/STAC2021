using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Roller : MonoBehaviour
{
    [SerializeField] GameObject Roller_T;
    [SerializeField] GameObject Roller_L;
    [SerializeField] GameObject Roller_B;

    private float rollingSpeed1 = .06f;
    private float rollingSpeed2 = .08f;
    private float rollingSpeed3 = .05f;

    // Update is called once per frame
    void Update()
    {
        Roller_T.transform.Rotate(0,0,rollingSpeed1);
        Roller_L.transform.Rotate(0,0,-rollingSpeed2);
        Roller_B.transform.Rotate(0,0,-rollingSpeed3);
    }
}
