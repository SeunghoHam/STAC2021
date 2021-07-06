using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Scroll : MonoBehaviour
{
    [Header("ContentObject")]
    public GameObject g_contentObject;

    [SerializeField] private bool isButtonDown = false;

    private float normal = 0.08f;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SetPosition();
    }


    void SetPosition()
    {
        if(!isButtonDown)
        {
            if(g_contentObject.transform.position.x >= -150)
            {
                //g_contentObject.transform.position = new Vector3(0,0,0);
                //Debug.Log("1스테이지로 위치 고정");
            }
        }
        
    }

    private void OnMouseDown()
    {
        isButtonDown = true;
    }

    private void OnMouseUp()
    {
        isButtonDown = false;
    }

    public void button_stage1()
    {
        SceneManager.LoadScene("Game");
    }
    public void button_stage2()
    {

    }
}
