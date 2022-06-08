using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Ctrl : MonoBehaviour
{
    string voidTimes;
    string distance;

    void Start()
    {
        
    }

    void Update()
    {
        voidTimes = GameManager.Instance.voidTime.ToString();
        distance = GameManager.Instance.NowDistance.ToString();
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(0,0,100,100), voidTimes))
        {
            Debug.Log("bbuk U");
        }
        if (GUI.Button(new Rect(0, 100, 100, 100), distance+"km"))
        {
            Debug.Log("bbuk U");
        }
    }
}
