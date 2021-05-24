using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text text_Score;
    
    [SerializeField] private int currentScore;
    public void IncreaseScore(int _num)
    {
        currentScore += _num;
    }
    void Start()
    {
         
    }

    
    void Update()
    {
        
    }
}
