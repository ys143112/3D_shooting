using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatUICtrl : MonoBehaviour
{
    private float MoveSpdVal = 0.5f;
    private float CtrlSpdVal = 2f;
    private float money = 0f;
    private float BarrierVal = 1f;
    private void Start()
    {
        
    }

    void Update()
    {
        money = GameManager.Instance.money;
    }

    public void PlusStat(int typeFlag)
    {
        switch(typeFlag)
        {
            case 0:
                if(money>=10)
                {
                    GameManager.Instance.ctrlDistance += MoveSpdVal;
                    GameManager.Instance.money -= 10f;
                }
                break;
            case 1:
                if(money>=10)
                {
                    CharacterCtrl.Instance.spd += CtrlSpdVal;
                    GameManager.Instance.money -= 10f;
                }
                break;
            case 2:
                if(money>=50)
                {
                    CharacterCtrl.Instance.barrier +=BarrierVal;
                    GameManager.Instance.money -= 50;
                }
                break;

        }

    }

}
