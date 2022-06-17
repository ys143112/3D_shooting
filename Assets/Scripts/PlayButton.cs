using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public GameObject InGame = null;
    public GameObject Main = null;
    public void StartBtn()
    {
        Main.SetActive(false);
        InGame.SetActive(true);
    }
}
