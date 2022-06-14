using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Ctrl : MonoBehaviour
{
    private string voidTimes;
    private string distance;
    GUIStyle style = new GUIStyle();


    void Start()
    {
        style.fontSize = 50;
        style.normal.textColor = Color.white;
    }

    void Update()
    {
        voidTimes = GameManager.Instance.voidTime.ToString();
        distance = GameManager.Instance.NowDistance.ToString();
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 250, 250), "총알 피한 횟수 :" + voidTimes + "회",style);
        GUI.Label(new Rect(0, 50, 250, 250), "현재 거리 :" + distance + "km",style);
    }
}
