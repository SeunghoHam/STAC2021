using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public bool isPause = false;
    
    [Header("Buttons")]
    [SerializeField] GameObject pause;
    private void Start() 
    {
        pause.SetActive(false);
    }
    public void pauseButton()
    {
        // 게임 정지시키고 일시정지 이미지
        pause.SetActive(true);
    }
    public void continueButton()
    {
        // 화면 전체가 크게 버튼. 진행 중인 게임 이어서
    }
    public void _startButton()
    {
        // 타이틀 - > 메인. 씬 전환
    }
    public void mainButton()
    {
        // 메인씬으로 전환
    }
    public void shopButton()
    {
        // 상점으로 이동
    }
    public void settingButton()
    {
        // 설정으로 이동
    }
    
}
