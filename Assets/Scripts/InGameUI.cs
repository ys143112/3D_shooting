using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public Text voidTime = null;
    public Text pathDistance = null;
    public Text hp = null;


    void Start()
    {
        
    }

    void Update()
    {
        voidTime.text = "회피 " + GameManager.Instance.voidTime.ToString() + "회";
        pathDistance.text = "진행 거리 :" + GameManager.Instance.nowDistance.ToString() + "km";
        hp.text = "목숨 :" + CharacterCtrl.Instance.hp.ToString();

    }
}
