using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;

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
        CheckBullet();
    }

    /// <summary>
    /// 우주선이 움직이는 함수
    /// </summary>
    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        var position = transform.position;

        position += new Vector3(horizontal, vertical, 0) * spd * Time.deltaTime;
        position.x = Clamp(position.x, -38, 38);
        position.y = Clamp(position.y, 0, 80);

        transform.position=position;

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

    
    void CheckBullet()
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = new Ray(transform.position, Vector3.forward);

        if(Physics.Raycast(ray,out hit,Mathf.Infinity))
        {
            float distance = (hit.transform.position-transform.position ).magnitude;
            if(distance<=10)
            {
                hp -= 1;
                Destroy(hit.transform.gameObject);
            }
        }

    }
}
