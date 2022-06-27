using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainUI : SingleTon<MainUI>
{
    public Text rank = null;
    public Text money = null;
    public GameObject tipTab = null;
    public GameObject shopPanel = null;
    public GameObject setPanel = null;
    public GameObject spaceShip = null;
    public GameObject ingameSpaceShip = null;

    public float mainMoney = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        SetMoney();
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

    void SetMoney()
    {
        money.text = "µ· "+mainMoney.ToString();
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

    public void Open(int typeFlag)
    {
        switch(typeFlag)
        {
            case 0:
                shopPanel.SetActive(true);
                spaceShip.SetActive(false);
                break;
            case 1:
                setPanel.SetActive(true);
                break;
            case 2:
                setPanel.SetActive(false);
                break;
            case 3:
                shopPanel.SetActive(false);
                spaceShip.SetActive(true);
                break;
            case 4:
                if(mainMoney>=20f)
                {
                    ingameSpaceShip.GetComponent<Material>().color = Color.yellow;
                    spaceShip.GetComponent<Material>().color = Color.yellow;
                }
                break;
            case 5:
                if (mainMoney >= 20f)
                {
                    ingameSpaceShip.GetComponent<Material>().color = Color.red;
                    spaceShip.GetComponent<Material>().color = Color.red;
                }
                break;
            case 6:
                if (mainMoney >= 20f)
                {
                    ingameSpaceShip.GetComponent<Material>().color = Color.green;
                    spaceShip.GetComponent<Material>().color = Color.green;
                }
                break;
            case 7:
                if (mainMoney >= 20f)
                {
                    ingameSpaceShip.GetComponent<Material>().color = Color.gray;
                    spaceShip.GetComponent<Material>().color = Color.gray;
                }
                break;
            case 8:
                if (mainMoney >= 20f)
                {
                    ingameSpaceShip.GetComponent<Material>().color = Color.blue;
                    spaceShip.GetComponent<Material>().color = Color.blue;
                }
                break;
                
        }
    }

    

}
