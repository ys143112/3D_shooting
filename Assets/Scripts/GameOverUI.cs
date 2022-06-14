using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public Text rankText = null;
    public Text voidTime = null;
    public Text pathDistance = null;
    public Button closeButton = null;

    private string voidTimeStr = null;
    private string pathDistanceStr = null;

    void Start()
    {
        voidTimeStr = GameManager.Instance.voidTime.ToString();
        voidTime.text = "회피 :" + voidTimeStr + "회";
        pathDistanceStr = GameManager.Instance.NowDistance.ToString();
        pathDistance.text = "진행 거리 :" + pathDistanceStr + "km";
        SetRank();
    }

    void Update()
    {

    }

    void SetRank()
    {
        float voidTime = GameManager.Instance.voidTime;
        if (voidTime > 1000)
        {
            rankText.text = "X Rank";
        }
        else if (voidTime > 800)
        {
            rankText.text = "S Rank";
        }
        else if (voidTime > 500)
        {
            rankText.text = "A Rank";
        }
        else if (voidTime > 300)
        {
            rankText.text = "B Rank";
        }
        else if (voidTime > 100)
        {
            rankText.text = "C Rank";
        }
        else
        {
            rankText.text = "Un Rank";
        }
    }

    void closeTab()
    {

    }
}
