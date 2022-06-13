using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Rank : MonoBehaviour
{
    public Text rankText = null;
    
    

    void Start()
    {
    }

    void Update()
    {
        SetRank();
    }

    void SetRank()
    {
        float voidTime = GameManager.Instance.voidTime;
        if ( voidTime>=0 && voidTime <100)
        {
            rankText.text = "Un Rank";
        }
        if (voidTime >= 100 && voidTime < 300)
        {
            rankText.text = "C Rank";
        }
        if (voidTime >= 300 && voidTime < 700)
        {
            rankText.text = "B Rank";
        }
        if (voidTime >= 700 && voidTime < 1500)
        {
            rankText.text = "A Rank";
        }
        if (voidTime >= 1500 && voidTime < 3000)
        {
            rankText.text = "S Rank";
        }
        if (voidTime >= 3000)
        {
            rankText.text = " Rank";
        }

    }
}
