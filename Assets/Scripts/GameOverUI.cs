using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : SingleTon<GameOverUI>
{
    public Text rankText = null;
    public Text voidTime = null;
    public Text pathDistance = null;
    public Button closeButton = null;
    public GameObject InGame = null;
    public GameObject GameOverUI_ = null;
    public GameObject Main = null;

    private string voidTimeStr = null;
    private string pathDistanceStr = null;

    void Start()
    {
        voidTimeStr = GameManager.Instance.voidTime.ToString();
        voidTime.text = "회피 :" + voidTimeStr + "회";
        pathDistanceStr = GameManager.Instance.nowDistance.ToString();
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

    public void closeTab()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        Color color = closeButton.image.color;
        for(float i=1f;i>0f;i -= 0.1f)
        {
            color.a = i;
            closeButton.image.color = color;

            yield return new WaitForSeconds(0.01f);
        }
        InGame.SetActive(false);
        Main.SetActive(true);
    }
}
