using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCtrl : MonoBehaviour
{
    //우주선 이동 속도
    private float spd = 25f;

    void Start()
    {
        
    }

    void Update()
    {
        Move();
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
}
