using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCtrl : MonoBehaviour
{
    //우주선 이동 속도
    public float spd = 25f;

    //우주선이 탄환을 맞아도 사는 횟수(=목숨)
    public float hp = 3f;

    public enum CharacterStateType { Idle, Die }

    private CharacterStateType CharacterState = CharacterStateType.Idle;

    void Start()
    {
        
    }

    void Update()
    {
        Move();
        StateCheck();
    }

    /// <summary>
    /// 우주선이 움직이는 함수
    /// </summary>
    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 pos = new Vector3(horizontal, vertical, 0);
        transform.Translate(pos * spd * Time.deltaTime, Space.World);
    }

    void StateCheck()
    {
        if (hp <= 0)
        {
            CharacterState = CharacterStateType.Die;
        }

        switch (CharacterState)
        {
            case CharacterStateType.Idle:
                break;
            case CharacterStateType.Die:
                
                break;
            default:
                break;
        }
    }
}
