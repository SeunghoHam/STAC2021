using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class StatusManager : MonoBehaviour
{
    [SerializeField] private GameObject[] go_hpArray;
    [SerializeField] private int maxHP;
    [SerializeField] private int currentHP;
    

    void UpdateHpStatus()
    {
        for(int i=0; i < go_hpArray.Length; i++)
        {
            if(i < currentHP)
                go_hpArray[i].SetActive(true);
            else
            go_hpArray[i].SetActive(false);
        }
    }
    public void DecreaseHP(int _num)
    {
        currentHP -=_num;
        UpdateHpStatus();
        if(currentHP <= 0)
            PlayerDead();

    }
    public void IncreaseHP(int _num)
    {
        currentHP += _num;
        if(currentHP == maxHP)
            return;

        if(currentHP > maxHP)
        {
            currentHP = maxHP;
            Debug.Log("Get Bonus Score");
        }
     
        UpdateHpStatus();
    }
    private void PlayerDead()
    {
        //Debug.Log("player is dead");
    }
    void Start()
    {
        currentHP = maxHP;
        UpdateHpStatus();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            IncreaseHP(1);
        }   
        if(Input.GetKeyDown(KeyCode.D))
        {
            DecreaseHP(1);
        }
    }
}
