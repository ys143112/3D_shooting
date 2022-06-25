using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public Text voidTime = null;
    public Text pathDistance = null;
    public Text hp = null;
    public Text money = null;
    public Text barrier = null;


    void Start()
    {
        
    }

    void Update()
    {
        voidTime.text = "ȸ�� " + GameManager.Instance.voidTime.ToString() + "ȸ";
        pathDistance.text = "���� �Ÿ� :" + GameManager.Instance.nowDistance.ToString() + "km";
        hp.text = "��� :" + CharacterCtrl.Instance.hp.ToString();
        money.text = "�� :" + GameManager.Instance.money.ToString();
        barrier.text = "��ȣ�� " + CharacterCtrl.Instance.barrier.ToString()+"��";
    }
}
