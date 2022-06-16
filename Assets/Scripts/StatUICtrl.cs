using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatUICtrl : MonoBehaviour
{
    private float MoveSpdVal = 0.5f;
    private float CtrlSpdVal = 2f;
    private float barrierCnt = 0f;

    
    private void Start()
    {
    }

    public void PlusStat(int typeFlag)
    {
        switch(typeFlag)
        {
            case 0:
                
                GameManager.Instance.ctrlDistance += MoveSpdVal;
                break;
            case 1:

                CharacterCtrl.Instance.spd += CtrlSpdVal;
                break;

        }

    }

}
