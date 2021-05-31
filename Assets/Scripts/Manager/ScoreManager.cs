using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text text_Score;
    [SerializeField] Animator anim_Score;
    [SerializeField] private int currentScore = 0;

    
    public void IncreaseScore(int _num)
    {
        currentScore += _num;
    }

    void Update()
    {
        text_Score.text = currentScore.ToString(format:"0##");

        if(Input.GetKeyDown(KeyCode.F))
        IncreaseScore(20);
    }
}
