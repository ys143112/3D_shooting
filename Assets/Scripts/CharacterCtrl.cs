using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCtrl : MonoBehaviour
{
    //���ּ� �̵� �ӵ�
    public float spd = 25f;

    //���ּ��� źȯ�� �¾Ƶ� ��� Ƚ��(=���)
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
    /// ���ּ��� �����̴� �Լ�
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
