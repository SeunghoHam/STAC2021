using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public bool isPause;
    [SerializeField] private GameObject g_Pause;
    [SerializeField] private GameObject g_Continue;
    [SerializeField] private GameObject g_Exit;
    void Awake()
    {   
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
        if(!isPause)
        {
            g_Pause.SetActive(false);
        }
    }
    public void PauseButton()
    {
        Time.timeScale =0;
        isPause = true;
    }
    public void Button_Continue()
    {
        Time.timeScale = 1;
        isPause = false;
    }

    public void Button_Back()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
    }
}
