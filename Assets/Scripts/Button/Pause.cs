using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static Pause Instance;
    [SerializeField] private bool isPause;
    [SerializeField] private GameObject g_Pause;
    void Awake()
    {
        Instance = this;    
    }
    void Start()
    {
        isPause = false;
        g_Pause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isPause)
        {
            g_Pause.SetActive(true);
        }
    }
    public void PauseButton()
    {
        isPause = !isPause;
    }
}
