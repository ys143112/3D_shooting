using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public GameObject InGameCamera = null;
    public GameObject MainCamera = null;
    public GameObject gameoverPanel =null;
    public GameObject ingameCanvas = null;

    private void Start()
    {
        
    }
    public void StartBtn()
    {
        MainCamera.SetActive(false);
        InGameCamera.SetActive(true);
        gameoverPanel.SetActive(false);
        CharacterCtrl.Instance.CharacterState = CharacterCtrl.CharacterStateType.Idle;
        CharacterCtrl.Instance.hp = 3;
        GameManager.Instance.nowDistance = 0f;
        GameManager.Instance.ctrlDistance = 10f;
        CharacterCtrl.Instance.spd = 25f;
        GameManager.Instance.voidTime = 0f;
        ingameCanvas.SetActive(true);
    }
}
