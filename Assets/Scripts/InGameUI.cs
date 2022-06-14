using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public Text voidTime = null;
    public Text pathDistance = null;

    private string voidTimeStr = null;
    private string pathDistanceStr = null;

    void Start()
    {
        
    }

    void Update()
    {
        voidTimeStr = GameManager.Instance.voidTime.ToString();
        voidTime.text = "회피 :" + voidTimeStr + "회";
        pathDistanceStr = GameManager.Instance.NowDistance.ToString();
        pathDistance.text = "진행 거리 :" + pathDistanceStr + "km";
    }
}
