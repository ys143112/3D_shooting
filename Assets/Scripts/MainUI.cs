using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainUI : MonoBehaviour
{
    public Text rank = null;
    public GameObject tipTab = null;
    public GameObject shopPanel = null;
    void Start()
    {
        
    }

    void Update()
    {
        SetRank_();
    }

    void SetRank_()
    {
        float voidTime = GameManager.Instance.voidTime;
        if (voidTime > 1000)
        {
            rank.text = "X Rank";
        }
        else if (voidTime > 800)
        {
            rank.text = "S Rank";
        }
        else if (voidTime > 500)
        {
            rank.text = "A Rank";
        }
        else if (voidTime > 300)
        {
            rank.text = "B Rank";
        }
        else if (voidTime > 100)
        {
            rank.text = "C Rank";
        }
        else
        {
            rank.text = "Un Rank";
        }
    }

    public void TipTab(int typeFlag)
    {
        switch(typeFlag)
        {
            case 0:
                tipTab.SetActive(true);
                break;
            case 1:
                tipTab.SetActive(false);
                break;
        }
    }

    public void Open()
    {
        shopPanel.SetActive(true);
    }

    

}
