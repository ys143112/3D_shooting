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
    public GameObject ingameCamera = null;
    public GameObject mainCamera = null;
    public GameObject ingameCanvas = null;


    private string voidTimeStr = null;
    private string pathDistanceStr = null;

    void Start()
    {
        voidTimeStr = GameManager.Instance.voidTime.ToString();
        voidTime.text = "ȸ�� :" + voidTimeStr + "ȸ";
        pathDistanceStr = GameManager.Instance.nowDistance.ToString();
        pathDistance.text = "���� �Ÿ� :" + pathDistanceStr + "km";
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
        AddMoney();
    }

    void AddMoney()
    {
        MainUI.Instance.mainMoney+=50;
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
        ingameCamera.SetActive(false);
        mainCamera.SetActive(true);
        ingameCanvas.SetActive(false);
        
        
    }
}
